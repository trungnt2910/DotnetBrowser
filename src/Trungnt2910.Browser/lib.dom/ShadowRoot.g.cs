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
public partial class ShadowRoot: DocumentFragment, IDocumentOrShadowRoot, IHasInnerHTML
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? DelegatesFocus
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.delegatesFocus");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Element? Host
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Element>.ValueOrNullFromJs($"{_jsThis}.host");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? Mode
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.mode");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<ShadowRoot?, Event?, JsObject?>? OnSlotChange
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<ShadowRoot?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onslotchange");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onslotchange = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? SlotAssignment
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.slotAssignment");
    }
    
    
    /// <summary>
    /// Returns the deepest element in the document through which or to which key events are being routed. This is, roughly speaking, the focused element in the document.
    /// For the purposes of this API, when a child browsing context is focused, its container is focused in the parent browsing context. For example, if the user moves the focus to a text control in an iframe, the iframe is the element returned by the activeElement API in the iframe's node document.
    /// Similarly, when the focused element is in a different node tree than documentOrShadowRoot, the element returned will be the host that's located in the same node tree as documentOrShadowRoot if documentOrShadowRoot is a shadow-including inclusive ancestor of the focused element, and null if not.
    /// </summary>
    public Element? ActiveElement
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Element>.ValueOrNullFromJs($"{_jsThis}.activeElement");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsArray<CSSStyleSheet>? AdoptedStyleSheets
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<CSSStyleSheet>>.ValueOrNullFromJs($"{_jsThis}.adoptedStyleSheets");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.adoptedStyleSheets = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// Returns document's fullscreen element.
    /// </summary>
    public Element? FullscreenElement
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Element>.ValueOrNullFromJs($"{_jsThis}.fullscreenElement");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Element? PictureInPictureElement
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Element>.ValueOrNullFromJs($"{_jsThis}.pictureInPictureElement");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Element? PointerLockElement
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Element>.ValueOrNullFromJs($"{_jsThis}.pointerLockElement");
    }
    
    
    /// <summary>
    /// Retrieves a collection of styleSheet objects representing the style sheets that correspond to each instance of a link or style object in the document.
    /// </summary>
    public StyleSheetList? StyleSheets
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<StyleSheetList>.ValueOrNullFromJs($"{_jsThis}.styleSheets");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? InnerHTML
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.innerHTML");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.innerHTML = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void AddEventListener(string? type, Union<EventListener, EventListenerObject>? listener, Union<bool, AddEventListenerOptions>? options) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.addEventListener({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(listener))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void RemoveEventListener(string? type, Union<EventListener, EventListenerObject>? listener, Union<bool, EventListenerOptions>? options) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.removeEventListener({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(listener))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// Returns the element for the specified x coordinate and the specified y coordinate.
    /// </summary>
    /// <param name="x">The x-offset</param>
    /// <param name="y">The y-offset</param>
    public Element? ElementFromPoint(double? x, double? y) => global::Trungnt2910.Browser.WebAssemblyRuntime<Element>.ValueOrNullFromJs($"{_jsThis}.elementFromPoint({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsArray<Element>? ElementsFromPoint(double? x, double? y) => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<Element>>.ValueOrNullFromJs($"{_jsThis}.elementsFromPoint({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsArray<Animation>? GetAnimations() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<Animation>>.ValueOrNullFromJs($"{_jsThis}.getAnimations()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> SlotChange
    {
        add => AddEventListener("slotchange", value);
        remove => RemoveEventListener("slotchange", value);
    }
    
}
#pragma warning restore CS0108, CS8764, CS8766

