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
/// Used to hold the data that is being dragged during a drag and drop operation. It may hold one or more data items, each of one or more data types. For more information about drag and drop, see HTML Drag and Drop API.
/// </summary>
// [JsObject]
public partial class DataTransfer: JsObject
{
    
    /// <summary>
    /// Returns the kind of operation that is currently selected. If the kind of operation isn't one of those that is allowed by the effectAllowed attribute, then the operation will fail.
    /// Can be set, to change the selected operation.
    /// The possible values are "none", "copy", "link", and "move".
    /// </summary>
    public string? DropEffect
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.dropEffect");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.dropEffect = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// Returns the kinds of operations that are to be allowed.
    /// Can be set (during the dragstart event), to change the allowed operations.
    /// The possible values are "none", "copy", "copyLink", "copyMove", "link", "linkMove", "move", "all", and "uninitialized",
    /// </summary>
    public string? EffectAllowed
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.effectAllowed");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.effectAllowed = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// Returns a FileList of the files being dragged, if any.
    /// </summary>
    public FileList? Files
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<FileList>.ValueOrNullFromJs($"{_jsThis}.files");
    }
    
    
    /// <summary>
    /// Returns a DataTransferItemList object, with the drag data.
    /// </summary>
    public DataTransferItemList? Items
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<DataTransferItemList>.ValueOrNullFromJs($"{_jsThis}.items");
    }
    
    
    /// <summary>
    /// Returns a frozen array listing the formats that were set in the dragstart event. In addition, if any files are being dragged, then one of the types will be the string "Files".
    /// </summary>
    public ReadonlyArray<string>? Types
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<ReadonlyArray<string>>.ValueOrNullFromJs($"{_jsThis}.types");
    }
    
    
    /// <summary>
    /// Removes the data of the specified formats. Removes all data if the argument is omitted.
    /// </summary>
    public void ClearData(string? format) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.clearData({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(format))})");
    
    /* // Skipping existing member GetData
    /// <summary>
    /// Returns the specified data. If there is no such data, returns the empty string.
    /// </summary>
    public string? GetData(string? format) => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.getData({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(format))})");
    */
    
    /// <summary>
    /// Adds the specified data.
    /// </summary>
    public void SetData(string? format, string? data) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setData({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(format))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(data))})");
    
    
    /// <summary>
    /// Uses the given element to update the drag feedback, replacing any previously specified feedback.
    /// </summary>
    public void SetDragImage(IElement? image, double? x, double? y) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.setDragImage({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(image))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(x))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(y))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

