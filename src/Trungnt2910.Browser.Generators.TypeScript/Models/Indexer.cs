using Trungnt2910.Browser.Generators.TypeScript.Utilities;
using System.Text;

namespace Trungnt2910.Browser.Generators.TypeScript.Models;

public class Indexer
{
    public Documentation Documentation { get; set; } = new();

    public TsType Type { get; set; } = new();

    public bool IsReadOnly { get; set; } = false;

    public List<TsType> Parameters { get; set; } = new();

    public List<string> ParameterNames { get; set; } = new();

    public Indexer()
    {

    }

    public string ToString(Context context, bool generateAsClass = false)
    {
        var sb = new StringBuilder();

        var realType = Type.Resolve(context);

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

        sb.AppendLine($"{context.Indent}[global::System.Runtime.CompilerServices.IndexerName(\"Indexer\")]");

        if (Documentation.IsDeprecated)
        {
            sb.Append($"{context.Indent}[global::System.Obsolete");
            if (!string.IsNullOrEmpty(Documentation.DeprecatedText))
            {
                sb.Append($"(\"{Documentation.DeprecatedText}\")");
            }
            sb.AppendLine("]");
        }

        sb.Append($"{context.Indent}public ");
        sb.Append(realType.ToString(context, appendIToInterface: false));

        //if (Type.IsNullable)
        //{
            sb.Append('?');
        //}

        sb.Append(" this[");

        for (int i = 0; i < Parameters.Count; ++i)
        {
            sb.Append(Parameters[i].Resolve(context).ToString(context));
            sb.Append(' ');
            sb.Append(ParameterNames[i]);
            if (i != Parameters.Count - 1)
            {
                sb.Append(',');
            }
        }

        sb.Append(']');

        if (!generateAsClass)
        {
            sb.Append(" { get; ");
            if (!IsReadOnly)
            {
                sb.Append("set; ");
            }
            sb.Append('}');
        }
        else
        {
            sb.AppendLine();
            sb.AppendLine($"{context.Indent}{{");
            
            context.PushIndent();

            sb.Append($"{context.Indent}get");

            var csharpTypeName = realType.ToString(context, appendIToInterface: false);
            var paramNames = string.Join(", ", ParameterNames.Select(p => $"{{(global::Trungnt2910.Browser.JsObject.ToJsObjectString({p.ToCSharpParamName()}))}}"));
            switch (csharpTypeName)
            {
                case "void":
                    sb.AppendLine($" => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($\"{{_jsThis}}[{paramNames}]\");");
                    break;
                case "string":
                    sb.AppendLine($" => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($\"{{_jsThis}}[{paramNames}]\");");
                    break;
                case "bool":
                case "double":
                    sb.AppendLine($" => global::Trungnt2910.Browser.WebAssemblyRuntime.{csharpTypeName}OrNullFromJs($\"{{_jsThis}}[{paramNames}]\");");
                    break;
                default:
                    sb.AppendLine($" => global::Trungnt2910.Browser.WebAssemblyRuntime<{csharpTypeName}>.ValueOrNullFromJs($\"{{_jsThis}}[{paramNames}]\");");
                    break;
            }

            if (!IsReadOnly)
            {
                sb.AppendLine($"{context.Indent}set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($\"{{_jsThis}}[{paramNames}] = {{(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}}\");");
            }

            context.PopIndent();

            sb.Append($"{context.Indent}}}");
        }

        return sb.ToString();
    }
}
