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
/// The legacy PerformanceNavigation interface represents information about how the navigation to the current document was done.
/// </summary>
[global::System.Obsolete("This interface is deprecated in the Navigation Timing Level 2 specification. Please use the PerformanceNavigationTiming interface instead.")]
[JsObject]
public partial class PerformanceNavigation: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public double? RedirectCount
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.redirectCount");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public double? Type
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.type");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? TYPE_BACK_FORWARD
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.TYPE_BACK_FORWARD");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? TYPE_NAVIGATE
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.TYPE_NAVIGATE");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? TYPE_RELOAD
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.TYPE_RELOAD");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? TYPE_RESERVED
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.TYPE_RESERVED");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public JsObject? ToJSON() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsObject>.ValueOrNullFromJs($"{_jsThis}.toJSON()");
    
}
#pragma warning restore CS0108, CS8764, CS8766

