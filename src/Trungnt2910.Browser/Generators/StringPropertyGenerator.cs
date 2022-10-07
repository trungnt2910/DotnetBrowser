using Gobie;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"StringPropertyAttribute", Namespace = "Trungnt2910.Browser.Generators")]
internal sealed class StringPropertyGenerator : GobieClassGenerator
{
    [Required]
    public string JsName { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [GobieTemplate]
    const string Template = @"
        public string? {{Name}}
        {
            get => global::Uno.Foundation.WebAssemblyRuntime.InvokeJS($""{_jsThis}.{{JsName}}"");
            set => global::Uno.Foundation.WebAssemblyRuntime.InvokeJS($""{_jsThis}.{{JsName}} = { ((value == null) ? ""null"" : ""{(global::Uno.Foundation.WebAssemblyRuntime.EscapeJs(value))}"") } "");
        }
    ";
}
