using Trungnt2910.Browser.Generators;

[assembly:MethodGeneratorGenerator(
    BaseName = "Method",
    MaxParams = 8,
    IncludeReturnTypeParam = true,
    Template = @"
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public {{@@RETURNTYPE@@}}? {{Name}}(@@PARAMETERS_WITH_TYPE@@) => {{@@RETURNTYPE@@}}.FromExpression($""{_jsThis}.{{JsName}}(@@PARAMETERS_TO_JS_OBJECT_STRING@@)"");
    "
)]

[assembly: MethodGeneratorGenerator(
    BaseName = "VoidMethod",
    MaxParams = 8,
    IncludeReturnTypeParam = false,
    Template = @"
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public void {{Name}}(@@PARAMETERS_WITH_TYPE@@) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($""{_jsThis}.{{JsName}}(@@PARAMETERS_TO_JS_OBJECT_STRING@@)"");
    "
)]

[assembly: MethodGeneratorGenerator(
    BaseName = "StringMethod",
    MaxParams = 8,
    IncludeReturnTypeParam = false,
    Template = @"
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public string? {{Name}}(@@PARAMETERS_WITH_TYPE@@) => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($""{_jsThis}.{{JsName}}(@@PARAMETERS_TO_JS_OBJECT_STRING@@)"");
    "
)]

[assembly: MethodGeneratorGenerator(
    BaseName = "NumericMethod",
    MaxParams = 8,
    IncludeReturnTypeParam = true,
    Template = @"
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public {{@@RETURNTYPE@@}}? {{Name}}(@@PARAMETERS_WITH_TYPE@@) => global::Trungnt2910.Browser.WebAssemblyRuntime.{{@@RETURNTYPE@@}}OrNullFromJs($""{_jsThis}.{{JsName}}(@@PARAMETERS_TO_JS_OBJECT_STRING@@)"");
    "
)]

[assembly: MethodGeneratorGenerator(
    BaseName = "VarArgsMethod",
    MaxParams = 8,
    IncludeReturnTypeParam = true,
    IncludeRestTypeParam = true,
    Template = @"
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public {{@@RETURNTYPE@@}}? {{Name}}(@@PARAMETERS_WITH_TYPE@@) => {{@@RETURNTYPE@@}}.FromExpression($""{_jsThis}.{{JsName}}(@@PARAMETERS_TO_JS_OBJECT_STRING@@)"");
    "
)]

[assembly: MethodGeneratorGenerator(
    BaseName = "NumericVarArgsMethod",
    MaxParams = 8,
    IncludeReturnTypeParam = true,
    IncludeRestTypeParam = true,
    Template = @"
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public {{@@RETURNTYPE@@}}? {{Name}}(@@PARAMETERS_WITH_TYPE@@) => global::Trungnt2910.Browser.WebAssemblyRuntime.{{@@RETURNTYPE@@}}OrNullFromJs($""{_jsThis}.{{JsName}}(@@PARAMETERS_TO_JS_OBJECT_STRING@@)"");
    "
)]