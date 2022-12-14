// This file was generated by "LibDomTypeScriptParser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", from "lib.dom.d.ts".
// Do not edit directly. If you encounter any bugs, please fix the generator's code.
//
// Copyright (C) 2022 Trung Nguyen. All rights reserved.
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
/// Provides a storage mechanism for Request / Response object pairs that are cached, for example as part of the ServiceWorker life cycle. Note that the Cache interface is exposed to windowed scopes as well as workers. You don't have to use it in conjunction with service workers, even though it is defined in the service worker spec.
/// Available only in secure contexts.
/// </summary>
[JsObject]
public partial class Cache: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise? Add(Union<Request, string, URL>? request) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.add({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(request))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise? AddAll(JsArray<Union<Request, string>>? requests) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.addAll({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(requests))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<bool>? Delete(Union<Request, string, URL>? request, CacheQueryOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<bool>>.ValueOrNullFromJs($"{_jsThis}.delete({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(request))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<ReadonlyArray<Request>>? Keys(Union<Request, string, URL>? request, CacheQueryOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<ReadonlyArray<Request>>>.ValueOrNullFromJs($"{_jsThis}.keys({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(request))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<Response>? Match(Union<Request, string, URL>? request, CacheQueryOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<Response>>.ValueOrNullFromJs($"{_jsThis}.match({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(request))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<ReadonlyArray<Response>>? MatchAll(Union<Request, string, URL>? request, CacheQueryOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<ReadonlyArray<Response>>>.ValueOrNullFromJs($"{_jsThis}.matchAll({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(request))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise? Put(Union<Request, string, URL>? request, Response? response) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.put({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(request))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(response))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

