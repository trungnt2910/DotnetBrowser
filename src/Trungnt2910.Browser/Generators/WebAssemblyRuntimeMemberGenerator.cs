using Gobie;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"WebAssemblyRuntimeMemberAttribute", Namespace = "Trungnt2910.Browser.Generators", AllowMultiple = true)]
internal sealed class WebAssemblyRuntimeMemberGenerator : GobieClassGenerator
{
    [Required]
    public string Type { get; set; } = string.Empty;

    [Required]
    public string AliasedType { get; set; } = string.Empty;

    [GobieTemplate]
    const string Template = @"
        /// <summary>
        /// An alias to <see cref=""{{Type}}FromJs""/> used by code generators.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static {{AliasedType}}? {{AliasedType}}FromJs(string js) => {{Type}}FromJs(js);

        /// <summary>
        /// An alias to <see cref=""{{Type}}OrNullFromJs""/> used by code generators.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static {{AliasedType}}? {{AliasedType}}OrNullFromJs(string js) => {{Type}}OrNullFromJs(js);
    ";
}
