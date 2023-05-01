using Trungnt2910.Browser.Generators.TypeScript.Utilities;
using System.Diagnostics;
using System.Text;

namespace Trungnt2910.Browser.Generators.TypeScript.Models;

[DebuggerDisplay("{(IsReadOnly ? \"readonly\" : \"\"),nq} {Type.Name,nq}{(IsNullable ? \"?\" : \"\" ),nq} {Name,nq}")]
public class Property : ICloneable
{
    public string Name { get; set; } = string.Empty;

    public Documentation Documentation { get; set; } = new();

    public bool IsReadOnly { get; set; } = false;

    public bool IsNullable { get; set; } = false;

    public TsType Type { get; set; } = new();

    public string? InterfaceName { get; set; }

    public Property()
    {

    }

    public string ToString(Context context, bool generateAsClass = false)
    {
        var type = Type.Resolve(context);

        var sb = new StringBuilder();
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

        if (Documentation.IsDeprecated)
        {
            sb.Append($"{context.Indent}[global::System.Obsolete");
            if (!string.IsNullOrEmpty(Documentation.DeprecatedText))
            {
                sb.Append($"(\"{Documentation.DeprecatedText}\")");
            }
            sb.AppendLine("]");
        }

        sb.Append($"{context.Indent}");

        if (!generateAsClass || string.IsNullOrEmpty(InterfaceName))
        {
            sb.Append("public ");
        }

        var typeString = type.ToString(context, appendIToInterface: false);
        sb.Append($"{typeString}");

        //if (type.IsNullable || IsNullable || 
        //    // Force nullable for primitives, because that's what the main library also does.
        //    type.IsCSharpPrimitive())
        //{
            sb.Append('?');
        //}

        sb.Append(' ');

        if (generateAsClass && !string.IsNullOrEmpty(InterfaceName))
        {
            sb.Append($"{InterfaceName}.");
        }

        sb.Append(Name.ToCSharpElementName());

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

            switch (typeString)
            {
                case "void":
                    sb.AppendLine($" => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($\"{{_jsThis}}.{Name}\");");
                    break;
                case "string":
                    sb.AppendLine($" => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($\"{{_jsThis}}.{Name}\");");
                    break;
                case "bool":
                case "double":
                    sb.AppendLine($" => global::Trungnt2910.Browser.WebAssemblyRuntime.{typeString}OrNullFromJs($\"{{_jsThis}}.{Name}\");");
                    break;
                default:
                    sb.AppendLine($" => global::Trungnt2910.Browser.WebAssemblyRuntime<{typeString}>.ValueOrNullFromJs($\"{{_jsThis}}.{Name}\");");
                    break;
            }

            if (!IsReadOnly)
            {
                sb.AppendLine($"{context.Indent}set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($\"{{_jsThis}}.{Name} = {{(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}}\");");
            }

            context.PopIndent();

            sb.Append($"{context.Indent}}}");
        }

        return sb.ToString();
    }

    public static bool operator ==(Property? left, Property? right)
    {
        if (left is null)
        {
            return right is null;
        }
        else if (right is null)
        {
            return left is null;
        }

        return left.Name == right.Name
            && left.Documentation == right.Documentation
            && left.IsReadOnly == right.IsReadOnly
            && left.IsNullable == right.IsNullable
            && left.Type == right.Type
            && left.InterfaceName == right.InterfaceName;
    }

    public static bool operator !=(Property? left, Property? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }
        
        if (obj is Property other)
        {
            return this == other;
        }

        return false;
    }

    public override int GetHashCode()
    {
        int hashCode = Name.GetHashCode();
        hashCode <<= 4;
        hashCode ^= Documentation.GetHashCode();
        hashCode <<= 4;
        hashCode ^= IsReadOnly.GetHashCode();
        hashCode <<= 1;
        hashCode ^= IsNullable.GetHashCode();
        hashCode <<= 1;
        hashCode ^= Type.GetHashCode();
        hashCode <<= 1;
        hashCode ^= InterfaceName?.GetHashCode() ?? -1;
        return hashCode;
    }

    public object Clone()
    {
        return new Property()
        {
            Name = Name,
            Documentation = (Documentation)Documentation.Clone(),
            IsReadOnly = IsReadOnly,
            IsNullable = IsNullable,
            Type = (TsType)Type.Clone(),
            InterfaceName = InterfaceName,
        };
    }
}
