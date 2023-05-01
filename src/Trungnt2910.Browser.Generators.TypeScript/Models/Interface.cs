using Trungnt2910.Browser.Generators.TypeScript.Utilities;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Trungnt2910.Browser.Generators.TypeScript.Models;

public class Interface
{
    const string SuppressWarnings = "CS0108, CS8764, CS8766";

    public string Name { get; set; } = string.Empty;

    public Documentation Documentation { get; set; } = new();

    public List<string> TypeParameters { get; set; } = new();

    public List<TsType?> TypeParameterDefaults { get; set; } = new();

    public List<TsType> BaseTypes { get; set; } = new();

    public List<Property> Properties { get; set; } = new();

    public List<Indexer> Indexers { get; set; } = new();

    public List<Method> Methods { get; set; } = new();

    public List<Method> CallSignatures { get; set; } = new();

    public TsType? EventMapType { get; set; }

    public TsType? ReadOnlyListElementType { get; set; }

    public Interface()
    {

    }

    private IEnumerable<Property> GetClassProperties(Context context)
    {
        return GetClassPropertiesInternal(context).ToList();
    }

    private IEnumerable<Property> GetClassPropertiesInternal(Context context, bool getInherited = false, bool ensureUnique = true, HashSet<Interface>? visitedInterfaces = null)
    {
        var returnedNames = new Dictionary<string, Dictionary<TsType, Property>>();
        visitedInterfaces ??= new();

        if (visitedInterfaces.Contains(this))
        {
            yield break;
        }

        visitedInterfaces.Add(this);

        foreach (var p in Properties)
        {
            var property = (Property)p.Clone();
            if (!ensureUnique)
            {
                property.InterfaceName = $"I{Name}";
            }
            else
            {
                if (!returnedNames.TryGetValue(property.Name, out var previousTypes))
                {
                    previousTypes = new();
                    returnedNames.Add(property.Name, previousTypes);
                }
                previousTypes.Add(property.Type, property);
            }
            yield return property;
        }

        if (!getInherited && BaseTypes.Count > 0)
        {
            var i = context.GetInterfaceFromType(BaseTypes[0]);
            if (i != null)
            {
                visitedInterfaces.Add(i);
            }
        }

        var yieldCurrent = getInherited;

        foreach (var b in BaseTypes.Select(context.GetInterfaceFromType).Where(i => i != null).Cast<Interface>())
        {
            foreach (var p in b.GetClassPropertiesInternal(context, true, false, yieldCurrent ? visitedInterfaces : null))
            {
                if (ensureUnique)
                {
                    if (!returnedNames.TryGetValue(p.Name, out var previousTypes))
                    {
                        previousTypes = new();
                        returnedNames.Add(p.Name, previousTypes);
                    }
                    var clash = previousTypes.FirstOrDefault(t => t.Key.EqualsIgnoreNullable(p.Type)).Value;
                    if (clash != null)
                    {
                        // Should inherit documentation, first from the base, then from any interfaces, if the string is empty.
                        if (!clash.Documentation.Comments.Where(c => !string.IsNullOrEmpty(c)).Any())
                        {
                            clash.Documentation.AppendCommentLines(p.Documentation.Comments);
                        }

                        if (yieldCurrent)
                        {
                            clash.Documentation.IsDeprecated = clash.Documentation.IsDeprecated && p.Documentation.IsDeprecated;
                            if (!clash.Documentation.IsDeprecated)
                            {
                                clash.Documentation.DeprecatedText = null;
                            }
                            clash.IsReadOnly = clash.IsReadOnly && p.IsReadOnly;
                            clash.IsNullable = clash.IsNullable && p.IsNullable;
                        }

                        // Same type already added.
                        continue;
                    }
                    else if (yieldCurrent && previousTypes.Any())
                    {
                        // Some different type already added.
                        previousTypes.Add(p.Type, p);
                    }
                    else if (yieldCurrent)
                    {
                        // First of the kind.
                        previousTypes.Add(p.Type, p);
                        p.InterfaceName = null;
                    }
                }

                if (yieldCurrent)
                {
                    yield return p;
                }
            }
            yieldCurrent = true;
        }
    }

