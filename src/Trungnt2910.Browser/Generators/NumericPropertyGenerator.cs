using Gobie;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"NumericPropertyAttribute", Namespace = "Trungnt2910.Browser.Generators", AllowMultiple = true)]
internal sealed class NumericPropertyGenerator : GobieClassGenerator
{
    [Required]
    public string JsName { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Type { get; set; } = string.Empty;

    public string Comments { get; set; } = "To be added.";

    public string SuppressWarnings { get; set; } = string.Empty; 

    [GobieTemplate]
    const string Template = @"
        #pragma warning disable {{SuppressWarnings}}
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public {{Type}}? {{Name}}
        {
            get => global::Trungnt2910.Browser.WebAssemblyRuntime.{{Type}}OrNullFromJs($""{_jsThis}.{{JsName}}"");
            set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($""{_jsThis}.{{JsName}} = {value}"");
        }
        #pragma warning restore {{SuppressWarnings}}
    ";
}

[GobieGeneratorName($"NumericReadOnlyPropertyAttribute", Namespace = "Trungnt2910.Browser.Generators", AllowMultiple = true)]
internal sealed class NumericReadOnlyPropertyGenerator : GobieClassGenerator
{
    [Required]
    public string JsName { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Type { get; set; } = string.Empty;

    public string Comments { get; set; } = "To be added.";

    public string SuppressWarnings { get; set; } = string.Empty;

    [GobieTemplate]
    const string Template = @"
        #pragma warning disable {{SuppressWarnings}}
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public {{Type}}? {{Name}} => global::Trungnt2910.Browser.WebAssemblyRuntime.{{Type}}OrNullFromJs($""{_jsThis}.{{JsName}}"");
        #pragma warning restore {{SuppressWarnings}}
    ";
}
