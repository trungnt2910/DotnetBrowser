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
/// To be added.
/// </summary>
[JsObject]
public partial class WEBGL_multi_draw: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void MultiDrawArraysInstancedWEBGL(double? mode, Union<Int32Array, JsArray<double>>? firstsList, double? firstsOffset, Union<Int32Array, JsArray<double>>? countsList, double? countsOffset, Union<Int32Array, JsArray<double>>? instanceCountsList, double? instanceCountsOffset, double? drawcount) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.multiDrawArraysInstancedWEBGL({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(mode))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(firstsList))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(firstsOffset))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(countsList))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(countsOffset))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(instanceCountsList))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(instanceCountsOffset))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(drawcount))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void MultiDrawArraysWEBGL(double? mode, Union<Int32Array, JsArray<double>>? firstsList, double? firstsOffset, Union<Int32Array, JsArray<double>>? countsList, double? countsOffset, double? drawcount) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.multiDrawArraysWEBGL({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(mode))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(firstsList))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(firstsOffset))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(countsList))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(countsOffset))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(drawcount))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void MultiDrawElementsInstancedWEBGL(double? mode, Union<Int32Array, JsArray<double>>? countsList, double? countsOffset, double? type, Union<Int32Array, JsArray<double>>? offsetsList, double? offsetsOffset, Union<Int32Array, JsArray<double>>? instanceCountsList, double? instanceCountsOffset, double? drawcount) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.multiDrawElementsInstancedWEBGL({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(mode))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(countsList))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(countsOffset))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(offsetsList))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(offsetsOffset))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(instanceCountsList))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(instanceCountsOffset))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(drawcount))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void MultiDrawElementsWEBGL(double? mode, Union<Int32Array, JsArray<double>>? countsList, double? countsOffset, double? type, Union<Int32Array, JsArray<double>>? offsetsList, double? offsetsOffset, double? drawcount) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.multiDrawElementsWEBGL({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(mode))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(countsList))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(countsOffset))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(offsetsList))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(offsetsOffset))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(drawcount))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

