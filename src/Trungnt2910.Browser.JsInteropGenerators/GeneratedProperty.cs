using Microsoft.CodeAnalysis;

namespace Trungnt2910.Browser.JsInteropGenerators;

internal class GeneratedProperty : GeneratedMember
{
    public override void Generate(SourceProductionContext context)
    {
        foreach (var diagnostic in Diagnostics)
        {
            context.ReportDiagnostic(diagnostic);
        }

        var namespaceName = ClassType?.NamespaceName;

        var className = ClassType?.GetFullName(withNamespace: false);

        var accessibility = JsImportAttribute.Accessibility;

        var jsName = JsImportAttribute.Name;
        if (string.IsNullOrEmpty(jsName))
        {
            jsName = Name;
        }

        if (Type == null)
        {
            return;
        }

        var typeFullName = Type.GetFullName();
        var getBody = "";
        var setBody = "";

        if (Type.IsTemplateParameter)
        {
            getBody = $@"get {{ int? ___resultHandle = __GetMember((int)Handle, ""{jsName}""); return ___resultHandle.HasValue ? __HandleFactory<{typeFullName}>.FromHandle(___resultHandle.Value) : null; }}";
            if (!JsImportAttribute.IsReadOnly)
            {
                setBody = $@"set => __SetMember((int)Handle, ""{jsName}"", (int)value.Handle);";
            }
        }
        else
        {
            switch (Type.SpecialType)
            {
                case SpecialType.System_Boolean:
                case SpecialType.System_String:
                case SpecialType.System_IntPtr:
                case SpecialType.System_Char:
                case SpecialType.System_Byte:
                case SpecialType.System_Int16:
                case SpecialType.System_Int32:
                case SpecialType.System_Single:
                case SpecialType.System_Double:
                    getBody = $@"get {{ __GetMemberRaw(""{jsName}"", out {typeFullName} ___result); return ___result; }}";
                    if (!JsImportAttribute.IsReadOnly)
                    {
                        setBody = $@"set {{ __SetMemberRaw((int)Handle, ""{jsName}"", value); }}";
                    }
                break;
                default:
                    getBody = $@"get {{ int? ___resultHandle = __GetMember((int)Handle, ""{jsName}""); return {typeFullName}.FromHandle(___resultHandle.Value) : null; }}";
                    if (!JsImportAttribute.IsReadOnly)
                    {
                        setBody = $@"set {{ __SetMember((int)Handle, ""{jsName}"", (int)value.Handle); }}";
                    }
                break;
            }
        }

        var source =
$@"{(string.IsNullOrEmpty(namespaceName) ? "" : $"namespace {namespaceName};\n")}
partial class {className}
{{
    {accessibility} {typeFullName} {Name}
    {{
        {getBody}
        {setBody}
    }}
}}";

        context.AddSource($"[property]{(string.IsNullOrEmpty(namespaceName) ? "" : namespaceName + ".")}{className}.{Name}.g.cs"
            .Replace('<', '[').Replace(' ', '_').Replace(',', '_').Replace('>', ']'), source);
    }
}
