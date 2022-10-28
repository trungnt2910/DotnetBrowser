using LibDomTypeScriptParser.Utilities;
using System.Text;
using Zu.TypeScript.TsTypes;

namespace LibDomTypeScriptParser.Models;

public class Event: ICloneable
{
    public string Name { get; set; } = string.Empty;

    public string? InterfaceName { get; set; }

    public TsType Type { get; set; } = new();

    public Documentation Documentation { get; set; } = new();

    public Event()
    {

    }

    public Event(KeyValuePair<string, TsType> kvp)
    {
        Name = kvp.Key;
        Type = kvp.Value;
    }

    public Event(PropertySignature property)
    {
        Name = ((StringLiteral)property.Children[0]).Text;
        Type = new TsType((TypeReferenceNode)property.Children[1]);
        Documentation = new Documentation(property);
    }

    public string ToString(Context context, bool generateAsClass = false, string? ownerName = null)
    {
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

        var typeString = Type.Resolve(context).ToString(context, appendIToInterface: false);
        sb.Append($"event EventHandler<{typeString}?> ");

        if (generateAsClass && !string.IsNullOrEmpty(InterfaceName))
        {
            sb.Append($"{InterfaceName}.");
        }

        sb.Append($"{Name.ToCSharpEventName()}");

        if (!generateAsClass)
        {
            sb.Append(';');
        }
        else
        {
            sb.AppendLine();
            sb.AppendLine($"{context.Indent}{{");

            context.PushIndent();

            var internalElementsSuffix = $"For{Name.ToCSharpEventName()}OfType{typeString.Replace("<", "_").Replace(">", "_").Replace(",", "_")}";
            if (!string.IsNullOrEmpty(InterfaceName))
            {
                internalElementsSuffix += $"ImplementingInterface{InterfaceName.Replace("<", "_").Replace(">", "_").Replace(",", "_")}";
            }
            var handlerMapName = $"_handlers{internalElementsSuffix}";
            var dispatcherName = $"_Dispatcher{internalElementsSuffix}";

            if (typeString == "Event")
            {
                sb.AppendLine($"{context.Indent}add => AddEventListener(\"{Name}\", value);");
                sb.AppendLine($"{context.Indent}remove => RemoveEventListener(\"{Name}\", value);");
            }
            else
            {
                sb.AppendLine($"{context.Indent}add");
                sb.AppendLine($"{context.Indent}{{");
                sb.AppendLine($"{context.Indent}{context.Indenter}{handlerMapName} ??= new();");
                sb.AppendLine($"{context.Indent}{context.Indenter}if ({handlerMapName}.Count == 0) AddEventListener(\"{Name}\", {dispatcherName});");
                sb.AppendLine($"{context.Indent}{context.Indenter}{handlerMapName}.Add(value);");
                sb.AppendLine($"{context.Indent}}}");
                sb.AppendLine($"{context.Indent}remove");
                sb.AppendLine($"{context.Indent}{{");
                sb.AppendLine($"{context.Indent}{context.Indenter}if ({handlerMapName} != null)");
                sb.AppendLine($"{context.Indent}{context.Indenter}{{");
                sb.AppendLine($"{context.Indent}{context.Indenter}{context.Indenter}{handlerMapName}.Remove(value);");
                sb.AppendLine($"{context.Indent}{context.Indenter}{context.Indenter}if ({handlerMapName}.Count == 0)");
                sb.AppendLine($"{context.Indent}{context.Indenter}{context.Indenter}{{");
                sb.AppendLine($"{context.Indent}{context.Indenter}{context.Indenter}{context.Indenter}RemoveEventListener(\"{Name}\", {dispatcherName});");
                sb.AppendLine($"{context.Indent}{context.Indenter}{context.Indenter}{context.Indenter}{handlerMapName} = null;");
                sb.AppendLine($"{context.Indent}{context.Indenter}{context.Indenter}}}");
                sb.AppendLine($"{context.Indent}{context.Indenter}}}");
                sb.AppendLine($"{context.Indent}}}");
            }

            context.PopIndent();
            sb.Append($"{context.Indent}}}");

            if (typeString != "Event")
            {
                sb.AppendLine();
                sb.AppendLine($"{context.Indent}#region Internal event management members for {(!string.IsNullOrEmpty(InterfaceName) ? $"{InterfaceName}." : "")}{Name.ToCSharpEventName()}");

                sb.AppendLine($"{context.Indent}private global::System.Collections.Generic.HashSet<global::System.EventHandler<{typeString}?>>? {handlerMapName};");
                sb.AppendLine($"{context.Indent}private void {dispatcherName}(object? sender, Event? args)");
                sb.AppendLine($"{context.Indent}{{");
                sb.AppendLine($"{context.Indent}{context.Indenter}var castedSender = sender;");
                if (ownerName != null)
                {
                    sb.AppendLine($"{context.Indent}{context.Indenter}if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<{ownerName}>();");
                }
                sb.AppendLine($"{context.Indent}{context.Indenter}foreach (var handler in {handlerMapName}!) handler?.Invoke(castedSender, args?.Cast<{typeString}>());");
                sb.AppendLine($"{context.Indent}}}");

                sb.AppendLine($"{context.Indent}#endregion");
            }
        }

        return sb.ToString();
    }

    public object Clone()
    {
        return new Event()
        {
            Name = Name,
            InterfaceName = InterfaceName,
            Type = (TsType)Type.Clone(),
            Documentation = (Documentation)Documentation.Clone(),
        };
    }
}
