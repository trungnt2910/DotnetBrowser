using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser.Dom;

/// <summary>
/// <see cref="Element"/> is the most general base class from which all element objects (i.e. objects that represent elements) in a <see cref="Document"/> inherit.
/// It only has methods and properties common to all kinds of elements. More specific classes inherit from <see cref="Element"/>.
/// </summary>
[JsObject]
public partial class Element : Node
{

}
