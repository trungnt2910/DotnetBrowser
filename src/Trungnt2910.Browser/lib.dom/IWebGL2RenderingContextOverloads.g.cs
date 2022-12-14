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
public interface IWebGL2RenderingContextOverloads
{
    /// <summary>
    /// To be added.
    /// </summary>
    public void BufferData(double? target, double? size, double? usage);
    /// <summary>
    /// To be added.
    /// </summary>
    public void BufferData(double? target, Union<ArrayBufferView, ArrayBuffer>? srcData, double? usage);
    /// <summary>
    /// To be added.
    /// </summary>
    public void BufferData(double? target, ArrayBufferView? srcData, double? usage, double? srcOffset, double? length);
    /// <summary>
    /// To be added.
    /// </summary>
    public void BufferSubData(double? target, double? dstByteOffset, Union<ArrayBufferView, ArrayBuffer>? srcData);
    /// <summary>
    /// To be added.
    /// </summary>
    public void BufferSubData(double? target, double? dstByteOffset, ArrayBufferView? srcData, double? srcOffset, double? length);
    /// <summary>
    /// To be added.
    /// </summary>
    public void CompressedTexImage2D(double? target, double? level, double? internalformat, double? width, double? height, double? border, double? imageSize, double? offset);
    /// <summary>
    /// To be added.
    /// </summary>
    public void CompressedTexImage2D(double? target, double? level, double? internalformat, double? width, double? height, double? border, ArrayBufferView? srcData, double? srcOffset, double? srcLengthOverride);
    /// <summary>
    /// To be added.
    /// </summary>
    public void CompressedTexSubImage2D(double? target, double? level, double? xoffset, double? yoffset, double? width, double? height, double? format, double? imageSize, double? offset);
    /// <summary>
    /// To be added.
    /// </summary>
    public void CompressedTexSubImage2D(double? target, double? level, double? xoffset, double? yoffset, double? width, double? height, double? format, ArrayBufferView? srcData, double? srcOffset, double? srcLengthOverride);
    /// <summary>
    /// To be added.
    /// </summary>
    public void ReadPixels(double? x, double? y, double? width, double? height, double? format, double? type, ArrayBufferView? dstData);
    /// <summary>
    /// To be added.
    /// </summary>
    public void ReadPixels(double? x, double? y, double? width, double? height, double? format, double? type, double? offset);
    /// <summary>
    /// To be added.
    /// </summary>
    public void ReadPixels(double? x, double? y, double? width, double? height, double? format, double? type, ArrayBufferView? dstData, double? dstOffset);
    /// <summary>
    /// To be added.
    /// </summary>
    public void TexImage2D(double? target, double? level, double? internalformat, double? width, double? height, double? border, double? format, double? type, ArrayBufferView? pixels);
    /// <summary>
    /// To be added.
    /// </summary>
    public void TexImage2D(double? target, double? level, double? internalformat, double? format, double? type, Union<ImageBitmap, ImageData, HTMLImageElement, HTMLCanvasElement, HTMLVideoElement>? source);
    /// <summary>
    /// To be added.
    /// </summary>
    public void TexImage2D(double? target, double? level, double? internalformat, double? width, double? height, double? border, double? format, double? type, double? pboOffset);
    /// <summary>
    /// To be added.
    /// </summary>
    public void TexImage2D(double? target, double? level, double? internalformat, double? width, double? height, double? border, double? format, double? type, Union<ImageBitmap, ImageData, HTMLImageElement, HTMLCanvasElement, HTMLVideoElement>? source);
    /// <summary>
    /// To be added.
    /// </summary>
    public void TexImage2D(double? target, double? level, double? internalformat, double? width, double? height, double? border, double? format, double? type, ArrayBufferView? srcData, double? srcOffset);
    /// <summary>
    /// To be added.
    /// </summary>
    public void TexSubImage2D(double? target, double? level, double? xoffset, double? yoffset, double? width, double? height, double? format, double? type, ArrayBufferView? pixels);
    /// <summary>
    /// To be added.
    /// </summary>
    public void TexSubImage2D(double? target, double? level, double? xoffset, double? yoffset, double? format, double? type, Union<ImageBitmap, ImageData, HTMLImageElement, HTMLCanvasElement, HTMLVideoElement>? source);
    /// <summary>
    /// To be added.
    /// </summary>
    public void TexSubImage2D(double? target, double? level, double? xoffset, double? yoffset, double? width, double? height, double? format, double? type, double? pboOffset);
    /// <summary>
    /// To be added.
    /// </summary>
    public void TexSubImage2D(double? target, double? level, double? xoffset, double? yoffset, double? width, double? height, double? format, double? type, Union<ImageBitmap, ImageData, HTMLImageElement, HTMLCanvasElement, HTMLVideoElement>? source);
    /// <summary>
    /// To be added.
    /// </summary>
    public void TexSubImage2D(double? target, double? level, double? xoffset, double? yoffset, double? width, double? height, double? format, double? type, ArrayBufferView? srcData, double? srcOffset);
    /// <summary>
    /// To be added.
    /// </summary>
    public void Uniform1fv(WebGLUniformLocation? location, Union<Float32Array, JsArray<double>>? data, double? srcOffset, double? srcLength);
    /// <summary>
    /// To be added.
    /// </summary>
    public void Uniform1iv(WebGLUniformLocation? location, Union<Int32Array, JsArray<double>>? data, double? srcOffset, double? srcLength);
    /// <summary>
    /// To be added.
    /// </summary>
    public void Uniform2fv(WebGLUniformLocation? location, Union<Float32Array, JsArray<double>>? data, double? srcOffset, double? srcLength);
    /// <summary>
    /// To be added.
    /// </summary>
    public void Uniform2iv(WebGLUniformLocation? location, Union<Int32Array, JsArray<double>>? data, double? srcOffset, double? srcLength);
    /// <summary>
    /// To be added.
    /// </summary>
    public void Uniform3fv(WebGLUniformLocation? location, Union<Float32Array, JsArray<double>>? data, double? srcOffset, double? srcLength);
    /// <summary>
    /// To be added.
    /// </summary>
    public void Uniform3iv(WebGLUniformLocation? location, Union<Int32Array, JsArray<double>>? data, double? srcOffset, double? srcLength);
    /// <summary>
    /// To be added.
    /// </summary>
    public void Uniform4fv(WebGLUniformLocation? location, Union<Float32Array, JsArray<double>>? data, double? srcOffset, double? srcLength);
    /// <summary>
    /// To be added.
    /// </summary>
    public void Uniform4iv(WebGLUniformLocation? location, Union<Int32Array, JsArray<double>>? data, double? srcOffset, double? srcLength);
    /// <summary>
    /// To be added.
    /// </summary>
    public void UniformMatrix2fv(WebGLUniformLocation? location, bool? transpose, Union<Float32Array, JsArray<double>>? data, double? srcOffset, double? srcLength);
    /// <summary>
    /// To be added.
    /// </summary>
    public void UniformMatrix3fv(WebGLUniformLocation? location, bool? transpose, Union<Float32Array, JsArray<double>>? data, double? srcOffset, double? srcLength);
    /// <summary>
    /// To be added.
    /// </summary>
    public void UniformMatrix4fv(WebGLUniformLocation? location, bool? transpose, Union<Float32Array, JsArray<double>>? data, double? srcOffset, double? srcLength);
}
#pragma warning restore CS0108, CS8764, CS8766

