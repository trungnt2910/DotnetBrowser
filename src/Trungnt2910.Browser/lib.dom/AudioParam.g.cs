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
/// The Web Audio API's AudioParam interface represents an audio-related parameter, usually a parameter of an AudioNode (such as GainNode.gain).
/// </summary>
[JsObject]
public partial class AudioParam: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? AutomationRate
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.automationRate");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.automationRate = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? DefaultValue
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.defaultValue");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? MaxValue
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.maxValue");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? MinValue
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.minValue");
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
    public AudioParam? CancelAndHoldAtTime(double? cancelTime) => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioParam>.ValueOrNullFromJs($"{_jsThis}.cancelAndHoldAtTime({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(cancelTime))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AudioParam? CancelScheduledValues(double? cancelTime) => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioParam>.ValueOrNullFromJs($"{_jsThis}.cancelScheduledValues({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(cancelTime))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AudioParam? ExponentialRampToValueAtTime(double? value, double? endTime) => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioParam>.ValueOrNullFromJs($"{_jsThis}.exponentialRampToValueAtTime({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(endTime))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AudioParam? LinearRampToValueAtTime(double? value, double? endTime) => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioParam>.ValueOrNullFromJs($"{_jsThis}.linearRampToValueAtTime({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(endTime))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AudioParam? SetTargetAtTime(double? target, double? startTime, double? timeConstant) => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioParam>.ValueOrNullFromJs($"{_jsThis}.setTargetAtTime({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(target))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(startTime))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(timeConstant))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AudioParam? SetValueAtTime(double? value, double? startTime) => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioParam>.ValueOrNullFromJs($"{_jsThis}.setValueAtTime({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(startTime))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AudioParam? SetValueCurveAtTime(Union<JsArray<double>, Float32Array>? values, double? startTime, double? duration) => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioParam>.ValueOrNullFromJs($"{_jsThis}.setValueCurveAtTime({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(values))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(startTime))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(duration))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

