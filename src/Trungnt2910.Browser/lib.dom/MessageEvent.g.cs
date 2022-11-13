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
/// A message received by a target object.
/// </summary>
[JsObject]
public partial class MessageEvent<T>: Event
{
    
    /// <summary>
    /// Returns the data of the message.
    /// </summary>
    public T? Data
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<T>.ValueOrNullFromJs($"{_jsThis}.data");
    }
    
    
    /// <summary>
    /// Returns the last event ID string, for server-sent events.
    /// </summary>
    public string? LastEventId
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.lastEventId");
    }
    
    
    /// <summary>
    /// Returns the origin of the message, for server-sent events and cross-document messaging.
    /// </summary>
    public string? Origin
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.origin");
    }
    
    
    /// <summary>
    /// Returns the MessagePort array sent with the message, for cross-document messaging and channel messaging.
    /// </summary>
    public ReadonlyArray<MessagePort>? Ports
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<ReadonlyArray<MessagePort>>.ValueOrNullFromJs($"{_jsThis}.ports");
    }
    
    
    /// <summary>
    /// Returns the WindowProxy of the source window, for cross-document messaging, and the MessagePort being attached, in the connect event fired at SharedWorkerGlobalScope objects.
    /// </summary>
    public Union<Window, MessagePort, ServiceWorker>? Source
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<Window, MessagePort, ServiceWorker>>.ValueOrNullFromJs($"{_jsThis}.source");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public void InitMessageEvent(string? type, bool? bubbles, bool? cancelable, JsObject? data, string? origin, string? lastEventId, Union<Window, MessagePort, ServiceWorker>? source, JsArray<MessagePort>? ports) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.initMessageEvent({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(bubbles))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(cancelable))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(data))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(origin))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(lastEventId))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(source))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(ports))})");
    
}
/// <summary>
/// A message received by a target object.
/// </summary>
[JsObject]
public partial class MessageEvent: Event
{
    
    /// <summary>
    /// Returns the data of the message.
    /// </summary>
    public JsObject? Data
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsObject>.ValueOrNullFromJs($"{_jsThis}.data");
    }
    
    
    /// <summary>
    /// Returns the last event ID string, for server-sent events.
    /// </summary>
    public string? LastEventId
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.lastEventId");
    }
    
    
    /// <summary>
    /// Returns the origin of the message, for server-sent events and cross-document messaging.
    /// </summary>
    public string? Origin
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.origin");
    }
    
    
    /// <summary>
    /// Returns the MessagePort array sent with the message, for cross-document messaging and channel messaging.
    /// </summary>
    public ReadonlyArray<MessagePort>? Ports
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<ReadonlyArray<MessagePort>>.ValueOrNullFromJs($"{_jsThis}.ports");
    }
    
    
    /// <summary>
    /// Returns the WindowProxy of the source window, for cross-document messaging, and the MessagePort being attached, in the connect event fired at SharedWorkerGlobalScope objects.
    /// </summary>
    public Union<Window, MessagePort, ServiceWorker>? Source
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<Window, MessagePort, ServiceWorker>>.ValueOrNullFromJs($"{_jsThis}.source");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public void InitMessageEvent(string? type, bool? bubbles, bool? cancelable, JsObject? data, string? origin, string? lastEventId, Union<Window, MessagePort, ServiceWorker>? source, JsArray<MessagePort>? ports) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.initMessageEvent({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(bubbles))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(cancelable))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(data))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(origin))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(lastEventId))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(source))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(ports))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766
