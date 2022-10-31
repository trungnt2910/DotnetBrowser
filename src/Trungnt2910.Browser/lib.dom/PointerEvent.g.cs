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
/// The state of a DOM event produced by a pointer such as the geometry of the contact point, the device type that generated the event, the amount of pressure that was applied on the contact surface, etc.
/// </summary>
[JsObject]
public partial class PointerEvent: MouseEvent
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? Height
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.height");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? IsPrimary
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.isPrimary");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? PointerId
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.pointerId");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? PointerType
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.pointerType");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? Pressure
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.pressure");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? TangentialPressure
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.tangentialPressure");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? TiltX
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.tiltX");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? TiltY
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.tiltY");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? Twist
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.twist");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? Width
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.width");
    }
    
    
    /// <summary>
    /// Available only in secure contexts.
    /// </summary>
    public JsArray<PointerEvent>? GetCoalescedEvents() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<PointerEvent>>.ValueOrNullFromJs($"{_jsThis}.getCoalescedEvents()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsArray<PointerEvent>? GetPredictedEvents() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<PointerEvent>>.ValueOrNullFromJs($"{_jsThis}.getPredictedEvents()");
    
}
#pragma warning restore CS0108, CS8764, CS8766

