using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;

namespace Trungnt2910.Browser;

/// <summary>
/// Methods used by source generators for JavaScript interop. Do not use them directly.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
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
    /// Gets a boolean from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A boolean resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial bool BoolFromJs(string js);

    /// <summary>
    /// Gets a boolean from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A boolean resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial bool BoolOrNullFromJs(string js);

    /// <summary>
    /// Gets an integer from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>An integer resulting from this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial int IntFromJs(string js);

    /// <summary>
    /// Gets an integer from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>An integer resulting from this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial int? IntOrNullFromJs(string js);

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
    /// Gets an object from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A <see cref="JSObject"/> representing the result of this expression.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial JSObject ObjectFromJs(string js);

    /// <summary>
    /// Gets an object from a JavaScript expression.
    /// </summary>
    /// <param name="js">The JavaScript expression.</param>
    /// <returns>A <see cref="JSObject"/> representing the result of this expression, or <see langword="null"/> if the JavaScript result is <c>null</c> or <c>undefined</c>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport("globalThis.window.eval")]
    public static partial JSObject? ObjectOrNullFromJs(string js);

    #region Generator Helpers
    // These methods exist to serve code generators only.

    /// <summary>
    /// An alias to <see cref="BoolOrNullFromJs"/> used by code generators.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool? boolOrNullFromJs(string js) => BoolOrNullFromJs(js);

    /// <summary>
    /// An alias to <see cref="IntOrNullFromJs"/> used by code generators.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int? intOrNullFromJs(string js) => IntOrNullFromJs(js);

    /// <summary>
    /// An alias to <see cref="DoubleOrNullFromJs"/> used by code generators.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double? doubleOrNullFromJs(string js) => DoubleOrNullFromJs(js);
    #endregion
}
