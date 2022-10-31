using Zu.TypeScript.TsTypes;

namespace LibDomTypeScriptParser.Models;

public class EventMap
{
    public string Name { get; set; } = string.Empty;

    public Documentation Documentation { get; set; } = new();

    public List<TsType> BaseTypes { get; set; } = new();

    public List<Event> Events { get; set; } = new();

    public EventMap(InterfaceDeclaration declaration)
    {
        Name = declaration.IdentifierStr;
        Documentation = new Documentation(declaration);

        if (declaration.TypeParameters?.Any() ?? false)
        {
            System.Diagnostics.Debugger.Break();
        }

        var extendList = declaration.HeritageClauses?.FirstOrDefault()?.Children;
        if (extendList?.Any() ?? false)
        {
            BaseTypes = extendList.Select(t => new TsType((ITypeNode)t)).ToList();
        }

        foreach (var member in declaration.Members)
        {
            if (member is PropertySignature property && 
                member.Children.Count == 2 && 
                member.Children[0].Kind == SyntaxKind.StringLiteral && 
                member.Children[1].Kind == SyntaxKind.TypeReference)
            {
                var ev = new Event(property);
                ev.Documentation.IsDeprecated = Documentation.IsDeprecated || ev.Documentation.IsDeprecated;
                Events.Add(ev);
            }
            else
            {
                Console.Error.WriteLine($"[{member.Pos}-{member.End}] Member {member.GetText()} not recognized in a event map.");
            }
        }
    }

    public IEnumerable<Event> GetEvents(Context context)
    {
        var existingEvents = new Dictionary<string, Event>();

        foreach (var baseEventMap in BaseTypes.Select(b => context.GetEventMapFromType(b)))
        {
            if (baseEventMap != null)
            {
                foreach (var ev in baseEventMap.GetEvents(context))
                {
                    existingEvents[ev.Name] = ev;
                }
            }
            else
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        foreach (var ev in Events)
        {
            existingEvents[ev.Name] = ev;
        }

        return existingEvents.Select(kvp => kvp.Value);
    }
}
