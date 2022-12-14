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
/// The validity states that an element can be in, with respect to constraint validation. Together, they help explain why an element's value fails to validate, if it's not valid.
/// </summary>
[JsObject]
public partial class ValidityState: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? BadInput
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.badInput");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? CustomError
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.customError");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? PatternMismatch
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.patternMismatch");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? RangeOverflow
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.rangeOverflow");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? RangeUnderflow
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.rangeUnderflow");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? StepMismatch
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.stepMismatch");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? TooLong
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.tooLong");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? TooShort
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.tooShort");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? TypeMismatch
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.typeMismatch");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? Valid
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.valid");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? ValueMissing
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.valueMissing");
    }
    
}
#pragma warning restore CS0108, CS8764, CS8766

