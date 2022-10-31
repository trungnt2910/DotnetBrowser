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
// [JsObject]
public partial class URLSearchParams: JsObject
{
    
    /// <summary>
    /// Appends a specified key/value pair as a new search parameter.
    /// </summary>
    public void Append(string? name, string? value) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.append({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(name))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))})");
    
    
    /// <summary>
    /// Deletes the given search parameter, and its associated value, from the list of all search parameters.
    /// </summary>
    public void Delete(string? name) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.delete({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(name))})");
    
    
    /// <summary>
    /// Returns the first value associated to the given search parameter.
    /// </summary>
    public string? Get(string? name) => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.get({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(name))})");
    
    
    /// <summary>
    /// Returns all the values association with a given search parameter.
    /// </summary>
    public JsArray<string>? GetAll(string? name) => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<string>>.ValueOrNullFromJs($"{_jsThis}.getAll({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(name))})");
    
    
    /// <summary>
    /// Returns a Boolean indicating if such a search parameter exists.
    /// </summary>
    public bool? Has(string? name) => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.has({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(name))})");
    
    
    /// <summary>
    /// Sets the value associated to a given search parameter to the given value. If there were several values, delete the others.
    /// </summary>
    public void Set(string? name, string? value) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.set({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(name))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Sort() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.sort()");
    
    
    /// <summary>
    /// Returns a string containing a query string suitable for use in a URL. Does not include the question mark.
    /// </summary>
    public override string? ToString() => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.toString()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void ForEach(JsAction<string?, string?, URLSearchParams?>? callbackfn, JsObject? thisArg) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.forEach({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(callbackfn))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(thisArg))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

