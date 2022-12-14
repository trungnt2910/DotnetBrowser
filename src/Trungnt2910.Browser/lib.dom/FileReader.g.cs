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
/// Lets web applications asynchronously read the contents of files (or raw data buffers) stored on the user's computer, using File or Blob objects to specify the file or data to read.
/// </summary>
[JsObject]
public partial class FileReader: EventTarget
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public DOMException? Error
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<DOMException>.ValueOrNullFromJs($"{_jsThis}.error");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<FileReader?, ProgressEvent<FileReader>?, JsObject?>? OnAbort
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<FileReader?, ProgressEvent<FileReader>?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onabort");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onabort = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<FileReader?, ProgressEvent<FileReader>?, JsObject?>? OnError
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<FileReader?, ProgressEvent<FileReader>?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onerror");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onerror = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<FileReader?, ProgressEvent<FileReader>?, JsObject?>? OnLoad
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<FileReader?, ProgressEvent<FileReader>?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onload");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onload = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<FileReader?, ProgressEvent<FileReader>?, JsObject?>? OnLoadEnd
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<FileReader?, ProgressEvent<FileReader>?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onloadend");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onloadend = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<FileReader?, ProgressEvent<FileReader>?, JsObject?>? OnLoadStart
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<FileReader?, ProgressEvent<FileReader>?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onloadstart");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onloadstart = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<FileReader?, ProgressEvent<FileReader>?, JsObject?>? OnProgress
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<FileReader?, ProgressEvent<FileReader>?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onprogress");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onprogress = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? ReadyState
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.readyState");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<string, ArrayBuffer>? Result
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<string, ArrayBuffer>>.ValueOrNullFromJs($"{_jsThis}.result");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? DONE
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.DONE");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? EMPTY
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.EMPTY");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? LOADING
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.LOADING");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Abort() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.abort()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void ReadAsArrayBuffer(Blob? blob) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.readAsArrayBuffer({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(blob))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void ReadAsBinaryString(Blob? blob) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.readAsBinaryString({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(blob))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void ReadAsDataURL(Blob? blob) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.readAsDataURL({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(blob))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void ReadAsText(Blob? blob, string? encoding) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.readAsText({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(blob))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(encoding))})");
    
    
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
    public event EventHandler<ProgressEvent<FileReader>?> WhenAborted
    {
        add
        {
            _handlersForWhenAbortedOfTypeProgressEvent_FileReader_ ??= new();
            if (_handlersForWhenAbortedOfTypeProgressEvent_FileReader_.Count == 0) AddEventListener("abort", _DispatcherForWhenAbortedOfTypeProgressEvent_FileReader_);
            _handlersForWhenAbortedOfTypeProgressEvent_FileReader_.Add(value);
        }
        remove
        {
            if (_handlersForWhenAbortedOfTypeProgressEvent_FileReader_ != null)
            {
                _handlersForWhenAbortedOfTypeProgressEvent_FileReader_.Remove(value);
                if (_handlersForWhenAbortedOfTypeProgressEvent_FileReader_.Count == 0)
                {
                    RemoveEventListener("abort", _DispatcherForWhenAbortedOfTypeProgressEvent_FileReader_);
                    _handlersForWhenAbortedOfTypeProgressEvent_FileReader_ = null;
                }
            }
        }
    }
    #region Internal event management members for WhenAborted
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ProgressEvent<FileReader>?>>? _handlersForWhenAbortedOfTypeProgressEvent_FileReader_;
    private void _DispatcherForWhenAbortedOfTypeProgressEvent_FileReader_(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<FileReader>();
        foreach (var handler in _handlersForWhenAbortedOfTypeProgressEvent_FileReader_!) handler?.Invoke(castedSender, args?.Cast<ProgressEvent<FileReader>>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ProgressEvent<FileReader>?> Errored
    {
        add
        {
            _handlersForErroredOfTypeProgressEvent_FileReader_ ??= new();
            if (_handlersForErroredOfTypeProgressEvent_FileReader_.Count == 0) AddEventListener("error", _DispatcherForErroredOfTypeProgressEvent_FileReader_);
            _handlersForErroredOfTypeProgressEvent_FileReader_.Add(value);
        }
        remove
        {
            if (_handlersForErroredOfTypeProgressEvent_FileReader_ != null)
            {
                _handlersForErroredOfTypeProgressEvent_FileReader_.Remove(value);
                if (_handlersForErroredOfTypeProgressEvent_FileReader_.Count == 0)
                {
                    RemoveEventListener("error", _DispatcherForErroredOfTypeProgressEvent_FileReader_);
                    _handlersForErroredOfTypeProgressEvent_FileReader_ = null;
                }
            }
        }
    }
    #region Internal event management members for Errored
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ProgressEvent<FileReader>?>>? _handlersForErroredOfTypeProgressEvent_FileReader_;
    private void _DispatcherForErroredOfTypeProgressEvent_FileReader_(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<FileReader>();
        foreach (var handler in _handlersForErroredOfTypeProgressEvent_FileReader_!) handler?.Invoke(castedSender, args?.Cast<ProgressEvent<FileReader>>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ProgressEvent<FileReader>?> Loaded
    {
        add
        {
            _handlersForLoadedOfTypeProgressEvent_FileReader_ ??= new();
            if (_handlersForLoadedOfTypeProgressEvent_FileReader_.Count == 0) AddEventListener("load", _DispatcherForLoadedOfTypeProgressEvent_FileReader_);
            _handlersForLoadedOfTypeProgressEvent_FileReader_.Add(value);
        }
        remove
        {
            if (_handlersForLoadedOfTypeProgressEvent_FileReader_ != null)
            {
                _handlersForLoadedOfTypeProgressEvent_FileReader_.Remove(value);
                if (_handlersForLoadedOfTypeProgressEvent_FileReader_.Count == 0)
                {
                    RemoveEventListener("load", _DispatcherForLoadedOfTypeProgressEvent_FileReader_);
                    _handlersForLoadedOfTypeProgressEvent_FileReader_ = null;
                }
            }
        }
    }
    #region Internal event management members for Loaded
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ProgressEvent<FileReader>?>>? _handlersForLoadedOfTypeProgressEvent_FileReader_;
    private void _DispatcherForLoadedOfTypeProgressEvent_FileReader_(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<FileReader>();
        foreach (var handler in _handlersForLoadedOfTypeProgressEvent_FileReader_!) handler?.Invoke(castedSender, args?.Cast<ProgressEvent<FileReader>>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ProgressEvent<FileReader>?> LoadEnd
    {
        add
        {
            _handlersForLoadEndOfTypeProgressEvent_FileReader_ ??= new();
            if (_handlersForLoadEndOfTypeProgressEvent_FileReader_.Count == 0) AddEventListener("loadend", _DispatcherForLoadEndOfTypeProgressEvent_FileReader_);
            _handlersForLoadEndOfTypeProgressEvent_FileReader_.Add(value);
        }
        remove
        {
            if (_handlersForLoadEndOfTypeProgressEvent_FileReader_ != null)
            {
                _handlersForLoadEndOfTypeProgressEvent_FileReader_.Remove(value);
                if (_handlersForLoadEndOfTypeProgressEvent_FileReader_.Count == 0)
                {
                    RemoveEventListener("loadend", _DispatcherForLoadEndOfTypeProgressEvent_FileReader_);
                    _handlersForLoadEndOfTypeProgressEvent_FileReader_ = null;
                }
            }
        }
    }
    #region Internal event management members for LoadEnd
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ProgressEvent<FileReader>?>>? _handlersForLoadEndOfTypeProgressEvent_FileReader_;
    private void _DispatcherForLoadEndOfTypeProgressEvent_FileReader_(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<FileReader>();
        foreach (var handler in _handlersForLoadEndOfTypeProgressEvent_FileReader_!) handler?.Invoke(castedSender, args?.Cast<ProgressEvent<FileReader>>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ProgressEvent<FileReader>?> LoadStart
    {
        add
        {
            _handlersForLoadStartOfTypeProgressEvent_FileReader_ ??= new();
            if (_handlersForLoadStartOfTypeProgressEvent_FileReader_.Count == 0) AddEventListener("loadstart", _DispatcherForLoadStartOfTypeProgressEvent_FileReader_);
            _handlersForLoadStartOfTypeProgressEvent_FileReader_.Add(value);
        }
        remove
        {
            if (_handlersForLoadStartOfTypeProgressEvent_FileReader_ != null)
            {
                _handlersForLoadStartOfTypeProgressEvent_FileReader_.Remove(value);
                if (_handlersForLoadStartOfTypeProgressEvent_FileReader_.Count == 0)
                {
                    RemoveEventListener("loadstart", _DispatcherForLoadStartOfTypeProgressEvent_FileReader_);
                    _handlersForLoadStartOfTypeProgressEvent_FileReader_ = null;
                }
            }
        }
    }
    #region Internal event management members for LoadStart
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ProgressEvent<FileReader>?>>? _handlersForLoadStartOfTypeProgressEvent_FileReader_;
    private void _DispatcherForLoadStartOfTypeProgressEvent_FileReader_(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<FileReader>();
        foreach (var handler in _handlersForLoadStartOfTypeProgressEvent_FileReader_!) handler?.Invoke(castedSender, args?.Cast<ProgressEvent<FileReader>>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ProgressEvent<FileReader>?> Progress
    {
        add
        {
            _handlersForProgressOfTypeProgressEvent_FileReader_ ??= new();
            if (_handlersForProgressOfTypeProgressEvent_FileReader_.Count == 0) AddEventListener("progress", _DispatcherForProgressOfTypeProgressEvent_FileReader_);
            _handlersForProgressOfTypeProgressEvent_FileReader_.Add(value);
        }
        remove
        {
            if (_handlersForProgressOfTypeProgressEvent_FileReader_ != null)
            {
                _handlersForProgressOfTypeProgressEvent_FileReader_.Remove(value);
                if (_handlersForProgressOfTypeProgressEvent_FileReader_.Count == 0)
                {
                    RemoveEventListener("progress", _DispatcherForProgressOfTypeProgressEvent_FileReader_);
                    _handlersForProgressOfTypeProgressEvent_FileReader_ = null;
                }
            }
        }
    }
    #region Internal event management members for Progress
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<ProgressEvent<FileReader>?>>? _handlersForProgressOfTypeProgressEvent_FileReader_;
    private void _DispatcherForProgressOfTypeProgressEvent_FileReader_(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<FileReader>();
        foreach (var handler in _handlersForProgressOfTypeProgressEvent_FileReader_!) handler?.Invoke(castedSender, args?.Cast<ProgressEvent<FileReader>>());
    }
    #endregion

    
}
#pragma warning restore CS0108, CS8764, CS8766

