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
public partial class MediaTrackConstraintSet: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<double, ConstrainDoubleRange>? AspectRatio
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<double, ConstrainDoubleRange>>.ValueOrNullFromJs($"{_jsThis}.aspectRatio");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.aspectRatio = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<bool, ConstrainBooleanParameters>? AutoGainControl
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<bool, ConstrainBooleanParameters>>.ValueOrNullFromJs($"{_jsThis}.autoGainControl");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.autoGainControl = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<double, ConstrainULongRange>? ChannelCount
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<double, ConstrainULongRange>>.ValueOrNullFromJs($"{_jsThis}.channelCount");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.channelCount = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<string, JsArray<string>, ConstrainDOMStringParameters>? DeviceId
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<string, JsArray<string>, ConstrainDOMStringParameters>>.ValueOrNullFromJs($"{_jsThis}.deviceId");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.deviceId = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<bool, ConstrainBooleanParameters>? EchoCancellation
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<bool, ConstrainBooleanParameters>>.ValueOrNullFromJs($"{_jsThis}.echoCancellation");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.echoCancellation = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<string, JsArray<string>, ConstrainDOMStringParameters>? FacingMode
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<string, JsArray<string>, ConstrainDOMStringParameters>>.ValueOrNullFromJs($"{_jsThis}.facingMode");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.facingMode = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<double, ConstrainDoubleRange>? FrameRate
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<double, ConstrainDoubleRange>>.ValueOrNullFromJs($"{_jsThis}.frameRate");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.frameRate = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<string, JsArray<string>, ConstrainDOMStringParameters>? GroupId
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<string, JsArray<string>, ConstrainDOMStringParameters>>.ValueOrNullFromJs($"{_jsThis}.groupId");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.groupId = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<double, ConstrainULongRange>? Height
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<double, ConstrainULongRange>>.ValueOrNullFromJs($"{_jsThis}.height");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.height = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<double, ConstrainDoubleRange>? Latency
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<double, ConstrainDoubleRange>>.ValueOrNullFromJs($"{_jsThis}.latency");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.latency = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<bool, ConstrainBooleanParameters>? NoiseSuppression
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<bool, ConstrainBooleanParameters>>.ValueOrNullFromJs($"{_jsThis}.noiseSuppression");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.noiseSuppression = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<double, ConstrainULongRange>? SampleRate
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<double, ConstrainULongRange>>.ValueOrNullFromJs($"{_jsThis}.sampleRate");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.sampleRate = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<double, ConstrainULongRange>? SampleSize
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<double, ConstrainULongRange>>.ValueOrNullFromJs($"{_jsThis}.sampleSize");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.sampleSize = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<bool, ConstrainBooleanParameters>? SuppressLocalAudioPlayback
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<bool, ConstrainBooleanParameters>>.ValueOrNullFromJs($"{_jsThis}.suppressLocalAudioPlayback");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.suppressLocalAudioPlayback = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<double, ConstrainULongRange>? Width
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<double, ConstrainULongRange>>.ValueOrNullFromJs($"{_jsThis}.width");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.width = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
}
#pragma warning restore CS0108, CS8764, CS8766

