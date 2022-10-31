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
/// Events that occur due to the user moving a mouse wheel or similar input device.
/// </summary>
[JsObject]
public partial class WheelEvent: MouseEvent
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? DeltaMode
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.deltaMode");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? DeltaX
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.deltaX");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? DeltaY
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.deltaY");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? DeltaZ
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.deltaZ");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? DOM_DELTA_LINE
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.DOM_DELTA_LINE");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? DOM_DELTA_PAGE
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.DOM_DELTA_PAGE");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? DOM_DELTA_PIXEL
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.DOM_DELTA_PIXEL");
    }
    
}
#pragma warning restore CS0108, CS8764, CS8766

