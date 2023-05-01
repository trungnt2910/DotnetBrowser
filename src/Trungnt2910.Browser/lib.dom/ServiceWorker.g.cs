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
/// This ServiceWorker API interface provides a reference to a service worker. Multiple browsing contexts (e.g. pages, workers, etc.) can be associated with the same service worker, each through a unique ServiceWorker object.
/// Available only in secure contexts.
/// </summary>
[JsObject]
public partial class ServiceWorker: EventTarget, IAbstractWorker
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<ServiceWorker?, Event?, JsObject?>? OnStateChange
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<ServiceWorker?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onstatechange");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onstatechange = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? ScriptURL
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.scriptURL");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? State
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.state");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<AbstractWorker?, ErrorEvent?, JsObject?>? OnError
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<AbstractWorker?, ErrorEvent?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onerror");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onerror = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void PostMessage(JsObject? message, JsArray<Union<ArrayBuffer, MessagePort, ImageBitmap>>? transfer) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.postMessage({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(message))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(transfer))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void PostMessage(JsObject? message, StructuredSerializeOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.postMessage({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(message))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void AddEventListener(string? type, Union<EventListener, EventListenerObject>? listener, Union<bool, AddEventListenerOptions>? options) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.addEventListener({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(listener))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void RemoveEventListener(string? type, Union<EventListener, EventListenerObject>? listener, Union<bool, EventListenerOptions>? options) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.removeEventListener({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(listener))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    void IAbstractWorker.AddEventListener(string? type, Union<EventListener, EventListenerObject>? listener, Union<bool, AddEventListenerOptions>? options) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.addEventListener({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(listener))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    void IAbstractWorker.RemoveEventListener(string? type, Union<EventListener, EventListenerObject>? listener, Union<bool, EventListenerOptions>? options) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.removeEventListener({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(listener))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ErrorEvent?> Errored
    {
        add
        {
            _handlersForErroredOfTypeErrorEvent ??= new();
            if (_handlersForErroredOfTypeErrorEvent.Count == 0) AddEventListener("error", _DispatcherForErroredOfTypeErrorEvent);
            _handlersForErroredOfTypeErrorEvent.Add(value);
        }
        remove
        {
            if (_handlersForErroredOfTypeErrorEvent != null)
            {
                _handlersForErroredOfTypeErrorEvent.Remove(value);
                if (_handlersForErroredOfTypeErrorEvent.Count == 0)
                {
                    RemoveEventListener("error", _DispatcherForErroredOfTypeErrorEvent);
                    _handlersForErroredOfTypeErrorEvent = null;
                }
            }
        }
    }
    #region Internal event management members for Errored
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ErrorEvent?>>? _handlersForErroredOfTypeErrorEvent;
    private void _DispatcherForErroredOfTypeErrorEvent(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<ServiceWorker>();
        foreach (var handler in _handlersForErroredOfTypeErrorEvent!) handler?.Invoke(castedSender, args?.Cast<ErrorEvent>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> StateChange
    {
        add => AddEventListener("statechange", value);
        remove => RemoveEventListener("statechange", value);
    }
    
}
#pragma warning restore CS0108, CS8764, CS8766

