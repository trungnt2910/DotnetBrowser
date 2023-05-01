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
/// This Streams API interface represents a readable stream of byte data. The Fetch API offers a concrete instance of a ReadableStream through the body property of a Response object.
/// </summary>
[JsObject]
public partial class ReadableStream<R>: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? Locked
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.locked");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise? Cancel(JsObject? reason) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.cancel({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(reason))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public ReadableStreamDefaultReader<R>? GetReader() => global::Trungnt2910.Browser.WebAssemblyRuntime<ReadableStreamDefaultReader<R>>.ValueOrNullFromJs($"{_jsThis}.getReader()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public ReadableStream<T>? PipeThrough<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>(ReadableWritablePair<T, R>? transform, StreamPipeOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime<ReadableStream<T>>.ValueOrNullFromJs($"{_jsThis}.pipeThrough({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(transform))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise? PipeTo(WritableStream<R>? destination, StreamPipeOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.pipeTo({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(destination))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsArray<ReadableStream<R>>? Tee() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<ReadableStream<R>>>.ValueOrNullFromJs($"{_jsThis}.tee()");
    
}
/// <summary>
/// This Streams API interface represents a readable stream of byte data. The Fetch API offers a concrete instance of a ReadableStream through the body property of a Response object.
/// </summary>
[JsObject]
public partial class ReadableStream: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? Locked
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.locked");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise? Cancel(JsObject? reason) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.cancel({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(reason))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public ReadableStreamDefaultReader<JsObject>? GetReader() => global::Trungnt2910.Browser.WebAssemblyRuntime<ReadableStreamDefaultReader<JsObject>>.ValueOrNullFromJs($"{_jsThis}.getReader()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public ReadableStream<T>? PipeThrough<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>(ReadableWritablePair<T, JsObject>? transform, StreamPipeOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime<ReadableStream<T>>.ValueOrNullFromJs($"{_jsThis}.pipeThrough({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(transform))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise? PipeTo(WritableStream<JsObject>? destination, StreamPipeOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.pipeTo({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(destination))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsArray<ReadableStream<JsObject>>? Tee() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<ReadableStream<JsObject>>>.ValueOrNullFromJs($"{_jsThis}.tee()");
    
}
#pragma warning restore CS0108, CS8764, CS8766

