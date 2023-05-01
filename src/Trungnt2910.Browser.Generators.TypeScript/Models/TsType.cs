using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Trungnt2910.Browser.Generators.TypeScript.Utilities;

namespace Trungnt2910.Browser.Generators.TypeScript.Models;

public enum TsTypeKind
{
    Normal,
    Union,
    Delegate,
    Array,
    Range,
    StringList,
    InlineType
}

public class TsType: ICloneable
{
    public List<TsType> MemberTypes { get; set; } = new();

    public List<TsType> TypeParameters { get; set; } = new();

    public List<TsType> DelegateParameters { get; set; } = new();

    public List<string> DelegateParameterNames { get; set; } = new();

    public TsType? DelegateReturnType { get; set; }

    public TsType? ArrayMemberType { get; set; }

    public string? FirstType { get; set; }

    public string? LastType { get; set; }

    public string Name { get; set; } = string.Empty;

    public TsTypeKind Kind { get; set; } = TsTypeKind.Normal;

    public bool IsNullable { get; set; } = false;

    public TsType()
    {

    }

    internal void AssignToThis(TsType other)
    {
        Kind = other.Kind;
        Name = other.Name;
        MemberTypes = other.MemberTypes;
        TypeParameters = other.TypeParameters;
        DelegateParameters = other.DelegateParameters;
        DelegateReturnType = other.DelegateReturnType;
        ArrayMemberType = other.ArrayMemberType;
        IsNullable = other.IsNullable;
        FirstType = other.FirstType;
        LastType = other.LastType;
    }

    public TsType Resolve(Context context)
    {
        var typeParamsMap = context.TypeParameters;

        var realName = Name;
        while (typeParamsMap.ContainsKey(realName))
        {
            realName = typeParamsMap[realName].ToString(context, false);
        }

        TsType newType = null!;

        if (realName == "Exclude")
        {
            // Support the special case Exclude<SomeTypeThatIsActuallyString, SomeOtherTypeThatIsAlsoActuallyString>
            var firstTypeParam = TypeParameters[0].Resolve(context);
            foreach (var t in TypeParameters.Skip(1))
            {
                if (t.Resolve(context) != firstTypeParam)
                {
                    context.GeneratorExecutionContext.ReportDiagnostic(Diagnostic.Create(Descriptors.UnsupportedFeatureDescriptor,
                        Location.None,
                        $"'Exclude' is not supported. Emitting C# 'object'."));
                    return new TsType() { Name = "object", Kind = TsTypeKind.Normal };
                }
            }
            return firstTypeParam;
        }

        if (TypeParameters.Count == 1 && TypeParameters[0].Name == "undefined")
        {
            context.GeneratorExecutionContext.ReportDiagnostic(Diagnostic.Create(Descriptors.UnsupportedFeatureDescriptor,
                Location.None,
                $"Ignoring 'undefined' type argument for '{realName}'."));
            return new TsType() { Name = realName, Kind = TsTypeKind.Normal };
        }

        if (context.TypeAliases.TryGetValue(Name, out var aliases))
        {
            if (aliases.TryGetValue(TypeParameters.Count, out var realTypeInfo))
            {
                for (int i = 0; i < TypeParameters.Count; ++i)
                {
                    context.TypeParameters.Add(realTypeInfo.Item1[i], TypeParameters[i]);
                }

                newType = (TsType)realTypeInfo.Item2.Clone();
                newType.Flatten();

                // Support for IDBValidKey
                // type IDBValidKey = number | string | Date | BufferSource | IDBValidKey[];
                if (newType.Kind == TsTypeKind.Union)
                {
                    if (newType.MemberTypes.Last().Kind == TsTypeKind.Array && newType.MemberTypes.Last().ArrayMemberType == this)
                    {
                        newType.MemberTypes.RemoveAt(newType.MemberTypes.Count - 1);
                        newType.MemberTypes.AddRange(newType.MemberTypes.Select(m => new TsType()
                        {
                            Kind = TsTypeKind.Array,
                            ArrayMemberType = m
                        // .ToList() to force evaluation before .AddRange is called.
                        }).ToList());
                    }
                }

                // Should be save to resolve here.
                newType = newType.Resolve(context);

                for (int i = 0; i < newType.TypeParameters.Count; ++i)
                {
                    newType.TypeParameters[i] = newType.TypeParameters[i].Resolve(context);
                }

                for (int i = 0; i < TypeParameters.Count; ++i)
                {
                    context.TypeParameters.Remove(realTypeInfo.Item1[i]);
                }
            }
        }
        else
        {
            newType = (TsType)Clone();
            newType.Name = realName;
            for (int i = 0; i < newType.TypeParameters.Count; ++i)
            {
                newType.TypeParameters[i] = newType.TypeParameters[i].Resolve(context);
            }
        }

        if (newType.Kind == TsTypeKind.Union)
        {
            newType.Flatten();

            while (true)
            {
                var didResolveSomething = false;
                for (int i = 0; i < newType.MemberTypes.Count; ++i)
                {
                    var oldMember = newType.MemberTypes[i];

                    var newMember = oldMember.Resolve(context);

                    newType.MemberTypes[i] = newMember;

                    if (newMember != oldMember)
                    {
                        didResolveSomething = true;
                    }
                }

                if (!didResolveSomething)
                {
                    break;
                }

                newType.Flatten();
            }
        }
        else if (newType.Kind == TsTypeKind.Array)
        {
            newType.ArrayMemberType = newType.ArrayMemberType!.Resolve(context);
        }
        else if (newType.Kind == TsTypeKind.StringList || newType.Kind == TsTypeKind.Range)
        {
            if (newType.Name != null)
            {
                newType.Kind = TsTypeKind.Normal;
                // To allow equality with normal types.
                newType.LastType = newType.FirstType = null;
            }
        }
        else if (newType.Kind == TsTypeKind.Normal)
        {
            newType.LastType = newType.FirstType = null;
        }

        return newType;
    }

