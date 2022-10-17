using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// The <see cref="JsArray{T}"/> object, as with arrays in other programming languages, enables storing a collection of multiple items under a single variable name, and has members for performing common array operations.
/// </summary>
/// <typeparam name="T">The array's element type. Must be a type that inherits from <see cref="JsObject"/>.</typeparam>
[JsObject]
[NumericProperty("length", "Length", "int", Comments = "Reflects the number of elements in an array.")]
//[NumericMethod<bool, T>("includes", "Includes", Param1 = "searchElement", Comments = "Determines whether the calling array contains a value, returning <c>true</c> or <c>false</c> as appropriate.")]
//[NumericMethod<bool, T, int>("includes", "Includes", Param1 = "searchElement", Param2 = "fromIndex", Comments = "Determines whether the calling array contains a value, returning <c>true</c> or <c>false</c> as appropriate.")]
//[NumericMethod<int, T>("indexOf", "IndexOf", Param1 = "searchElement", Comments = "Returns the first (least) index at which a given element can be found in the calling array.")]
//[NumericMethod<int, T, int>("indexOf", "IndexOf", Param1 = "searchElement", Param2 = "fromIndex", Comments = "Returns the first (least) index at which a given element can be found in the calling array.")]
[Method<JsObject, int>("at", "At", Param1 = "index", Comments = "Returns the array item at the given index. Accepts negative integers, which count back from the last item.")]
//[NumericVarArgsMethod<int, T>("push", "Push", Comments = "Adds one or more elements to the end of an array, and returns the new <see cref=\"Length\"/> of the array.")]
//[VarArgsMethod<JsArray, int, int, T>("splice", "Splice", Param1 = "start", Param2 = "deleteCount", Comments = "Adds and/or removes elements from an array.")]
public partial class JsArray<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T> : JsObject, IList<T?>
{
    // C# does not support using generic parameters to instantiate attributes.
    // For this class only, some methods have to be manually written.

    private static readonly MethodInfo _converterMethod;
    private static readonly bool _isParse;

    static JsArray()
    {
        var fromExpression = typeof(T).GetMethod(nameof(FromExpression), BindingFlags.Static | BindingFlags.Public);
        if (fromExpression != null)
        {
            _converterMethod = fromExpression;
            _isParse = false;
            return;
        }
        var parse = typeof(T).GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, new[] { typeof(string), typeof(T).MakeByRefType() } );
        if (parse != null)
        {
            _converterMethod = parse;
            _isParse = true;
            return;
        }
        throw new NotSupportedException($"Attempted to create a JsArray of an unsupported type {typeof(T).FullName}.");
    }

    /// <inheritdoc/>
    public T? this[int index]
    {
        get
        {
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (_isParse)
            {
                var parameters = new object?[] { WebAssemblyRuntime.InvokeJS($"{_jsThis}[{index}]"), null };
                var result = (bool)_converterMethod!.Invoke(null, parameters)!;
                if (result)
                {
                    return (T?)parameters[1];
                }
                return default;
            }
            else
            {
                return (T?)_converterMethod!.Invoke(null, new object[] { $"{_jsThis}[{index}]" })!;
            }
        }
        set
        {
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            WebAssemblyRuntime.InvokeJS($"{_jsThis}[{index}] = {ToJsObjectString(value) ?? "null"}");
        }
    }

    /// <inheritdoc/>
    public int Count => Length!.Value;

    /// <inheritdoc/>
    public bool IsReadOnly => false;

    /// <inheritdoc/>
    public void Add(T? item)
    {
        Push(item);
    }

    /// <inheritdoc/>
    public void Clear()
    {
        Splice(0, (int)Length!);
    }

    /// <inheritdoc/>
    public bool Contains(T? item)
    {
        return (bool)Includes(item)!;
    }

    /// <inheritdoc/>
    public void CopyTo(T?[] array, int arrayIndex)
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
    public IEnumerator<T?> GetEnumerator()
    {
        for (int i = 0; i < Count; ++i)
        {
            yield return this[i];
        }
    }

    /// <summary>
    /// Returns the first (least) index at which a given element can be found in the calling array.
    /// </summary>
    public int IndexOf(T? searchElement) => WebAssemblyRuntime.Int32FromJs($"{_jsThis}.indexOf({ToJsObjectString(searchElement)})");

    /// <inheritdoc/>
    public void Insert(int index, T? item)
    {
        Splice(index, 0, item);
    }

    /// <inheritdoc/>
    public bool Remove(T? item)
    {
        var index = IndexOf(item);
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

    #region Methods that should have been generated.
    /// <summary>
    /// Determines whether the calling array contains a value, returning <c>true</c> or <c>false</c> as appropriate.
    /// </summary>
    public bool? Includes(T? searchElement) => WebAssemblyRuntime.BooleanOrNullFromJs($"{_jsThis}.includes({ToJsObjectString(searchElement)})");

    /// <summary>
    /// Adds one or more elements to the end of an array, and returns the new <see cref = "Length"/> of the array.
    /// </summary>
    public int? Push(params T?[]? args) => WebAssemblyRuntime.Int32OrNullFromJs($"{_jsThis}.push({string.Join(",", args?.Select(arg => ToJsObjectString(arg)) ?? Array.Empty<string>())})");

    /// <summary>
    /// Adds and/or removes elements from an array.
    /// </summary>
    public JsArray<T>? Splice(int? start, int? deleteCount, params T?[]? args) => JsArray<T>.FromExpression($"{_jsThis}.splice({ToJsObjectString(start)}, {ToJsObjectString(deleteCount)}, {string.Join(",", args?.Select(arg => ToJsObjectString(arg)) ?? Array.Empty<string>())})");
    #endregion

}
