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
/// NodeList objects are collections of nodes, usually returned by properties such as Node.childNodes and methods such as document.querySelectorAll().
/// </summary>
[JsObject]
public partial class NodeList: JsObject, global::System.Collections.Generic.IReadOnlyList<Node?>
{
    
    /// <summary>
    /// Returns the number of nodes in the collection.
    /// </summary>
    public double? Length
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.length");
    }
    
    
    /// <summary>
    /// Returns the node with index index from the collection. The nodes are sorted in tree order.
    /// </summary>
    public Node? Item(double? index) => global::Trungnt2910.Browser.WebAssemblyRuntime<Node>.ValueOrNullFromJs($"{_jsThis}.item({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))})");
    
    
    /// <summary>
    /// Performs the specified action for each node in an list.
    /// </summary>
    /// <param name="callbackfn">A function that accepts up to three arguments. forEach calls the callbackfn function one time for each element in the list.</param>
    /// <param name="thisArg">An object to which the this keyword can refer in the callbackfn function. If thisArg is omitted, undefined is used as the this value.</param>
    public void ForEach(JsAction<INode?, double?, NodeList?>? callbackfn, JsObject? thisArg) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.forEach({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(callbackfn))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(thisArg))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Runtime.CompilerServices.IndexerName("Indexer")]
    public Node? this[double index]
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Node>.ValueOrNullFromJs($"{_jsThis}[{(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))}]");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}[{(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))}] = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <inheritdoc/>
    public int Count => global::Trungnt2910.Browser.WebAssemblyRuntime.Int32FromJs($"{_jsThis}.length");
    
    
    /// <inheritdoc/>
    [global::System.Runtime.CompilerServices.IndexerName("Indexer")]
    public Node? this[int index] => global::Trungnt2910.Browser.WebAssemblyRuntime<Node>.ValueOrNullFromJs($"{_jsThis}[{(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))}]");
    
    
    /// <inheritdoc/>
    public global::System.Collections.Generic.IEnumerator<Node?> GetEnumerator() { for (int i = 0; i < Count; ++i) yield return this[i]; }
    
    
    /// <inheritdoc/>
    global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    
}
#pragma warning restore CS0108, CS8764, CS8766
