using Gobie;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"NumericPropertyAttribute", Namespace = "Trungnt2910.Browser.Generators")]
internal sealed class NumericPropertyGenerator : GobieClassGenerator
{
    [Required]
    public string JsName { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Type { get; set; } = string.Empty;

    [GobieTemplate]
    const string Template = @"
        public {{Type}}? {{Name}}
        {
            get => {{Type}}.Parse(global::Uno.Foundation.WebAssemblyRuntime.InvokeJS($""{_jsThis}.{{JsName}}""));
            set => global::Uno.Foundation.WebAssemblyRuntime.InvokeJS($""{_jsThis}.{{JsName}} = {value}"");
        }
    ";
}
