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
public partial class MediaRecorder: EventTarget
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? AudioBitsPerSecond
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.audioBitsPerSecond");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? MimeType
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.mimeType");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<MediaRecorder?, BlobEvent?, JsObject?>? OnDataAvailable
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<MediaRecorder?, BlobEvent?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.ondataavailable");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.ondataavailable = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<MediaRecorder?, MediaRecorderErrorEvent?, JsObject?>? OnError
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<MediaRecorder?, MediaRecorderErrorEvent?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onerror");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onerror = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<MediaRecorder?, Event?, JsObject?>? OnPause
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<MediaRecorder?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onpause");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onpause = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<MediaRecorder?, Event?, JsObject?>? Onresume
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<MediaRecorder?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onresume");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onresume = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<MediaRecorder?, Event?, JsObject?>? OnStart
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<MediaRecorder?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onstart");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onstart = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<MediaRecorder?, Event?, JsObject?>? Onstop
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<MediaRecorder?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onstop");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onstop = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
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
    public MediaStream? Stream
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<MediaStream>.ValueOrNullFromJs($"{_jsThis}.stream");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? VideoBitsPerSecond
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.videoBitsPerSecond");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Pause() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.pause()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void RequestData() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.requestData()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Resume() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.resume()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Start(double? timeslice) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.start({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(timeslice))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Stop() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.stop()");
    
    
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
    public event EventHandler<BlobEvent?> DataAvailable
    {
        add
        {
            _handlersForDataAvailableOfTypeBlobEvent ??= new();
            if (_handlersForDataAvailableOfTypeBlobEvent.Count == 0) AddEventListener("dataavailable", _DispatcherForDataAvailableOfTypeBlobEvent);
            _handlersForDataAvailableOfTypeBlobEvent.Add(value);
        }
        remove
        {
            if (_handlersForDataAvailableOfTypeBlobEvent != null)
            {
                _handlersForDataAvailableOfTypeBlobEvent.Remove(value);
                if (_handlersForDataAvailableOfTypeBlobEvent.Count == 0)
                {
                    RemoveEventListener("dataavailable", _DispatcherForDataAvailableOfTypeBlobEvent);
                    _handlersForDataAvailableOfTypeBlobEvent = null;
                }
            }
        }
    }
    #region Internal event management members for DataAvailable
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<BlobEvent?>>? _handlersForDataAvailableOfTypeBlobEvent;
    private void _DispatcherForDataAvailableOfTypeBlobEvent(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<MediaRecorder>();
        foreach (var handler in _handlersForDataAvailableOfTypeBlobEvent!) handler?.Invoke(castedSender, args?.Cast<BlobEvent>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<MediaRecorderErrorEvent?> Errored
    {
        add
        {
            _handlersForErroredOfTypeMediaRecorderErrorEvent ??= new();
            if (_handlersForErroredOfTypeMediaRecorderErrorEvent.Count == 0) AddEventListener("error", _DispatcherForErroredOfTypeMediaRecorderErrorEvent);
            _handlersForErroredOfTypeMediaRecorderErrorEvent.Add(value);
        }
        remove
        {
            if (_handlersForErroredOfTypeMediaRecorderErrorEvent != null)
            {
                _handlersForErroredOfTypeMediaRecorderErrorEvent.Remove(value);
                if (_handlersForErroredOfTypeMediaRecorderErrorEvent.Count == 0)
                {
                    RemoveEventListener("error", _DispatcherForErroredOfTypeMediaRecorderErrorEvent);
                    _handlersForErroredOfTypeMediaRecorderErrorEvent = null;
                }
            }
        }
    }
    #region Internal event management members for Errored
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<MediaRecorderErrorEvent?>>? _handlersForErroredOfTypeMediaRecorderErrorEvent;
    private void _DispatcherForErroredOfTypeMediaRecorderErrorEvent(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<MediaRecorder>();
        foreach (var handler in _handlersForErroredOfTypeMediaRecorderErrorEvent!) handler?.Invoke(castedSender, args?.Cast<MediaRecorderErrorEvent>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> WhenPaused
    {
        add => AddEventListener("pause", value);
        remove => RemoveEventListener("pause", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Resumed
    {
        add => AddEventListener("resume", value);
        remove => RemoveEventListener("resume", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Started
    {
        add => AddEventListener("start", value);
        remove => RemoveEventListener("start", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Stopped
    {
        add => AddEventListener("stop", value);
        remove => RemoveEventListener("stop", value);
    }
    
}
#pragma warning restore CS0108, CS8764, CS8766

