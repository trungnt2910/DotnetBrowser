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
/// This Web Speech API interface is the controller interface for the speech service; this can be used to retrieve information about the synthesis voices available on the device, start and pause speech, and other commands besides.
/// </summary>
[JsObject]
public partial class SpeechSynthesis: EventTarget
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<SpeechSynthesis?, Event?, JsObject?>? OnVoicesChanged
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<SpeechSynthesis?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onvoiceschanged");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onvoiceschanged = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? Paused
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.paused");
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
    public bool? Speaking
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.speaking");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Cancel() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.cancel()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsArray<SpeechSynthesisVoice>? GetVoices() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<SpeechSynthesisVoice>>.ValueOrNullFromJs($"{_jsThis}.getVoices()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Pause() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.pause()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Resume() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.resume()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Speak(SpeechSynthesisUtterance? utterance) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.speak({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(utterance))})");
    
    
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
    public event EventHandler<Event?> VoicesChanged
    {
        add => AddEventListener("voiceschanged", value);
        remove => RemoveEventListener("voiceschanged", value);
    }
    
}
#pragma warning restore CS0108, CS8764, CS8766

