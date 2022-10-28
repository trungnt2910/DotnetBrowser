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
public interface IParentNode: INode
{
    /// <summary>
    /// To be added.
    /// </summary>
    public double? ChildElementCount { get; }
    /// <summary>
    /// Returns the child elements.
    /// </summary>
    public HTMLCollection? Children { get; }
    /// <summary>
    /// Returns the first child that is an element, and null otherwise.
    /// </summary>
    public Element? FirstElementChild { get; }
    /// <summary>
    /// Returns the last child that is an element, and null otherwise.
    /// </summary>
    public Element? LastElementChild { get; }
    /// <summary>
    /// Inserts nodes after the last child of node, while replacing strings in nodes with equivalent Text nodes.
    /// Throws a "HierarchyRequestError" DOMException if the constraints of the node tree are violated.
    /// </summary>
    public void Append(params Union<INode, string>?[]? nodes);
    /// <summary>
    /// Inserts nodes before the first child of node, while replacing strings in nodes with equivalent Text nodes.
    /// Throws a "HierarchyRequestError" DOMException if the constraints of the node tree are violated.
    /// </summary>
    public void Prepend(params Union<INode, string>?[]? nodes);
    /// <summary>
    /// To be added.
    /// </summary>
    public E? QuerySelector<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] E>(string? selectors) where E: global::Trungnt2910.Browser.JsObject, IElement;
    /// <summary>
    /// To be added.
    /// </summary>
    public NodeListOf<E>? QuerySelectorAll<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] E>(string? selectors) where E: global::Trungnt2910.Browser.JsObject, IElement;
    /// <summary>
    /// Replace all children of node with nodes, while replacing strings in nodes with equivalent Text nodes.
    /// Throws a "HierarchyRequestError" DOMException if the constraints of the node tree are violated.
    /// </summary>
    public void ReplaceChildren(params Union<INode, string>?[]? nodes);
}
#pragma warning restore CS0108, CS8764, CS8766
