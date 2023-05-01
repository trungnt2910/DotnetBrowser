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
/// This Web Crypto API interface provides a number of low-level cryptographic functions. It is accessed via the Crypto.subtle properties available in a window context (via Window.crypto).
/// Available only in secure contexts.
/// </summary>
[JsObject]
public partial class SubtleCrypto: JsObject
{
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<ArrayBuffer>? Decrypt(Union<Algorithm, string, RsaOaepParams, AesCtrParams, AesCbcParams, AesGcmParams>? algorithm, CryptoKey? key, Union<ArrayBufferView, ArrayBuffer>? data) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<ArrayBuffer>>.ValueOrNullFromJs($"{_jsThis}.decrypt({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(algorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(key))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(data))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<ArrayBuffer>? DeriveBits(Union<Algorithm, string, EcdhKeyDeriveParams, HkdfParams, Pbkdf2Params>? algorithm, CryptoKey? baseKey, double? length) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<ArrayBuffer>>.ValueOrNullFromJs($"{_jsThis}.deriveBits({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(algorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(baseKey))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(length))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<CryptoKey>? DeriveKey(Union<Algorithm, string, EcdhKeyDeriveParams, HkdfParams, Pbkdf2Params>? algorithm, CryptoKey? baseKey, Union<Algorithm, string, AesDerivedKeyParams, HmacImportParams, HkdfParams, Pbkdf2Params>? derivedKeyType, bool? extractable, JsArray<string>? keyUsages) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<CryptoKey>>.ValueOrNullFromJs($"{_jsThis}.deriveKey({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(algorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(baseKey))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(derivedKeyType))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(extractable))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(keyUsages))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<ArrayBuffer>? Digest(Union<Algorithm, string>? algorithm, Union<ArrayBufferView, ArrayBuffer>? data) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<ArrayBuffer>>.ValueOrNullFromJs($"{_jsThis}.digest({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(algorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(data))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<ArrayBuffer>? Encrypt(Union<Algorithm, string, RsaOaepParams, AesCtrParams, AesCbcParams, AesGcmParams>? algorithm, CryptoKey? key, Union<ArrayBufferView, ArrayBuffer>? data) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<ArrayBuffer>>.ValueOrNullFromJs($"{_jsThis}.encrypt({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(algorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(key))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(data))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Union<Promise<JsonWebKey>, Promise<ArrayBuffer>>? ExportKey(string? format, CryptoKey? key) => global::Trungnt2910.Browser.WebAssemblyRuntime<Union<Promise<JsonWebKey>, Promise<ArrayBuffer>>>.ValueOrNullFromJs($"{_jsThis}.exportKey({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(format))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(key))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<ArrayBuffer>? WrapKey(string? format, CryptoKey? key, CryptoKey? wrappingKey, Union<Algorithm, string, RsaOaepParams, AesCtrParams, AesCbcParams, AesGcmParams>? wrapAlgorithm) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<ArrayBuffer>>.ValueOrNullFromJs($"{_jsThis}.wrapKey({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(format))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(key))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(wrappingKey))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(wrapAlgorithm))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<CryptoKeyPair>? GenerateKey(Union<RsaHashedKeyGenParams, EcKeyGenParams>? algorithm, bool? extractable, ReadonlyArray<string>? keyUsages) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<CryptoKeyPair>>.ValueOrNullFromJs($"{_jsThis}.generateKey({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(algorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(extractable))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(keyUsages))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<CryptoKey>? GenerateKey(Union<AesKeyGenParams, HmacKeyGenParams, Pbkdf2Params>? algorithm, bool? extractable, ReadonlyArray<string>? keyUsages) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<CryptoKey>>.ValueOrNullFromJs($"{_jsThis}.generateKey({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(algorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(extractable))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(keyUsages))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<Union<CryptoKeyPair, CryptoKey>>? GenerateKey(Union<Algorithm, string>? algorithm, bool? extractable, JsArray<string>? keyUsages) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<Union<CryptoKeyPair, CryptoKey>>>.ValueOrNullFromJs($"{_jsThis}.generateKey({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(algorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(extractable))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(keyUsages))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<CryptoKey>? ImportKey(string? format, JsonWebKey? keyData, Union<Algorithm, string, RsaHashedImportParams, EcKeyImportParams, HmacImportParams, AesKeyAlgorithm>? algorithm, bool? extractable, ReadonlyArray<string>? keyUsages) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<CryptoKey>>.ValueOrNullFromJs($"{_jsThis}.importKey({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(format))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(keyData))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(algorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(extractable))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(keyUsages))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<CryptoKey>? ImportKey(string? format, Union<ArrayBufferView, ArrayBuffer>? keyData, Union<Algorithm, string, RsaHashedImportParams, EcKeyImportParams, HmacImportParams, AesKeyAlgorithm>? algorithm, bool? extractable, JsArray<string>? keyUsages) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<CryptoKey>>.ValueOrNullFromJs($"{_jsThis}.importKey({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(format))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(keyData))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(algorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(extractable))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(keyUsages))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<ArrayBuffer>? Sign(Union<Algorithm, string, RsaPssParams, EcdsaParams>? algorithm, CryptoKey? key, Union<ArrayBufferView, ArrayBuffer>? data) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<ArrayBuffer>>.ValueOrNullFromJs($"{_jsThis}.sign({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(algorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(key))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(data))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<CryptoKey>? UnwrapKey(string? format, Union<ArrayBufferView, ArrayBuffer>? wrappedKey, CryptoKey? unwrappingKey, Union<Algorithm, string, RsaOaepParams, AesCtrParams, AesCbcParams, AesGcmParams>? unwrapAlgorithm, Union<Algorithm, string, RsaHashedImportParams, EcKeyImportParams, HmacImportParams, AesKeyAlgorithm>? unwrappedKeyAlgorithm, bool? extractable, JsArray<string>? keyUsages) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<CryptoKey>>.ValueOrNullFromJs($"{_jsThis}.unwrapKey({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(format))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(wrappedKey))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(unwrappingKey))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(unwrapAlgorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(unwrappedKeyAlgorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(extractable))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(keyUsages))})");
    
    
    /// <summary>
    /// To be added.
    /// </summary>
    public Promise<bool>? Verify(Union<Algorithm, string, RsaPssParams, EcdsaParams>? algorithm, CryptoKey? key, Union<ArrayBufferView, ArrayBuffer>? signature, Union<ArrayBufferView, ArrayBuffer>? data) => global::Trungnt2910.Browser.WebAssemblyRuntime<Promise<bool>>.ValueOrNullFromJs($"{_jsThis}.verify({(global::Trungnt2910.Browser.JsObject.ToJsObjectString(algorithm))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(key))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(signature))}, {(global::Trungnt2910.Browser.JsObject.ToJsObjectString(data))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

