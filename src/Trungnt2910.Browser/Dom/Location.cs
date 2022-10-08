using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser.Dom;

/// <summary>
/// The <see cref="Location"/> interface represents the location (URL) of the object it is linked to. Changes done on it are reflected on the object it relates to.
/// </summary>
/// <remarks>
/// Both the <see cref="Document"/> and <see cref="Window"/> interface have such a linked Location, accessible via <see cref="Document.Location"/> and <see cref="Window.Location"/> respectively.
/// </remarks>
[JsObject]
[StringProperty("href", "Href", Comments = "A stringifier that returns a string containing the entire URL. If changed, the associated document navigates to the new page. It can be set from a different origin than the associated document.")]
[StringProperty("protocol", "Protocol", Comments = "A string containing the protocol scheme of the URL, including the final ':'")]
[StringProperty("host", "Host", Comments = "A string containing the host, that is the hostname, a ':', and the port of the URL.")]
[StringProperty("hostname", "Hostname", Comments = "A string containing the domain of the URL.")]
[StringProperty("port", "Port", Comments = "A string containing the port number of the URL.")]
[StringProperty("pathname", "Pathname", Comments = "A string containing an initial '/' followed by the path of the URL, not including the query string or fragment.")]
[StringProperty("search", "Search", Comments = "A string containing a '?' followed by the parameters or \"querystring\" of the URL. Modern browsers provide <see cref=\"URLSearchParams\"/> and <see cref=\"URL.SearchParams\"/> to make it easy to parse out the parameters from the querystring.")]
[StringProperty("hash", "Hash", Comments = "A string containing a '#' followed by the fragment identifier of the URL.")]
[StringReadOnlyProperty("origin", "Origin", Comments = "Returns a string containing the canonical form of the origin of the specific location.")]
public partial class Location: JsObject
{
}
