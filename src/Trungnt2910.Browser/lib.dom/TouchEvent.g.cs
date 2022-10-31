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
/// An event sent when the state of contacts with a touch-sensitive surface changes. This surface can be a touch screen or trackpad, for example. The event can describe one or more points of contact with the screen and includes support for detecting movement, addition and removal of contact points, and so forth.
/// </summary>
[JsObject]
public partial class TouchEvent: UIEvent
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? AltKey
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.altKey");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public TouchList? ChangedTouches
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<TouchList>.ValueOrNullFromJs($"{_jsThis}.changedTouches");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? CtrlKey
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.ctrlKey");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? MetaKey
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.metaKey");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? ShiftKey
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.shiftKey");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public TouchList? TargetTouches
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<TouchList>.ValueOrNullFromJs($"{_jsThis}.targetTouches");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public TouchList? Touches
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<TouchList>.ValueOrNullFromJs($"{_jsThis}.touches");
    }
    
}
#pragma warning restore CS0108, CS8764, CS8766

