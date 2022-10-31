using LibDomTypeScriptParser;
using LibDomTypeScriptParser.Models;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using Zu.TypeScript;
using Zu.TypeScript.TsTypes;

var fileText = File.ReadAllText(Settings.InputFile);

var licenseHeaderBegin = fileText.IndexOf("/*");
var licenseHeaderEnd = fileText.IndexOf("*/");

var licenseText = fileText[licenseHeaderBegin..(licenseHeaderEnd + 2)].ReplaceLineEndings();

Console.Error.WriteLine("Get/Set accessors are stripped from the source code as they are not supported by the parser.");

var getSetAccessorRegex = new Regex(@"^\s*[gs]et .*\n", RegexOptions.Multiline);
fileText = getSetAccessorRegex.Replace(fileText, m =>
{
    Console.Error.WriteLine($"[{m.Index}-{m.Index + m.Length}] get/set accessor stripped from source: " + m.Value.Trim());
    // Do this to preserve source positions.
    return new string(' ', m.Value.Length - Environment.NewLine.Length) + Environment.NewLine;
});

var ast = new TypeScriptAST(fileText, Settings.InputFile);

Console.Error.WriteLine("Types ending with EventMap are skipped due to C# compatibility reasons.");
Console.Error.WriteLine("Generic constraints with \"extends keyof\" are skipped due to C# compatibility reasons.");
Console.Error.WriteLine("Functions addEventListener and removeEventListener are skipped due to C# compatibility reasons.");

var generatorContext = new Context();

var typeAliases = ast.OfKind(SyntaxKind.TypeAliasDeclaration)
    .Cast<TypeAliasDeclaration>()
    .ToList();

foreach (var t in typeAliases)
{
    if (!generatorContext.TypeAliases.TryGetValue(t.IdentifierStr, out var dict))
    {
        dict = new();
        generatorContext.TypeAliases.Add(t.IdentifierStr, dict);
    }

    dict.Add(t.TypeParameters?.Count ?? 0, new Tuple<List<string>, TsType> (t.TypeParameters?.Select(p => p.IdentifierStr).ToList() ?? new List<string>(), new TsType(t.Type)));
}

var interfaces = ast.OfKind(SyntaxKind.InterfaceDeclaration)
    .Where(i => !i.IdentifierStr.EndsWith("EventMap"))
    .Where(i => !i.IdentifierStr.EndsWith("NameMap"))
    .Select(decl => new Interface((InterfaceDeclaration)decl))
    .ToList();

var mustBeInterfaceSet = new HashSet<Interface>(interfaces
        .Where(i => i.BaseTypes.Count >= 2)
        .SelectMany(i =>
            i.BaseTypes
                .Select(t => interfaces.FirstOrDefault(i => i.Name == t.Name && i.TypeParameters.Count == t.TypeParameters.Count))
                .Where(i => i != null)
                .Cast<Interface>()
            ));

var mustBeInterfaceQueue = new Queue<Interface>(mustBeInterfaceSet);

while (mustBeInterfaceQueue.Count > 0)
{
    var currentInterface = mustBeInterfaceQueue.Dequeue();
    foreach (var baseInterface in currentInterface.BaseTypes
                .Select(t => interfaces.FirstOrDefault(i => (i.Name == t.Name || i.Name == "Has" + t.Name) && i.TypeParameters.Count == t.TypeParameters.Count))
                .Where(i => i != null)
                .Cast<Interface>())
    {
        if (!mustBeInterfaceSet.Contains(baseInterface))
        {
            mustBeInterfaceSet.Add(baseInterface);
            mustBeInterfaceQueue.Enqueue(baseInterface);
        }
    }
}

foreach (var n in mustBeInterfaceSet)
{
    generatorContext.MustBeInterface.Add(n.Name);
}

generatorContext.InlineInterfaces = ast.OfKind(SyntaxKind.TypeLiteral)
    .Where(lit => lit.Parent?.Kind != SyntaxKind.VariableDeclaration)
    .ToDictionary(lit => lit.GetText(), lit => new Interface((TypeLiteralNode)lit));

generatorContext.Interfaces = interfaces;

generatorContext.EventMaps = ast.OfKind(SyntaxKind.InterfaceDeclaration)
    .Where(i => i.IdentifierStr.EndsWith("EventMap"))
    .Select(decl => new EventMap((InterfaceDeclaration)decl))
    .ToList();

var globalInterface = interfaces.SingleOrDefault(i => i.Name == Settings.GlobalInterfaceName);

if (globalInterface != null)
{
    globalInterface.Properties.AddRange(
        ast.RootNode.Children.OfType<VariableStatement>()
            .SelectMany(statement => statement.DeclarationList.Declarations)
            .Where(statement => !statement.GetDescendants().OfType<TypeLiteralNode>().Any())
            .Where(statement => !statement.GetDescendants().OfType<TypeQueryNode>().Any())
            .Select(statement => new Property(statement))
            .Where(property => !globalInterface.Properties.Where(existingProperty => existingProperty.Name == property.Name).Any())
    );

    globalInterface.Methods.AddRange(
        ast.RootNode.Children.OfType<FunctionDeclaration>()
            .Where(method => !method.GetText().Contains("extends keyof"))
            .Select(statement => new Method(statement))
            .Where(method => !globalInterface.Methods.Where(existingMethod => existingMethod.Name == method.Name).Any())
    );
}

generatorContext.LoadExistingTypesLibrary(Settings.ExistingLibrary);

if (Directory.Exists(Settings.OutputFolder))
{
    Directory.Delete(Settings.OutputFolder, true);
}

Directory.CreateDirectory(Settings.OutputFolder);

foreach (var i in mustBeInterfaceSet)
{
    using var outputFile = File.CreateText(Path.Combine(Settings.OutputFolder, $"I{i.Name}.g.cs"));
    WriteHeader(outputFile);
    outputFile.WriteLine(i.ToString(generatorContext));
}

foreach (var i in interfaces)
{
    using var outputFile = File.CreateText(Path.Combine(Settings.OutputFolder, $"{i.Name}.g.cs"));
    WriteHeader(outputFile);
    outputFile.WriteLine(i.ToString(generatorContext, generateAsClass: true));
}

foreach (var kvp in generatorContext.InlineInterfaces)
{
    using var outputFile = File.CreateText(Path.Combine(Settings.OutputFolder, $"{kvp.Value.Name}.g.cs"));
    WriteHeader(outputFile);
    outputFile.WriteLine(kvp.Value.ToString(generatorContext, generateAsClass: true));
}

void WriteHeader(TextWriter outputFile)
{
    outputFile.WriteLine($"// This file was generated by \"{Assembly.GetExecutingAssembly().FullName}\", from \"{Settings.InputFile}\".");
    outputFile.WriteLine($"// Do not edit directly. If you encounter any bugs, please fix the generator's code.");
    outputFile.WriteLine($"//");
    outputFile.WriteLine($"// Copyright (C) {DateTime.Now.Year} Trung Nguyen. All rights reserved.");
    outputFile.WriteLine($"// Licensed under the MIT License.");
    outputFile.WriteLine();
    outputFile.WriteLine(licenseText);
    outputFile.WriteLine();
    outputFile.WriteLine("#nullable enable");
    outputFile.WriteLine("using System;");
    outputFile.WriteLine("using System.Diagnostics.CodeAnalysis;");
    outputFile.WriteLine("using Trungnt2910.Browser.Generators;");
    outputFile.WriteLine();
    outputFile.WriteLine($"namespace {Settings.DestinationNamespace};");
    outputFile.WriteLine();
}