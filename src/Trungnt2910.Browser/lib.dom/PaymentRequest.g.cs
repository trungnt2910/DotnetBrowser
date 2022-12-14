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
/// This Payment Request API interface is the primary access point into the API, and lets web content and apps accept payments from the end user.
/// Available only in secure contexts.
/// </summary>
[JsObject]
public partial class PaymentRequest: EventTarget
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public string? Id
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.id");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<PaymentRequest?, Event?, JsObject?>? OnPaymentMethodChange
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<PaymentRequest?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onpaymentmethodchange");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onpaymentmethodchange = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise? Abort() => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise>.ValueOrNullFromJs($"{_jsThis}.abort()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<bool>? CanMakePayment() => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<bool>>.ValueOrNullFromJs($"{_jsThis}.canMakePayment()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<PaymentResponse>? Show(Union<PaymentDetailsUpdate, PromiseLike<PaymentDetailsUpdate>>? detailsPromise) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<PaymentResponse>>.ValueOrNullFromJs($"{_jsThis}.show({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(detailsPromise))})");
    
    
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
    public event EventHandler<Event?> PaymentMethodChange
    {
        add => AddEventListener("paymentmethodchange", value);
        remove => RemoveEventListener("paymentmethodchange", value);
    }
    
}
#pragma warning restore CS0108, CS8764, CS8766

