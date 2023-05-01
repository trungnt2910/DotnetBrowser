using Zu.TypeScript.TsTypes;

namespace Trungnt2910.Browser.Generators.TypeScript.Utilities;

internal static class JsDocHelpers
{
    public static string ToXmlDocString(this List<JsDoc>? jsDoc)
    {
        return string.Join(Environment.NewLine, jsDoc?.Select(d => d.Comment) ?? Array.Empty<string>())
                     .ToXmlDocString();
    }

    public static string ToXmlDocString(this string? str)
    {
        return str?.Replace("<", "&lt;")
                  .Replace(">", "&gt;")
                  .Replace("&", "&amp;") ?? string.Empty;
    }

    public static string ToCommentAttributeLiteral(this string jsDocString)
    {
        return jsDocString
                    .Replace("\"", "\\\"")
                    .Replace(Environment.NewLine, " ");
    }

    public static bool HasDeprecatedTag(this List<JsDoc>? jsDoc)
    {
        return jsDoc
            ?.SelectMany(d => d.Tags?.Where(t => t?.TagName?.Text == "deprecated") ?? Array.Empty<IJsDocTag>())
            .Any() 
            ?? false;
    }
}