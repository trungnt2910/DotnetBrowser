using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser.Dom;

/// <summary>
/// The <see cref="DocumentFragment"/> interface represents a minimal document object that has no parent.
/// </summary>
/// <remarks>
/// It is used as a lightweight version of <see cref="Document"/> that stores a segment of a document structure comprised of nodes just like a standard document.
/// The key difference is due to the fact that the document fragment isn't part of the active document tree structure. Changes made to the fragment don't affect the document.
/// </remarks>
[JsObject]
public partial class DocumentFragment : Node
{

}
