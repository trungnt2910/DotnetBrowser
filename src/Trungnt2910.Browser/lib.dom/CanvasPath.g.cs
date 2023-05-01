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
public partial class CanvasPath: JsObject, ICanvasPath
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Arc(double? x, double? y, double? radius, double? startAngle, double? endAngle, bool? counterclockwise) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.arc({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(radius))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(startAngle))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(endAngle))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(counterclockwise))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void ArcTo(double? x1, double? y1, double? x2, double? y2, double? radius) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.arcTo({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x1))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y1))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x2))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y2))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(radius))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void BezierCurveTo(double? cp1x, double? cp1y, double? cp2x, double? cp2y, double? x, double? y) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.bezierCurveTo({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(cp1x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(cp1y))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(cp2x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(cp2y))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void ClosePath() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.closePath()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Ellipse(double? x, double? y, double? radiusX, double? radiusY, double? rotation, double? startAngle, double? endAngle, bool? counterclockwise) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.ellipse({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(radiusX))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(radiusY))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(rotation))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(startAngle))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(endAngle))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(counterclockwise))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void LineTo(double? x, double? y) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.lineTo({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void MoveTo(double? x, double? y) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.moveTo({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void QuadraticCurveTo(double? cpx, double? cpy, double? x, double? y) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.quadraticCurveTo({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(cpx))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(cpy))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Rect(double? x, double? y, double? w, double? h) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.rect({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(w))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(h))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

