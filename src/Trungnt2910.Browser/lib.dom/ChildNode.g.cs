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
[JsObject]
public partial class ChildNode: Node, IChildNode
{
    
    /// <summary>
    /// Inserts nodes just after node, while replacing strings in nodes with equivalent Text nodes.
    /// Throws a "HierarchyRequestError" DOMException if the constraints of the node tree are violated.
    /// </summary>
    public void After(params Union<INode, string>?[]? nodes) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.after({(string.Join(",", global::System.Linq.Enumerable.Select(nodes ?? global::System.Array.Empty<Union<INode, string>>(), __arg => global::Trungnt2910.Browser.JsObject.ToJsObjectString(__arg))))})");
    
    
    /// <summary>
    /// Inserts nodes just before node, while replacing strings in nodes with equivalent Text nodes.
    /// Throws a "HierarchyRequestError" DOMException if the constraints of the node tree are violated.
    /// </summary>
    public void Before(params Union<INode, string>?[]? nodes) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.before({(string.Join(",", global::System.Linq.Enumerable.Select(nodes ?? global::System.Array.Empty<Union<INode, string>>(), __arg => global::Trungnt2910.Browser.JsObject.ToJsObjectString(__arg))))})");
    
    
    /// <summary>
    /// Removes node.
    /// </summary>
    public void Remove() => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.remove()");
    
    
    /// <summary>
    /// Replaces node with nodes, while replacing strings in nodes with equivalent Text nodes.
    /// Throws a "HierarchyRequestError" DOMException if the constraints of the node tree are violated.
    /// </summary>
    public void ReplaceWith(params Union<INode, string>?[]? nodes) => global::Trungnt2910.Browser.WebAssemblyRuntime.InvokeJS($"{_jsThis}.replaceWith({(string.Join(",", global::System.Linq.Enumerable.Select(nodes ?? global::System.Array.Empty<Union<INode, string>>(), __arg => global::Trungnt2910.Browser.JsObject.ToJsObjectString(__arg))))})");
    
}
#pragma warning restore CS0108, CS8764, CS8766

