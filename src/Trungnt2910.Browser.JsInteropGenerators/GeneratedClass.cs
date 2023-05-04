using Microsoft.CodeAnalysis;

namespace Trungnt2910.Browser.JsInteropGenerators;

internal class GeneratedClass : GeneratedMember
{
    public override void Generate(SourceProductionContext context)
    {
        var namespaceName = ClassType?.NamespaceName;

        var classNameWithoutGenericParams = ClassType?.Name;
        var className = ClassType?.GetFullName(withNamespace: false);

        var jsName = JsImportAttribute.Name;
        if (string.IsNullOrEmpty(jsName))
        {
            jsName = ClassType?.Name;
        }

        var baseClassList = "";
        if (ClassType?.BaseType?.SpecialType == SpecialType.System_Object)
        {
            baseClassList = $" : global::Trungnt2910.Browser.JsObject";
        }

        var constraintsList = "";
        if (TypeParameters?.Any() ?? false)
        {
            constraintsList = $" where {string.Join(" where ", TypeParameters.Select(tp => 
                (TypeConstraints?.ContainsKey(tp) ?? false) ? 
                    $"{tp}: {string.Join(", ", TypeConstraints[tp].Select(t 
                        => $"{t?.GetFullName()}"))}"
                    : $"{tp}: global::Trungnt2910.Browser.JsObject"))}";
        }

        foreach (var diagnostic in Diagnostics)
        {
            context.ReportDiagnostic(diagnostic);
        }

        context.AddSource($"[class]{(string.IsNullOrEmpty(namespaceName) ? "" : namespaceName + ".")}{className?
            .Replace('<', '[').Replace(' ', '_').Replace(',', '_').Replace('>', ']')}.g.cs",
            CodeSnippets.JsObjectBoilerplate(namespaceName, JsImportAttribute.Accessibility, className, classNameWithoutGenericParams, baseClassList, constraintsList)
        );
    }
}
