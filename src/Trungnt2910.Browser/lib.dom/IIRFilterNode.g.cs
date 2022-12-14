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
/// The IIRFilterNode interface of the Web Audio API is a AudioNode processor which implements a general infinite impulse response (IIR)  filter; this type of filter can be used to implement tone control devices and graphic equalizers as well. It lets the parameters of the filter response be specified, so that it can be tuned as needed.
/// </summary>
[JsObject]
public partial class IIRFilterNode: AudioNode
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void GetFrequencyResponse(Float32Array? frequencyHz, Float32Array? magResponse, Float32Array? phaseResponse) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.getFrequencyResponse({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(frequencyHz))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(magResponse))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(phaseResponse))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

