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
/// TextEncoder takes a stream of code points as input and emits a stream of bytes. For a more scalable, non-native library, see StringView – a C-like representation of strings based on typed arrays.
/// </summary>
[JsObject]
public partial class TextEncoder: TextEncoderCommon
{
    
    /// <summary>
    /// Returns the result of running UTF-8's encoder.
    /// </summary>
    public Uint8Array? Encode(string? input) => global::Trungnt2910.Browser.WebAssemblyRuntime<Uint8Array>.ValueOrNullFromJs($"{_jsThis}.encode({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(input))})");
    
    
    /// <summary>
    /// Runs the UTF-8 encoder on source, stores the result of that operation into destination, and returns the progress made as an object wherein read is the number of converted code units of source and written is the number of bytes modified in destination.
    /// </summary>
    public TextEncoderEncodeIntoResult? EncodeInto(string? source, Uint8Array? destination) => global::Trungnt2910.Browser.WebAssemblyRuntime<TextEncoderEncodeIntoResult>.ValueOrNullFromJs($"{_jsThis}.encodeInto({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(source))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(destination))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

