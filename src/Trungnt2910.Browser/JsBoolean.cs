using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// A class wrapped around the JavaScript <code>boolean</code> type.
/// </summary>
[JsObject]
public partial class JsBoolean : JsObject
{
    /// <summary>
    /// Converts the <see cref="JsBoolean"/> to a C# <see cref="bool"/>
    /// </summary>
    /// <param name="boolean">A <see cref="JsBoolean"/></param>
    public static implicit operator bool(JsBoolean boolean)
    {
        return WebAssemblyRuntime.BooleanFromJs(boolean._jsThis);
    }
}
