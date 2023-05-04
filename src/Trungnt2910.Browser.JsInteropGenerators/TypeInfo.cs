using Microsoft.CodeAnalysis;

namespace Trungnt2910.Browser.JsInteropGenerators;

internal class TypeInfo
{
    public string Name { get; set; } = string.Empty;
    public string NamespaceName { get; set; } = string.Empty;
    public TypeInfo? BaseType { get; set; }
    public TypeInfo? ElementType { get; set; }
    public List<TypeInfo> Interfaces { get; set; } = new();
    public List<TypeInfo> TypeArguments { get; set; } = new();
    public Dictionary<string, List<TypeInfo>> TypeConstraints { get; set; } = new();
    public bool IsInterface { get; set; }
    public bool IsTemplateParameter { get; set; }
    public bool IsArray { get; set; }
    public SpecialType SpecialType { get; set; }

    public string GetFullName(bool withNamespace = true)
    {
        if (IsArray)
        {
            return $"{ElementType?.GetFullName()}[]";
        }

        if (IsTemplateParameter)
        {
            return Name;
        }

        var result = Name;
        if (TypeArguments.Any())
        {
            result += $"<{string.Join(",", TypeArguments.Select(arg => arg.GetFullName()))}>";
        }

        if (withNamespace)
        {
            result = $"global::{(!string.IsNullOrEmpty(NamespaceName) ? $"{NamespaceName}." : "")}{result}";
        }

        return result;
    }
}
