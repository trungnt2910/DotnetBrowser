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
/// A PannerNode always has exactly one input and one output: the input can be mono or stereo but the output is always stereo (2 channels); you can't have panning effects without at least two audio channels!
/// </summary>
[JsObject]
public partial class PannerNode: AudioNode
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? ConeInnerAngle
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.coneInnerAngle");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.coneInnerAngle = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? ConeOuterAngle
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.coneOuterAngle");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.coneOuterAngle = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? ConeOuterGain
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.coneOuterGain");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.coneOuterGain = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? DistanceModel
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.distanceModel");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.distanceModel = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? MaxDistance
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.maxDistance");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.maxDistance = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AudioParam? OrientationX
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioParam>.ValueOrNullFromJs($"{_jsThis}.orientationX");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AudioParam? OrientationY
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioParam>.ValueOrNullFromJs($"{_jsThis}.orientationY");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AudioParam? OrientationZ
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioParam>.ValueOrNullFromJs($"{_jsThis}.orientationZ");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? PanningModel
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.panningModel");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.panningModel = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AudioParam? PositionX
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioParam>.ValueOrNullFromJs($"{_jsThis}.positionX");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AudioParam? PositionY
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioParam>.ValueOrNullFromJs($"{_jsThis}.positionY");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AudioParam? PositionZ
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<AudioParam>.ValueOrNullFromJs($"{_jsThis}.positionZ");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? RefDistance
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.refDistance");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.refDistance = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? RolloffFactor
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.rolloffFactor");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.rolloffFactor = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public void SetOrientation(double? x, double? y, double? z) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setOrientation({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(z))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public void SetPosition(double? x, double? y, double? z) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setPosition({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(z))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766
