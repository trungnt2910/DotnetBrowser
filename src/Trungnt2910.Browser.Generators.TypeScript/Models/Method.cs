using Trungnt2910.Browser.Generators.TypeScript.Utilities;
using System.Text;

namespace Trungnt2910.Browser.Generators.TypeScript.Models;

public class Method: ICloneable
{
    public string Name { get; set; } = string.Empty;

    public TsType ReturnType { get; set; } = new();

    public Documentation Documentation { get; set; } = new();

    public List<TsType> Parameters { get; set; } = new();

    public List<string> ParameterNames { get; set; } = new();

    public bool IsLastParameterParams { get; set; } = false;

    public List<string> TypeParameters { get; set; } = new();

    public List<TsType?> TypeParameterDefaults { get; set; } = new();

    public List<TsType?> TypeParameterConstraints { get; set; } = new();

    public string? InterfaceName { get; set; }

    public Method()
    {

    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="context"></param>
    /// <param name="generateAsClass"></param>
    /// <param name="overrideExisting"></param>
    /// <returns></returns>
    public string ToString(Context context, bool generateAsClass = false, bool overrideExisting = false)
    {
        var sb = new StringBuilder();

        var resolvedReturnType = ReturnType.Resolve(context);

        sb.AppendLine($"{context.Indent}/// <summary>");
        if (Documentation.Comments.Any())
        {
            foreach (var line in Documentation.Comments)
            {
                sb.AppendLine($"{context.Indent}/// {line}");
            }
        }
        else
        {
            sb.AppendLine($"{context.Indent}/// To be added.");
        }
        sb.AppendLine($"{context.Indent}/// </summary>");

        foreach (var kvp in Documentation.ParamComments)
        {
            sb.AppendLine($"{context.Indent}/// <param name=\"{kvp.Key}\">{kvp.Value}</param>");
        }

        if (Documentation.IsDeprecated)
        {
            sb.Append($"{context.Indent}[global::System.Obsolete");
            if (!string.IsNullOrEmpty(Documentation.DeprecatedText))
            {
                sb.Append($"(\"{Documentation.DeprecatedText}\")");
            }
            sb.AppendLine("]");
        }

        sb.Append($"{context.Indent}{(InterfaceName != null ? "" : "public ")}{(overrideExisting ? "override " : "")}{resolvedReturnType.ToString(context, appendIToInterface: false)}");

        if (resolvedReturnType.Name != "void")
        {
            sb.Append('?');
        }

        sb.Append($" {((InterfaceName != null) ? $"{InterfaceName.ToCSharpTypeName()}." : "")}{Name.ToCSharpElementName()}");

        if (TypeParameters.Any())
        {
            sb.Append($"<{string.Join(", ", TypeParameters.Select(tp => $"[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] {tp}"))}>");
        }

        sb.Append('(');

        var paramsTypeString = string.Empty;

        int firstDefaultableParameter = Parameters.Count;
        while (firstDefaultableParameter > 0 && Parameters[firstDefaultableParameter - 1].IsNullable)
        {
            --firstDefaultableParameter;
        }

        for (int i = 0; i < Parameters.Count; ++i)
        {
            if (IsLastParameterParams && i == Parameters.Count - 1)
            {
                sb.Append("params ");
                var currentParamType = Parameters[i].Resolve(context);
                if (currentParamType.Kind != TsTypeKind.Array)
                {
                    System.Diagnostics.Debugger.Break();
                }
                else
                {
                    paramsTypeString = currentParamType.ArrayMemberType!.ToString(context);
                    sb.Append(paramsTypeString);
                    // TODO: Append if only this is nullable.
                    sb.Append('?');
                    sb.Append("[]");
                }
            }
            else
            {
                var currentParamType = Parameters[i].Resolve(context);
                sb.Append(currentParamType.ToString(context));
            }
            //if (currentParamType.IsNullable || currentParamType.IsCSharpPrimitive())
            //{
                sb.Append('?');
            //}
            sb.Append(' ');
            sb.Append(ParameterNames[i].ToCSharpParamName());

            if (!IsLastParameterParams && i >= firstDefaultableParameter)
            {
                sb.Append(" = null");
            }

            if (i != Parameters.Count - 1)
            {
                sb.Append(", ");
            }
        }

        sb.Append(')');

        sb.Append(' ');
        var constraintsStrings = new List<string>();
        for (int i = 0; i < TypeParameters.Count; ++i)
        {
            if (TypeParameterConstraints[i] != null)
            {
                var resolvedParamType = TypeParameterConstraints[i]!.Resolve(context);
                if (context.MustBeInterface.Contains(resolvedParamType.Name))
                {
                    constraintsStrings.Add($"where {TypeParameters[i]}: global::Trungnt2910.Browser.JsObject, {resolvedParamType.ToString(context)}");
                }
                else
                {
                    constraintsStrings.Add($"where {TypeParameters[i]}: {resolvedParamType.ToString(context)}");
                }
            }
            else
            {
                constraintsStrings.Add($"where {TypeParameters[i]}: class?");
            }
        }
        sb.Append(string.Join(" ", constraintsStrings));

        if (!generateAsClass)
        {
            sb.Append(';');
        }
        else
        {
            string paramJsString;
            if (!IsLastParameterParams)
            {
                paramJsString = string.Join(", ", ParameterNames.Select(p => $"{{(global::Trungnt2910.Browser.JsObject.ToJsObjectString({p.ToCSharpParamName()}))}}"));
            }
            else
            {
                paramJsString = string.Join(", ", ParameterNames.GetRange(0, ParameterNames.Count - 1).Select(p => $"{{(global::Trungnt2910.Browser.JsObject.ToJsObjectString({p.ToCSharpParamName()}))}}"));
                if (!string.IsNullOrEmpty(paramJsString))
                {
                    paramJsString += ", ";
                }
                paramJsString += $"{{(string.Join(\",\", global::System.Linq.Enumerable.Select({ParameterNames.Last()} ?? global::System.Array.Empty<{paramsTypeString}>(), __arg => global::Trungnt2910.Browser.JsObject.ToJsObjectString(__arg))))}}";
            }
            var returnTypeString = resolvedReturnType.ToString(context, appendIToInterface: false);
            switch (returnTypeString)
            {
                case "void":
                    sb.Append($" => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($\"{{_jsThis}}.{Name}({paramJsString})\");");
                break;
                case "string":
                    sb.Append($" => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($\"{{_jsThis}}.{Name}({paramJsString})\");");
                break;
                case "bool":
                case "double":
                    sb.Append($" => global::Trungnt2910.Browser.WebAssemblyRuntime.{returnTypeString}OrNullFromJs($\"{{_jsThis}}.{Name}({paramJsString})\");");
                break;
                default:
                    sb.Append($" => global::Trungnt2910.Browser.WebAssemblyRuntime<{returnTypeString}>.ValueOrNullFromJs($\"{{_jsThis}}.{Name}({paramJsString})\");");
                break;
            }
        }

        return sb.ToString();
    }

    public bool IsCSharpSpecialMethod(Context context)
    {
        switch (Name)
        {
            case "toString":
                return TypeParameters.Count == 0 && Parameters.Count == 0 && ReturnType.Resolve(context).Name == "string";
            default:
                return false;
        }
    }

    public object Clone()
    {
        return new Method()
        {
            Name = Name,
            ReturnType = (TsType)ReturnType.Clone(),
            Documentation = (Documentation)Documentation.Clone(),
            Parameters = Parameters.Select(p => p.Clone()).Cast<TsType>().ToList(),
            ParameterNames = new List<string>(ParameterNames),
            IsLastParameterParams = IsLastParameterParams,
            TypeParameters = new List<string>(TypeParameters),
            TypeParameterDefaults = TypeParameterDefaults.Select(p => p?.Clone()).Cast<TsType?>().ToList(),
            TypeParameterConstraints = TypeParameterConstraints.Select(p => p?.Clone()).Cast<TsType?>().ToList(),
            InterfaceName = InterfaceName,
        };
    }
}
