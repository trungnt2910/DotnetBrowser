using Trungnt2910.Browser.Generators;

[assembly:MethodGeneratorGenerator(
    BaseName = "Method",
    MaxParams = 16,
    IncludeReturnTypeParam = true,
    Template = @"
        #pragma warning disable {{SuppressWarnings}}
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public {{@@RETURNTYPE@@}}? {{Name}}(@@PARAMETERS_WITH_TYPE@@) => {{@@RETURNTYPE@@}}.FromExpression($""{_jsThis}.{{JsName}}(@@PARAMETERS_TO_JS_OBJECT_STRING@@)"");
        #pragma warning restore {{SuppressWarnings}}
    "
)]

[assembly: MethodGeneratorGenerator(
    BaseName = "VoidMethod",
    MaxParams = 16,
    IncludeReturnTypeParam = false,
    Template = @"
        #pragma warning disable {{SuppressWarnings}}
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public void {{Name}}(@@PARAMETERS_WITH_TYPE@@) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($""{_jsThis}.{{JsName}}(@@PARAMETERS_TO_JS_OBJECT_STRING@@)"");
        #pragma warning restore {{SuppressWarnings}}
    "
)]

[assembly: MethodGeneratorGenerator(
    BaseName = "StringMethod",
    MaxParams = 16,
    IncludeReturnTypeParam = false,
    Template = @"
        #pragma warning disable {{SuppressWarnings}}
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public string? {{Name}}(@@PARAMETERS_WITH_TYPE@@) => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($""{_jsThis}.{{JsName}}(@@PARAMETERS_TO_JS_OBJECT_STRING@@)"");
        #pragma warning restore {{SuppressWarnings}}
    "
)]

[assembly: MethodGeneratorGenerator(
    BaseName = "NumericMethod",
    MaxParams = 16,
    IncludeReturnTypeParam = true,
    Template = @"
        #pragma warning disable {{SuppressWarnings}}
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public {{@@RETURNTYPE@@}}? {{Name}}(@@PARAMETERS_WITH_TYPE@@) => global::Trungnt2910.Browser.WebAssemblyRuntime.{{@@RETURNTYPE@@}}OrNullFromJs($""{_jsThis}.{{JsName}}(@@PARAMETERS_TO_JS_OBJECT_STRING@@)"");
        #pragma warning restore {{SuppressWarnings}}
    "
)]

[assembly: MethodGeneratorGenerator(
    BaseName = "VarArgsMethod",
    MaxParams = 16,
    IncludeReturnTypeParam = true,
    IncludeRestTypeParam = true,
    Template = @"
        #pragma warning disable {{SuppressWarnings}}
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public {{@@RETURNTYPE@@}}? {{Name}}(@@PARAMETERS_WITH_TYPE@@) => {{@@RETURNTYPE@@}}.FromExpression($""{_jsThis}.{{JsName}}(@@PARAMETERS_TO_JS_OBJECT_STRING@@)"");
        #pragma warning restore {{SuppressWarnings}}
    "
)]

[assembly: MethodGeneratorGenerator(
    BaseName = "NumericVarArgsMethod",
    MaxParams = 16,
    IncludeReturnTypeParam = true,
    IncludeRestTypeParam = true,
    Template = @"
        #pragma warning disable {{SuppressWarnings}}
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public {{@@RETURNTYPE@@}}? {{Name}}(@@PARAMETERS_WITH_TYPE@@) => global::Trungnt2910.Browser.WebAssemblyRuntime.{{@@RETURNTYPE@@}}OrNullFromJs($""{_jsThis}.{{JsName}}(@@PARAMETERS_TO_JS_OBJECT_STRING@@)"");
        #pragma warning restore {{SuppressWarnings}}
    "
)]