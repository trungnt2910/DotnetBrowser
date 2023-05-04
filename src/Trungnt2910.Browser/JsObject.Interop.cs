using System.ComponentModel;
using System.Runtime.InteropServices.JavaScript;

namespace Trungnt2910.Browser;

public partial class JsObject
{
    /// <summary>
    /// Sets the value of the member <paramref name="name"/> of the JavaScript object represented by 
    /// <paramref name="handle"/> to the object represented by <paramref name="valueHandle"/>.
    /// </summary>
    /// <param name="handle">The handle of the object that owns the member.</param>
    /// <param name="name">The member name.</param>
    /// <param name="valueHandle">The handle of the desired value.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport($"globalThis.{_jsType}.{nameof(SetMember)}")]
    public static partial void SetMember(int handle, [JSMarshalAs<JSType.Any>] object name, int valueHandle);

    /// <summary>
    /// Sets the value of the member <paramref name="name"/> of the JavaScript object represented by 
    /// <paramref name="handle"/> to the object represented by <paramref name="valueHandle"/>.
    /// </summary>
    /// <param name="handle">The handle of the object that owns the member.</param>
    /// <param name="name">The member name.</param>
    /// <param name="valueHandle">The handle of the desired value.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport($"globalThis.{_jsType}.{nameof(SetMember)}")]
    public static partial void SetMember(int handle, string name, int valueHandle);

    /// <summary>
    /// Sets the value of the member <paramref name="name"/> of the JavaScript object represented by 
    /// <paramref name="handle"/> to <paramref name="value"/>.
    /// </summary>
    /// <param name="handle">The handle of the object that owns the member.</param>
    /// <param name="name">The member name.</param>
    /// <param name="value">The desired value.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport($"globalThis.{_jsType}.{nameof(SetMemberRaw)}")]
    public static partial void SetMemberRaw(int handle, [JSMarshalAs<JSType.Any>] object name, [JSMarshalAs<JSType.Any>] object value);

    /// <summary>
    /// Sets the value of the member <paramref name="name"/> of the JavaScript object represented by 
    /// <paramref name="handle"/> to <paramref name="value"/>.
    /// </summary>
    /// <param name="handle">The handle of the object that owns the member.</param>
    /// <param name="name">The member name.</param>
    /// <param name="value">The desired value.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JSImport($"globalThis.{_jsType}.{nameof(SetMemberRaw)}")]
    public static partial void SetMemberRaw(int handle, string name, [JSMarshalAs<JSType.Any>] object value);
}
