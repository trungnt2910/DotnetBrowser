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
/// A generic interface for representing an audio processing module. Examples include:
/// </summary>
[JsObject]
public partial class AudioNode: EventTarget
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? ChannelCount
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.channelCount");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.channelCount = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? ChannelCountMode
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.channelCountMode");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.channelCountMode = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? ChannelInterpretation
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.channelInterpretation");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.channelInterpretation = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public BaseAudioContext? Context
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<BaseAudioContext>.ValueOrNullFromJs($"{_jsThis}.context");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? NumberOfInputs
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.numberOfInputs");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? NumberOfOutputs
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.numberOfOutputs");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AudioNode? Connect(AudioNode? destinationNode, double? output, double? input) => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioNode>.ValueOrNullFromJs($"{_jsThis}.connect({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(destinationNode))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(output))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(input))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Connect(AudioParam? destinationParam, double? output) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.connect({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(destinationParam))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(output))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Disconnect() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.disconnect()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Disconnect(double? output) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.disconnect({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(output))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Disconnect(AudioNode? destinationNode) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.disconnect({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(destinationNode))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Disconnect(AudioNode? destinationNode, double? output) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.disconnect({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(destinationNode))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(output))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Disconnect(AudioNode? destinationNode, double? output, double? input) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.disconnect({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(destinationNode))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(output))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(input))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Disconnect(AudioParam? destinationParam) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.disconnect({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(destinationParam))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Disconnect(AudioParam? destinationParam, double? output) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.disconnect({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(destinationParam))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(output))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

