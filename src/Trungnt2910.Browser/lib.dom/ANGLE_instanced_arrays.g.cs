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
/// The ANGLE_instanced_arrays extension is part of the WebGL API and allows to draw the same object, or groups of similar objects multiple times, if they share the same vertex data, primitive count and type.
/// </summary>
[JsObject]
public partial class ANGLE_instanced_arrays: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? VERTEX_ATTRIB_ARRAY_DIVISOR_ANGLE
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.VERTEX_ATTRIB_ARRAY_DIVISOR_ANGLE");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void DrawArraysInstancedANGLE(double? mode, double? first, double? count, double? primcount) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.drawArraysInstancedANGLE({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(mode))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(first))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(count))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(primcount))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void DrawElementsInstancedANGLE(double? mode, double? count, double? type, double? offset, double? primcount) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.drawElementsInstancedANGLE({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(mode))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(count))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(offset))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(primcount))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void VertexAttribDivisorANGLE(double? index, double? divisor) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.vertexAttribDivisorANGLE({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(divisor))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766
