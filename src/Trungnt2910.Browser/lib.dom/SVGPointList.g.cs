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
public partial class SVGPointList: JsObject, global::System.Collections.Generic.IReadOnlyList<DOMPoint?>
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? Length
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.length");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? NumberOfItems
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.numberOfItems");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public DOMPoint? AppendItem(DOMPoint? newItem) => global::Trungnt2910.Browser.WebAssemblyRuntime<DOMPoint>.ValueOrNullFromJs($"{_jsThis}.appendItem({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(newItem))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Clear() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.clear()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public DOMPoint? GetItem(double? index) => global::Trungnt2910.Browser.WebAssemblyRuntime<DOMPoint>.ValueOrNullFromJs($"{_jsThis}.getItem({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public DOMPoint? Initialize(DOMPoint? newItem) => global::Trungnt2910.Browser.WebAssemblyRuntime<DOMPoint>.ValueOrNullFromJs($"{_jsThis}.initialize({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(newItem))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public DOMPoint? InsertItemBefore(DOMPoint? newItem, double? index) => global::Trungnt2910.Browser.WebAssemblyRuntime<DOMPoint>.ValueOrNullFromJs($"{_jsThis}.insertItemBefore({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(newItem))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public DOMPoint? RemoveItem(double? index) => global::Trungnt2910.Browser.WebAssemblyRuntime<DOMPoint>.ValueOrNullFromJs($"{_jsThis}.removeItem({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public DOMPoint? ReplaceItem(DOMPoint? newItem, double? index) => global::Trungnt2910.Browser.WebAssemblyRuntime<DOMPoint>.ValueOrNullFromJs($"{_jsThis}.replaceItem({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(newItem))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Runtime.CompilerServices.IndexerName("Indexer")]
    public DOMPoint? this[double index]
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<DOMPoint>.ValueOrNullFromJs($"{_jsThis}[{(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))}]");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}[{(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))}] = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <inheritdoc/>
    public int Count => global::Trungnt2910.Browser.WebAssemblyRuntime.Int32FromJs($"{_jsThis}.length");
    
    
    /// <inheritdoc/>
    [global::System.Runtime.CompilerServices.IndexerName("Indexer")]
    public DOMPoint? this[int index] => global::Trungnt2910.Browser.WebAssemblyRuntime<DOMPoint>.ValueOrNullFromJs($"{_jsThis}[{(global::Trungnt2910.Browser.JsObject.ToJsObjectString(index))}]");
    
    
    /// <inheritdoc/>
    public global::System.Collections.Generic.IEnumerator<DOMPoint?> GetEnumerator() { for (int i = 0; i < Count; ++i) yield return this[i]; }
    
    
    /// <inheritdoc/>
    global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    
}
#pragma warning restore CS0108, CS8764, CS8766