    public void Flatten()
    {
        if (Kind != TsTypeKind.Union)
        {
            return;
        }

        var newMemberTypes = new List<TsType>();
        var alreadyAdded = new HashSet<TsType>();

        foreach (var t in MemberTypes)
        {
            if (t.Kind == TsTypeKind.Union)
            {
                t.Flatten();
                foreach (var subType in t.MemberTypes)
                {
                    if (!alreadyAdded.Contains(subType))
                    {
                        newMemberTypes.Add(subType);
                        alreadyAdded.Add(subType);
                    }
                }
            }
            else
            {
                if (!alreadyAdded.Contains(t))
                {
                    newMemberTypes.Add(t);
                    alreadyAdded.Add(t);
                }
            }
        }

        MemberTypes = newMemberTypes;
    }

    public TsType UnionWith(TsType other)
    {
        if (Kind == TsTypeKind.Union)
        {
            var newType = (TsType)Clone();
            newType.MemberTypes.Add(other);
            return newType;
        }
        else
        {
            return new TsType()
            {
                Kind = TsTypeKind.Union,
                MemberTypes = new List<TsType>() { (TsType)Clone(), other }
            };
        }
    }

    public bool IsCSharpPrimitive()
    {
        return new[] { "number", "boolean" }.Contains(Name);
    }