    private IEnumerable<Method> GetClassMethods(Context context)
    {
        return GetClassMethodsInternal(context).ToList();
    }

    private IEnumerable<Method> GetClassMethodsInternal(Context context, bool getInherited = false, bool ensureUnique = true, HashSet<Interface>? visitedInterfaces = null)
    {
        var returnedNames = new Dictionary<string, List<List<TsType>>>();
        visitedInterfaces ??= new();

        if (visitedInterfaces.Contains(this))
        {
            yield break;
        }

        visitedInterfaces.Add(this);

        foreach (var m in UnifyMethods(context, Methods))
        {
            var method = m;
            if (!ensureUnique)
            {
                method = (Method)method.Clone();
                method.InterfaceName = $"I{Name}";
            }
            else
            {
                var currentList = m.Parameters.Select(p => p.Resolve(context)).ToList();
                if (!returnedNames.TryGetValue(m.Name, out var previousParams))
                {
                    previousParams = new();
                    returnedNames.Add(m.Name, previousParams);
                }
                previousParams.Add(currentList);
            }
            
            yield return method;
        }

        if (!getInherited && BaseTypes.Count > 0)
        {
            var i = context.GetInterfaceFromType(BaseTypes[0]);
            if (i != null)
            {
                visitedInterfaces.Add(i);
            }
        }

        var yieldCurrent = getInherited;

        foreach (var b in BaseTypes.Select(context.GetInterfaceFromType).Where(i => i != null).Cast<Interface>())
        {
            foreach (var m in b.GetClassMethodsInternal(context, true, false, yieldCurrent ? visitedInterfaces : null))
            {
                if (ensureUnique)
                {
                    var collide = false;
                    var currentList = m.Parameters.Select(p => p.Resolve(context)).ToList();
                    if (!returnedNames.TryGetValue(m.Name, out var previousParams))
                    {
                        previousParams = new();
                        returnedNames.Add(m.Name, previousParams);
                    }
                    else
                    {
                        foreach (var previousList in previousParams)
                        {
                            if (previousList.Count == currentList.Count && 
                                !previousList.Zip(currentList, (First, Second) => (First, Second)).Where(pair => !pair.First.EqualsIgnoreNullable(pair.Second)).Any())
                            {
                                collide = true;
                                break;
                            }
                        }
                    }

                    if (!collide && yieldCurrent)
                    {
                        previousParams.Add(currentList);
                        m.InterfaceName = null;
                    }
                }
                if (yieldCurrent)
                {
                    yield return m;
                }
            }

            yieldCurrent = true;
        }
    }

    private IEnumerable<Method> UnifyMethods(Context context, IEnumerable<Method> methods)
    {
        var methodList = new List<Method>(methods);

        for (int i = 0; i < methodList.Count; ++i)
        {
            var method = (Method)methodList[i].Clone();
            var methodReturnType = method.ReturnType;
            for (int j = i + 1; j < methodList.Count; ++j)
            {
                var otherMethod = methodList[j];
                if (otherMethod.Name != method.Name)
                {
                    continue;
                }
                if (otherMethod.TypeParameters.Count != method.TypeParameters.Count)
                {
                    continue;
                }
                if (otherMethod.Parameters.Count != method.Parameters.Count)
                {
                    continue;
                }
                if (otherMethod.InterfaceName != method.InterfaceName)
                {
                    continue;
                }
                for (int paramIndex = 0; paramIndex < otherMethod.Parameters.Count; ++paramIndex)
                {
                    if (!otherMethod.Parameters[paramIndex].Resolve(context)
                        .EqualsIgnoreNullable(method.Parameters[paramIndex].Resolve(context)))
                    {
                        goto bail;
                    }
                }
                for (int paramIndex = 0; paramIndex < otherMethod.Parameters.Count; ++paramIndex)
                {
                    method.Parameters[paramIndex].IsNullable = otherMethod.Parameters[paramIndex].Resolve(context).IsNullable;
                }
                if (method.Documentation != otherMethod.Documentation)
                {
                    if (!method.Documentation.Comments.SequenceEqual(otherMethod.Documentation.Comments))
                    {
                        method.Documentation.AppendCommentLines(otherMethod.Documentation.Comments, false);
                    }
                }
                if (method.ReturnType != otherMethod.ReturnType)
                {
                    // Now it's differing only by return type.
                    methodReturnType = methodReturnType.UnionWith(otherMethod.ReturnType);
                }
                methodList[j] = methodList.Last();
                methodList.RemoveAt(methodList.Count - 1);
                --j;
            bail: continue;
            }
            method.ReturnType = methodReturnType;
            yield return method;
        }
    }

