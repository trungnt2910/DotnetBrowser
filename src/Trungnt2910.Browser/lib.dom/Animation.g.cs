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
public partial class Animation: EventTarget
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? CurrentTime
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.currentTime");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.currentTime = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AnimationEffect? Effect
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<AnimationEffect>.ValueOrNullFromJs($"{_jsThis}.effect");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.effect = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<Animation>? Finished
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<Animation>>.ValueOrNullFromJs($"{_jsThis}.finished");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? Id
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.id");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.id = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<Animation?, AnimationPlaybackEvent?, JsObject?>? OnCancel
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<Animation?, AnimationPlaybackEvent?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.oncancel");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.oncancel = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<Animation?, AnimationPlaybackEvent?, JsObject?>? OnFinish
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<Animation?, AnimationPlaybackEvent?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onfinish");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onfinish = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<Animation?, Event?, JsObject?>? OnRemove
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<Animation?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onremove");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onremove = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? Pending
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.pending");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? PlayState
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.playState");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? PlaybackRate
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.playbackRate");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.playbackRate = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<Animation>? Ready
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<Animation>>.ValueOrNullFromJs($"{_jsThis}.ready");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? ReplaceState
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.replaceState");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? StartTime
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.startTime");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.startTime = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public AnimationTimeline? Timeline
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<AnimationTimeline>.ValueOrNullFromJs($"{_jsThis}.timeline");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.timeline = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Cancel() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.cancel()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void CommitStyles() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.commitStyles()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Finish() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.finish()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Pause() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.pause()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Persist() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.persist()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Play() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.play()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Reverse() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.reverse()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void UpdatePlaybackRate(double? playbackRate) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.updatePlaybackRate({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(playbackRate))})");
    
    
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
    public event EventHandler<AnimationPlaybackEvent?> Cancelled
    {
        add
        {
            _handlersForCancelledOfTypeAnimationPlaybackEvent ??= new();
            if (_handlersForCancelledOfTypeAnimationPlaybackEvent.Count == 0) AddEventListener("cancel", _DispatcherForCancelledOfTypeAnimationPlaybackEvent);
            _handlersForCancelledOfTypeAnimationPlaybackEvent.Add(value);
        }
        remove
        {
            if (_handlersForCancelledOfTypeAnimationPlaybackEvent != null)
            {
                _handlersForCancelledOfTypeAnimationPlaybackEvent.Remove(value);
                if (_handlersForCancelledOfTypeAnimationPlaybackEvent.Count == 0)
                {
                    RemoveEventListener("cancel", _DispatcherForCancelledOfTypeAnimationPlaybackEvent);
                    _handlersForCancelledOfTypeAnimationPlaybackEvent = null;
                }
            }
        }
    }
    #region Internal event management members for Cancelled
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<AnimationPlaybackEvent?>>? _handlersForCancelledOfTypeAnimationPlaybackEvent;
    private void _DispatcherForCancelledOfTypeAnimationPlaybackEvent(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<Animation>();
        foreach (var handler in _handlersForCancelledOfTypeAnimationPlaybackEvent!) handler?.Invoke(castedSender, args?.Cast<AnimationPlaybackEvent>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<AnimationPlaybackEvent?> WhenFinished
    {
        add
        {
            _handlersForWhenFinishedOfTypeAnimationPlaybackEvent ??= new();
            if (_handlersForWhenFinishedOfTypeAnimationPlaybackEvent.Count == 0) AddEventListener("finish", _DispatcherForWhenFinishedOfTypeAnimationPlaybackEvent);
            _handlersForWhenFinishedOfTypeAnimationPlaybackEvent.Add(value);
        }
        remove
        {
            if (_handlersForWhenFinishedOfTypeAnimationPlaybackEvent != null)
            {
                _handlersForWhenFinishedOfTypeAnimationPlaybackEvent.Remove(value);
                if (_handlersForWhenFinishedOfTypeAnimationPlaybackEvent.Count == 0)
                {
                    RemoveEventListener("finish", _DispatcherForWhenFinishedOfTypeAnimationPlaybackEvent);
                    _handlersForWhenFinishedOfTypeAnimationPlaybackEvent = null;
                }
            }
        }
    }
    #region Internal event management members for WhenFinished
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<AnimationPlaybackEvent?>>? _handlersForWhenFinishedOfTypeAnimationPlaybackEvent;
    private void _DispatcherForWhenFinishedOfTypeAnimationPlaybackEvent(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<Animation>();
        foreach (var handler in _handlersForWhenFinishedOfTypeAnimationPlaybackEvent!) handler?.Invoke(castedSender, args?.Cast<AnimationPlaybackEvent>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Remove
    {
        add => AddEventListener("remove", value);
        remove => RemoveEventListener("remove", value);
    }
    
}
#pragma warning restore CS0108, CS8764, CS8766
