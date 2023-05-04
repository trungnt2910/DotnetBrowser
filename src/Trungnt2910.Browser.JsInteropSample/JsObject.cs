using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
    /// Returns the result of a JavaScript expression, or <see langword="null"/> if the result is <c>null</c>.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>The result.</returns>
    /// <remarks>This method exists for code generators only. Do not call it directly. Use <see cref="FromExpression"/> instead to create a <see cref="JsObject"/>.</remarks>
    [JSImport($"globalThis.window.eval")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected static partial int? __Int32OrNullFromJs(string js);

    /// <summary>
    /// Creates a <see cref="JsObject"/> from a raw JavaScript expression.
    /// </summary>
    /// <param name="jsExpression">The JavaScript expression as a <see langword="string"/>.</param>
    /// <returns>A <see cref="JsObject"/> representing the expression's result, or <see langword="null"/> if the expression evaluates to <c>null</c> or <c>undefined</c>.</returns>
    public static JsObject? FromExpression(string jsExpression)
    {
        // TODO: Which one is faster? This?
        var objectHandle = __Int32OrNullFromJs($"{_jsType}.CreateHandle({jsExpression})");
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
                return $"\"{EscapeJs(obj.ToString()!)}\"";
                // For the default case, System.Text.Json used to be used,
                // but it's now removed to make this library linker-friendly.
        }
    }

    /// <summary>
    /// The handle to the underlying JavaScript instance.
    /// </summary>
    public IntPtr Handle => (IntPtr)_jsHandle;

    [JSImport($"globalThis.{_jsType}.{nameof(GetJsType)}")]
    private static partial string GetJsType(int index);

    /// <summary>
    /// Gets the underlying JavaScript object's type, using the JavaScript <c>typeof</c> keyword.
    /// </summary>
    /// <returns>The underlying JavaScript object's type.</returns>
    public string GetJsType()
    {
        return _type ??= GetJsType(_jsHandle);
    }

    [JSImport($"globalThis.{_jsType}.{nameof(ToString)}")]
    private static partial string ToString(int index);

    /// <summary>
    /// Returns this object as a C# string.
    /// If the object is not a JavaScript string, returns the object's JSON representation.
    /// </summary>
    /// <returns>A string value.</returns>
    public override string ToString()
    {
        return ToString(_jsHandle);
    }

    [JSImport($"globalThis.{_jsType}.{nameof(ToStringRaw)}")]
    private static partial string ToStringRaw(int index);

    private string ToStringRaw()
    {
        return ToStringRaw(_jsHandle);
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
        __Int32OrNullFromJs(Encoding.UTF8.GetString(data));
    }
}
