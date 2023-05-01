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
/// To be added.
/// </summary>
[JsObject]
public partial class XMLHttpRequestUpload: XMLHttpRequestEventTarget
{
    
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
    public event EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?> WhenAborted
    {
        add
        {
            _handlersForWhenAbortedOfTypeProgressEvent_XMLHttpRequestEventTarget_ ??= new();
            if (_handlersForWhenAbortedOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0) AddEventListener("abort", _DispatcherForWhenAbortedOfTypeProgressEvent_XMLHttpRequestEventTarget_);
            _handlersForWhenAbortedOfTypeProgressEvent_XMLHttpRequestEventTarget_.Add(value);
        }
        remove
        {
            if (_handlersForWhenAbortedOfTypeProgressEvent_XMLHttpRequestEventTarget_ != null)
            {
                _handlersForWhenAbortedOfTypeProgressEvent_XMLHttpRequestEventTarget_.Remove(value);
                if (_handlersForWhenAbortedOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0)
                {
                    RemoveEventListener("abort", _DispatcherForWhenAbortedOfTypeProgressEvent_XMLHttpRequestEventTarget_);
                    _handlersForWhenAbortedOfTypeProgressEvent_XMLHttpRequestEventTarget_ = null;
                }
            }
        }
    }
    #region Internal event management members for WhenAborted
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?>>? _handlersForWhenAbortedOfTypeProgressEvent_XMLHttpRequestEventTarget_;
    private void _DispatcherForWhenAbortedOfTypeProgressEvent_XMLHttpRequestEventTarget_(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<XMLHttpRequestUpload>();
        foreach (var handler in _handlersForWhenAbortedOfTypeProgressEvent_XMLHttpRequestEventTarget_!) handler?.Invoke(castedSender, args?.Cast<ProgressEvent<XMLHttpRequestEventTarget>>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?> Errored
    {
        add
        {
            _handlersForErroredOfTypeProgressEvent_XMLHttpRequestEventTarget_ ??= new();
            if (_handlersForErroredOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0) AddEventListener("error", _DispatcherForErroredOfTypeProgressEvent_XMLHttpRequestEventTarget_);
            _handlersForErroredOfTypeProgressEvent_XMLHttpRequestEventTarget_.Add(value);
        }
        remove
        {
            if (_handlersForErroredOfTypeProgressEvent_XMLHttpRequestEventTarget_ != null)
            {
                _handlersForErroredOfTypeProgressEvent_XMLHttpRequestEventTarget_.Remove(value);
                if (_handlersForErroredOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0)
                {
                    RemoveEventListener("error", _DispatcherForErroredOfTypeProgressEvent_XMLHttpRequestEventTarget_);
                    _handlersForErroredOfTypeProgressEvent_XMLHttpRequestEventTarget_ = null;
                }
            }
        }
    }
    #region Internal event management members for Errored
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?>>? _handlersForErroredOfTypeProgressEvent_XMLHttpRequestEventTarget_;
    private void _DispatcherForErroredOfTypeProgressEvent_XMLHttpRequestEventTarget_(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<XMLHttpRequestUpload>();
        foreach (var handler in _handlersForErroredOfTypeProgressEvent_XMLHttpRequestEventTarget_!) handler?.Invoke(castedSender, args?.Cast<ProgressEvent<XMLHttpRequestEventTarget>>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?> Loaded
    {
        add
        {
            _handlersForLoadedOfTypeProgressEvent_XMLHttpRequestEventTarget_ ??= new();
            if (_handlersForLoadedOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0) AddEventListener("load", _DispatcherForLoadedOfTypeProgressEvent_XMLHttpRequestEventTarget_);
            _handlersForLoadedOfTypeProgressEvent_XMLHttpRequestEventTarget_.Add(value);
        }
        remove
        {
            if (_handlersForLoadedOfTypeProgressEvent_XMLHttpRequestEventTarget_ != null)
            {
                _handlersForLoadedOfTypeProgressEvent_XMLHttpRequestEventTarget_.Remove(value);
                if (_handlersForLoadedOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0)
                {
                    RemoveEventListener("load", _DispatcherForLoadedOfTypeProgressEvent_XMLHttpRequestEventTarget_);
                    _handlersForLoadedOfTypeProgressEvent_XMLHttpRequestEventTarget_ = null;
                }
            }
        }
    }
    #region Internal event management members for Loaded
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?>>? _handlersForLoadedOfTypeProgressEvent_XMLHttpRequestEventTarget_;
    private void _DispatcherForLoadedOfTypeProgressEvent_XMLHttpRequestEventTarget_(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<XMLHttpRequestUpload>();
        foreach (var handler in _handlersForLoadedOfTypeProgressEvent_XMLHttpRequestEventTarget_!) handler?.Invoke(castedSender, args?.Cast<ProgressEvent<XMLHttpRequestEventTarget>>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?> LoadEnd
    {
        add
        {
            _handlersForLoadEndOfTypeProgressEvent_XMLHttpRequestEventTarget_ ??= new();
            if (_handlersForLoadEndOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0) AddEventListener("loadend", _DispatcherForLoadEndOfTypeProgressEvent_XMLHttpRequestEventTarget_);
            _handlersForLoadEndOfTypeProgressEvent_XMLHttpRequestEventTarget_.Add(value);
        }
        remove
        {
            if (_handlersForLoadEndOfTypeProgressEvent_XMLHttpRequestEventTarget_ != null)
            {
                _handlersForLoadEndOfTypeProgressEvent_XMLHttpRequestEventTarget_.Remove(value);
                if (_handlersForLoadEndOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0)
                {
                    RemoveEventListener("loadend", _DispatcherForLoadEndOfTypeProgressEvent_XMLHttpRequestEventTarget_);
                    _handlersForLoadEndOfTypeProgressEvent_XMLHttpRequestEventTarget_ = null;
                }
            }
        }
    }
    #region Internal event management members for LoadEnd
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?>>? _handlersForLoadEndOfTypeProgressEvent_XMLHttpRequestEventTarget_;
    private void _DispatcherForLoadEndOfTypeProgressEvent_XMLHttpRequestEventTarget_(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<XMLHttpRequestUpload>();
        foreach (var handler in _handlersForLoadEndOfTypeProgressEvent_XMLHttpRequestEventTarget_!) handler?.Invoke(castedSender, args?.Cast<ProgressEvent<XMLHttpRequestEventTarget>>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?> LoadStart
    {
        add
        {
            _handlersForLoadStartOfTypeProgressEvent_XMLHttpRequestEventTarget_ ??= new();
            if (_handlersForLoadStartOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0) AddEventListener("loadstart", _DispatcherForLoadStartOfTypeProgressEvent_XMLHttpRequestEventTarget_);
            _handlersForLoadStartOfTypeProgressEvent_XMLHttpRequestEventTarget_.Add(value);
        }
        remove
        {
            if (_handlersForLoadStartOfTypeProgressEvent_XMLHttpRequestEventTarget_ != null)
            {
                _handlersForLoadStartOfTypeProgressEvent_XMLHttpRequestEventTarget_.Remove(value);
                if (_handlersForLoadStartOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0)
                {
                    RemoveEventListener("loadstart", _DispatcherForLoadStartOfTypeProgressEvent_XMLHttpRequestEventTarget_);
                    _handlersForLoadStartOfTypeProgressEvent_XMLHttpRequestEventTarget_ = null;
                }
            }
        }
    }
    #region Internal event management members for LoadStart
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?>>? _handlersForLoadStartOfTypeProgressEvent_XMLHttpRequestEventTarget_;
    private void _DispatcherForLoadStartOfTypeProgressEvent_XMLHttpRequestEventTarget_(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<XMLHttpRequestUpload>();
        foreach (var handler in _handlersForLoadStartOfTypeProgressEvent_XMLHttpRequestEventTarget_!) handler?.Invoke(castedSender, args?.Cast<ProgressEvent<XMLHttpRequestEventTarget>>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?> Progress
    {
        add
        {
            _handlersForProgressOfTypeProgressEvent_XMLHttpRequestEventTarget_ ??= new();
            if (_handlersForProgressOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0) AddEventListener("progress", _DispatcherForProgressOfTypeProgressEvent_XMLHttpRequestEventTarget_);
            _handlersForProgressOfTypeProgressEvent_XMLHttpRequestEventTarget_.Add(value);
        }
        remove
        {
            if (_handlersForProgressOfTypeProgressEvent_XMLHttpRequestEventTarget_ != null)
            {
                _handlersForProgressOfTypeProgressEvent_XMLHttpRequestEventTarget_.Remove(value);
                if (_handlersForProgressOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0)
                {
                    RemoveEventListener("progress", _DispatcherForProgressOfTypeProgressEvent_XMLHttpRequestEventTarget_);
                    _handlersForProgressOfTypeProgressEvent_XMLHttpRequestEventTarget_ = null;
                }
            }
        }
    }
    #region Internal event management members for Progress
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?>>? _handlersForProgressOfTypeProgressEvent_XMLHttpRequestEventTarget_;
    private void _DispatcherForProgressOfTypeProgressEvent_XMLHttpRequestEventTarget_(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<XMLHttpRequestUpload>();
        foreach (var handler in _handlersForProgressOfTypeProgressEvent_XMLHttpRequestEventTarget_!) handler?.Invoke(castedSender, args?.Cast<ProgressEvent<XMLHttpRequestEventTarget>>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?> TimedOut
    {
        add
        {
            _handlersForTimedOutOfTypeProgressEvent_XMLHttpRequestEventTarget_ ??= new();
            if (_handlersForTimedOutOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0) AddEventListener("timeout", _DispatcherForTimedOutOfTypeProgressEvent_XMLHttpRequestEventTarget_);
            _handlersForTimedOutOfTypeProgressEvent_XMLHttpRequestEventTarget_.Add(value);
        }
        remove
        {
            if (_handlersForTimedOutOfTypeProgressEvent_XMLHttpRequestEventTarget_ != null)
            {
                _handlersForTimedOutOfTypeProgressEvent_XMLHttpRequestEventTarget_.Remove(value);
                if (_handlersForTimedOutOfTypeProgressEvent_XMLHttpRequestEventTarget_.Count == 0)
                {
                    RemoveEventListener("timeout", _DispatcherForTimedOutOfTypeProgressEvent_XMLHttpRequestEventTarget_);
                    _handlersForTimedOutOfTypeProgressEvent_XMLHttpRequestEventTarget_ = null;
                }
            }
        }
    }
    #region Internal event management members for TimedOut
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ProgressEvent<XMLHttpRequestEventTarget>?>>? _handlersForTimedOutOfTypeProgressEvent_XMLHttpRequestEventTarget_;
    private void _DispatcherForTimedOutOfTypeProgressEvent_XMLHttpRequestEventTarget_(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<XMLHttpRequestUpload>();
        foreach (var handler in _handlersForTimedOutOfTypeProgressEvent_XMLHttpRequestEventTarget_!) handler?.Invoke(castedSender, args?.Cast<ProgressEvent<XMLHttpRequestEventTarget>>());
    }
    #endregion

    
}
#pragma warning restore CS0108, CS8764, CS8766

