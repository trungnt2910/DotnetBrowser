using Microsoft.CodeAnalysis;

namespace Trungnt2910.Browser.Generators.TypeScript.Models;

public class Context
{
    public string Indent { get; set; } = string.Empty;

    public Dictionary<string, TsType> TypeParameters { get; set; } = new();

    public Dictionary<string, Dictionary<int, Tuple<List<string>, TsType>>> TypeAliases { get; set; } = new();

    public HashSet<string> MustBeInterface { get; set; } = new();

    public List<Interface> Interfaces { get; set; } = new();

    public List<EventMap> EventMaps { get; set; } = new();

    public string Indenter { get; set; } = "    ";

    public Dictionary<string, Interface> InlineInterfaces { get; set; } = new();

    public GeneratorExecutionContext GeneratorExecutionContext;

    public void PushIndent()
    {
        Indent += Indenter;
    }

    public void PopIndent()
    {
        Indent = Indent.Substring(0, Indent.Length - Indenter.Length);
    }

    public Interface? GetInterfaceFromType(TsType t)
    {
        var completeMatch = Interfaces.SingleOrDefault(i => (i.Name == t.Name || i.Name == "Has" + t.Name) && (i.TypeParameters.Count == t.TypeParameters.Count));
        if (completeMatch != null)
        {
            return completeMatch;
        }
        var partialMatch = Interfaces.SingleOrDefault(i => (i.Name == t.Name || i.Name == "Has" + t.Name) 
                                             && (i.TypeParameterDefaults.Where(def => def == null).Count() <= t.TypeParameters.Count));
        return partialMatch;
    }

    public EventMap? GetEventMapFromType(TsType t)
    {
        return EventMaps.SingleOrDefault(em => em.Name == t.Name);
    }

    public bool TypeExists(Interface type)
    {
        return false;
    }

    public bool PropertyExists(Interface type, Property property)
    {
        return false;
    }

    public bool MethodExists(Interface type, Method method)
    {
        return false;
    }

    public bool EventExists(Interface type, Event ev)
    {
        return false;
    }
}
