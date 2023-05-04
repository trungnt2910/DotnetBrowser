using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Text;

namespace Trungnt2910.Browser;

public partial class JsObject
{
    /// <summary>
    /// Escapes a string for use with JavaScript.
    /// </summary>
    /// <param name="s">The string to escape.</param>
    /// <returns>An escaped string that can be used in JavaScript string literals.</returns>
    [Pure]
    private static string EscapeJs(string s)
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

}
