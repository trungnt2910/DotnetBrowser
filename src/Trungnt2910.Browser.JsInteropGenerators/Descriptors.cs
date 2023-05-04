using Microsoft.CodeAnalysis;

namespace Trungnt2910.Browser.JsInteropGenerators;

internal static class Descriptors
{
    public static DiagnosticDescriptor UnsupportedConstraintClauses = new DiagnosticDescriptor(
#pragma warning disable RS2008 // Enable analyzer release tracking
    "JSI0001",
#pragma warning restore RS2008 // Enable analyzer release tracking
    "Member contains unsupported constraint clauses",
    "Member contains unsupported constraint clauses",
    nameof(IncrementalGenerator),
    DiagnosticSeverity.Error,
    isEnabledByDefault: true);

    public static DiagnosticDescriptor InvalidPropertyImport = new DiagnosticDescriptor(
#pragma warning disable RS2008 // Enable analyzer release tracking
    "JSI0002",
#pragma warning restore RS2008 // Enable analyzer release tracking
    "Invalid property import",
    "Invalid property import: {0}",
    nameof(IncrementalGenerator),
    DiagnosticSeverity.Error,
    isEnabledByDefault: true);

    public static DiagnosticDescriptor InvalidClassImport = new DiagnosticDescriptor(
#pragma warning disable RS2008 // Enable analyzer release tracking
    "JSI0003",
#pragma warning restore RS2008 // Enable analyzer release tracking
    "Invalid property import",
    "Invalid property import: {0}",
    nameof(IncrementalGenerator),
    DiagnosticSeverity.Error,
    isEnabledByDefault: true);
}
