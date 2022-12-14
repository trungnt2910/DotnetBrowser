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
/// Used to represent a value that can be an &amp;lt;angle&amp;gt; or &amp;lt;number&amp;gt; value. An SVGAngle reflected through the animVal attribute is always read only.
/// </summary>
[JsObject]
public partial class SVGAngle: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? UnitType
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.unitType");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? Value
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.value");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.value = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? ValueAsString
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.valueAsString");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.valueAsString = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? ValueInSpecifiedUnits
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.valueInSpecifiedUnits");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.valueInSpecifiedUnits = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? SVG_ANGLETYPE_DEG
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.SVG_ANGLETYPE_DEG");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? SVG_ANGLETYPE_GRAD
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.SVG_ANGLETYPE_GRAD");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? SVG_ANGLETYPE_RAD
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.SVG_ANGLETYPE_RAD");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? SVG_ANGLETYPE_UNKNOWN
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.SVG_ANGLETYPE_UNKNOWN");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? SVG_ANGLETYPE_UNSPECIFIED
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.SVG_ANGLETYPE_UNSPECIFIED");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void ConvertToSpecifiedUnits(double? unitType) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.convertToSpecifiedUnits({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(unitType))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void NewValueSpecifiedUnits(double? unitType, double? valueInSpecifiedUnits) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.newValueSpecifiedUnits({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(unitType))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(valueInSpecifiedUnits))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

