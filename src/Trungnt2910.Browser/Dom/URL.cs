using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser.Dom;

/// <summary>
/// The <see cref="URL"/> interface is used to parse, construct, normalize, and encode URLs. It works by providing properties which allow you to easily read and modify the components of a URL.
/// </summary>
[JsObject]
[StringProperty("search", "Search", Comments = "A string indicating the URL's parameter string; if any parameters are provided, this string includes all of them, beginning with the leading ? character.")]
[JsObjectReadOnlyProperty("searchParams", "SearchParams", nameof(URLSearchParams), Comments = "A <see cref=\"URLSearchParams\"/> object which can be used to access the individual query parameters found in <see cref=\"Search\"/>.")]
public partial class URL: JsObject
{
}
