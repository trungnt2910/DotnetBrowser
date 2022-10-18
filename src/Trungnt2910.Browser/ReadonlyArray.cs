using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// The <see cref="ReadonlyArray{T}"/> type describes <see cref="JsArray{T}"/>s that can only be read from.
/// Any variable with a reference to a <see cref="ReadonlyArray{T}"/> can't add, remove, or replace any elements of the array.
/// </summary>
/// <typeparam name="T">The array's member type.</typeparam>
[JsObject]
[NumericProperty("length", "Length", "int", Comments = "Reflects the number of elements in an array.")]
public partial class ReadonlyArray<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T> : JsObject, IReadOnlyList<T?>
{
    /// <inheritdoc/>
    public T? this[int index] => WebAssemblyRuntime<T>.ValueOrNullFromJs($"{_jsThis}[{index}]");

    /// <inheritdoc/>
    public int Count => (int)Length!;

    /// <inheritdoc/>
    public IEnumerator<T?> GetEnumerator()
    {
        for (int i = 0; i < Count; ++i)
        {
            yield return this[i];
        }
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
