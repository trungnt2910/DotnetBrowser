using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser.Dom;

/// <summary>
/// The <see cref="DataTransfer"/> object is used to hold the data that is being dragged during a drag and drop operation. It may hold one or more data items, each of one or more data types. 
/// For more information about drag and drop, see <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTML_Drag_and_Drop_API">HTML Drag and Drop API</see>.
/// </summary>
[JsObject]
[StringMethod<string>("getData", "GetData", Param1 = "format", Comments = "Retrieves the data for a given type, or an empty string if data for that type does not exist or the data transfer contains no data.")]
public partial class DataTransfer: JsObject
{
}