    public string ToString(Context context, bool appendIToInterface = true, bool forceReference = false)
    {
        var typeParamsMap = context.TypeParameters;

        var realName = Name;
        while (typeParamsMap.ContainsKey(realName))
        {
            realName = typeParamsMap[realName].ToString(context, appendIToInterface);
        }

        if (context.TypeAliases.TryGetValue(realName, out var aliases))
        {
            if (aliases.TryGetValue(TypeParameters.Count, out var realTypeInfo))
            {
                for (int i = 0; i < TypeParameters.Count; ++i)
                {
                    context.TypeParameters.Add(realTypeInfo.Item1[i], TypeParameters[i]);
                }

                var stringValue = realTypeInfo.Item2.ToString(context, appendIToInterface);

                for (int i = 0; i < TypeParameters.Count; ++i)
                {
                    context.TypeParameters.Remove(realTypeInfo.Item1[i]);
                }

                return stringValue;
            }
        }

        if (new[] { "Body", "InnerHTML" }.Contains(realName))
        {
            realName = "Has" + realName;
        }

        switch (Kind)
        {
            case TsTypeKind.Normal:
            case TsTypeKind.Range:
            case TsTypeKind.StringList:
            {
                if (forceReference && new[] { "number", "boolean" }.Contains(realName))
                {
                    switch (realName)
                    {
                        case "number":
                            return "JsNumber";
                        case "boolean":
                            return "JsBoolean";
                    }
                }
                return (appendIToInterface && context.MustBeInterface.Contains(realName) ? "I" : "") + realName.ToCSharpTypeName() + (!TypeParameters.Where(t => t.Name != "void").Any() ? "" : $"<{string.Join(", ", TypeParameters.Where(t => t.Name != "void").Select(t => t.Resolve(context).ToString(context, appendIToInterface, true)))}>");
            }
            case TsTypeKind.Union:
                return $"Union<{string.Join(", ", MemberTypes.Select(m => m.ToString(context, appendIToInterface)))}>";
            case TsTypeKind.Array:
                return $"JsArray<{ArrayMemberType?.ToString(context, appendIToInterface)}>";
            case TsTypeKind.Delegate:
            {
                if (new[] { "void", "undefined", "null" }.Contains(DelegateReturnType?.ToString(context, appendIToInterface)))
                {
                    if (DelegateParameters.Any())
                    {
                        return $"JsAction<{string.Join(", ", DelegateParameters.Select(t => t.ToString(context, appendIToInterface) + "?"))}>";
                    }
                    return "JsAction";
                }
                return $"JsFunc<{string.Join(", ", DelegateParameters.Concat(new[] { DelegateReturnType! }).Select(t => t.ToString(context, appendIToInterface) + "?"))}>";
            }
            case TsTypeKind.InlineType:
            {
                return context.InlineInterfaces[Name].Name.ToCSharpTypeName();
            }
            default:
                throw new InvalidOperationException();
        }
    }

    public bool EqualsIgnoreNullable(TsType? other)
    {
        if (other == null)
        {
            return false;
        }

        return Kind == other.Kind
            && Name == other.Name
            && MemberTypes.SequenceEqual(other.MemberTypes)
            && TypeParameters.SequenceEqual(other.TypeParameters)
            && DelegateParameters.SequenceEqual(other.DelegateParameters)
            && ArrayMemberType == other.ArrayMemberType
            && FirstType == other.FirstType
            && LastType == other.LastType;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not TsType type)
        {
            return false;
        }
        return this == type;
    }

    public override int GetHashCode()
    {
        int hashCode = Kind.GetHashCode();
        hashCode <<= 2;
        hashCode ^= Name.GetHashCode();
        hashCode <<= 4;
        hashCode ^= MemberTypes.Aggregate(0, (code, type) => (code << 5) ^ type.GetHashCode());
        hashCode ^= TypeParameters.Aggregate(0, (code, type) => (code << 6) ^ type.GetHashCode());
        hashCode ^= DelegateParameters.Aggregate(0, (code, type) => (code << 7) ^ type.GetHashCode());
        hashCode <<= 3;
        hashCode ^= DelegateReturnType?.GetHashCode() ?? 0;
        hashCode ^= ArrayMemberType?.GetHashCode() ?? 0;
        hashCode ^= IsNullable.GetHashCode();
        hashCode ^= (FirstType?.GetHashCode() ?? 0) << 16;
        hashCode ^= LastType?.GetHashCode() ?? 0;
        return hashCode;
    }

    public object Clone()
    {
        return new TsType()
        {
            Kind = Kind,
            Name = Name,
            MemberTypes = MemberTypes.Select(m => m.Clone()).Cast<TsType>().ToList(),
            TypeParameters = TypeParameters.Select(m => m.Clone()).Cast<TsType>().ToList(),
            DelegateParameters = DelegateParameters.Select(m => m.Clone()).Cast<TsType>().ToList(),
            DelegateParameterNames = new List<string>(DelegateParameterNames),
            DelegateReturnType = (TsType?)DelegateReturnType?.Clone(),
            ArrayMemberType = (TsType?)ArrayMemberType?.Clone(),
            IsNullable = IsNullable,
            FirstType = FirstType,
            LastType = LastType,
        };
    }

    public static bool operator==(TsType? left, TsType? right)
    {
        if (left is null)
        {
            return right is null;
        }
        else if (right is null)
        {
            return left is null;
        }

        return left.EqualsIgnoreNullable(right) && left.IsNullable == right.IsNullable;
    }

    public static bool operator!=(TsType? left, TsType? right)
    {
        return !(left == right);
    }
}
