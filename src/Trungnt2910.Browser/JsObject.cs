﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
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
    internal readonly int _jsHandle;

    internal JsObject(int handle)
    {
        _jsHandle = handle;
        IncrementReferenceCount(handle);
        _jsThis = $"{_jsType}.ReferencedObjects[{_jsHandle}]";
    }

    /// <summary>
    /// Constructs a <see cref="JsObject"/> from a JavaScript handle.
    /// </summary>
    /// <param name="handle">The JavaScript handle</param>
    [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    protected JsObject(IntPtr handle) : this((int)handle) { }

    [JSImport($"globalThis.{_jsType}.{nameof(IncrementReferenceCount)}")]
    internal static partial void IncrementReferenceCount(int index);

    [JSImport($"globalThis.{_jsType}.{nameof(DecrementReferenceCount)}")]
    internal static partial void DecrementReferenceCount(int index);

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
        var objectHandle = WebAssemblyRuntime.Int32OrNullFromJs($"{_jsType}.CreateHandle({jsExpression})");
        // or this?
        // using var systemObj = WebAssemblyRuntime.ObjectOrNullFromJs(jsExpression);
        // var objectHandle = CreateHandle(systemObj);
        // Currently we're choosing the first method. The second method pollutes the JavaScript object with a
        // custom handle property, even after the managed object is disposed.
        if (objectHandle == null)
        {
            return null;
        }
        return FromHandle(objectHandle.Value);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static JsObject FromHandle(int objectHandle)
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

    /// <summary>
    /// Returns a <see cref="JsObject"/> from a JavaScript handle.
    /// </summary>
    /// <param name="objectHandle">The JavaScript handle.</param>
    /// <returns>A <see cref="JsObject"/> or <see langword="null"/> if the handle is invalid.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static JsObject FromHandle(IntPtr objectHandle) => FromHandle((int)objectHandle);

    /// <summary>
    /// Returns the equivalent JavaScript representation of an object.
    /// </summary>
    /// <param name="obj">The managed object.</param>
    /// <returns>The JavaScript representation.</returns>
    /// <remarks>This method exists for code generators only. Do not use this method directly.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string ToJsObjectString(object? obj)
    {
        switch (obj)
        {
            case null:
                return "null";
            case bool:
                // Special case for booleans:
                // The default C# converter converts a `true` value to `"True"` and `false` value to `"False"`,
                // but JavaScript uses `"true"` and `"false"` (without a capital letter).
                return (bool)obj ? "true" : "false";
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
            case SystemJSObject systemJSObject:
                return FromSystemJSObject(systemJSObject)?._jsThis ?? "null";
            case string:
            case char:
            default:
                return $"\"{WebAssemblyRuntime.EscapeJs(obj.ToString()!)}\"";
                // For the default case, System.Text.Json used to be used,
                // but it's now removed to make this library linker-friendly.
        }
    }

    /// <summary>
    /// The handle to the underlying JavaScript instance.
    /// </summary>
    public IntPtr Handle => (IntPtr)_jsHandle;

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
        var argsStringList = args?.Select(ToJsObjectString);
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
    public T Cast<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>() where T : JsObject
    {
        var fromHandle = typeof(T).GetMethod(nameof(FromHandle), BindingFlags.Static | BindingFlags.Public);
        return (T)fromHandle!.Invoke(null, new object[] { (IntPtr)_jsHandle })!;
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
        return WebAssemblyRuntime.BooleanFromJs($"({_jsThis}) ? true : false");
    }

    /// <inheritdoc/>
    public byte ToByte(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return byte.Parse(ToStringRaw(), provider);
            case "number":
                return WebAssemblyRuntime.ByteFromJs(_jsThis);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Byte.");
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
                return (char)ToInt32(provider);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Char.");
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
                return DateTimeOffset.FromUnixTimeMilliseconds((long)ToDouble(provider)).DateTime;
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to DateTime.");
        }
    }

    /// <inheritdoc/>
    public decimal ToDecimal(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return decimal.Parse(ToStringRaw(), provider);
            case "number":
                return WebAssemblyRuntime.DecimalFromJs(_jsThis);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Decimal.");
        }
    }

    /// <inheritdoc/>
    public double ToDouble(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return double.Parse(ToStringRaw(), provider);
            case "number":
                return WebAssemblyRuntime.DoubleFromJs(_jsThis);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Double.");
        }
    }

    /// <inheritdoc/>
    public short ToInt16(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return short.Parse(ToStringRaw(), provider);
            case "number":
                return WebAssemblyRuntime.Int16FromJs(_jsThis);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Int16.");
        }
    }

    /// <inheritdoc/>
    public int ToInt32(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return int.Parse(ToStringRaw(), provider);
            case "number":
                return WebAssemblyRuntime.Int32FromJs(_jsThis);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Int32.");
        }
    }

    /// <inheritdoc/>
    public long ToInt64(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return long.Parse(ToStringRaw(), provider);
            case "number":
                return WebAssemblyRuntime.Int64FromJs(_jsThis);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Int64.");
        }
    }

    /// <inheritdoc/>
    public sbyte ToSByte(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return sbyte.Parse(ToStringRaw(), provider);
            case "number":
                return WebAssemblyRuntime.SByteFromJs(_jsThis);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to SByte.");
        }
    }

    /// <inheritdoc/>
    public float ToSingle(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return float.Parse(ToStringRaw(), provider);
            case "number":
                return WebAssemblyRuntime.SingleFromJs(_jsThis);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Single.");
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
        switch (Type.GetTypeCode(conversionType))
        {
            case TypeCode.Boolean:
                return ToBoolean(provider);
            case TypeCode.Byte:
                return ToByte(provider);
            case TypeCode.Char:
                return ToChar(provider);
            case TypeCode.DateTime:
                return ToDateTime(provider);
            case TypeCode.Decimal:
                return ToDecimal(provider);
            case TypeCode.Double:
                return ToDouble(provider);
            case TypeCode.Int16:
                return ToInt16(provider);
            case TypeCode.Int32:
                return ToInt32(provider);
            case TypeCode.Int64:
                return ToInt64(provider);
            case TypeCode.Object:
                return this;
            case TypeCode.SByte:
                return ToSByte(provider);
            case TypeCode.Single:
                return ToSingle(provider);
            case TypeCode.String:
                return ToString(provider);
            case TypeCode.UInt16:
                return ToUInt16(provider);
            case TypeCode.UInt32:
                return ToUInt32(provider);
            case TypeCode.UInt64:
                return ToUInt64(provider);
            default:
                throw new InvalidCastException($"Conversion from JsObject to {conversionType} is not supported.");
        }
    }

    /// <inheritdoc/>
    public ushort ToUInt16(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return ushort.Parse(ToStringRaw(), provider);
            case "number":
                return WebAssemblyRuntime.UInt16FromJs(_jsThis);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to UInt16.");
        }
    }

    /// <inheritdoc/>
    public uint ToUInt32(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return uint.Parse(ToStringRaw(), provider);
            case "number":
                return WebAssemblyRuntime.UInt32FromJs(_jsThis);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to UInt32.");
        }
    }

    /// <inheritdoc/>
    public ulong ToUInt64(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return ulong.Parse(ToStringRaw(), provider);
            case "number":
                return WebAssemblyRuntime.UInt64FromJs(_jsThis);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to UInt64.");
        }
    }
    #endregion

    #region Conversion from primitives
    [JSImport($"globalThis.{_jsType}.{nameof(CreateHandle)}")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    private static partial int CreateHandle(short number);

    [JSImport($"globalThis.{_jsType}.{nameof(CreateHandle)}")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    private static partial int CreateHandle(int number);

    [JSImport($"globalThis.{_jsType}.{nameof(CreateHandle)}")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    private static partial int CreateHandle(byte number);

    [JSImport($"globalThis.{_jsType}.{nameof(CreateHandle)}")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    private static partial int CreateHandle(float number);

    [JSImport($"globalThis.{_jsType}.{nameof(CreateHandle)}")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    private static partial int CreateHandle(double number);

    [JSImport($"globalThis.{_jsType}.{nameof(CreateHandle)}")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    private static partial int CreateHandle(string str);

    /// <summary>
    /// Implicitly converts this <see langword="short"/> value to a <see cref="JsObject"/>.
    /// </summary>
    /// <param name="number">The value.</param>
    [return:NotNullIfNotNull(nameof(number))]
    public static implicit operator JsObject?(short? number)
    {
        if (number == null)
        {
            return null;
        }

        return FromHandle(CreateHandle((short)number));
    }

    /// <summary>
    /// Implicitly converts this <see langword="int"/> value to a <see cref="JsObject"/>.
    /// </summary>
    /// <param name="number">The value.</param>
    [return: NotNullIfNotNull(nameof(number))]
    public static implicit operator JsObject?(int? number)
    {
        if (number == null)
        {
            return null;
        }

        return FromHandle(CreateHandle((int)number));
    }

    /// <summary>
    /// Implicitly converts this <see langword="byte"/> value to a <see cref="JsObject"/>.
    /// </summary>
    /// <param name="number">The value.</param>
    [return: NotNullIfNotNull(nameof(number))]
    public static implicit operator JsObject?(byte? number)
    {
        if (number == null)
        {
            return null;
        }

        return FromHandle(CreateHandle((byte)number));
    }

    /// <summary>
    /// Implicitly converts this <see langword="float"/> value to a <see cref="JsObject"/>.
    /// </summary>
    /// <param name="number">The value.</param>
    [return: NotNullIfNotNull(nameof(number))]
    public static implicit operator JsObject?(float? number)
    {
        if (number == null)
        {
            return null;
        }

        return FromHandle(CreateHandle((float)number));
    }

    /// <summary>
    /// Implicitly converts this <see langword="double"/> value to a <see cref="JsObject"/>.
    /// </summary>
    /// <param name="number">The value.</param>
    [return: NotNullIfNotNull(nameof(number))]
    public static implicit operator JsObject?(double? number)
    {
        if (number == null)
        {
            return null;
        }

        return FromHandle(CreateHandle((double)number));
    }

    /// <summary>
    /// Implicitly converts this <see langword="string"/> value to a <see cref="JsObject"/>.
    /// </summary>
    /// <param name="number">The number.</param>
    [return: NotNullIfNotNull(nameof(number))]
    public static implicit operator JsObject?(string? number)
    {
        if (number == null)
        {
            return null;
        }

        return FromHandle(CreateHandle((string)number));
    }
    #endregion

    #region Equality
    /// <summary>
    /// Compares two JavaScript objects for reference equality.
    /// </summary>
    /// <param name="left">The first object.</param>
    /// <param name="right">The second object.</param>
    /// <returns><see langword="true"/> if the two objects refers to the same underlying JavaScript object.</returns>
    public static bool operator ==(JsObject? left, JsObject? right)
    {
        return left?._jsHandle == right?._jsHandle;
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
        return _jsHandle;
    }
    #endregion

    /// <summary>
    /// Finalizes the current managed object. This includes
    /// decrementing the JavaScript object reference count.
    /// </summary>
    ~JsObject()
    {
        if (_objectCache.TryGetValue(_jsHandle, out var reference) && 
            reference.TryGetTarget(out JsObject? obj) && 
            ReferenceEquals(obj, this))
        {
            _objectCache.Remove(_jsHandle);
        }
        DecrementReferenceCount(_jsHandle);
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
