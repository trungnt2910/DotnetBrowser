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
/// An object able to programmatically obtain the position of the device. It gives Web content access to the location of the device. This allows a Web site or app to offer customized results based on the user's location.
/// </summary>
[JsObject]
public partial class Geolocation: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void ClearWatch(double? watchId) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.clearWatch({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(watchId))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void GetCurrentPosition(PositionCallback? successCallback, PositionErrorCallback? errorCallback, PositionOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.getCurrentPosition({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(successCallback))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(errorCallback))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? WatchPosition(PositionCallback? successCallback, PositionErrorCallback? errorCallback, PositionOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.watchPosition({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(successCallback))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(errorCallback))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

