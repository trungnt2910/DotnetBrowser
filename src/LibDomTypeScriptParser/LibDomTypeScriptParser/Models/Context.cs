using LibDomTypeScriptParser.Utilities;
using Mono.Cecil;
using System.Text;

namespace LibDomTypeScriptParser.Models;

public class Context
{
    public string Indent { get; set; } = string.Empty;

    public Dictionary<string, TsType> TypeParameters { get; set; } = new();

    public Dictionary<string, Dictionary<int, Tuple<List<string>, TsType>>> TypeAliases { get; set; } = new();

    public HashSet<string> MustBeInterface { get; set; } = new();

    public List<Interface> Interfaces { get; set; } = new();

    public List<EventMap> EventMaps { get; set; } = new();

    public string Indenter { get; set; } = "    ";

    public Dictionary<string, TypeDefinition> ExistingTypeDefinitions { get; set; } = new();

    public Dictionary<string, Interface> InlineInterfaces { get; set; } = new();

    public void PushIndent()
    {
        Indent += Indenter;
    }

    public void PopIndent()
    {
        Indent = Indent[0..^Indenter.Length];
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

    public bool LoadExistingTypesLibrary(string path)
    {
        if (!File.Exists(path))
        {
            return false;
        }

        try
        {
            using var asmDef = AssemblyDefinition.ReadAssembly(path, new ReaderParameters()
            {
                InMemory = true,
            });

            ExistingTypeDefinitions = asmDef.MainModule.GetTypes().Where(type => type.Namespace == "Trungnt2910.Browser.Dom").ToDictionary(t => t.Name, t => t);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"Failed to load existing types assembly {path}: {e}");
            return false;
        }

        return true;
    }

    public bool TypeExists(Interface type)
    {
        return ExistingTypeDefinitions.ContainsKey(type.Name.ToCSharpTypeName());
    }

    public bool PropertyExists(Interface type, Property property)
    {
        if (ExistingTypeDefinitions.TryGetValue(type.Name.ToCSharpTypeName(), out var managedType))
        {
            foreach (var managedProperty in managedType.Properties)
            {
                if (managedProperty.Name != property.Name.ToCSharpElementName())
                {
                    continue;
                }

                var returnTypeString = property.Type.Resolve(this).ToString(this, appendIToInterface: false);
                if (returnTypeString != MonoCecilNameToString(managedProperty.PropertyType))
                {
                    continue;
                }

                return true;
            }
        }

        return false;
    }

    public bool MethodExists(Interface type, Method method)
    {
        if (ExistingTypeDefinitions.TryGetValue(type.Name.ToCSharpTypeName(), out var managedType))
        {
            foreach (var managedMethod in managedType.Methods)
            {
                if (managedMethod.Name != method.Name.ToCSharpElementName())
                {
                    continue;
                }

                if (managedMethod.HasGenericParameters && managedMethod.GenericParameters.Count != method.TypeParameters.Count)
                {
                    continue;
                }

                if (managedMethod.Parameters.Count != method.Parameters.Count)
                {
                    continue;
                }

                var bad = false;

                for (int i = 0; i < method.Parameters.Count; ++i)
                {
                    var paramTypeString = method.Parameters[i].Resolve(this).ToString(this);
                    if (paramTypeString != MonoCecilNameToString(managedMethod.Parameters[i].ParameterType))
                    {
                        bad = true;
                    }
                }

                if (bad)
                {
                    continue;
                }

                return true;
            }
        }

        return false;
    }

    public bool EventExists(Interface type, Event ev)
    {
        if (ExistingTypeDefinitions.TryGetValue(type.Name.ToCSharpTypeName(), out var managedType))
        {
            foreach (var managedEvent in managedType.Events)
            {
                if (managedEvent.Name == ev.Name.ToCSharpEventName())
                {
                    return true;
                }
            }
        }

        return false;
    }

    private string MonoCecilNameToString(TypeReference type)
    {
        if (type.IsGenericParameter)
        {
            System.Diagnostics.Debugger.Break();
        }

        var baseName = type.Name.Split('`')[0];

        switch (baseName)
        {
            case "Nullable":
                return MonoCecilNameToString(((GenericInstanceType)type).GenericArguments[0]);
            case "Int32":
                return "int";
            case "Double":
                return "double";
            case "Boolean":
                return "bool";
            case "String":
                return "string";
            case "Object":
                return "object";
        }

        var sb = new StringBuilder();
        sb.Append(baseName);

        if (type.IsGenericInstance)
        {
            sb.Append('<');
            sb.Append(string.Join(", ", ((GenericInstanceType)type).GenericArguments.Select(p => MonoCecilNameToString(type))));
            sb.Append('>');
        }

        return sb.ToString();
    }
}