    private IEnumerable<Event> GetClassEvents(Context context, bool getInherited = false, bool ensureUnique = true, HashSet<Interface>? visitedInterfaces = null)
    {
        var returnedNames = new Dictionary<string, HashSet<TsType>>();
        visitedInterfaces ??= new();

        if (visitedInterfaces.Contains(this))
        {
            yield break;
        }

        visitedInterfaces.Add(this);

        if (EventMapType != null)
        {
            var eventMap = context.GetEventMapFromType(EventMapType);
            if (eventMap == null)
            {
                context.GeneratorExecutionContext.ReportDiagnostic(Diagnostic.Create(Descriptors.GeneralWarningDescriptor,
                    Location.None,
                    $"Cannot resolve event map '{EventMapType.Name}'"));
            }
            else
            {
                foreach (var ev in eventMap.GetEvents(context))
                {
                    if (!ensureUnique)
                    {
                        ev.InterfaceName = $"I{Name}";
                    }
                    else
                    {
                        returnedNames.Add(ev.Name, new HashSet<TsType>() { ev.Type });
                        ev.InterfaceName = null;
                    }
                    yield return ev;
                }
            }
        }

        if (!getInherited && BaseTypes.Count > 0)
        {
            var i = context.GetInterfaceFromType(BaseTypes[0]);
            if (i != null)
            {
                visitedInterfaces.Add(i);
            }
        }

        foreach (var b in BaseTypes.Skip(getInherited ? 0 : 1).Select(tsType => context.GetInterfaceFromType(tsType)).Where(i => i != null).Cast<Interface>())
        {
            foreach (var ev in b.GetClassEvents(context, true, false, visitedInterfaces))
            {
                if (ensureUnique)
                {
                    if (!returnedNames.TryGetValue(ev.Name, out var previousTypes))
                    {
                        previousTypes = new();
                        returnedNames.Add(ev.Name, previousTypes);
                    }
                    if (previousTypes.Contains(ev.Type))
                    {
                        // Same type already added.
                        continue;
                    }
                    else if (previousTypes.Any())
                    {
                        // Some different type already added.
                        previousTypes.Add(ev.Type);
                        yield return ev;
                    }
                    else
                    {
                        // First of the kind.
                        previousTypes.Add(ev.Type);
                        ev.InterfaceName = null;
                        yield return ev;
                    }
                }
                else
                {
                    yield return ev;
                }
            }
        }
    }

    public string ToString(Context context, bool generateAsClass = false)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{context.Indent}#pragma warning disable {SuppressWarnings}");

        var isReadOnlyList = ReadOnlyListElementType != null;

