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
/// The CharacterData abstract interface represents a Node object that contains characters. This is an abstract interface, meaning there aren't any object of type CharacterData: it is implemented by other interfaces, like Text, Comment, or ProcessingInstruction which aren't abstract.
/// </summary>
public interface ICharacterData: INode, IChildNode, INonDocumentTypeChildNode
{
    /// <summary>
    /// To be added.
    /// </summary>
    public string? Data { get; set; }
    /// <summary>
    /// To be added.
    /// </summary>
    public double? Length { get; }
    /// <summary>
    /// To be added.
    /// </summary>
    public Document? OwnerDocument { get; }
    /// <summary>
    /// To be added.
    /// </summary>
    public void AppendData(string? data);
    /// <summary>
    /// To be added.
    /// </summary>
    public void DeleteData(double? offset, double? count);
    /// <summary>
    /// To be added.
    /// </summary>
    public void InsertData(double? offset, string? data);
    /// <summary>
    /// To be added.
    /// </summary>
    public void ReplaceData(double? offset, double? count, string? data);
    /// <summary>
    /// To be added.
    /// </summary>
    public string? SubstringData(double? offset, double? count);
}
#pragma warning restore CS0108, CS8764, CS8766
