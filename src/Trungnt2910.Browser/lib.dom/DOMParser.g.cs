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
/// Provides the ability to parse XML or HTML source code from a string into a DOM Document.
/// </summary>
[JsObject]
public partial class DOMParser: JsObject
{
    
    /// <summary>
    /// Parses string using either the HTML or XML parser, according to type, and returns the resulting Document. type can be "text/html" (which will invoke the HTML parser), or any of "text/xml", "application/xml", "application/xhtml+xml", or "image/svg+xml" (which will invoke the XML parser).
    /// For the XML parser, if string cannot be parsed, then the returned Document will contain elements describing the resulting error.
    /// Note that script elements are not evaluated during parsing, and the resulting document's encoding will always be UTF-8.
    /// Values other than the above for type will cause a TypeError exception to be thrown.
    /// </summary>
    public Document? ParseFromString(string? @string, string? type) => global::Trungnt2910.Browser.WebAssemblyRuntime<Document>.ValueOrNullFromJs($"{_jsThis}.parseFromString({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(@string))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

