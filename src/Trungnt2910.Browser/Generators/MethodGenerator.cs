using Trungnt2910.Browser.Generators;

[assembly:MethodGeneratorGenerator(
    BaseName = "Method", 
    MaxParams = 8,
    Template = @"
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public {{@@RETURNTYPE@@}}? {{Name}}(@@PARAMETERS_WITH_TYPE@@) => {{@@RETURNTYPE@@}}.FromExpression($""{_jsThis}.{{JsName}}(@@PARAMETERS_TO_JS_OBJECT_STRING@@)"");
    "
)]