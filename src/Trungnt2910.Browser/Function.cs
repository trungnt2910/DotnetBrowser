using System;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// Every JavaScript function is actually a <see cref="Function"/> object. This can be seen with the code <c>(function () {}).constructor === Function</c>, which returns true.
/// </summary>
/// <remarks>
/// For strongly typed variants, see <see cref="JsAction"/> and <see cref="JsFunc"/>.
/// </remarks>
[JsObject]
public partial class Function: JsObject
{
    /// <summary>
    /// Gets a managed <see cref="Delegate"/> from this JavaScript <see cref="Function"/>.
    /// </summary>
    /// <param name="func">The function.</param>
    public static implicit operator Delegate(Function func)
    {
        return func.Invoke;
    }
}
