using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
using SystemJSObject = System.Runtime.InteropServices.JavaScript.JSObject;

namespace Trungnt2910.Browser;

/// <summary>
/// The base class of all marshalled JavaScript objects.
/// Unlike <see cref="SystemJSObject"/>, this class is built with strong typing support in mind.
/// </summary>
public partial class JsObject : IConvertible
{
    private const string _jsType = "Trungnt2910.Browser.JsObject";
    private static readonly Dictionary<int, WeakReference<JsObject>> _objectCache = new();

    private string? _type;
    internal readonly string _jsThis;

    /// <summary>
    /// The JavaScript handle of this object.
    /// </summary>
    protected readonly int JsHandle;

    /// <summary>
    /// Constructs a <see cref="JsObject"/> from a JavaScript handle.
    /// </summary>
    /// <param name="handle">The JavaScript handle</param>
    /// <remarks>
    /// This constructor is for internal purposes only. The preferred way of getting
    /// an object from a handle is <see cref="FromHandle(int)"/>
    /// </remarks>
    protected JsObject(int handle)
    {
        JsHandle = handle;
        IncrementReferenceCount(handle);
        _jsThis = $"{_jsType}.ReferencedObjects[{JsHandle}]";
    }

    [JSImport($"globalThis.{_jsType}.{nameof(IncrementReferenceCount)}")]
    private static partial void IncrementReferenceCount(int index);

    [JSImport($"globalThis.{_jsType}.{nameof(DecrementReferenceCount)}")]
    private static partial void DecrementReferenceCount(int index);

