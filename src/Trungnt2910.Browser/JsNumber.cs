using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// A class wrapped around the JavaScript <code>number</code> type.
/// </summary>
[JsObject]
public partial class JsNumber : JsObject
{
    /// <summary>
    /// Converts the <see cref="JsNumber"/> to a C# <see cref="double"/>
    /// </summary>
    /// <param name="number">A <see cref="JsNumber"/></param>
    public static implicit operator double(JsNumber number)
    {
        return WebAssemblyRuntime.DoubleFromJs(number._jsThis);
    }
}
