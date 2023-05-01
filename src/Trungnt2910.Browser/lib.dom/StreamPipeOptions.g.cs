// This file was generated by "LibDomTypeScriptParser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", from "lib.dom.d.ts".
// Do not edit directly. If you encounter any bugs, please fix the generator's code.
//
// Copyright (C) 2023 Trung Nguyen. All rights reserved.
// Licensed under the MIT License.

/*! *****************************************************************************
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the Apache License, Version 2.0 (the "License"); you may not use
this file except in compliance with the License. You may obtain a copy of the
License at http://www.apache.org/licenses/LICENSE-2.0

THIS CODE IS PROVIDED ON AN *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
MERCHANTABLITY OR NON-INFRINGEMENT.

See the Apache Version 2.0 License for specific language governing permissions
and limitations under the License.
***************************************************************************** */

#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser.Dom;

#pragma warning disable CS0108, CS8764, CS8766
/// <summary>
/// To be added.
/// </summary>
[JsObject]
public partial class StreamPipeOptions: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? PreventAbort
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.preventAbort");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.preventAbort = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? PreventCancel
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.preventCancel");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.preventCancel = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// Pipes this readable stream to a given writable stream destination. The way in which the piping process behaves under various error conditions can be customized with a number of passed options. It returns a promise that fulfills when the piping process completes successfully, or rejects if any errors were encountered.
    /// Piping a stream will lock it for the duration of the pipe, preventing any other consumer from acquiring a reader.
    /// Errors and closures of the source and destination streams propagate as follows:
    /// An error in this source readable stream will abort destination, unless preventAbort is truthy. The returned promise will be rejected with the source's error, or with any error that occurs during aborting the destination.
    /// An error in destination will cancel this source readable stream, unless preventCancel is truthy. The returned promise will be rejected with the destination's error, or with any error that occurs during canceling the source.
    /// When this source readable stream closes, destination will be closed, unless preventClose is truthy. The returned promise will be fulfilled once this process completes, unless an error is encountered while closing the destination, in which case it will be rejected with that error.
    /// If destination starts out closed or closing, this source readable stream will be canceled, unless preventCancel is true. The returned promise will be rejected with an error indicating piping to a closed stream failed, or with any error that occurs during canceling the source.
    /// The signal option can be set to an AbortSignal to allow aborting an ongoing pipe operation via the corresponding AbortController. In this case, this source readable stream will be canceled, and destination aborted, unless the respective options preventCancel or preventAbort are set.
    /// </summary>
    public bool? PreventClose
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.preventClose");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.preventClose = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AbortSignal? Signal
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<AbortSignal>.ValueOrNullFromJs($"{_jsThis}.signal");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.signal = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
}
#pragma warning restore CS0108, CS8764, CS8766

