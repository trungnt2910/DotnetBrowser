using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// Constructs an object type whose property keys are <typeparamref name="TKey"/> and whose property values are <typeparamref name="TValue"/>.
/// This utility can be used to map the properties of a type to another type.
/// </summary>
[JsObject]
public partial class Record<TKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TValue>: JsObject
{
    /// <summary>
    /// Gets a value for the specified key.
    /// </summary>
    /// <param name="index">The key.</param>
    /// <returns>The value for the specified key.</returns>
    public TValue? this[TKey index]
    {
        get => WebAssemblyRuntime<TValue>.ValueOrNullFromJs($"{_jsThis}[{ToJsObjectString(index)}]");
        set => WebAssemblyRuntime<TValue>.ValueOrNullFromJs($"{_jsThis}[{ToJsObjectString(index)}] = {ToJsObjectString(value)}");
    }
}
