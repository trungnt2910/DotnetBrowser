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
/// IDBIndex interface of the IndexedDB API provides asynchronous access to an index in a database. An index is a kind of object store for looking up records in another object store, called the referenced object store. You use this interface to retrieve data.
/// </summary>
[JsObject]
public partial class IDBIndex: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<string, JsArray<string>>? KeyPath
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<string, JsArray<string>>>.ValueOrNullFromJs($"{_jsThis}.keyPath");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? MultiEntry
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.multiEntry");
    }
    
    
    /// <summary>
    /// Returns the name of the index.
    /// </summary>
    public string? Name
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.StringOrNullFromJs($"{_jsThis}.name");
        set => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.name = {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(value))}");
    }
    
    
    /// <summary>
    /// Returns the IDBObjectStore the index belongs to.
    /// </summary>
    public IDBObjectStore? ObjectStore
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime<IDBObjectStore>.ValueOrNullFromJs($"{_jsThis}.objectStore");
    }
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? Unique
    {
        get => global::Trungnt2910.Browser.WebAssemblyRuntime.boolOrNullFromJs($"{_jsThis}.unique");
    }
    
    
    /// <summary>
    /// Retrieves the number of records matching the given key or key range in query.
    /// If successful, request's result will be the count.
    /// </summary>
    public IDBRequest<double>? Count(Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>, IDBKeyRange>? query) => global::Trungnt2910.Browser.WebAssemblyRuntime<IDBRequest<double>>.ValueOrNullFromJs($"{_jsThis}.count({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(query))})");
    
    
    /// <summary>
    /// Retrieves the value of the first record matching the given key or key range in query.
    /// If successful, request's result will be the value, or undefined if there was no matching record.
    /// </summary>
    public IDBRequest<JsObject>? Get(Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>, IDBKeyRange>? query) => global::Trungnt2910.Browser.WebAssemblyRuntime<IDBRequest<JsObject>>.ValueOrNullFromJs($"{_jsThis}.get({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(query))})");
    
    
    /// <summary>
    /// Retrieves the values of the records matching the given key or key range in query (up to count if given).
    /// If successful, request's result will be an Array of the values.
    /// </summary>
    public IDBRequest<JsArray<JsObject>>? GetAll(Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>, IDBKeyRange>? query, double? count) => global::Trungnt2910.Browser.WebAssemblyRuntime<IDBRequest<JsArray<JsObject>>>.ValueOrNullFromJs($"{_jsThis}.getAll({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(query))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(count))})");
    
    
    /// <summary>
    /// Retrieves the keys of records matching the given key or key range in query (up to count if given).
    /// If successful, request's result will be an Array of the keys.
    /// </summary>
    public IDBRequest<JsArray<Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>>>>? GetAllKeys(Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>, IDBKeyRange>? query, double? count) => global::Trungnt2910.Browser.WebAssemblyRuntime<IDBRequest<JsArray<Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>>>>>.ValueOrNullFromJs($"{_jsThis}.getAllKeys({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(query))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(count))})");
    
    
    /// <summary>
    /// Retrieves the key of the first record matching the given key or key range in query.
    /// If successful, request's result will be the key, or undefined if there was no matching record.
    /// </summary>
    public IDBRequest<Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>>>>>? GetKey(Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>, IDBKeyRange>? query) => global::Trungnt2910.Browser.WebAssemblyRuntime<IDBRequest<Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>>>>>>.ValueOrNullFromJs($"{_jsThis}.getKey({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(query))})");
    
    
    /// <summary>
    /// Opens a cursor over the records matching query, ordered by direction. If query is null, all records in index are matched.
    /// If successful, request's result will be an IDBCursorWithValue, or null if there were no matching records.
    /// </summary>
    public IDBRequest<IDBCursorWithValue>? OpenCursor(Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>, IDBKeyRange>? query, string? direction) => global::Trungnt2910.Browser.WebAssemblyRuntime<IDBRequest<IDBCursorWithValue>>.ValueOrNullFromJs($"{_jsThis}.openCursor({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(query))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(direction))})");
    
    
    /// <summary>
    /// Opens a cursor with key only flag set over the records matching query, ordered by direction. If query is null, all records in index are matched.
    /// If successful, request's result will be an IDBCursor, or null if there were no matching records.
    /// </summary>
    public IDBRequest<IDBCursor>? OpenKeyCursor(Union<double, string, Date, ArrayBufferView, ArrayBuffer, JsArray<double>, JsArray<string>, JsArray<Date>, JsArray<Union<ArrayBufferView, ArrayBuffer>>, IDBKeyRange>? query, string? direction) => global::Trungnt2910.Browser.WebAssemblyRuntime<IDBRequest<IDBCursor>>.ValueOrNullFromJs($"{_jsThis}.openKeyCursor({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(query))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(direction))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

