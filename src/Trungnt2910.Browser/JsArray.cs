using System;
using System.Collections;
using System.Collections.Generic;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// The <see cref="JsArray"/> object, as with arrays in other programming languages, enables storing a collection of multiple items under a single variable name, and has members for performing common array operations.
/// </summary>
[JsObject]
[NumericProperty("length", "Length", "int", Comments = "Reflects the number of elements in an array.")]
[NumericMethod<bool, object>("includes", "Includes", Param1 = "searchElement", Comments = "Determines whether the calling array contains a value, returning <c>true</c> or <c>false</c> as appropriate.")]
[NumericMethod<bool, object, int>("includes", "Includes", Param1 = "searchElement", Param2 = "fromIndex", Comments = "Determines whether the calling array contains a value, returning <c>true</c> or <c>false</c> as appropriate.")]
[NumericMethod<int, object>("indexOf", "IndexOf", Param1 = "searchElement", Comments = "Returns the first (least) index at which a given element can be found in the calling array.")]
[NumericMethod<int, object, int>("indexOf", "IndexOf", Param1 = "searchElement", Param2 = "fromIndex", Comments = "Returns the first (least) index at which a given element can be found in the calling array.")]
[Method<JsObject, int>("at", "At", Param1 = "index", Comments = "Returns the array item at the given index. Accepts negative integers, which count back from the last item.")]
[NumericVarArgsMethod<int, object>("push", "Push", Comments = "Adds one or more elements to the end of an array, and returns the new <see cref=\"Length\"/> of the array.")]
[VarArgsMethod<JsArray, int, int, object>("splice", "Splice", Param1 = "start", Param2 = "deleteCount", Comments = "Adds and/or removes elements from an array.")]
public partial class JsArray : JsObject, IList<JsObject?>
{
    /// <inheritdoc/>
    public JsObject? this[int index] 
    {
        get
        {
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return this[index.ToString()];
        }
        set
        {
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            this[index.ToString()] = value;
        }
    }

    /// <inheritdoc/>
    public int Count => Length!.Value;

    /// <inheritdoc/>
    public bool IsReadOnly => false;

    /// <inheritdoc/>
    public void Add(JsObject? item)
    {
        Push(item);
    }

    /// <inheritdoc/>
    public void Clear()
    {
        Splice(0, (int)Length!);
    }

    /// <inheritdoc/>
    public bool Contains(JsObject? item)
    {
        return (bool)Includes(item)!;
    }

    /// <inheritdoc/>
    public void CopyTo(JsObject?[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);
        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }
        if (Count > array.Length - arrayIndex)
        {
            throw new ArgumentException("The number of elements in the source is greater than the available space in the destination array.", nameof(array));
        }
        for (int i = 0; i < Count; ++i)
        {
            array[i + arrayIndex] = this[i];
        }
    }

    /// <inheritdoc/>
    public IEnumerator<JsObject?> GetEnumerator()
    {
        for (int i = 0; i < Count; ++i)
        {
            yield return this[i];
        }
    }

    /// <inheritdoc/>
    public int IndexOf(JsObject? item)
    {
        return (int)IndexOf((object?)item)!;
    }

    /// <inheritdoc/>
    public void Insert(int index, JsObject? item)
    {
        Splice(index, 0, item);
    }
    
    /// <inheritdoc/>
    public bool Remove(JsObject? item)
    {
        var index = IndexOf((object?)item);
        if (index == -1)
        {
            return false;
        }
        Splice(index, 1);
        return true;
    }

    /// <inheritdoc/>
    public void RemoveAt(int index)
    {
        Splice(index, 1);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}