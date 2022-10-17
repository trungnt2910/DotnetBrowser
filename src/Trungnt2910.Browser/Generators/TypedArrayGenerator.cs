using Gobie;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"TypedArrayAttribute", Namespace = "Trungnt2910.Browser.Generators")]
internal sealed class TypedArrayGenerator: GobieClassGenerator
{
    [Required]
    public string MemberType { get; set; } = string.Empty;

    [GobieTemplate]
    const string Template = @"
    /// <inheritdoc/>
    public {{MemberType}} this[int index]
    {
        get => WebAssemblyRuntime.{{MemberType}}FromJs($""{_jsThis}[{index}]"");
        set => WebAssemblyRuntime.{{MemberType}}FromJs($""{_jsThis}[{index}] = {value}"");
    }

    /// <inheritdoc/>
    public int Count => WebAssemblyRuntime.Int32FromJs($""{_jsThis}.length"");

    /// <inheritdoc/>
    public global::System.Collections.Generic.IEnumerator<{{MemberType}}> GetEnumerator()
    {
        for (int i = 0; i < Count; ++i)
        {
            yield return this[i];
        }
    }

    /// <inheritdoc/>
    global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    ";
}
