using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace Trungnt2910.Browser.Generators;

internal class MethodGeneratorGeneratorHandler : IHandler
{
    public IEnumerable<ClassDeclarationSyntax> Handle(AttributeSyntax attribute)
    {
        var maxParamsArg = attribute.ArgumentList?.Arguments
            .Single(a => a.NameEquals?.Name.ToString() == nameof(MethodGeneratorGeneratorAttribute.MaxParams))
            ?.Expression;

        if (!int.TryParse(maxParamsArg?.ToString(), out var maxParams))
        {
            maxParams = MethodGeneratorGeneratorAttribute.DefaultMaxParams;
        }

        var baseNameArg = attribute.ArgumentList?.Arguments
            .Single(a => a.NameEquals?.Name.ToString() == nameof(MethodGeneratorGeneratorAttribute.BaseName))
            ?.Expression;

        var baseName = baseNameArg?.ToString().Trim('\"') ?? MethodGeneratorGeneratorAttribute.DefaultBaseName;

        var templateArg = attribute.ArgumentList?.Arguments
            .Single(a => a.NameEquals?.Name.ToString() == nameof(MethodGeneratorGeneratorAttribute.Template))
            ?.Expression;

        var template = templateArg?.ToString() ?? string.Empty;

        var sb = new StringBuilder();

        for (int i = 0; i < maxParams; ++i)
        {
            sb.AppendLine(Build(baseName, template, i));
        }

        var content = sb.ToString();

        return CSharpSyntaxTree.ParseText(content).GetRoot().ChildNodes()
            .Where(n => n is ClassDeclarationSyntax)
            .Cast<ClassDeclarationSyntax>();
    }

    private string Build(string baseName, string template, int paramCount)
    {
        var sb = new StringBuilder();
        var typeArguments = string.Join(",", (new[] { "TReturn" }).Concat(Enumerable.Range(1, paramCount).Select(i => $"T{i}")));

        var processedTemplate = template
            .Replace("@@RETURNTYPE@@", "TReturn")
            .Replace("@@PARAMETERS_WITH_TYPE@@", string.Join(",", Enumerable.Range(1, paramCount).Select(i => $"{{{{T{i}}}}} {{{{Param{i}}}}}")))
            .Replace("@@PARAMETERS_TO_JS_OBJECT_STRING@@", string.Join(", ", Enumerable.Range(1, paramCount).Select(i => $"{{(global::Trungnt2910.Browser.JsObject.ToJsObjectString({{{{Param{i}}}}}))}}")));

        sb.AppendLine($"[global::Gobie.GobieGeneratorName($\"{baseName}Attribute<{typeArguments}>\", Namespace = \"Trungnt2910.Browser.Generators\", AllowMultiple = true)]");
        sb.AppendLine($"internal sealed class {baseName}Generator<{typeArguments}> : global::Gobie.GobieClassGenerator");
        sb.Append($@"{{
    [global::Gobie.Required]
    public string JsName {{ get; set; }} = string.Empty;

    [global::Gobie.Required]
    public string Name {{ get; set; }} = string.Empty;

{string.Join("\n", Enumerable.Range(1, paramCount).Select(i => $"    public string Param{i} {{ get; set; }} = \"param{i}\";\n"))}

    public string Comments {{ get; set; }} = ""To be added"";

    [global::Gobie.GobieTemplate]
    const string Template = {processedTemplate};
}}");

        return sb.ToString();
    }
}
