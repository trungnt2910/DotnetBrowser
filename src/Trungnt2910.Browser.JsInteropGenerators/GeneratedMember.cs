using Trungnt2910.Browser.JsInterop;

namespace Trungnt2910.Browser.JsInteropGenerators;

internal abstract class GeneratedMember
{
    public string? Name { get; set; }
    public TypeInfo? ClassType { get; set; }
    public TypeInfo? Type { get; set; }
    public List<string>? TypeParameters { get; set; }
    public Dictionary<string, List<TypeInfo>>? TypeConstraints { get; set; }
    public List<TypeInfo>? Parameters { get; set; }
    public List<string>? ParameterNames { get; set; }
    public bool IsLastParameterParams { get; set; }
    public string VirtualOverrideSealedNew { get; set; } = string.Empty;
    public JsImportAttribute JsImportAttribute { get; set; } = new();
    public List<Microsoft.CodeAnalysis.Diagnostic> Diagnostics { get; set; } = new();

    protected GeneratedMember()
    {

    }

    public abstract void Generate(Microsoft.CodeAnalysis.SourceProductionContext context);
}
