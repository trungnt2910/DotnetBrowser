using Trungnt2910.Browser.Generators.TypeScript.Utilities;

namespace Trungnt2910.Browser.Generators.TypeScript.Models;

public class Documentation: ICloneable
{
    public List<string> Comments { get; set; } = new();

    public bool IsDeprecated { get; set; } = false;

    public string? DeprecatedText { get; set; }

    public Dictionary<string, string> ParamComments { get; set; } = new();

    public Documentation()
    {

    }

    public void AppendCommentLine(string line)
    {
        if (Comments.Count != 0)
        {
            Comments[Comments.Count - 1] += "<br/>";
        }
        Comments.Add(line.ToXmlDocString());
    }

    public void AppendCommentLines(IEnumerable<string> lines, bool escapeXml = true)
    {
        if (Comments.Count != 0)
        {
            Comments[Comments.Count - 1] += "<br/>";
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
