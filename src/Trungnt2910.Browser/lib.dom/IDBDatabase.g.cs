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
/// This IndexedDB API interface provides a connection to a database; you can use an IDBDatabase object to open a transaction on your database then create, manipulate, and delete objects (data) in that database. The interface provides the only way to get and manage versions of the database.
/// </summary>
[JsObject]
public partial class IDBDatabase: EventTarget
{
    
    /// <summary>
    /// Returns the name of the database.
    /// </summary>
    public string? Name
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.name");
    }
    
    
    /// <summary>
    /// Returns a list of the names of object stores in the database.
    /// </summary>
    public DOMStringList? ObjectStoreNames
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<DOMStringList>.ValueOrNullFromJs($"{_jsThis}.objectStoreNames");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<IDBDatabase?, Event?, JsObject?>? OnAbort
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<IDBDatabase?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onabort");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onabort = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<IDBDatabase?, Event?, JsObject?>? OnClose
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<IDBDatabase?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onclose");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onclose = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<IDBDatabase?, Event?, JsObject?>? OnError
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<IDBDatabase?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onerror");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onerror = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<IDBDatabase?, IDBVersionChangeEvent?, JsObject?>? OnVersionChange
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<IDBDatabase?, IDBVersionChangeEvent?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onversionchange");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onversionchange = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// Returns the version of the database.
    /// </summary>
    public double? Version
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.version");
    }
    
    
    /// <summary>
    /// Closes the connection once all running transactions have finished.
    /// </summary>
    public void Close() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.close()");
    
    
    /// <summary>
    /// Creates a new object store with the given name and options and returns a new IDBObjectStore.
    /// Throws a "InvalidStateError" DOMException if not called within an upgrade transaction.
    /// </summary>
    public IDBObjectStore? CreateObjectStore(string? name, IDBObjectStoreParameters? options) => global::Trungnt2910.Browser.WebAssemblyRuntime<IDBObjectStore>.ValueOrNullFromJs($"{_jsThis}.createObjectStore({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(name))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// Deletes the object store with the given name.
    /// Throws a "InvalidStateError" DOMException if not called within an upgrade transaction.
    /// </summary>
    public void DeleteObjectStore(string? name) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.deleteObjectStore({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(name))})");
    
    
    /// <summary>
    /// Returns a new transaction with the given mode ("readonly" or "readwrite") and scope which can be a single object store name or an array of names.
    /// </summary>
    public IDBTransaction? Transaction(Union<string, JsArray<string>>? storeNames, string? mode, IDBTransactionOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime<IDBTransaction>.ValueOrNullFromJs($"{_jsThis}.transaction({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(storeNames))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(mode))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
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
    public event EventHandler<Event?> WhenAborted
    {
        add => AddEventListener("abort", value);
        remove => RemoveEventListener("abort", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> WhenClosed
    {
        add => AddEventListener("close", value);
        remove => RemoveEventListener("close", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Errored
    {
        add => AddEventListener("error", value);
        remove => RemoveEventListener("error", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<IDBVersionChangeEvent?> VersionChange
    {
        add
        {
            _handlersForVersionChangeOfTypeIDBVersionChangeEvent ??= new();
            if (_handlersForVersionChangeOfTypeIDBVersionChangeEvent.Count == 0) AddEventListener("versionchange", _DispatcherForVersionChangeOfTypeIDBVersionChangeEvent);
            _handlersForVersionChangeOfTypeIDBVersionChangeEvent.Add(value);
        }
        remove
        {
            if (_handlersForVersionChangeOfTypeIDBVersionChangeEvent != null)
            {
                _handlersForVersionChangeOfTypeIDBVersionChangeEvent.Remove(value);
                if (_handlersForVersionChangeOfTypeIDBVersionChangeEvent.Count == 0)
                {
                    RemoveEventListener("versionchange", _DispatcherForVersionChangeOfTypeIDBVersionChangeEvent);
                    _handlersForVersionChangeOfTypeIDBVersionChangeEvent = null;
                }
            }
        }
    }
    #region Internal event management members for VersionChange
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<IDBVersionChangeEvent?>>? _handlersForVersionChangeOfTypeIDBVersionChangeEvent;
    private void _DispatcherForVersionChangeOfTypeIDBVersionChangeEvent(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<IDBDatabase>();
        foreach (var handler in _handlersForVersionChangeOfTypeIDBVersionChangeEvent!) handler?.Invoke(castedSender, args?.Cast<IDBVersionChangeEvent>());
    }
    #endregion

    
}
#pragma warning restore CS0108, CS8764, CS8766

