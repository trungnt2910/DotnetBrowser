using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Trungnt2910.Browser.Generators.TypeScript.Factories;
using Trungnt2910.Browser.Generators.TypeScript.Models;

namespace Trungnt2910.Browser.Generators.TypeScript;

[Generator]
public class TypeScriptSourceGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {

    }

    public void Execute(GeneratorExecutionContext context)
    {
        context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("build_property.rootnamespace", out var globalNamespaceName);

        var files = context.AdditionalFiles.Where(at => at.Path.EndsWith(".d.ts", StringComparison.InvariantCultureIgnoreCase));

        foreach (var file in files)
        {
            // Remove the .ts and then the .d
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(file.Path)).Trim();
            var namespaceName = globalNamespaceName;

            if (context.AnalyzerConfigOptions.GetOptions(file).TryGetValue("build_metadata.AdditionalFiles.NamespaceName", out var perFilenamespaceName))
            {
                if (!string.IsNullOrWhiteSpace(perFilenamespaceName))
                {
                    namespaceName = perFilenamespaceName;
                }
            }

            if (string.IsNullOrWhiteSpace(namespaceName))
            {
                namespaceName = fileNameWithoutExtension.Trim();
            }

            if (string.IsNullOrWhiteSpace(namespaceName))
            {
                context.ReportDiagnostic(Diagnostic.Create(Descriptors.BadNamespaceDescriptor, Location.None, file.Path));
                continue;
            }

            context.AnalyzerConfigOptions.GetOptions(file).TryGetValue("build_metadata.AdditionalFiles.GlobalInterfaceName", out var globalInterfaceName);

            var source = file.GetText()?.ToString() ?? string.Empty;

            var generated = ProcessFile(context, namespaceName!, globalInterfaceName, file.Path, source);

            if (generated != null)
            {
                var sourceText = SourceText.From(generated, System.Text.Encoding.UTF8);
                context.AddSource($"{fileNameWithoutExtension}.g.cs", sourceText);
            }
        }
    }

    private string? ProcessFile(GeneratorExecutionContext context, string namespaceName, string? globalInterfaceName, string filePath, string fileText)
    {
        var generatorContext = new Context()
        {
            GeneratorExecutionContext = context
        };

        if (!TypeScriptAstFactory.GenerateContext(generatorContext, globalInterfaceName, filePath, fileText))
        {
            return null;
        }

        var mustBeInterfaceSet = new HashSet<Interface>(generatorContext.Interfaces
                .Where(i => i.BaseTypes.Count >= 2)
                .SelectMany(i =>
                    i.BaseTypes
                        .Select(t => generatorContext.Interfaces.FirstOrDefault(i => i.Name == t.Name && i.TypeParameters.Count == t.TypeParameters.Count))
                        .Where(i => i != null)
                        .Cast<Interface>()
                    ));

        var mustBeInterfaceQueue = new Queue<Interface>(mustBeInterfaceSet);

        while (mustBeInterfaceQueue.Count > 0)
        {
            var currentInterface = mustBeInterfaceQueue.Dequeue();
            foreach (var baseInterface in currentInterface.BaseTypes
                        .Select(t => generatorContext.Interfaces.FirstOrDefault(i => (i.Name == t.Name || i.Name == "Has" + t.Name) && i.TypeParameters.Count == t.TypeParameters.Count))
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

        using var sw = new StringWriter();

        sw.WriteLine("#nullable enable");
        sw.WriteLine("using System;");
        sw.WriteLine("using System.Diagnostics.CodeAnalysis;");
        sw.WriteLine("using Trungnt2910.Browser;");
        sw.WriteLine();
        sw.WriteLine($"namespace {namespaceName};");

        foreach (var i in mustBeInterfaceSet)
        {
            sw.WriteLine(i.ToString(generatorContext));
        }

        foreach (var i in generatorContext.Interfaces)
        {
            sw.WriteLine(i.ToString(generatorContext, generateAsClass: true));
        }

        foreach (var kvp in generatorContext.InlineInterfaces)
        {
            sw.WriteLine(kvp.Value.ToString(generatorContext, generateAsClass: true));
        }

        return sw.ToString();
    }
}
