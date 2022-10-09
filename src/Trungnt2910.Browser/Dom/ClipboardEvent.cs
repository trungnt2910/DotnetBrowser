using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser.Dom;

/// <summary>
/// The <see cref="ClipboardEvent"/> interface represents events providing information related to modification of the clipboard, that is `cut`, `copy`, and `paste` events.
/// </summary>
[JsObject]
[JsObjectProperty("clipboardData", "ClipboardData", nameof(DataTransfer), Comments = "A <see cref=\"DataTransfer\"/> object containing the data affected by the user-initiated cut, copy, or paste operation, along with its MIME type.")]
public partial class ClipboardEvent : Event
{
}
