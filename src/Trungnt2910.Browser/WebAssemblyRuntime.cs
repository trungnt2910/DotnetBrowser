using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// Methods used by source generators for JavaScript interop. Do not use them directly.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[WebAssemblyRuntimeMember("String", "string")]
[WebAssemblyRuntimeMember("Boolean", "bool")]
[WebAssemblyRuntimeMember("SByte", "sbyte")]
[WebAssemblyRuntimeMember("Int16", "short")]
[WebAssemblyRuntimeMember("Int32", "int")]
[WebAssemblyRuntimeMember("Int64", "long")]
[WebAssemblyRuntimeMember("Byte", "byte")]
[WebAssemblyRuntimeMember("UInt16", "ushort")]
[WebAssemblyRuntimeMember("UInt32", "uint")]
[WebAssemblyRuntimeMember("UInt64", "ulong")]
[WebAssemblyRuntimeMember("Single", "float")]
[WebAssemblyRuntimeMember("Double", "double")]
[WebAssemblyRuntimeMember("Decimal", "decimal")]
public static partial class WebAssemblyRuntime
{
    /// <summary>
    /// Escapes a string for use with JavaScript.
    /// </summary>
    /// <param name="s">The string to escape.</param>
    /// <returns>An escaped string that can be used in JavaScript string literals.</returns>
    [Pure]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string EscapeJs(string s)
    {
        if (s == null)
        {
            return "";
        }

        bool NeedsEscape(string s2)
        {
            for (int i = 0; i < s2.Length; i++)
            {
                var c = s2[i];

                if (
                    c > 255
                    || c < 32
                    || c == '\\'
                    || c == '"'
                    || c == '\r'
                    || c == '\n'
                    || c == '\t'
                )
                {
                    return true;
                }
            }

            return false;
        }

        if (NeedsEscape(s))
        {
            var r = new StringBuilder(s.Length);

            foreach (var c in s)
            {
                switch (c)
                {
                    case '\\':
                        r.Append("\\\\");
                        continue;
                    case '"':
                        r.Append("\\\"");
                        continue;
                    case '\r':
                        continue;
                    case '\n':
                        r.Append("\\n");
                        continue;
                    case '\t':
                        r.Append("\\t");
                        continue;
                }

                if (c < 32)
                {
                    continue; // not displayable
                }

                if (c <= 255)
                {
                    r.Append(c);
                }
                else
                {
                    r.Append("\\u");
                    r.Append(((ushort)c).ToString("X4"));
                }
            }

            return r.ToString();
        }
        else
        {
            return s;
        }
    }

