using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Trungnt2910.Browser.JsInteropGenerators;

internal static class CodeAnalysisHelpers
{
    public static bool IsAttribute(this NameSyntax nameSyntax, string attributeName)
    {
        var nameString = nameSyntax.ToString();
        return nameString == attributeName || nameString + "Attribute" == attributeName;
    }

    public static bool IsJsObject(this ITypeSymbol typeInfo)
    {
        while (typeInfo.BaseType != null)
        {
            if (typeInfo.BaseType.Name == "JsObject" &&
                typeInfo.BaseType.ContainingNamespace.Name == "Trungnt2910.Browser")
            {
                return true;
            }
        }
        return false;
    }

    public static string GetNamespaceName(this INamespaceSymbol symbol, bool appendDot = false)
    {
        if (symbol.IsGlobalNamespace)
        {
            return "global" + (appendDot ? "::" : "");
        }

        return $"{GetNamespaceName(symbol.ContainingNamespace, true)}{symbol.Name}{(appendDot ? "." : "")}";
    }

    public static string GetContainingNamespaceName(this ISymbol symbol, bool appendDot = false)
    {
        return GetNamespaceName(symbol.ContainingNamespace, appendDot);
    }

    public static string GetNameWithTypeArguments(this ITypeSymbol symbol)
    {
        var result = symbol.Name;

        if (symbol is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.TypeArguments.Any())
        {
            result += $"<{string.Join(", ", namedTypeSymbol.TypeArguments.Select(t => t.GetNameWithTypeArguments()))}>";
        }

        return result;
    }

    public static string GetFullName(this ITypeSymbol symbol)
    {
        if (symbol.SpecialType == SpecialType.System_Void)
        {
            return "void";
        }
        if (symbol.TypeKind == TypeKind.TypeParameter)
        {
            return symbol.Name;
        }
        return $"{symbol.GetContainingNamespaceName(true)}{symbol.GetNameWithTypeArguments()}";
    }
}
