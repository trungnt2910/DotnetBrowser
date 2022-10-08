using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser.Dom;

/// <summary>
/// The <see cref="Document"/> interface represents any web page loaded in the browser and serves as an entry point into the web page's content, which is the DOM tree.
/// </summary>
[JsObject]
[JsObjectProperty("body", "Body", nameof(HTMLElement), Comments = "Returns the &lt;body&gt; or &lt;frameset&gt; node of the current document.")]
[JsObjectReadOnlyProperty("defaultView", "DefaultView", nameof(Window), Comments = "Returns a reference to the <see cref=\"Window.Instance\"/> object.")]
[JsObjectReadOnlyProperty("location", "Location", nameof(Location), Comments = "Returns the URI of the current document.")]
[Method<Text, string>("createTextNode", "CreateTextNode", Param1 = "data", Comments = "Creates a text node.")]
public partial class Document: Node
{

}
