using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser.Dom;

/// <summary>
/// The DOM <see cref="Node"/> interface is an abstract base class upon which many other DOM API objects are based, thus letting those object types to be used similarly and often interchangeably.
/// </summary>
[JsObject]
[Method<Node, Node>("appendChild", "AppendChild", Param1 = "childNode", Comments = "Adds the specified <paramref name=\"childNode\"/> argument as the last child to the current node. If the argument referenced an existing node on the DOM tree, the node will be detached from its current position and attached at the new position.")]
public partial class Node: JsObject
{
}
