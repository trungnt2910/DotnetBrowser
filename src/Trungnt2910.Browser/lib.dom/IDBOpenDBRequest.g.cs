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
/// Also inherits methods from its parents IDBRequest and EventTarget.
/// </summary>
[JsObject]
public partial class IDBOpenDBRequest: IDBRequest<IDBDatabase>
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<IDBOpenDBRequest?, Event?, JsObject?>? OnBlocked
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<IDBOpenDBRequest?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onblocked");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onblocked = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<IDBOpenDBRequest?, IDBVersionChangeEvent?, JsObject?>? OnUpgradeNeeded
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<IDBOpenDBRequest?, IDBVersionChangeEvent?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onupgradeneeded");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onupgradeneeded = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
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
    public event EventHandler<Event?> Success
    {
        add => AddEventListener("success", value);
        remove => RemoveEventListener("success", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Blocked
    {
        add => AddEventListener("blocked", value);
        remove => RemoveEventListener("blocked", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<IDBVersionChangeEvent?> UpgradeNeeded
    {
        add
        {
            _handlersForUpgradeNeededOfTypeIDBVersionChangeEvent ??= new();
            if (_handlersForUpgradeNeededOfTypeIDBVersionChangeEvent.Count == 0) AddEventListener("upgradeneeded", _DispatcherForUpgradeNeededOfTypeIDBVersionChangeEvent);
            _handlersForUpgradeNeededOfTypeIDBVersionChangeEvent.Add(value);
        }
        remove
        {
            if (_handlersForUpgradeNeededOfTypeIDBVersionChangeEvent != null)
            {
                _handlersForUpgradeNeededOfTypeIDBVersionChangeEvent.Remove(value);
                if (_handlersForUpgradeNeededOfTypeIDBVersionChangeEvent.Count == 0)
                {
                    RemoveEventListener("upgradeneeded", _DispatcherForUpgradeNeededOfTypeIDBVersionChangeEvent);
                    _handlersForUpgradeNeededOfTypeIDBVersionChangeEvent = null;
                }
            }
        }
    }
    #region Internal event management members for UpgradeNeeded
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<IDBVersionChangeEvent?>>? _handlersForUpgradeNeededOfTypeIDBVersionChangeEvent;
    private void _DispatcherForUpgradeNeededOfTypeIDBVersionChangeEvent(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<IDBOpenDBRequest>();
        foreach (var handler in _handlersForUpgradeNeededOfTypeIDBVersionChangeEvent!) handler?.Invoke(castedSender, args?.Cast<IDBVersionChangeEvent>());
    }
    #endregion

    
}
#pragma warning restore CS0108, CS8764, CS8766

