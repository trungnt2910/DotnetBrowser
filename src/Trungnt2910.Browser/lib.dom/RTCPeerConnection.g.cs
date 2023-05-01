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
/// A WebRTC connection between the local computer and a remote peer. It provides methods to connect to a remote peer, maintain and monitor the connection, and close the connection once it's no longer needed.
/// </summary>
[JsObject]
public partial class RTCPeerConnection: EventTarget
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? CanTrickleIceCandidates
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.canTrickleIceCandidates");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? ConnectionState
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.connectionState");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public RTCSessionDescription? CurrentLocalDescription
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<RTCSessionDescription>.ValueOrNullFromJs($"{_jsThis}.currentLocalDescription");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public RTCSessionDescription? CurrentRemoteDescription
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<RTCSessionDescription>.ValueOrNullFromJs($"{_jsThis}.currentRemoteDescription");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? IceConnectionState
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.iceConnectionState");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? IceGatheringState
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.iceGatheringState");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public RTCSessionDescription? LocalDescription
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<RTCSessionDescription>.ValueOrNullFromJs($"{_jsThis}.localDescription");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<RTCPeerConnection?, Event?, JsObject?>? OnConnectionStateChange
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<RTCPeerConnection?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onconnectionstatechange");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onconnectionstatechange = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<RTCPeerConnection?, RTCDataChannelEvent?, JsObject?>? OnDataChannel
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<RTCPeerConnection?, RTCDataChannelEvent?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.ondatachannel");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.ondatachannel = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<RTCPeerConnection?, RTCPeerConnectionIceEvent?, JsObject?>? OnIceCandidate
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<RTCPeerConnection?, RTCPeerConnectionIceEvent?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onicecandidate");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onicecandidate = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<RTCPeerConnection?, Event?, JsObject?>? OnIceCandidateError
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<RTCPeerConnection?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onicecandidateerror");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onicecandidateerror = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<RTCPeerConnection?, Event?, JsObject?>? OnIceConnectionStateChange
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<RTCPeerConnection?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.oniceconnectionstatechange");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.oniceconnectionstatechange = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<RTCPeerConnection?, Event?, JsObject?>? OnIceGatheringStateChange
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<RTCPeerConnection?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onicegatheringstatechange");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onicegatheringstatechange = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<RTCPeerConnection?, Event?, JsObject?>? OnNegotiationNeeded
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<RTCPeerConnection?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onnegotiationneeded");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onnegotiationneeded = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<RTCPeerConnection?, Event?, JsObject?>? OnSignalingStateChange
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<RTCPeerConnection?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onsignalingstatechange");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onsignalingstatechange = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<RTCPeerConnection?, RTCTrackEvent?, JsObject?>? OnTrack
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<RTCPeerConnection?, RTCTrackEvent?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.ontrack");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.ontrack = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public RTCSessionDescription? PendingLocalDescription
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<RTCSessionDescription>.ValueOrNullFromJs($"{_jsThis}.pendingLocalDescription");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public RTCSessionDescription? PendingRemoteDescription
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<RTCSessionDescription>.ValueOrNullFromJs($"{_jsThis}.pendingRemoteDescription");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public RTCSessionDescription? RemoteDescription
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<RTCSessionDescription>.ValueOrNullFromJs($"{_jsThis}.remoteDescription");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public RTCSctpTransport? Sctp
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<RTCSctpTransport>.ValueOrNullFromJs($"{_jsThis}.sctp");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? SignalingState
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.signalingState");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise? AddIceCandidate(RTCIceCandidateInit? candidate) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.addIceCandidate({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(candidate))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public Promise? AddIceCandidate(RTCIceCandidateInit? candidate, VoidFunction? successCallback, RTCPeerConnectionErrorCallback? failureCallback) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.addIceCandidate({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(candidate))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(successCallback))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(failureCallback))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public RTCRtpSender? AddTrack(MediaStreamTrack? track, params MediaStream?[]? streams) => global::Trungnt2910.Browser.WebAssemblyRuntime<RTCRtpSender>.ValueOrNullFromJs($"{_jsThis}.addTrack({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(track))}, {(string.Join(",", global::System.Linq.Enumerable.Select(streams ?? global::System.Array.Empty<MediaStream>(), __arg => global::Trungnt2910.Browser.JsObject.ToJsObjectString(__arg))))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public RTCRtpTransceiver? AddTransceiver(Union<MediaStreamTrack, string>? trackOrKind, RTCRtpTransceiverInit? init) => global::Trungnt2910.Browser.WebAssemblyRuntime<RTCRtpTransceiver>.ValueOrNullFromJs($"{_jsThis}.addTransceiver({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(trackOrKind))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(init))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void Close() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.close()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<RTCSessionDescriptionInit>? CreateAnswer(RTCAnswerOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<RTCSessionDescriptionInit>>.ValueOrNullFromJs($"{_jsThis}.createAnswer({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public Promise? CreateAnswer(RTCSessionDescriptionCallback? successCallback, RTCPeerConnectionErrorCallback? failureCallback) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.createAnswer({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(successCallback))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(failureCallback))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public RTCDataChannel? CreateDataChannel(string? label, RTCDataChannelInit? dataChannelDict) => global::Trungnt2910.Browser.WebAssemblyRuntime<RTCDataChannel>.ValueOrNullFromJs($"{_jsThis}.createDataChannel({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(label))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(dataChannelDict))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<RTCSessionDescriptionInit>? CreateOffer(RTCOfferOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<RTCSessionDescriptionInit>>.ValueOrNullFromJs($"{_jsThis}.createOffer({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public Promise? CreateOffer(RTCSessionDescriptionCallback? successCallback, RTCPeerConnectionErrorCallback? failureCallback, RTCOfferOptions? options) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.createOffer({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(successCallback))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(failureCallback))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(options))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public RTCConfiguration? GetConfiguration() => global::Trungnt2910.Browser.WebAssemblyRuntime<RTCConfiguration>.ValueOrNullFromJs($"{_jsThis}.getConfiguration()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsArray<RTCRtpReceiver>? GetReceivers() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<RTCRtpReceiver>>.ValueOrNullFromJs($"{_jsThis}.getReceivers()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsArray<RTCRtpSender>? GetSenders() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<RTCRtpSender>>.ValueOrNullFromJs($"{_jsThis}.getSenders()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<RTCStatsReport>? GetStats(MediaStreamTrack? selector) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<RTCStatsReport>>.ValueOrNullFromJs($"{_jsThis}.getStats({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(selector))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsArray<RTCRtpTransceiver>? GetTransceivers() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<RTCRtpTransceiver>>.ValueOrNullFromJs($"{_jsThis}.getTransceivers()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void RemoveTrack(RTCRtpSender? sender) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.removeTrack({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(sender))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void RestartIce() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.restartIce()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetConfiguration(RTCConfiguration? configuration) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setConfiguration({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(configuration))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise? SetLocalDescription(RTCLocalSessionDescriptionInit? description) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.setLocalDescription({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(description))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public Promise? SetLocalDescription(RTCLocalSessionDescriptionInit? description, VoidFunction? successCallback, RTCPeerConnectionErrorCallback? failureCallback) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.setLocalDescription({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(description))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(successCallback))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(failureCallback))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise? SetRemoteDescription(RTCSessionDescriptionInit? description) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.setRemoteDescription({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(description))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public Promise? SetRemoteDescription(RTCSessionDescriptionInit? description, VoidFunction? successCallback, RTCPeerConnectionErrorCallback? failureCallback) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.setRemoteDescription({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(description))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(successCallback))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(failureCallback))})");
    
    
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
    public event EventHandler<Event?> ConnectionStateChange
    {
        add => AddEventListener("connectionstatechange", value);
        remove => RemoveEventListener("connectionstatechange", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<RTCDataChannelEvent?> DataChannel
    {
        add
        {
            _handlersForDataChannelOfTypeRTCDataChannelEvent ??= new();
            if (_handlersForDataChannelOfTypeRTCDataChannelEvent.Count == 0) AddEventListener("datachannel", _DispatcherForDataChannelOfTypeRTCDataChannelEvent);
            _handlersForDataChannelOfTypeRTCDataChannelEvent.Add(value);
        }
        remove
        {
            if (_handlersForDataChannelOfTypeRTCDataChannelEvent != null)
            {
                _handlersForDataChannelOfTypeRTCDataChannelEvent.Remove(value);
                if (_handlersForDataChannelOfTypeRTCDataChannelEvent.Count == 0)
                {
                    RemoveEventListener("datachannel", _DispatcherForDataChannelOfTypeRTCDataChannelEvent);
                    _handlersForDataChannelOfTypeRTCDataChannelEvent = null;
                }
            }
        }
    }
    #region Internal event management members for DataChannel
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<RTCDataChannelEvent?>>? _handlersForDataChannelOfTypeRTCDataChannelEvent;
    private void _DispatcherForDataChannelOfTypeRTCDataChannelEvent(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<RTCPeerConnection>();
        foreach (var handler in _handlersForDataChannelOfTypeRTCDataChannelEvent!) handler?.Invoke(castedSender, args?.Cast<RTCDataChannelEvent>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<RTCPeerConnectionIceEvent?> IceCandidate
    {
        add
        {
            _handlersForIceCandidateOfTypeRTCPeerConnectionIceEvent ??= new();
            if (_handlersForIceCandidateOfTypeRTCPeerConnectionIceEvent.Count == 0) AddEventListener("icecandidate", _DispatcherForIceCandidateOfTypeRTCPeerConnectionIceEvent);
            _handlersForIceCandidateOfTypeRTCPeerConnectionIceEvent.Add(value);
        }
        remove
        {
            if (_handlersForIceCandidateOfTypeRTCPeerConnectionIceEvent != null)
            {
                _handlersForIceCandidateOfTypeRTCPeerConnectionIceEvent.Remove(value);
                if (_handlersForIceCandidateOfTypeRTCPeerConnectionIceEvent.Count == 0)
                {
                    RemoveEventListener("icecandidate", _DispatcherForIceCandidateOfTypeRTCPeerConnectionIceEvent);
                    _handlersForIceCandidateOfTypeRTCPeerConnectionIceEvent = null;
                }
            }
        }
    }
    #region Internal event management members for IceCandidate
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<RTCPeerConnectionIceEvent?>>? _handlersForIceCandidateOfTypeRTCPeerConnectionIceEvent;
    private void _DispatcherForIceCandidateOfTypeRTCPeerConnectionIceEvent(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<RTCPeerConnection>();
        foreach (var handler in _handlersForIceCandidateOfTypeRTCPeerConnectionIceEvent!) handler?.Invoke(castedSender, args?.Cast<RTCPeerConnectionIceEvent>());
    }
    #endregion

    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> IceCandidateError
    {
        add => AddEventListener("icecandidateerror", value);
        remove => RemoveEventListener("icecandidateerror", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> IceConnectionStateChange
    {
        add => AddEventListener("iceconnectionstatechange", value);
        remove => RemoveEventListener("iceconnectionstatechange", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> IceGatheringStateChange
    {
        add => AddEventListener("icegatheringstatechange", value);
        remove => RemoveEventListener("icegatheringstatechange", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> NegotiationNeeded
    {
        add => AddEventListener("negotiationneeded", value);
        remove => RemoveEventListener("negotiationneeded", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> SignalingStateChange
    {
        add => AddEventListener("signalingstatechange", value);
        remove => RemoveEventListener("signalingstatechange", value);
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<RTCTrackEvent?> Track
    {
        add
        {
            _handlersForTrackOfTypeRTCTrackEvent ??= new();
            if (_handlersForTrackOfTypeRTCTrackEvent.Count == 0) AddEventListener("track", _DispatcherForTrackOfTypeRTCTrackEvent);
            _handlersForTrackOfTypeRTCTrackEvent.Add(value);
        }
        remove
        {
            if (_handlersForTrackOfTypeRTCTrackEvent != null)
            {
                _handlersForTrackOfTypeRTCTrackEvent.Remove(value);
                if (_handlersForTrackOfTypeRTCTrackEvent.Count == 0)
                {
                    RemoveEventListener("track", _DispatcherForTrackOfTypeRTCTrackEvent);
                    _handlersForTrackOfTypeRTCTrackEvent = null;
                }
            }
        }
    }
    #region Internal event management members for Track
    private global::System.Collections.Generic.HashSet<global::System.EventHandler<RTCTrackEvent?>>? _handlersForTrackOfTypeRTCTrackEvent;
    private void _DispatcherForTrackOfTypeRTCTrackEvent(object? sender, Event? args)
    {
        var castedSender = sender;
        if (sender is EventTarget eventTarget) castedSender = eventTarget.Cast<RTCPeerConnection>();
        foreach (var handler in _handlersForTrackOfTypeRTCTrackEvent!) handler?.Invoke(castedSender, args?.Cast<RTCTrackEvent>());
    }
    #endregion

    
}
#pragma warning restore CS0108, CS8764, CS8766

