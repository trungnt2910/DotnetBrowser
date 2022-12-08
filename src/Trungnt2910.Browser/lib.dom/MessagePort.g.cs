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
/// This Channel Messaging API interface represents one of the two ports of a MessageChannel, allowing messages to be sent from one port and listening out for them arriving at the other.
/// </summary>
[JsObject]
public partial class MessagePort: EventTarget
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<MessagePort?, MessageEvent?, JsObject?>? OnMessage
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<MessagePort?, MessageEvent?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onmessage");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onmessage = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<MessagePort?, MessageEvent?, JsObject?>? OnMessageError
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<MessagePort?, MessageEvent?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onmessageerror");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onmessageerror = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// Disconnects the port, so that it is no longer active.
    /// </summary>
    public void Close() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.close()");
    
    
    /// <summary>
    /// Posts a message through the channel. Objects listed in transfer are transferred, not just cloned, meaning that they are no longer usable on the sending side.
    /// Throws a "DataCloneError" DOMException if transfer contains duplicate objects or port, or if message could not be cloned.
    /// </summary>
    public void PostMessage(JsObject? message, JsArray<Union<ArrayBuffer, MessagePort, ImageBitmap>>? transfer) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.postMessage({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(message))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(transfer))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void PostMessage(JsObject? message, StructuredSerializeOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.postMessage({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(message))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// Begins dispatching messages received on the port.
    /// </summary>
    public void Start() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.start()");
    
    
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
    public event EventHandler<MessageEvent?> Message
    {
        add
        {
            _handlersForMessageOfTypeMessageEvent ??= new();
            if (_handlersForMessageOfTypeMessageEvent.Count == 0) AddEventListener("message", _DispatcherForMessageOfTypeMessageEvent);
            _handlersForMessageOfTypeMessageEvent.Add(value);
        }
        remove
        {
            if (_handlersForMessageOfTypeMessageEvent != null)
            {
                _handlersForMessageOfTypeMessageEvent.Remove(value);
                if (_handlersForMessageOfTypeMessageEvent.Count == 0)
                {
                    RemoveEventListener("message", _DispatcherForMessageOfTypeMessageEvent);
                    _handlersForMessageOfTypeMessageEvent = null;
                }
            }
        }
    }
    #region Internal event management members for Message
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<MessageEvent?>>? _handlersForMessageOfTypeMessageEvent;
    private void _DispatcherForMessageOfTypeMessageEvent(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<MessagePort>();
        foreach (var handler in _handlersForMessageOfTypeMessageEvent!) handler?.Invoke(castedSender, args?.Cast<MessageEvent>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<MessageEvent?> MessageError
    {
        add
        {
            _handlersForMessageErrorOfTypeMessageEvent ??= new();
            if (_handlersForMessageErrorOfTypeMessageEvent.Count == 0) AddEventListener("messageerror", _DispatcherForMessageErrorOfTypeMessageEvent);
            _handlersForMessageErrorOfTypeMessageEvent.Add(value);
        }
        remove
        {
            if (_handlersForMessageErrorOfTypeMessageEvent != null)
            {
                _handlersForMessageErrorOfTypeMessageEvent.Remove(value);
                if (_handlersForMessageErrorOfTypeMessageEvent.Count == 0)
                {
                    RemoveEventListener("messageerror", _DispatcherForMessageErrorOfTypeMessageEvent);
                    _handlersForMessageErrorOfTypeMessageEvent = null;
                }
            }
        }
    }
    #region Internal event management members for MessageError
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<MessageEvent?>>? _handlersForMessageErrorOfTypeMessageEvent;
    private void _DispatcherForMessageErrorOfTypeMessageEvent(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<MessagePort>();
        foreach (var handler in _handlersForMessageErrorOfTypeMessageEvent!) handler?.Invoke(castedSender, args?.Cast<MessageEvent>());
    }
    #endregion

    
}
#pragma warning restore CS0108, CS8764, CS8766
