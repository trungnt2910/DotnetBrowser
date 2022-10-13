using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;

namespace Trungnt2910.Browser;

internal static partial class WebAssemblyRuntime
{
    [Pure]
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

    [JSImport("globalThis.window.eval")]
    public static partial string StringFromJs(string js);

    [JSImport("globalThis.window.eval")]
    public static partial string? StringOrNullFromJs(string js);

    [JSImport("globalThis.window.eval")]
    public static partial bool BoolFromJs(string js);

    [JSImport("globalThis.window.eval")]
    public static partial bool BoolOrNullFromJs(string js);

    [JSImport("globalThis.window.eval")]
    public static partial int IntFromJs(string js);

    [JSImport("globalThis.window.eval")]
    public static partial int? IntOrNullFromJs(string js);

    [JSImport("globalThis.window.eval")]
    public static partial double DoubleFromJs(string js);

    [JSImport("globalThis.window.eval")]
    public static partial double? DoubleOrNullFromJs(string js);

    [JSImport("globalThis.window.eval")]
    public static partial JSObject ObjectFromJs(string js);

    [JSImport("globalThis.window.eval")]
    public static partial JSObject? ObjectOrNullFromJs(string js);

    #region Generator Helpers
    // These methods exist to serve code generators only.

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool? boolOrNullFromJs(string js) => BoolOrNullFromJs(js);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int? intOrNullFromJs(string js) => IntOrNullFromJs(js);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double? doubleOrNullFromJs(string js) => DoubleOrNullFromJs(js);
    #endregion
}
