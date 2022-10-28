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
/// A set of space-separated tokens. Such a set is returned by Element.classList, HTMLLinkElement.relList, HTMLAnchorElement.relList, HTMLAreaElement.relList, HTMLIframeElement.sandbox, or HTMLOutputElement.htmlFor. It is indexed beginning with 0 as with JavaScript Array objects. DOMTokenList is always case-sensitive.
/// </summary>
[JsObject]
public partial class DOMTokenList: JsObject, global::System.Collections.Generic.IReadOnlyList<string?>
{
    
    /// <summary>
    /// Returns the number of tokens.
    /// </summary>
    public double? Length
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.length");
    }
    
    
    /// <summary>
    /// Returns the associated set as string.
    /// Can be set, to change the associated attribute.
    /// </summary>
    public string? Value
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.value");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.value = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public override string? ToString() => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.toString()");
    
    
    /// <summary>
    /// Adds all arguments passed, except those already present.
    /// Throws a "SyntaxError" DOMException if one of the arguments is the empty string.
    /// Throws an "InvalidCharacterError" DOMException if one of the arguments contains any ASCII whitespace.
    /// </summary>
    public void Add(params string?[]? tokens) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.add({(string.Join(",", global::System.Linq.Enumerable.Select(tokens ?? global::System.Array.Empty<string>(), __arg => global::Trungnt2910.Browser.JsObject.ToJsObjectString(__arg))))})");
    
    
    /// <summary>
    /// Returns true if token is present, and false otherwise.
    /// </summary>
    public bool? Contains(string? token) => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.contains({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(token))})");
    
    
    /// <summary>
    /// Returns the token with index index.
    /// </summary>
    public string? Item(double? index) => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.item({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))})");
    
    
    /// <summary>
    /// Removes arguments passed, if they are present.
    /// Throws a "SyntaxError" DOMException if one of the arguments is the empty string.
    /// Throws an "InvalidCharacterError" DOMException if one of the arguments contains any ASCII whitespace.
    /// </summary>
    public void Remove(params string?[]? tokens) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.remove({(string.Join(",", global::System.Linq.Enumerable.Select(tokens ?? global::System.Array.Empty<string>(), __arg => global::Trungnt2910.Browser.JsObject.ToJsObjectString(__arg))))})");
    
    
    /// <summary>
    /// Replaces token with newToken.
    /// Returns true if token was replaced with newToken, and false otherwise.
    /// Throws a "SyntaxError" DOMException if one of the arguments is the empty string.
    /// Throws an "InvalidCharacterError" DOMException if one of the arguments contains any ASCII whitespace.
    /// </summary>
    public bool? Replace(string? token, string? newToken) => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.replace({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(token))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(newToken))})");
    
    
    /// <summary>
    /// Returns true if token is in the associated attribute's supported tokens. Returns false otherwise.
    /// Throws a TypeError if the associated attribute has no supported tokens defined.
    /// </summary>
    public bool? Supports(string? token) => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.supports({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(token))})");
    
    
    /// <summary>
    /// If force is not given, "toggles" token, removing it if it's present and adding it if it's not present. If force is true, adds token (same as add()). If force is false, removes token (same as remove()).
    /// Returns true if token is now present, and false otherwise.
    /// Throws a "SyntaxError" DOMException if token is empty.
    /// Throws an "InvalidCharacterError" DOMException if token contains any spaces.
    /// </summary>
    public bool? Toggle(string? token, bool? force) => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.toggle({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(token))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(force))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void ForEach(JsAction<string?, double?, DOMTokenList?>? callbackfn, JsObject? thisArg) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.forEach({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(callbackfn))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(thisArg))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Runtime.CompilerServices.IndexerName("Indexer")]
    public string? this[double index]
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}[{(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))}]");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}[{(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))}] = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <inheritdoc/>
    public int Count => global::Trungnt2910.Browser.WebAssemblyRuntime.Int32FromJs($"{_jsThis}.length");
    
    
    /// <inheritdoc/>
    [global::System.Runtime.CompilerServices.IndexerName("Indexer")]
    public string? this[int index] => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}[{(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))}]");
    
    
    /// <inheritdoc/>
    public global::System.Collections.Generic.IEnumerator<string?> GetEnumerator() { for (int i = 0; i < Count; ++i) yield return this[i]; }
    
    
    /// <inheritdoc/>
    global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    
}
#pragma warning restore CS0108, CS8764, CS8766

