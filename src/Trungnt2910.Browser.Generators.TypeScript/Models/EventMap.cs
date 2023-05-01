namespace Trungnt2910.Browser.Generators.TypeScript.Models;

public class EventMap
{
    public string Name { get; set; } = string.Empty;

    public Documentation Documentation { get; set; } = new();

    public List<TsType> BaseTypes { get; set; } = new();

    public List<Event> Events { get; set; } = new();

    public EventMap()
    {

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
