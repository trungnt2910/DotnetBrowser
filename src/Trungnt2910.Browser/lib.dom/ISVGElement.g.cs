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
/// All of the SVG DOM interfaces that correspond directly to elements in the SVG language derive from the SVGElement interface.
/// </summary>
public interface ISVGElement: IElement, IDocumentAndElementEventHandlers, IElementCSSInlineStyle, IGlobalEventHandlers, IHTMLOrSVGElement
{
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public JsObject? ClassName { get; }
    /// <summary>
    /// To be added.
    /// </summary>
    public SVGSVGElement? OwnerSVGElement { get; }
    /// <summary>
    /// To be added.
    /// </summary>
    public SVGElement? ViewportElement { get; }
    /// <summary>
    /// To be added.
    /// </summary>
    public void AddEventListener(string? type, Union<EventListener, EventListenerObject>? listener, Union<bool, AddEventListenerOptions>? options);
    /// <summary>
    /// To be added.
    /// </summary>
    public void RemoveEventListener(string? type, Union<EventListener, EventListenerObject>? listener, Union<bool, EventListenerOptions>? options);
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> FullscreenChange;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> FullscreenError;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ClipboardEvent?> Copy;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ClipboardEvent?> Cut;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ClipboardEvent?> Paste;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<UIEvent?> WhenAborted;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<AnimationEvent?> AnimationCancel;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<AnimationEvent?> AnimationEnd;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<AnimationEvent?> AnimationIteration;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<AnimationEvent?> AnimationStart;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<MouseEvent?> AuxClick;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<InputEvent?> BeforeInput;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<FocusEvent?> Blurred;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> CanPlay;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> CanPlayThrough;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Change;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<MouseEvent?> Clicked;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> WhenClosed;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<CompositionEvent?> CompositionEnd;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<CompositionEvent?> CompositionStart;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<CompositionEvent?> CompositionUpdate;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<MouseEvent?> ContextMenu;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> CueChange;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<MouseEvent?> DblClick;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<DragEvent?> Drag;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<DragEvent?> DragEnd;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<DragEvent?> DragEnter;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<DragEvent?> DragLeave;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<DragEvent?> DragOver;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<DragEvent?> DragStart;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<DragEvent?> Drop;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> DurationChange;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Emptied;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> WhenEnded;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ErrorEvent?> Errored;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<FocusEvent?> Focused;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<FocusEvent?> FocusIn;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<FocusEvent?> FocusOut;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<FormDataEvent?> FormData;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<PointerEvent?> GotPointerCapture;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Input;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Invalid;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<KeyboardEvent?> KeyDown;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<KeyboardEvent?> KeyPress;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<KeyboardEvent?> KeyUp;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Loaded;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> LoadedData;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> LoadedMetadata;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> LoadStart;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<PointerEvent?> LostPointerCapture;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<MouseEvent?> MouseDown;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<MouseEvent?> MouseEnter;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<MouseEvent?> MouseLeave;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<MouseEvent?> MouseMove;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<MouseEvent?> MouseOut;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<MouseEvent?> MouseOver;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<MouseEvent?> MouseUp;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> WhenPaused;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> WhenPlayed;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Playing;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<PointerEvent?> PointerCancel;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<PointerEvent?> PointerDown;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<PointerEvent?> PointerEnter;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<PointerEvent?> PointerLeave;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<PointerEvent?> PointerMove;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<PointerEvent?> PointerOut;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<PointerEvent?> PointerOver;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<PointerEvent?> PointerUp;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<ProgressEvent?> Progress;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> RateChange;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> WhenReset;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<UIEvent?> Resize;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Scrolled;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<SecurityPolicyViolationEvent?> SecurityPolicyViolation;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Seeked;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> WhenSeeking;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> WhenSelected;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> SelectionChange;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> SelectStart;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> SlotChange;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Stalled;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<SubmitEvent?> Submitted;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Suspend;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> TimeUpdate;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Toggle;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<TouchEvent?> TouchCancel;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<TouchEvent?> TouchEnd;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<TouchEvent?> TouchMove;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<TouchEvent?> TouchStart;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<TransitionEvent?> TransitionCancel;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<TransitionEvent?> TransitionEnd;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<TransitionEvent?> TransitionRun;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<TransitionEvent?> TransitionStart;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> VolumeChange;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> Waiting;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> WebkitAnimationEnd;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> WebkitAnimationIteration;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> WebkitAnimationStart;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<Event?> WebkitTransitionEnd;
    /// <summary>
    /// To be added.
    /// </summary>
    public event EventHandler<WheelEvent?> Wheel;
}
#pragma warning restore CS0108, CS8764, CS8766
