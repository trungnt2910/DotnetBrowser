using Microsoft.CodeAnalysis;

namespace Trungnt2910.Browser.Generators.TypeScript;

internal static class Descriptors
{
    public static DiagnosticDescriptor BadNamespaceDescriptor = new DiagnosticDescriptor(
#pragma warning disable RS2008 // Enable analyzer release tracking
        "DTS0001",
#pragma warning restore RS2008 // Enable analyzer release tracking
        "Failed to infer namespace name for file",
        "Failed to infer namespace name for file: '{0}'",
        nameof(TypeScriptSourceGenerator),
        DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public static DiagnosticDescriptor GeneralWarningDescriptor = new DiagnosticDescriptor(
#pragma warning disable RS2008 // Enable analyzer release tracking
       "DTS0002",
#pragma warning restore RS2008 // Enable analyzer release tracking
        "",
        "{0}",
        nameof(TypeScriptSourceGenerator),
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true);

    public static DiagnosticDescriptor UnsupportedFeatureDescriptor = new DiagnosticDescriptor(
#pragma warning disable RS2008 // Enable analyzer release tracking
       "DTS0003",
#pragma warning restore RS2008 // Enable analyzer release tracking
        "Source contains unsupported feature",
        "Source contains unsupported feature: '{0}'",
        nameof(TypeScriptSourceGenerator),
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true);
}
