using Gobie;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"{nameof(JsObject)}PropertyAttribute", Namespace = "Trungnt2910.Browser.Generators")]
internal sealed class JsObjectPropertyGenerator : GobieClassGenerator
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
            get => {{Type}}.FromExpression($""{_jsThis}.{{JsName}}"");
            set => global::Uno.Foundation.WebAssemblyRuntime.InvokeJS($""{_jsThis}.{{JsName}} = {value?._jsThis ?? ""null""}"");
        }
    ";
}

[GobieGeneratorName($"{nameof(JsObject)}ReadOnlyPropertyAttribute", Namespace = "Trungnt2910.Browser.Generators")]
internal sealed class JsObjectReadOnlyPropertyGenerator : GobieClassGenerator
{
    [Required]
    public string JsName { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Type { get; set; } = string.Empty;

    [GobieTemplate]
    const string Template = @"
        public {{Type}}? {{Name}} => {{Type}}.FromExpression($""{_jsThis}.{{JsName}}"");
    ";
}
