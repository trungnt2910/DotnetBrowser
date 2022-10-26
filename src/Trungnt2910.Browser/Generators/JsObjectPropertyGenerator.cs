using Gobie;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"{nameof(JsObject)}PropertyAttribute", Namespace = "Trungnt2910.Browser.Generators", AllowMultiple = true)]
internal sealed class JsObjectPropertyGenerator : GobieClassGenerator
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
            get => {{Type}}.FromExpression($""{_jsThis}.{{JsName}}"");
            set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($""{_jsThis}.{{JsName}} = {value?._jsThis ?? ""null""}"");
        }
        #pragma warning restore {{SuppressWarnings}}
    ";
}

[GobieGeneratorName($"{nameof(JsObject)}ReadOnlyPropertyAttribute", Namespace = "Trungnt2910.Browser.Generators", AllowMultiple = true)]
internal sealed class JsObjectReadOnlyPropertyGenerator : GobieClassGenerator
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
        public {{Type}}? {{Name}} => {{Type}}.FromExpression($""{_jsThis}.{{JsName}}"");
        #pragma warning restore {{SuppressWarnings}}
    ";
}
