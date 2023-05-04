using Microsoft.CodeAnalysis;

namespace Trungnt2910.Browser.JsInteropGenerators;

internal class GeneratedMethod : GeneratedMember
{
    public override void Generate(SourceProductionContext context)
    {
        foreach (var diagnostic in Diagnostics)
        {
            context.ReportDiagnostic(diagnostic);
        }

        var namespaceName = ClassType?.NamespaceName;

        var classNameWithoutGenericParams = ClassType?.Name;
        var className = ClassType?.GetFullName(withNamespace: false);

        var accessibility = JsImportAttribute.Accessibility;

        var typeParametersList = "";
        if (TypeParameters?.Any() ?? false)
        {
            typeParametersList = $"<{string.Join(", ", TypeParameters)}>";
        }

        var jsName = JsImportAttribute.Name;
        if (string.IsNullOrEmpty(jsName))
        {
            jsName = Name;
        }

        var constraintsList = "";
        if (TypeParameters?.Any() ?? false)
        {
            constraintsList = $" where {string.Join(" where ", TypeParameters.Select(tp =>
                (TypeConstraints?.ContainsKey(tp) ?? false) ?
                    $"{tp}: {string.Join(", ", TypeConstraints[tp].Select(t
                        => $"{t.GetFullName()}"))}"
                    : $"{tp}: global::Trungnt2910.Browser.JsObject"))}";
        }

        if (Type == null)
        {
            return;
        }

        var parameterList = "";
        if (ParameterNames != null)
        {
            for (int i = 0; i < ParameterNames.Count; ++i)
            {
                if (i == ParameterNames.Count - 1 && IsLastParameterParams)
                {
                    parameterList += $@"params {Parameters![i].GetFullName()} {ParameterNames[i]}";
                }
                else
                {
                    parameterList += $@"{Parameters![i].GetFullName()} {ParameterNames[i]}";
                }

                if (i != ParameterNames.Count - 1)
                {
                    parameterList += ", ";
                }
            }
        }

        var objectArrayCreation = "";
        if (IsLastParameterParams)
        {
            objectArrayCreation = $@"var ___args = new object[{Parameters!.Count - 1} + {ParameterNames!.Last()}.Length];";
        }
        else if (Parameters?.Any() ?? false)
        {
            objectArrayCreation = $@"var ___args = new object[{Parameters!.Count}];";
        }
        else
        {
            objectArrayCreation = $@"object[] ___args = null;";
        }

        if (ParameterNames != null)
        {
            for (int i = 0; i < ParameterNames.Count; ++i)
            {
                if (i == ParameterNames.Count - 1 && IsLastParameterParams)
                {
                    objectArrayCreation += $@"global::System.Array.Copy({ParameterNames[i]}, 0, ___args, {i}, {ParameterNames[i]}.Length);";
                }
                else
                {
                    objectArrayCreation += $@"___args[{i}] = {ParameterNames[i]};";
                }
            }
        }

        var functionBody = "";
        var typeFullName = Type.GetFullName();

        switch (Type.SpecialType)
        {
            case SpecialType.System_Void:
                functionBody = $@"__InvokeMemberRaw(""{jsName}"", ___args);";
            break;
            case SpecialType.System_Boolean:
            case SpecialType.System_String:
            case SpecialType.System_IntPtr:
            case SpecialType.System_Char:
            case SpecialType.System_Byte:
            case SpecialType.System_Int16:
            case SpecialType.System_Int32:
            case SpecialType.System_Single:
            case SpecialType.System_Double:
                functionBody = $@"__InvokeMemberRaw(""{jsName}"", ___args, out {typeFullName} ___result); return ___result;";
            break;
            default:
                if (!Type.IsTemplateParameter)
                {
                    functionBody = $@"int? ___resultHandle = __InvokeMember(""{jsName}"", ___args); return ___resultHandle.HasValue ? {typeFullName}.FromHandle(___resultHandle.Value) : null;";
                }
                else
                {
                    functionBody = $@"int? ___resultHandle = __InvokeMember(""{jsName}"", ___args); return ___resultHandle.HasValue ? __HandleFactory<{typeFullName}>.FromHandle(___resultHandle.Value) : null;";
                }
                break;
        }

        context.AddSource($"[method]{(string.IsNullOrEmpty(namespaceName) ? "" : namespaceName + ".")}{className}.{Name}{typeParametersList}.g.cs"
            .Replace('<', '[').Replace(' ', '_').Replace(',', '_').Replace('>', ']'), 
            CodeSnippets.JsMethodBoilerplate(namespaceName, className, accessibility, VirtualOverrideSealedNew, typeFullName, 
                Name, typeParametersList, parameterList, constraintsList, objectArrayCreation, functionBody));
    }
}
