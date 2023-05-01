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
/// Node is an interface from which a number of DOM API object types inherit. It allows those types to be treated similarly; for example, inheriting the same set of methods, or being tested in the same way.
/// </summary>
public interface INode: IEventTarget
{
    /// <summary>
    /// Returns node's node document's document base URL.
    /// </summary>
    public string? BaseURI { get; }
    /// <summary>
    /// Returns the children.
    /// </summary>
    public NodeListOf<ChildNode>? ChildNodes { get; }
    /// <summary>
    /// Returns the first child.
    /// </summary>
    public ChildNode? FirstChild { get; }
    /// <summary>
    /// Returns true if node is connected and false otherwise.
    /// </summary>
    public bool? IsConnected { get; }
    /// <summary>
    /// Returns the last child.
    /// </summary>
    public ChildNode? LastChild { get; }
    /// <summary>
    /// Returns the next sibling.
    /// </summary>
    public ChildNode? NextSibling { get; }
    /// <summary>
    /// Returns a string appropriate for the type of node.
    /// </summary>
    public string? NodeName { get; }
    /// <summary>
    /// Returns the type of node.
    /// </summary>
    public double? NodeType { get; }
    /// <summary>
    /// To be added.
    /// </summary>
    public string? NodeValue { get; set; }
    /// <summary>
    /// Returns the node document. Returns null for documents.
    /// </summary>
    public Document? OwnerDocument { get; }
    /// <summary>
    /// Returns the parent element.
    /// </summary>
    public HTMLElement? ParentElement { get; }
    /// <summary>
    /// Returns the parent.
    /// </summary>
    public ParentNode? ParentNode { get; }
    /// <summary>
    /// Returns the previous sibling.
    /// </summary>
    public ChildNode? PreviousSibling { get; }
    /// <summary>
    /// To be added.
    /// </summary>
    public string? TextContent { get; set; }
    /// <summary>
    /// To be added.
    /// </summary>
    public double? ATTRIBUTE_NODE { get; }
    /// <summary>
    /// node is a CDATASection node.
    /// </summary>
    public double? CDATA_SECTION_NODE { get; }
    /// <summary>
    /// node is a Comment node.
    /// </summary>
    public double? COMMENT_NODE { get; }
    /// <summary>
    /// node is a DocumentFragment node.
    /// </summary>
    public double? DOCUMENT_FRAGMENT_NODE { get; }
    /// <summary>
    /// node is a document.
    /// </summary>
    public double? DOCUMENT_NODE { get; }
    /// <summary>
    /// Set when other is a descendant of node.
    /// </summary>
    public double? DOCUMENT_POSITION_CONTAINED_BY { get; }
    /// <summary>
    /// Set when other is an ancestor of node.
    /// </summary>
    public double? DOCUMENT_POSITION_CONTAINS { get; }
    /// <summary>
    /// Set when node and other are not in the same tree.
    /// </summary>
    public double? DOCUMENT_POSITION_DISCONNECTED { get; }
    /// <summary>
    /// Set when other is following node.
    /// </summary>
    public double? DOCUMENT_POSITION_FOLLOWING { get; }
    /// <summary>
    /// To be added.
    /// </summary>
    public double? DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC { get; }
    /// <summary>
    /// Set when other is preceding node.
    /// </summary>
    public double? DOCUMENT_POSITION_PRECEDING { get; }
    /// <summary>
    /// node is a doctype.
    /// </summary>
    public double? DOCUMENT_TYPE_NODE { get; }
    /// <summary>
    /// node is an element.
    /// </summary>
    public double? ELEMENT_NODE { get; }
    /// <summary>
    /// To be added.
    /// </summary>
    public double? ENTITY_NODE { get; }
    /// <summary>
    /// To be added.
    /// </summary>
    public double? ENTITY_REFERENCE_NODE { get; }
    /// <summary>
    /// To be added.
    /// </summary>
    public double? NOTATION_NODE { get; }
    /// <summary>
    /// node is a ProcessingInstruction node.
    /// </summary>
    public double? PROCESSING_INSTRUCTION_NODE { get; }
    /// <summary>
    /// node is a Text node.
    /// </summary>
    public double? TEXT_NODE { get; }
    /// <summary>
    /// To be added.
    /// </summary>
    public T? AppendChild<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>(T? node) where T: global::Trungnt2910.Browser.JsObject, INode;
    /// <summary>
    /// Returns a copy of node. If deep is true, the copy also includes the node's descendants.
    /// </summary>
    public Node? CloneNode(bool? deep);
    /// <summary>
    /// Returns a bitmask indicating the position of other relative to node.
    /// </summary>
    public double? CompareDocumentPosition(INode? other);
    /// <summary>
    /// Returns true if other is an inclusive descendant of node, and false otherwise.
    /// </summary>
    public bool? Contains(INode? other);
    /// <summary>
    /// Returns node's root.
    /// </summary>
    public Node? GetRootNode(GetRootNodeOptions? options);
    /// <summary>
    /// Returns whether node has children.
    /// </summary>
    public bool? HasChildNodes();
    /// <summary>
    /// To be added.
    /// </summary>
    public T? InsertBefore<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>(T? node, INode? child) where T: global::Trungnt2910.Browser.JsObject, INode;
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? IsDefaultNamespace(string? @namespace);
    /// <summary>
    /// Returns whether node and otherNode have the same properties.
    /// </summary>
    public bool? IsEqualNode(INode? otherNode);
    /// <summary>
    /// To be added.
    /// </summary>
    public bool? IsSameNode(INode? otherNode);
    /// <summary>
    /// To be added.
    /// </summary>
    public string? LookupNamespaceURI(string? prefix);
    /// <summary>
    /// To be added.
    /// </summary>
    public string? LookupPrefix(string? @namespace);
    /// <summary>
    /// Removes empty exclusive Text nodes and concatenates the data of remaining contiguous exclusive Text nodes into the first of their nodes.
    /// </summary>
    public void Normalize();
    /// <summary>
    /// To be added.
    /// </summary>
    public T? RemoveChild<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>(T? child) where T: global::Trungnt2910.Browser.JsObject, INode;
    /// <summary>
    /// To be added.
    /// </summary>
    public T? ReplaceChild<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>(INode? node, T? child) where T: global::Trungnt2910.Browser.JsObject, INode;
}
#pragma warning restore CS0108, CS8764, CS8766