        if (!generateAsClass)
        {
            for (int nonDefaultTypeParams = TypeParameterDefaults.Count; nonDefaultTypeParams >= 0; --nonDefaultTypeParams)
            {
                if (nonDefaultTypeParams < TypeParameterDefaults.Count && TypeParameterDefaults[nonDefaultTypeParams] == null)
                {
                    break;
                }

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

                sb.Append($"{context.Indent}public interface I{Name}");
                if (nonDefaultTypeParams > 0)
                {
                    sb.Append($"<{string.Join(", ", TypeParameters.Take(nonDefaultTypeParams))}>");
                }
                if (BaseTypes.Count > 0 || isReadOnlyList)
                {
                    var baseTypesString = BaseTypes
                        .Select(t => $"I{t.ToString(context, false)}")
                        .Concat(isReadOnlyList ?
                            new[] { $"global::System.Collections.Generic.IReadOnlyList<{ReadOnlyListElementType!.ToString(context, false)}?>" } : Array.Empty<string>());
                    sb.Append($": {string.Join(", ", baseTypesString)}");
                }
                sb.AppendLine();
                if (nonDefaultTypeParams > 0)
                {
                    context.PushIndent();
                    sb.AppendLine($"{context.Indent}{string.Join(" ", TypeParameters.Take(nonDefaultTypeParams).Select(n => $"where {n}: class?"))}");
                    context.PopIndent();
                }
                sb.AppendLine($"{context.Indent}{{");

                for (int defaultParams = nonDefaultTypeParams; defaultParams < TypeParameters.Count; ++defaultParams)
                {
                    context.TypeParameters.Add(TypeParameters[defaultParams], TypeParameterDefaults[defaultParams]!);
                }

                context.PushIndent();

                foreach (var p in Properties)
                {
                    if (isReadOnlyList && p.Name == "length")
                    {
                        continue;
                    }
                    sb.AppendLine(p.ToString(context));
                }

                foreach (var m in UnifyMethods(context, Methods))
                {
                    sb.AppendLine(m.ToString(context));
                }

                foreach (var i in Indexers)
                {
                    if (isReadOnlyList && i.Parameters.Count == 1 && i.Parameters[0].Name == "number")
                    {
                        continue;
                    }
                    sb.AppendLine(i.ToString(context));
                }

                if (EventMapType != null)
                {
                    var eventMap = context.GetEventMapFromType(EventMapType);
                    if (eventMap != null)
                    {
                        foreach (var e in eventMap.GetEvents(context))
                        {
                            sb.AppendLine(e.ToString(context));
                        }
                    }
                }

                context.PopIndent();

                for (int defaultParams = nonDefaultTypeParams; defaultParams < TypeParameters.Count; ++defaultParams)
                {
                    context.TypeParameters.Remove(TypeParameters[defaultParams]);
                }

                sb.AppendLine($"{context.Indent}}}");
            }
        }
        else
        {
            for (int nonDefaultTypeParams = TypeParameterDefaults.Count; nonDefaultTypeParams >= 0; --nonDefaultTypeParams)
            {
                if (nonDefaultTypeParams < TypeParameterDefaults.Count && TypeParameterDefaults[nonDefaultTypeParams] == null)
                {
                    break;
                }

                for (int defaultParams = nonDefaultTypeParams; defaultParams < TypeParameters.Count; ++defaultParams)
                {
                    context.TypeParameters.Add(TypeParameters[defaultParams], TypeParameterDefaults[defaultParams]!);
                }

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

                sb.Append($"{context.Indent}public partial class {Name}");
                if (nonDefaultTypeParams > 0)
                {
                    sb.Append($"<{string.Join(", ", TypeParameters.Take(nonDefaultTypeParams))}>");
                }

                bool thisMustBeInterface = context.MustBeInterface.Contains(Name);

                // This type should have a real base class.
                if (BaseTypes.Count == 1)
                {
                    sb.Append($": {BaseTypes[0].ToString(context, false)}");
                }
                else if (BaseTypes.Count == 0)
                {
                    if (CallSignatures.Count >= 1)
                    {
                        if (CallSignatures.Count > 1)
                        {
                            context.GeneratorExecutionContext.ReportDiagnostic(Diagnostic.Create(Descriptors.UnsupportedFeatureDescriptor,
                                Location.None,
                                $"Class '{Name}' has multiple call signatures which is not supported. Generating the first signature only."));
                        }
                        var returnType = CallSignatures[0].ReturnType.Resolve(context);
                        var returnTypeString = returnType.ToString(context, appendIToInterface: false);
                        if (new[] { "void", "undefined", "null" }.Contains(returnTypeString))
                        {
                            if (CallSignatures[0].Parameters.Any())
                            {
                                sb.Append($": JsAction<{string.Join(", ", CallSignatures[0].Parameters.Select(t => t.ToString(context, true) + "?"))}>");
                            }
                            else
                            {
                                sb.Append(": JsAction");
                            }
                        }
                        else if (returnType.Kind == TsTypeKind.Union && returnType.MemberTypes.Any(m => m.Resolve(context).Name == "void"))
                        {
                            var baseType = new TsType()
                            {
                                Kind = TsTypeKind.Union,
                                MemberTypes = returnType.MemberTypes.Select(m => new TsType()
                                {
                                    Kind = TsTypeKind.Delegate,
                                    DelegateReturnType = m,
                                    DelegateParameters = CallSignatures[0].Parameters,
                                    DelegateParameterNames = CallSignatures[0].ParameterNames
                                }).ToList()
                            };
                            sb.Append($": {baseType.Resolve(context).ToString(context, false)}");
                        }
                        else
                        {
                            sb.Append($": JsFunc<{string.Join(", ", CallSignatures[0].Parameters.Select(t => t.ToString(context, true) + "?").Concat(new[] { returnTypeString + "?" }))}>");
                        }
                    }
                    else if (GetClassEvents(context).Any())
                    {
                        // Classes with events must inherit from EventTarget.
                        sb.Append($": EventTarget");
                    }
                    else
                    {
                        sb.Append($": JsObject");
                    }
                }
                else
                {
                    if (CallSignatures.Count >= 1)
                    {
                        context.GeneratorExecutionContext.ReportDiagnostic(Diagnostic.Create(Descriptors.UnsupportedFeatureDescriptor,
                            Location.None,
                            $"Call signatures are not supported for class '{Name}' because it has a base type."));
                    }
                    sb.Append($": {BaseTypes[0].ToString(context, false)}, {string.Join(", ", BaseTypes.Skip(1).Select(t => $"I{t.ToString(context, false)}"))}");
                }

                if (thisMustBeInterface)
                {
                    sb.Append($", I{Name}");
                }

                if (isReadOnlyList)
                {
                    sb.Append($", global::System.Collections.Generic.IReadOnlyList<{ReadOnlyListElementType!.ToString(context, false)}?>");
                }

                sb.AppendLine();

                if (nonDefaultTypeParams > 0)
                {
                    context.PushIndent();
                    sb.AppendLine($"{context.Indent}{string.Join(" ", TypeParameters.Take(nonDefaultTypeParams).Select(n => $"where {n}: class?"))}");
                    context.PopIndent();
                }

                sb.AppendLine($"{context.Indent}{{");

                context.PushIndent();

                foreach (var p in GetClassProperties(context))
                {
                    if (new[] { "null", "undefined" }.Contains(p.Type.Name))
                    {
                        context.GeneratorExecutionContext.ReportDiagnostic(Diagnostic.Create(Descriptors.UnsupportedFeatureDescriptor,
                            Location.None,
                            $"Skipping '{p.Type.Name}' member '{p.Name.ToCSharpElementName()}' in class '{Name.ToCSharpElementName()}'"));
                        continue;
                    }

                    if (p.Name.ToCSharpElementName() == Name)
                    {
                        context.GeneratorExecutionContext.ReportDiagnostic(Diagnostic.Create(Descriptors.UnsupportedFeatureDescriptor,
                            Location.None,
                            $"Skipping member '{p.Name.ToCSharpElementName()}' in class '{Name.ToCSharpElementName()}' because it has the same name as the enclosing class type."));
                        continue;
                    }

                    var prefix = "";
                    var postfix = "";
                    if (context.PropertyExists(this, p))
                    {
                        prefix = $"/* // Skipping existing member {p.Name.ToCSharpElementName()}";
                        postfix = "*/";
                    }
                    sb.AppendLine($"{context.Indent}{prefix}");
                    sb.AppendLine(p.ToString(context, generateAsClass: true));
                    sb.AppendLine($"{context.Indent}{postfix}");
                }

                foreach (var m in GetClassMethods(context))
                {
                    var prefix = "";
                    var postfix = "";
                    if (context.MethodExists(this, m))
                    {
                        prefix = $"/* // Skipping existing member {m.Name.ToCSharpElementName()}";
                        postfix = "*/";
                    }
                    sb.AppendLine($"{context.Indent}{prefix}");
                    sb.AppendLine(m.ToString(context, generateAsClass: true, overrideExisting: m.IsCSharpSpecialMethod(context)));
                    sb.AppendLine($"{context.Indent}{postfix}");
                }

                foreach (var i in Indexers)
                {
                    sb.AppendLine($"{context.Indent}");
                    sb.AppendLine(i.ToString(context, generateAsClass: true));
                    sb.AppendLine($"{context.Indent}");
                }

                foreach (var e in GetClassEvents(context))
                {
                    var prefix = "";
                    var postfix = "";
                    if (context.EventExists(this, e))
                    {
                        prefix = $"/* // Skipping existing member {e.Name.ToCSharpEventName()}";
                        postfix = "*/";
                    }
                    sb.AppendLine($"{context.Indent}{prefix}");
                    sb.AppendLine(e.ToString(context, generateAsClass: true, ownerName: Name.ToCSharpTypeName()));
                    sb.AppendLine($"{context.Indent}{postfix}");
                }


                if (isReadOnlyList)
                {
                    sb.AppendLine($"{context.Indent}");
                    sb.AppendLine($"{context.Indent}/// <inheritdoc/>");
                    sb.AppendLine($"{context.Indent}public int Count => global::Trungnt2910.Browser.WebAssemblyRuntime.Int32FromJs($\"{{_jsThis}}.length\");");
                    sb.AppendLine($"{context.Indent}");

                    var indexer = Indexers.Single(i => i.Parameters.Count == 1 && i.Parameters[0].Name == "number");
                    var indexerTypeString = ReadOnlyListElementType!.Resolve(context).ToString(context, false);
                    var indexerParamName = indexer.ParameterNames[0].ToCSharpParamName();
                    var indexerParam = $"{{(global::Trungnt2910.Browser.JsObject.ToJsObjectString({indexerParamName}))}}";

                    sb.AppendLine($"{context.Indent}");
                    sb.AppendLine($"{context.Indent}/// <inheritdoc/>");
                    sb.AppendLine($"{context.Indent}[global::System.Runtime.CompilerServices.IndexerName(\"Indexer\")]");
                    sb.Append($"{context.Indent}public {indexerTypeString}? this[int {indexerParamName}]");

                    switch (indexerTypeString)
                    {
                        case "void":
                            sb.AppendLine($" => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($\"{{_jsThis}}[{indexerParam}]\");");
                            break;
                        case "string":
                            sb.AppendLine($" => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($\"{{_jsThis}}[{indexerParam}]\");");
                            break;
                        case "bool":
                        case "double":
                            sb.AppendLine($" => global::Trungnt2910.Browser.WebAssemblyRuntime.{indexerTypeString}OrNullFromJs($\"{{_jsThis}}[{indexerParam}]\");");
                            break;
                        default:
                            sb.AppendLine($" => global::Trungnt2910.Browser.WebAssemblyRuntime<{indexerTypeString}>.ValueOrNullFromJs($\"{{_jsThis}}[{indexerParam}]\");");
                            break;
                    }
                    sb.AppendLine($"{context.Indent}");

                    sb.AppendLine($"{context.Indent}");
                    sb.AppendLine($"{context.Indent}/// <inheritdoc/>");
                    sb.AppendLine($"{context.Indent}public global::System.Collections.Generic.IEnumerator<{indexerTypeString}?> GetEnumerator() {{ for (int i = 0; i < Count; ++i) yield return this[i]; }}");
                    sb.AppendLine($"{context.Indent}");

                    sb.AppendLine($"{context.Indent}");
                    sb.AppendLine($"{context.Indent}/// <inheritdoc/>");
                    sb.AppendLine($"{context.Indent}global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();");
                    sb.AppendLine($"{context.Indent}");
                }

                sb.AppendLine(JsObjectGenerator.ClassTemplate
                    .Replace("{{ClassNameWithoutGenericParameters}}", Name)
                    .Replace("{{ClassName}}", Name + (nonDefaultTypeParams > 0 ? $"<{string.Join(", ", TypeParameters.Take(nonDefaultTypeParams))}>" : string.Empty)));

                context.PopIndent();

                sb.AppendLine($"{context.Indent}}}");

                for (int defaultParams = nonDefaultTypeParams; defaultParams < TypeParameters.Count; ++defaultParams)
                {
                    context.TypeParameters.Remove(TypeParameters[defaultParams]);
                }
            }
        }

        sb.AppendLine($"{context.Indent}#pragma warning restore {SuppressWarnings}");

        return sb.ToString();
    }
}
