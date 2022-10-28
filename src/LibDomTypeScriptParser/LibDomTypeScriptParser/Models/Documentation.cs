using LibDomTypeScriptParser.Utilities;
using Zu.TypeScript.TsTypes;

namespace LibDomTypeScriptParser.Models;

public class Documentation: ICloneable
{
    public List<string> Comments { get; set; } = new();

    public bool IsDeprecated { get; set; } = false;

    public string? DeprecatedText { get; set; }

    public Dictionary<string, string> ParamComments { get; set; } = new();

    public Documentation()
    {

    }

    public Documentation(INode nodeInterface)
    {
        if (nodeInterface is Node node)
        {
            var commentRangeStart = node.Pos;
            var commentRangeEnd = node.NodeStart;

            if (commentRangeStart != null)
            {
                var commentStrings = (IEnumerable<string>)node.SourceStr[commentRangeStart.Value..commentRangeEnd]
                    .ReplaceLineEndings().Trim().Split(Environment.NewLine);

                commentStrings = commentStrings.Reverse().TakeWhile(s => !string.IsNullOrEmpty(s)).Reverse()
                    .Select(s => s.Trim().Trim(new[] { '*', '/' }).Trim())
                    .Where(s => !string.IsNullOrEmpty(s));

                var nonTagged = new List<string>();

                foreach (var commentString in commentStrings)
                {
                    if (commentString.StartsWith("@"))
                    {
                        var firstWord = new string(commentString.Skip(1).TakeWhile(ch => !char.IsWhiteSpace(ch)).ToArray());
                        var contents = commentString[(1 + firstWord.Length)..].Trim();
                        switch (firstWord)
                        {
                            case "deprecated":
                                IsDeprecated = true;
                                if (!string.IsNullOrEmpty(contents))
                                {
                                    if (DeprecatedText != null)
                                    {
                                        DeprecatedText += Environment.NewLine + contents;
                                    }
                                    else
                                    {
                                        DeprecatedText = contents;
                                    }
                                }
                            break;
                            case "param":
                                {
                                    var paramName = new string(contents.TakeWhile(ch => !char.IsWhiteSpace(ch)).ToArray());
                                    ParamComments.Add(paramName, contents[paramName.Length..].Trim().ToXmlDocString());
                                }
                            break;
                            default:
                                Console.Error.WriteLine($"[{commentRangeStart}-{commentRangeEnd}] Unsupported JsDoc tag: {firstWord}");
                                nonTagged.Add(commentString);
                            break;
                        }
                    }
                    else
                    {
                        Comments.Add(commentString.ToXmlDocString());
                    }
                }

                DeprecatedText = DeprecatedText?.ToCommentAttributeLiteral();
            }
        }
    }

    public void AppendCommentLine(string line)
    {
        if (Comments.Count != 0)
        {
            Comments[^1] += "<br/>";
        }
        Comments.Add(line.ToXmlDocString());
    }

    public void AppendCommentLines(IEnumerable<string> lines, bool escapeXml = true)
    {
        if (Comments.Count != 0)
        {
            Comments[^1] += "<br/>";
        }
        if (escapeXml)
        {
            lines = lines.Select(l => l.ToXmlDocString());
        }
        Comments.AddRange(lines);
    }

    public static bool operator ==(Documentation? left, Documentation? right)
    {
        if (left is null)
        {
            return right is null;
        }
        else if (right is null)
        {
            return left is null;
        }

        return left.Comments.SequenceEqual(right.Comments)
            && left.IsDeprecated == right.IsDeprecated
            && left.DeprecatedText == right.DeprecatedText
            && left.ParamComments.Count == right.ParamComments.Count && !left.ParamComments.Except(right.ParamComments).Any();
    }

    public static bool operator !=(Documentation? left, Documentation? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is Documentation other)
        {
            return this == other;
        }

        return false;
    }

    public override int GetHashCode()
    {
        int hashCode = Comments.Aggregate(0, (code, cmt) => (code << 8) ^ cmt.GetHashCode());
        hashCode <<= 1;
        hashCode ^= IsDeprecated.GetHashCode();
        hashCode <<= 10;
        hashCode ^= DeprecatedText?.GetHashCode() ?? -1;
        hashCode <<= 4;
        hashCode <<= ParamComments.OrderBy(kvp => kvp.Key).Aggregate(0, (code, kvp) => (code << 9) ^ kvp.GetHashCode());
        return hashCode;
    }

    public object Clone()
    {
        return new Documentation()
        {
            Comments = Comments,
            IsDeprecated = IsDeprecated,
            DeprecatedText = DeprecatedText,
            ParamComments = new Dictionary<string, string>(ParamComments)
        };
    }
}
