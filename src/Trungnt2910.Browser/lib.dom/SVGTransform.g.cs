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
/// SVGTransform is the interface for one of the component transformations within an SVGTransformList; thus, an SVGTransform object corresponds to a single component (e.g., scale(…) or matrix(…)) within a transform attribute.
/// </summary>
[JsObject]
public partial class SVGTransform: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? Angle
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.angle");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public DOMMatrix? Matrix
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<DOMMatrix>.ValueOrNullFromJs($"{_jsThis}.matrix");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? Type
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.type");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? SVG_TRANSFORM_MATRIX
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.SVG_TRANSFORM_MATRIX");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? SVG_TRANSFORM_ROTATE
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.SVG_TRANSFORM_ROTATE");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? SVG_TRANSFORM_SCALE
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.SVG_TRANSFORM_SCALE");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? SVG_TRANSFORM_SKEWX
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.SVG_TRANSFORM_SKEWX");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? SVG_TRANSFORM_SKEWY
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.SVG_TRANSFORM_SKEWY");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? SVG_TRANSFORM_TRANSLATE
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.SVG_TRANSFORM_TRANSLATE");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? SVG_TRANSFORM_UNKNOWN
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.SVG_TRANSFORM_UNKNOWN");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetMatrix(DOMMatrix2DInit? matrix) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setMatrix({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(matrix))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetRotate(double? angle, double? cx, double? cy) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setRotate({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(angle))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(cx))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(cy))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetScale(double? sx, double? sy) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setScale({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(sx))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(sy))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetSkewX(double? angle) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setSkewX({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(angle))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetSkewY(double? angle) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setSkewY({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(angle))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetTranslate(double? tx, double? ty) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setTranslate({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(tx))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(ty))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

