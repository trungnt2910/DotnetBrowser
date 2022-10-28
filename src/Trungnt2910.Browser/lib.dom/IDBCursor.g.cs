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
/// This IndexedDB API interface represents a cursor for traversing or iterating over multiple records in a database.
/// </summary>
[JsObject]
public partial class IDBCursor: JsObject
{
    
    /// <summary>
    /// Returns the direction ("next", "nextunique", "prev" or "prevunique") of the cursor.
    /// </summary>
    public string? Direction
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.direction");
    }
    
    
    /// <summary>
    /// Returns the key of the cursor. Throws a "InvalidStateError" DOMException if the cursor is advancing or is finished.
    /// </summary>
    public Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>>? Key
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>>>.ValueOrNullFromJs($"{_jsThis}.key");
    }
    
    
    /// <summary>
    /// Returns the effective key of the cursor. Throws a "InvalidStateError" DOMException if the cursor is advancing or is finished.
    /// </summary>
    public Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>>? PrimaryKey
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>>>.ValueOrNullFromJs($"{_jsThis}.primaryKey");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public IDBRequest? Request
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<IDBRequest>.ValueOrNullFromJs($"{_jsThis}.request");
    }
    
    
    /// <summary>
    /// Returns the IDBObjectStore or IDBIndex the cursor was opened from.
    /// </summary>
    public Union<IDBObjectStore, IDBIndex>? Source
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<IDBObjectStore, IDBIndex>>.ValueOrNullFromJs($"{_jsThis}.source");
    }
    
    
    /// <summary>
    /// Advances the cursor through the next count records in range.
    /// </summary>
    public void Advance(double? count) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.advance({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(count))})");
    
    
    /// <summary>
    /// Advances the cursor to the next record in range.
    /// </summary>
    public void Continue(Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>>? key) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.continue({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(key))})");
    
    
    /// <summary>
    /// Advances the cursor to the next record in range matching or after key and primaryKey. Throws an "InvalidAccessError" DOMException if the source is not an index.
    /// </summary>
    public void ContinuePrimaryKey(Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>>? key, Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>>? primaryKey) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.continuePrimaryKey({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(key))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(primaryKey))})");
    
    
    /// <summary>
    /// Delete the record pointed at by the cursor with a new value.
    /// If successful, request's result will be undefined.
    /// </summary>
    public IDBRequest? Delete() => global::Trungnt2910.Browser.WebAssemblyRuntime<IDBRequest>.ValueOrNullFromJs($"{_jsThis}.delete()");
    
    
    /// <summary>
    /// Updated the record pointed at by the cursor with a new value.
    /// Throws a "DataError" DOMException if the effective object store uses in-line keys and the key would have changed.
    /// If successful, request's result will be the record's key.
    /// </summary>
    public IDBRequest<Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>>>? Update(JsObject? value) => global::Trungnt2910.Browser.WebAssemblyRuntime<IDBRequest<Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>>>>.ValueOrNullFromJs($"{_jsThis}.update({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

