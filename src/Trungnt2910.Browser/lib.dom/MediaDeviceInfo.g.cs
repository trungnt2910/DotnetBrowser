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
/// The MediaDevicesInfo interface contains information that describes a single media input or output device.
/// Available only in secure contexts.
/// </summary>
[JsObject]
public partial class MediaDeviceInfo: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? DeviceId
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.deviceId");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? GroupId
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.groupId");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? Kind
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.kind");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? Label
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.label");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsObject? ToJSON() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsObject>.ValueOrNullFromJs($"{_jsThis}.toJSON()");
    
}
#pragma warning restore CS0108, CS8764, CS8766