    /// <summary>
    /// Invokes the specified JavaScript and returns the result as a string.
    /// </summary>
    /// <param name="js">The JavaScript code.</param>
    /// <returns>A string, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string? InvokeJS(string js)
    {
        return StringOrNullFromJs(@$"
            (function() {{
                const __result = ({js});
                if (__result === null || __result === undefined)
                    return null;
                if (typeof __result === ""string"")
                    return __result;
                if (__result.toString)
                    return __result.toString();
                return JSON.stringify(__result);
            }})();
        ");
    }

    /// <summary>
    /// Gets an object from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A <see cref="JSObject"/> representing the result of this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial JSObject JSObjectFromJs(string js);

    /// <summary>
    /// Gets an object from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A <see cref="JSObject"/> representing the result of this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial JSObject? JSObjectOrNullFromJs(string js);

    /// <summary>
    /// Gets a string from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A string resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial string StringFromJs(string js);

    /// <summary>
    /// Gets a string from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A string resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial string? StringOrNullFromJs(string js);

    /// <summary>
    /// Gets a bool from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A bool resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial bool BooleanFromJs(string js);

    /// <summary>
    /// Gets a bool from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A bool resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial bool? BooleanOrNullFromJs(string js);

    /// <summary>
    /// Gets a sbyte from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A sbyte resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static sbyte SByteFromJs(string js) => (sbyte)Int16FromJs(js);

    /// <summary>
    /// Gets a sbyte from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A sbyte resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static sbyte? SByteOrNullFromJs(string js) => (sbyte?)Int16OrNullFromJs(js);


    /// <summary>
    /// Gets a short from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A short resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial short Int16FromJs(string js);

    /// <summary>
    /// Gets a short from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A short resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial short? Int16OrNullFromJs(string js);


    /// <summary>
    /// Gets a int from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A int resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial int Int32FromJs(string js);

    /// <summary>
    /// Gets a int from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A int resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial int? Int32OrNullFromJs(string js);


    /// <summary>
    /// Gets a long from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A long resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    [return:JSMarshalAs<JSType.BigInt>]
    public static partial long Int64FromJs(string js);

    /// <summary>
    /// Gets a long from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A long resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    [return: JSMarshalAs<JSType.BigInt>]
    public static partial long? Int64OrNullFromJs(string js);

    /// <summary>
    /// Gets a byte from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A byte resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial byte ByteFromJs(string js);

    /// <summary>
    /// Gets a byte from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A byte resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial byte? ByteOrNullFromJs(string js);


    /// <summary>
    /// Gets a ushort from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A ushort resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static ushort UInt16FromJs(string js) => (ushort)UInt32FromJs(js);

    /// <summary>
    /// Gets a ushort from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A ushort resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static ushort? UInt16OrNullFromJs(string js) => (ushort?)UInt32OrNullFromJs(js);


    /// <summary>
    /// Gets a uint from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A uint resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static uint UInt32FromJs(string js) => (uint)UInt64FromJs(js);

    /// <summary>
    /// Gets a uint from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A uint resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static uint? UInt32OrNullFromJs(string js) => (uint?)UInt64OrNullFromJs(js);


    /// <summary>
    /// Gets a ulong from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A ulong resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static ulong UInt64FromJs(string js) => ulong.Parse(InvokeJS(js)!);

    /// <summary>
    /// Gets a ulong from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A ulong resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static ulong? UInt64OrNullFromJs(string js)
    {
        var result = InvokeJS(js);
        if (result == null)
        {
            return null;
        }
        return ulong.Parse(result);
    }

    /// <summary>
    /// Gets a float from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A float resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial float SingleFromJs(string js);

    /// <summary>
    /// Gets a float from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A float resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial float? SingleOrNullFromJs(string js);


    /// <summary>
    /// Gets a double from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A double resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial double DoubleFromJs(string js);

    /// <summary>
    /// Gets a double from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A double resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial double? DoubleOrNullFromJs(string js);


    /// <summary>
    /// Gets a decimal from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A decimal resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static decimal DecimalFromJs(string js) => decimal.Parse(InvokeJS(js)!);

    /// <summary>
    /// Gets a decimal from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A decimal resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static decimal? DecimalOrNullFromJs(string js)
    {
        var result = InvokeJS(js);
        if (result == null)
        {
            return null;
        }
        return decimal.Parse(result);
    }
}

/// <summary>
/// Methods used by source generators for JavaScript interop. Do not use them directly.
/// </summary>
/// <typeparam name="T"></typeparam>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class WebAssemblyRuntime<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>
{
    /// <summary>
    /// Gets a <typeparamref name="T"/> from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A <typeparamref name="T"/> resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static T ValueFromJs(string js)
    {
        return _valueFromJs(js);
    }

    /// <summary>
    /// Gets a <typeparamref name="T"/> from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A <typeparamref name="T"/> resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static T? ValueOrNullFromJs(string js)
    {
        return _valueOrNullFromJs(js);
    }

    private static readonly Func<string, T> _valueFromJs;
    private static readonly Func<string, T?> _valueOrNullFromJs;

    static WebAssemblyRuntime()
    {
        if (typeof(JsObject).IsAssignableFrom(typeof(T)))
        {
            var method = typeof(T).GetMethod(nameof(JsObject.FromExpression), BindingFlags.Public | BindingFlags.Static)!;
            _valueOrNullFromJs = (Func<string, T?>)Delegate.CreateDelegate(typeof(Func<string, T?>), method, true)!;
            _valueFromJs = (Func<string, T>)_valueOrNullFromJs;
        }
        else if (typeof(T).IsPrimitive || typeof(T) == typeof(string))
        {
            var method = typeof(WebAssemblyRuntime).GetMethod($"{typeof(T).Name}FromJs", BindingFlags.Public | BindingFlags.Static, new[] { typeof(string) })!;
            var nullableMethod = typeof(WebAssemblyRuntime).GetMethod($"{typeof(T).Name}OrNullFromJs", BindingFlags.Public | BindingFlags.Static, new[] { typeof(string) })!;
            _valueFromJs = (Func<string, T>)Delegate.CreateDelegate(typeof(Func<string, T>), method, true)!;
            if (typeof(T).IsValueType)
            {
                // For value types, T? is the same as T in generic contexts.
                _valueOrNullFromJs = _valueFromJs;
            }
            else
            {
                _valueOrNullFromJs = (Func<string, T?>)Delegate.CreateDelegate(typeof(Func<string, T?>), nullableMethod, true)!;
            }
        }
        else
        {
            throw new NotSupportedException($"The type {typeof(T).FullName} is not supported for JavaScript interop.");
        }
    }
}