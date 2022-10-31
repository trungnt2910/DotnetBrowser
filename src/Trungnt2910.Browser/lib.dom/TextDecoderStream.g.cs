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
/// To be added.
/// </summary>
[JsObject]
public partial class TextDecoderStream: GenericTransformStream, ITextDecoderCommon
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public ReadableStream<string>? Readable
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<ReadableStream<string>>.ValueOrNullFromJs($"{_jsThis}.readable");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public WritableStream<Union<ArrayBufferView, ArrayBuffer>>? Writable
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<WritableStream<Union<ArrayBufferView, ArrayBuffer>>>.ValueOrNullFromJs($"{_jsThis}.writable");
    }
    
    
    /// <summary>
    /// Returns encoding's name, lowercased.
    /// </summary>
    public string? Encoding
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.encoding");
    }
    
    
    /// <summary>
    /// Returns true if error mode is "fatal", otherwise false.
    /// </summary>
    public bool? Fatal
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.fatal");
    }
    
    
    /// <summary>
    /// Returns the value of ignore BOM.
    /// </summary>
    public bool? IgnoreBOM
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.ignoreBOM");
    }
    
}
#pragma warning restore CS0108, CS8764, CS8766

