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
/// Provides access to performance-related information for the current page. It's part of the High Resolution Time API, but is enhanced by the Performance Timeline API, the Navigation Timing API, the User Timing API, and the Resource Timing API.
/// </summary>
[JsObject]
public partial class Performance: EventTarget
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public EventCounts? EventCounts
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<EventCounts>.ValueOrNullFromJs($"{_jsThis}.eventCounts");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public PerformanceNavigation? Navigation
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<PerformanceNavigation>.ValueOrNullFromJs($"{_jsThis}.navigation");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsFunc<Performance?, Event?, JsObject?>? OnResourceTimingBufferFull
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<JsFunc<Performance?, Event?, JsObject?>>.ValueOrNullFromJs($"{_jsThis}.onresourcetimingbufferfull");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.onresourcetimingbufferfull = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? TimeOrigin
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.timeOrigin");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    [global::System.Obsolete]
    public PerformanceTiming? Timing
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<PerformanceTiming>.ValueOrNullFromJs($"{_jsThis}.timing");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void ClearMarks(string? markName) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.clearMarks({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(markName))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void ClearMeasures(string? measureName) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.clearMeasures({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(measureName))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void ClearResourceTimings() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.clearResourceTimings()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsArray<PerformanceEntry>? GetEntries() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<PerformanceEntry>>.ValueOrNullFromJs($"{_jsThis}.getEntries()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsArray<PerformanceEntry>? GetEntriesByName(string? name, string? type) => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<PerformanceEntry>>.ValueOrNullFromJs($"{_jsThis}.getEntriesByName({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(name))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsArray<PerformanceEntry>? GetEntriesByType(string? type) => global::Trungnt2910.Browser.WebAssemblyRuntime<JsArray<PerformanceEntry>>.ValueOrNullFromJs($"{_jsThis}.getEntriesByType({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(type))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public PerformanceMark? Mark(string? markName, PerformanceMarkOptions? markOptions) => global::Trungnt2910.Browser.WebAssemblyRuntime<PerformanceMark>.ValueOrNullFromJs($"{_jsThis}.mark({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(markName))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(markOptions))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public PerformanceMeasure? Measure(string? measureName, Union<string, PerformanceMeasureOptions>? startOrMeasureOptions, string? endMark) => global::Trungnt2910.Browser.WebAssemblyRuntime<PerformanceMeasure>.ValueOrNullFromJs($"{_jsThis}.measure({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(measureName))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(startOrMeasureOptions))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(endMark))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public double? Now() => global::Trungnt2910.Browser.WebAssemblyRuntime.doubleOrNullFromJs($"{_jsThis}.now()");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public void SetResourceTimingBufferSize(double? maxSize) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setResourceTimingBufferSize({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(maxSize))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public JsObject? ToJSON() => global::Trungnt2910.Browser.WebAssemblyRuntime<JsObject>.ValueOrNullFromJs($"{_jsThis}.toJSON()");
    
    
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
    public event EventHandler<Event?> ResourceTimingBufferFull
    {
        add => AddEventListener("resourcetimingbufferfull", value);
        remove => RemoveEventListener("resourcetimingbufferfull", value);
    }
    
}
#pragma warning restore CS0108, CS8764, CS8766

