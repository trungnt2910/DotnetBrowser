using Gobie;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"MethodAttribute<T>", Namespace = "Trungnt2910.Browser.Generators", AllowMultiple = true)]
internal sealed class MethodGenerator<T> : GobieClassGenerator
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
        public {{T}} {{Name}}() => {{T}}.FromExpression($""{_jsThis}.{{JsName}}()"");
    ";
}

[GobieGeneratorName($"MethodAttribute<T, T1>", Namespace = "Trungnt2910.Browser.Generators", AllowMultiple = true)]
internal sealed class MethodGenerator<T, T1> : GobieClassGenerator
{
    [Required]
    public string JsName { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Param1 { get; set; } = "param1";

    public string Comments { get; set; } = "To be added.";

    [GobieTemplate]
    const string Template = @"
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public {{T}} {{Name}}({{T1}} {{Param1}}) => {{T}}.FromExpression($""{_jsThis}.{{JsName}}(
            {(global::Trungnt2910.Browser.JsObject.ToJsObjectString({{Param1}}))})
        "");
    ";
}
