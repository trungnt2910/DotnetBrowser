using System.ComponentModel;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// The <see cref="ArrayBuffer"/> object is used to represent a generic, fixed-length raw binary data buffer.
/// </summary>
[JsObject]
public partial class ArrayBuffer: JsObject
{
}

/// <summary>
/// A TypeScript object for something that looks like a <see cref="ArrayBuffer"/>.
/// </summary>
[JsObject]
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class ArrayBufferLike : JsObject
{
    /// <summary>
    /// Converts this <see cref="ArrayBufferLike"/> instance to a <see cref="ArrayBuffer"/>.
    /// </summary>
    /// <param name="self">The <see cref="ArrayBufferLike"/> instance.</param>
    public static implicit operator ArrayBuffer(ArrayBufferLike self)
    {
        return self.Cast<ArrayBuffer>();
    }

    /// <summary>
    /// Converts this <see cref="ArrayBuffer"/> instance to a <see cref="ArrayBufferLike"/>.
    /// </summary>
    /// <param name="self">The <see cref="ArrayBuffer"/> instance.</param>
    public static implicit operator ArrayBufferLike(ArrayBuffer self)
    {
        return self.Cast<ArrayBufferLike>();
    }
}
