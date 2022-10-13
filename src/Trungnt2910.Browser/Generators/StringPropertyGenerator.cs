using Gobie;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"StringPropertyAttribute", Namespace = "Trungnt2910.Browser.Generators", AllowMultiple = true)]
internal sealed class StringPropertyGenerator : GobieClassGenerator
{
    [Required]
    public string JsName { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Comments { get; set; } = "To be added.";

    [GobieTemplate]
    const string Template = @"
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public string? {{Name}}
        {
            get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($""{_jsThis}.{{JsName}}"");
            set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($""{_jsThis}.{{JsName}} = { ((value == null) ? ""null"" : $""\""{(global::Trungnt2910.Browser.WebAssemblyRuntime.EscapeJs(value))}\"""") } "");
        }
    ";
}

[GobieGeneratorName($"StringReadOnlyPropertyAttribute", Namespace = "Trungnt2910.Browser.Generators", AllowMultiple = true)]
internal sealed class StringReadOnlyPropertyGenerator : GobieClassGenerator
{
    [Required]
    public string JsName { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Comments { get; set; } = "To be added.";

    [GobieTemplate]
    const string Template = @"
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public string? {{Name}} => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($""{_jsThis}.{{JsName}}"");
    ";
}
