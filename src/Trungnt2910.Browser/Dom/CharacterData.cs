using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser.Dom;

/// <summary>
/// The <see cref="CharacterData"/> abstract interface represents a <see cref="Node"/> object that contains characters. 
/// This is an abstract interface, meaning there aren't any objects of type <see cref="CharacterData"/>: it is implemented by other interfaces like 
/// <see cref="Text"/>, <see cref="Comment"/>, <see cref="CDATASection"/>, or <see cref="ProcessingInstruction"/>, which aren't abstract.
/// </summary>
[JsObject]
public partial class CharacterData : Node
{
}
