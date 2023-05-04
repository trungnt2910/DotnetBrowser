using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;

namespace Trungnt2910.Browser;

public partial class JsObject
{
    [JSImport($"globalThis.{_jsType}.{nameof(CreateHandle)}")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    private static partial int CreateHandle(short number);

    [JSImport($"globalThis.{_jsType}.{nameof(CreateHandle)}")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    private static partial int CreateHandle(int number);

    [JSImport($"globalThis.{_jsType}.{nameof(CreateHandle)}")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    private static partial int CreateHandle(byte number);

    [JSImport($"globalThis.{_jsType}.{nameof(CreateHandle)}")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    private static partial int CreateHandle(float number);

    [JSImport($"globalThis.{_jsType}.{nameof(CreateHandle)}")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    private static partial int CreateHandle(double number);

    [JSImport($"globalThis.{_jsType}.{nameof(CreateHandle)}")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    private static partial int CreateHandle(string str);

    /// <summary>
    /// Implicitly converts this <see langword="short"/> value to a <see cref="JsObject"/>.
    /// </summary>
    /// <param name="number">The value.</param>
    [return: NotNullIfNotNull(nameof(number))]
    public static implicit operator JsObject?(short? number)
    {
        if (number == null)
        {
            return null;
        }

        return FromHandle(CreateHandle((short)number));
    }

    /// <summary>
    /// Implicitly converts this <see langword="int"/> value to a <see cref="JsObject"/>.
    /// </summary>
    /// <param name="number">The value.</param>
    [return: NotNullIfNotNull(nameof(number))]
    public static implicit operator JsObject?(int? number)
    {
        if (number == null)
        {
            return null;
        }

        return FromHandle(CreateHandle((int)number));
    }

    /// <summary>
    /// Implicitly converts this <see langword="byte"/> value to a <see cref="JsObject"/>.
    /// </summary>
    /// <param name="number">The value.</param>
    [return: NotNullIfNotNull(nameof(number))]
    public static implicit operator JsObject?(byte? number)
    {
        if (number == null)
        {
            return null;
        }

        return FromHandle(CreateHandle((byte)number));
    }

    /// <summary>
    /// Implicitly converts this <see langword="float"/> value to a <see cref="JsObject"/>.
    /// </summary>
    /// <param name="number">The value.</param>
    [return: NotNullIfNotNull(nameof(number))]
    public static implicit operator JsObject?(float? number)
    {
        if (number == null)
        {
            return null;
        }

        return FromHandle(CreateHandle((float)number));
    }

    /// <summary>
    /// Implicitly converts this <see langword="double"/> value to a <see cref="JsObject"/>.
    /// </summary>
    /// <param name="number">The value.</param>
    [return: NotNullIfNotNull(nameof(number))]
    public static implicit operator JsObject?(double? number)
    {
        if (number == null)
        {
            return null;
        }

        return FromHandle(CreateHandle((double)number));
    }

    /// <summary>
    /// Implicitly converts this <see langword="string"/> value to a <see cref="JsObject"/>.
    /// </summary>
    /// <param name="number">The number.</param>
    [return: NotNullIfNotNull(nameof(number))]
    public static implicit operator JsObject?(string? number)
    {
        if (number == null)
        {
            return null;
        }

        return FromHandle(CreateHandle((string)number));
    }
}