    /// <summary>
    /// Creates an internal handle for <paramref name="jsObject"/>.
    /// </summary>
    /// <param name="jsObject">The JavaScript object.</param>
    /// <returns>A handle for the object, or <see langword="null"/> if the object is null or undefined.</returns>
    /// <remarks>This method exists for code generators only. Do not call it directly. Use <see cref="FromSystemJSObject"/> or <see cref="FromExpression"/> instead to create a <see cref="JsObject"/>.</remarks>
    [JSImport($"globalThis.{_jsType}.{nameof(CreateHandle)}")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static partial int? CreateHandle(SystemJSObject? jsObject);

    /// <summary>
    /// Creates a <see cref="JsObject"/> from a <see cref="SystemJSObject"/>.
    /// </summary>
    /// <param name="obj">The <see cref="SystemJSObject"/>.</param>
    /// <returns>A <see cref="JsObject"/> representing an equivalent object, or <see langword="null"/> if the passed object is invalid.</returns>
    public static JsObject? FromSystemJSObject(SystemJSObject obj)
    {
        if (obj.IsDisposed)
        {
            return null;
        }
        var objectHandle = CreateHandle(obj);
        if (objectHandle == null)
        {
            return null;
        }
        return FromHandle(objectHandle.Value);
    }

    /// <summary>
    /// Creates a <see cref="JsObject"/> from a raw JavaScript expression.
    /// </summary>
    /// <param name="jsExpression">The JavaScript expression as a <see langword="string"/>.</param>
    /// <returns>A <see cref="JsObject"/> representing the expression's result, or <see langword="null"/> if the expression evaluates to <c>null</c> or <c>undefined</c>.</returns>
    public static JsObject? FromExpression(string jsExpression)
    {
        // TODO: Which one is faster? This?
        // WebAssemblyRuntime.InvokeJS($"{_jsType}.ConstructObject({jsExpression})");
        // or this?
        var objectHandle = CreateHandle(WebAssemblyRuntime.ObjectOrNullFromJs(jsExpression));
        if (objectHandle == null)
        {
            return null;
        }
        return FromHandle(objectHandle.Value);
    }

    /// <summary>
    /// Returns a <see cref="JsObject"/> from a JavaScript handle.
    /// </summary>
    /// <param name="objectHandle">The JavaScript handle.</param>
    /// <returns>A <see cref="JsObject"/> or <see langword="null"/> if the handle is invalid.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static JsObject FromHandle(int objectHandle)
    {
        JsObject? obj;
        if (_objectCache.TryGetValue(objectHandle, out WeakReference<JsObject>? weakReference))
        {
            if (_objectCache[objectHandle].TryGetTarget(out obj))
            {
                return obj;
            }
            obj = new JsObject(objectHandle);
            weakReference.SetTarget(obj);
            return obj;
        }
        obj = new JsObject(objectHandle);
        _objectCache.Add(objectHandle, new WeakReference<JsObject>(obj));
        return obj;
    }

    internal static string ToJsObjectString(object? obj)
    {
        switch (obj)
        {
            case null:
                return "null";
            case string:
            case char:
                return $"\"{WebAssemblyRuntime.EscapeJs(obj.ToString()!)}\"";
            case sbyte:
            case byte:
            case short:
            case ushort:
            case int:
            case uint:
            case long:
            case ulong:
            case float:
            case double:
            case decimal:
                return obj.ToString()!;
            case JsObject jsObj:
                return jsObj._jsThis;
            default:
                return JsonSerializer.Serialize(obj);
        }
    }

    /// <summary>
    /// Gets or sets a member of the current object.
    /// </summary>
    /// <param name="index">The member name</param>
    /// <returns>A <see cref="JsObject"/> representing the corresponding JavaScript member, or <see langword="null"/> if the member is equal to <c>null</c> or <c>undefined</c>.</returns>
    /// <remarks>
    /// This function should only be used when strongly-typed C# bindings are not available yet.
    /// </remarks>
    public JsObject? this[string index]
    {
        get => FromExpression($"{_jsThis}[\"{WebAssemblyRuntime.EscapeJs(index)}\"]");
        set => WebAssemblyRuntime.InvokeJS($"{_jsThis}[\"{WebAssemblyRuntime.EscapeJs(index)}\"] = {value?._jsThis ?? "null"}");
    }

    /// <summary>
    /// Invokes the current object as a JavaScript function.
    /// </summary>
    /// <param name="args">The function's arguments.</param>
    /// <returns>A <see cref="JsObject"/> representing the function's result, or <see langword="null"/> if the function evaluates to <c>null</c> or <c>undefined</c>.</returns>
    public JsObject? Invoke(params object?[]? args)
    {
        var argsStringList = args?.Select(a => ToJsObjectString(a));
        return FromExpression($"{_jsThis}({string.Join(",", argsStringList ?? Array.Empty<string>())})");
    }

    /// <summary>
    /// Invokes a member of the current object as a JavaScript function.
    /// </summary>
    /// <param name="index">The function's name.</param>
    /// <param name="args">The function's arguments.</param>
    /// <returns>A <see cref="JsObject"/> representing the function's result, or <see langword="null"/> if the function evaluates to <c>null</c> or <c>undefined</c>.</returns>
    public JsObject? InvokeMember(string index, params object?[]? args)
    {
        var argsStringList = args?.Select(a => ToJsObjectString(a));
        return FromExpression($"{_jsThis}[\"{WebAssemblyRuntime.EscapeJs(index)}\"]({string.Join(",", argsStringList ?? Array.Empty<string>())})");
    }

    /// <summary>
    /// Sets the value of the current object's JavaScript property to something other than a <see cref="JsObject"/>
    /// </summary>
    /// <param name="index">The property's name.</param>
    /// <param name="value">The new value.</param>
    /// <remarks>
    /// <see cref="this[string]"/> is preferred the value is a <see cref="JsObject"/>.
    /// </remarks>
    public void SetValue(string index, object value)
    {
        WebAssemblyRuntime.InvokeJS($"{_jsThis}[\"{WebAssemblyRuntime.EscapeJs(index)}\"] = {ToJsObjectString(value)}");
    }

    /// <summary>
    /// Gets the underlying JavaScript object's type, using the JavaScript <c>typeof</c> keyword.
    /// </summary>
    /// <returns>The underlying JavaScript object's type.</returns>
    public string GetJsType()
    {
        return _type ??= WebAssemblyRuntime.StringFromJs($"typeof {_jsThis}");
    }

    /// <summary>
    /// Returns this object as a C# string.
    /// If the object is not a JavaScript string, returns the object's JSON representation.
    /// </summary>
    /// <returns>A string value.</returns>
    public override string ToString()
    {
        if (GetJsType() == "string")
        {
            return WebAssemblyRuntime.StringFromJs(_jsThis);
        }
        return WebAssemblyRuntime.StringFromJs($"JSON.stringify({_jsThis})");
    }

    private string ToStringRaw()
    {
        return WebAssemblyRuntime.StringFromJs(_jsThis);
    }

    /// <summary>
    /// Cast this object to another <see cref="JsObject"/>-derived type.
    /// </summary>
    /// <typeparam name="T">Any type that derives from <see cref="JsObject"/>.</typeparam>
    /// <returns>A value of type <typeparamref name="T"/> that represents the same JavaScript object.</returns>
    public T Cast<T>() where T : JsObject
    {
        var fromHandle = typeof(T).GetMethod(nameof(FromHandle), BindingFlags.Static | BindingFlags.Public);
        return (T)fromHandle!.Invoke(null, new object[] { JsHandle })!;
    }

    /// <summary>
    /// Converts a <see cref="JsObject"/> to a <see cref="SystemJSObject"/>
    /// </summary>
    /// <param name="obj">The <see cref="JsObject"/>.</param>
    public static implicit operator SystemJSObject(JsObject obj)
    {
        return JSHost.GlobalThis.GetPropertyAsJSObject(obj._jsThis)!;
    }

    #region IConvertible
    /// <inheritdoc/>
    public TypeCode GetTypeCode()
    {
        switch (GetJsType())
        {
            case "string":
                return TypeCode.String;
            case "number":
                return TypeCode.Double;
            case "boolean":
                return TypeCode.Boolean;
            default:
                return TypeCode.Object;
        }
    }

    /// <inheritdoc/>
    public bool ToBoolean(IFormatProvider? provider)
    {
        return WebAssemblyRuntime.BoolFromJs($"({_jsThis}) ? true : false");
    }

    /// <inheritdoc/>
    public byte ToByte(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return byte.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    /// <inheritdoc/>
    public char ToChar(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return ToStringRaw()[0];
            case "number":
                return (char)int.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    /// <inheritdoc/>
    public DateTime ToDateTime(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return DateTime.Parse(ToStringRaw(), provider);
            case "number":
                return DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(ToStringRaw())).DateTime;
            default:
                throw new NotSupportedException();
        }
    }

    /// <inheritdoc/>
    public decimal ToDecimal(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return decimal.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    /// <inheritdoc/>
    public double ToDouble(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return double.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    /// <inheritdoc/>
    public short ToInt16(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return short.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    /// <inheritdoc/>
    public int ToInt32(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return int.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    /// <inheritdoc/>
    public long ToInt64(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return long.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    /// <inheritdoc/>
    public sbyte ToSByte(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return sbyte.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    /// <inheritdoc/>
    public float ToSingle(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return float.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    /// <inheritdoc/>
    public string ToString(IFormatProvider? provider)
    {
        return ToString();
    }

    /// <inheritdoc/>
    public object ToType(Type conversionType, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public ushort ToUInt16(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return ushort.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    /// <inheritdoc/>
    public uint ToUInt32(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return uint.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    /// <inheritdoc/>
    public ulong ToUInt64(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return ulong.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }
    #endregion

    /// <summary>
    /// Compares two JavaScript objects for reference equality.
    /// </summary>
    /// <param name="left">The first object.</param>
    /// <param name="right">The second object.</param>
    /// <returns><see langword="true"/> if the two objects refers to the same underlying JavaScript object.</returns>
    public static bool operator ==(JsObject? left, JsObject? right)
    {
        return left?.JsHandle == right?.JsHandle;
    }

    /// <summary>
    /// Checks if the two <see cref="JsObject"/> refers to different underlying JavaScript objects.
    /// </summary>
    /// <param name="left">The first object.</param>
    /// <param name="right">The second object.</param>
    /// <returns>The result of the comparision.</returns>
    public static bool operator !=(JsObject? left, JsObject? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Checks if the current <see cref="JsObject"/> is equal to <paramref name="obj"/>.
    /// </summary>
    /// <param name="obj">Any object.</param>
    /// <returns><see langword="true"/> if <paramref name="obj"/> is an equivalent <see cref="JsObject"/> or <see cref="SystemJSObject"/>.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is JsObject jsObject)
        {
            return this == jsObject;
        }
        else if (obj is SystemJSObject systemJSObject)
        {
            return this == FromSystemJSObject(systemJSObject);
        }
        return false;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return JsHandle;
    }

    /// <summary>
    /// Finalizes the current managed object. This includes
    /// decrementing the JavaScript object reference count.
    /// </summary>
    ~JsObject()
    {
        if (_objectCache.TryGetValue(JsHandle, out var reference) && 
            reference.TryGetTarget(out JsObject? obj) && 
            ReferenceEquals(obj, this))
        {
            _objectCache.Remove(JsHandle);
        }
        DecrementReferenceCount(JsHandle);
    }

    [SuppressMessage("Usage", "CA2255:The 'ModuleInitializer' attribute should not be used in libraries", Justification = "The JS code needs to be initialized early before any type loads.")]
    [ModuleInitializer]
    internal static void InitializeJavaScript()
    {
        using var resourceStream = Assembly.GetExecutingAssembly()
            .GetManifestResourceStream(typeof(JsObject).FullName! + ".js")!;

        var data = new byte[resourceStream.Length];
        resourceStream.ReadExactly(data.AsSpan());

        // We are declaring a few public classes so we want to explicitly use window.eval
        // to make sure the JS runs in global scope.
        WebAssemblyRuntime.InvokeJS($"window.eval(\"{WebAssemblyRuntime.EscapeJs(Encoding.UTF8.GetString(data))}\")");
    }
}
