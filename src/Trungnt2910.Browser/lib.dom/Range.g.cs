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
/// A fragment of a document that can contain nodes and parts of text nodes.
/// </summary>
[JsObject]
public partial class Range: AbstractRange
{
    
    /// <summary>
    /// Returns the node, furthest away from the document, that is an ancestor of both range's start node and end node.
    /// </summary>
    public Node? CommonAncestorContainer
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Node>.ValueOrNullFromJs($"{_jsThis}.commonAncestorContainer");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? END_TO_END
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.END_TO_END");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? END_TO_START
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.END_TO_START");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? START_TO_END
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.START_TO_END");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? START_TO_START
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.START_TO_START");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public DocumentFragment? CloneContents() => global::Trungnt2910.Browser.WebAssemblyRuntime<DocumentFragment>.ValueOrNullFromJs($"{_jsThis}.cloneContents()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Range? CloneRange() => global::Trungnt2910.Browser.WebAssemblyRuntime<Range>.ValueOrNullFromJs($"{_jsThis}.cloneRange()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Collapse(bool? toStart) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.collapse({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(toStart))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? CompareBoundaryPoints(double? how, Range? sourceRange) => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.compareBoundaryPoints({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(how))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(sourceRange))})");
    
    
    /// <summary>
    /// Returns −1 if the point is before the range, 0 if the point is in the range, and 1 if the point is after the range.
    /// </summary>
    public double? ComparePoint(INode? node, double? offset) => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.comparePoint({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(node))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(offset))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public DocumentFragment? CreateContextualFragment(string? fragment) => global::Trungnt2910.Browser.WebAssemblyRuntime<DocumentFragment>.ValueOrNullFromJs($"{_jsThis}.createContextualFragment({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(fragment))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void DeleteContents() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.deleteContents()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Detach() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.detach()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public DocumentFragment? ExtractContents() => global::Trungnt2910.Browser.WebAssemblyRuntime<DocumentFragment>.ValueOrNullFromJs($"{_jsThis}.extractContents()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public DOMRect? GetBoundingClientRect() => global::Trungnt2910.Browser.WebAssemblyRuntime<DOMRect>.ValueOrNullFromJs($"{_jsThis}.getBoundingClientRect()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public DOMRectList? GetClientRects() => global::Trungnt2910.Browser.WebAssemblyRuntime<DOMRectList>.ValueOrNullFromJs($"{_jsThis}.getClientRects()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void InsertNode(INode? node) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.insertNode({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(node))})");
    
    
    /// <summary>
    /// Returns whether range intersects node.
    /// </summary>
    public bool? IntersectsNode(INode? node) => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.intersectsNode({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(node))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? IsPointInRange(INode? node, double? offset) => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.isPointInRange({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(node))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(offset))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SelectNode(INode? node) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.selectNode({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(node))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SelectNodeContents(INode? node) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.selectNodeContents({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(node))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetEnd(INode? node, double? offset) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setEnd({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(node))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(offset))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetEndAfter(INode? node) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setEndAfter({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(node))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetEndBefore(INode? node) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setEndBefore({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(node))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetStart(INode? node, double? offset) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setStart({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(node))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(offset))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetStartAfter(INode? node) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setStartAfter({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(node))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetStartBefore(INode? node) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setStartBefore({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(node))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SurroundContents(INode? newParent) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.surroundContents({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(newParent))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public override string? ToString() => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.toString()");
    
}
#pragma warning restore CS0108, CS8764, CS8766

