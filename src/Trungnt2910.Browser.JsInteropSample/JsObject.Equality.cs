using SystemJSObject = System.Runtime.InteropServices.JavaScript.JSObject;

namespace Trungnt2910.Browser;

public partial class JsObject
{
    /// <summary>
    /// Compares two JavaScript objects for reference equality.
    /// </summary>
    /// <param name="left">The first object.</param>
    /// <param name="right">The second object.</param>
    /// <returns><see langword="true"/> if the two objects refers to the same underlying JavaScript object.</returns>
    public static bool operator ==(JsObject? left, JsObject? right)
    {
        return left?._jsHandle == right?._jsHandle;
    }

    /// <summary>
    /// Checks if the two <see cref="JsObject"/> refers to different underlying JavaScript objects.
    /// </summary>
    /// <param name="left">The first object.</param>
    /// <param name="right">The second object.</param>
    /// <returns>The result of the comparision.</returns>
    public static bool operator !=(JsObject? left, JsObject? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Checks if the current <see cref="JsObject"/> is equal to <paramref name="obj"/>.
    /// </summary>
    /// <param name="obj">Any object.</param>
    /// <returns><see langword="true"/> if <paramref name="obj"/> is an equivalent <see cref="JsObject"/> or <see cref="SystemJSObject"/>.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is JsObject jsObject)
        {
            return this == jsObject;
        }
        else if (obj is SystemJSObject systemJSObject)
        {
            return this == FromSystemJSObject(systemJSObject);
        }
        return false;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return _jsHandle;
    }
}
