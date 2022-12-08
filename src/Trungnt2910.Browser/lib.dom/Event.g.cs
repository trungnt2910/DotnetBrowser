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
/// An event which takes place in the DOM.
/// </summary>
// [JsObject]
public partial class Event: JsObject
{
    
    /// <summary>
    /// Returns true or false depending on how event was initialized. True if event goes through its target's ancestors in reverse tree order, and false otherwise.
    /// </summary>
    public bool? Bubbles
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.bubbles");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? CancelBubble
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.cancelBubble");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.cancelBubble = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// Returns true or false depending on how event was initialized. Its return value does not always carry meaning, but true can indicate that part of the operation during which event was dispatched, can be canceled by invoking the preventDefault() method.
    /// </summary>
    public bool? Cancelable
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.cancelable");
    }
    
    
    /// <summary>
    /// Returns true or false depending on how event was initialized. True if event invokes listeners past a ShadowRoot node that is the root of its target, and false otherwise.
    /// </summary>
    public bool? Composed
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.composed");
    }
    
    
    /// <summary>
    /// Returns the object whose event listener's callback is currently being invoked.
    /// </summary>
    public EventTarget? CurrentTarget
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<EventTarget>.ValueOrNullFromJs($"{_jsThis}.currentTarget");
    }
    
    
    /// <summary>
    /// Returns true if preventDefault() was invoked successfully to indicate cancelation, and false otherwise.
    /// </summary>
    public bool? DefaultPrevented
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.defaultPrevented");
    }
    
    
    /// <summary>
    /// Returns the event's phase, which is one of NONE, CAPTURING_PHASE, AT_TARGET, and BUBBLING_PHASE.
    /// </summary>
    public double? EventPhase
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.eventPhase");
    }
    
    
    /// <summary>
    /// Returns true if event was dispatched by the user agent, and false otherwise.
    /// </summary>
    public bool? IsTrusted
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.isTrusted");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public bool? ReturnValue
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.returnValue");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.returnValue = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public EventTarget? SrcElement
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<EventTarget>.ValueOrNullFromJs($"{_jsThis}.srcElement");
    }
    
    
    /// <summary>
    /// Returns the object to which event is dispatched (its target).
    /// </summary>
    public EventTarget? Target
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<EventTarget>.ValueOrNullFromJs($"{_jsThis}.target");
    }
    
    
    /// <summary>
    /// Returns the event's timestamp as the number of milliseconds measured relative to the time origin.
    /// </summary>
    public double? TimeStamp
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.timeStamp");
    }
    
    
    /// <summary>
    /// Returns the type of event, e.g. "click", "hashchange", or "submit".
    /// </summary>
    public string? Type
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.type");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? AT_TARGET
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.AT_TARGET");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? BUBBLING_PHASE
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.BUBBLING_PHASE");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? CAPTURING_PHASE
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.CAPTURING_PHASE");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? NONE
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.NONE");
    }
    
    
    /// <summary>
    /// Returns the invocation target objects of event's path (objects on which listeners will be invoked), except for any nodes in shadow trees of which the shadow root's mode is "closed" that are not reachable from event's currentTarget.
    /// </summary>
    public JsArray<EventTarget>? ComposedPath() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<EventTarget>>.ValueOrNullFromJs($"{_jsThis}.composedPath()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public void InitEvent(string? type, bool? bubbles, bool? cancelable) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.initEvent({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(bubbles))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(cancelable))})");
    
    
    /// <summary>
    /// If invoked when the cancelable attribute value is true, and while executing a listener for the event with passive set to false, signals to the operation that caused event to be dispatched that it needs to be canceled.
    /// </summary>
    public void PreventDefault() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.preventDefault()");
    
    
    /// <summary>
    /// Invoking this method prevents event from reaching any registered event listeners after the current one finishes running and, when dispatched in a tree, also prevents event from reaching any other objects.
    /// </summary>
    public void StopImmediatePropagation() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.stopImmediatePropagation()");
    
    
    /// <summary>
    /// When dispatched in a tree, invoking this method prevents event from reaching any objects other than the current object.
    /// </summary>
    public void StopPropagation() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.stopPropagation()");
    
}
#pragma warning restore CS0108, CS8764, CS8766
