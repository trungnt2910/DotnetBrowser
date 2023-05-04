using System;
using System.Runtime.InteropServices.JavaScript;

namespace Trungnt2910.Browser;

public partial class JsObject
{
    /// <inheritdoc/>
    public TypeCode GetTypeCode()
    {
        switch (GetJsType())
        {
            case "string":
                return TypeCode.String;
            case "number":
                return TypeCode.Double;
            case "boolean":
                return TypeCode.Boolean;
            default:
                return TypeCode.Object;
        }
    }

    [JSImport($"globalThis.{_jsType}.{nameof(ToBoolean)}")]
    private static partial bool ToBoolean(int index);

    /// <inheritdoc/>
    public bool ToBoolean(IFormatProvider? provider)
    {
        return ToBoolean(_jsHandle);
    }

    [JSImport($"globalThis.{_jsType}.ToNumber")]
    private static partial byte ToByte(int index);

    /// <inheritdoc/>
    public byte ToByte(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return byte.Parse(ToStringRaw(), provider);
            case "number":
                return ToByte(_jsHandle);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Byte.");
        }
    }

    /// <inheritdoc/>
    public char ToChar(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return ToStringRaw()[0];
            case "number":
                return (char)ToInt32(provider);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Char.");
        }
    }

    /// <inheritdoc/>
    public DateTime ToDateTime(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return DateTime.Parse(ToStringRaw(), provider);
            case "number":
                return DateTimeOffset.FromUnixTimeMilliseconds((long)ToDouble(provider)).DateTime;
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to DateTime.");
        }
    }

    /// <inheritdoc/>
    public decimal ToDecimal(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return decimal.Parse(ToStringRaw(), provider);
            case "number":
                return decimal.Parse(ToString(), provider);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Decimal.");
        }
    }

    [JSImport($"globalThis.{_jsType}.ToNumber")]
    private static partial double ToDouble(int index);

    /// <inheritdoc/>
    public double ToDouble(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return double.Parse(ToStringRaw(), provider);
            case "number":
                return ToDouble(_jsHandle);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Double.");
        }
    }

    [JSImport($"globalThis.{_jsType}.ToNumber")]
    private static partial short ToInt16(int index);

    /// <inheritdoc/>
    public short ToInt16(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return short.Parse(ToStringRaw(), provider);
            case "number":
                return ToInt16(_jsHandle);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Int16.");
        }
    }

    [JSImport($"globalThis.{_jsType}.ToNumber")]
    private static partial int ToInt32(int index);

    /// <inheritdoc/>
    public int ToInt32(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return int.Parse(ToStringRaw(), provider);
            case "number":
                return ToInt32(_jsHandle);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Int32.");
        }
    }

    [JSImport($"globalThis.{_jsType}.ToNumber")]
    [return: JSMarshalAs<JSType.BigInt>]
    private static partial long ToInt64(int index);

    /// <inheritdoc/>
    public long ToInt64(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return long.Parse(ToStringRaw(), provider);
            case "number":
                return long.Parse(ToString(), provider);
            case "bigint":
                return ToInt64(_jsHandle);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Int64.");
        }
    }

    /// <inheritdoc/>
    public sbyte ToSByte(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return sbyte.Parse(ToStringRaw(), provider);
            case "number":
                return (sbyte)ToInt32(provider);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to SByte.");
        }
    }

    [JSImport($"globalThis.{_jsType}.ToNumber")]
    private static partial float ToSingle(int index);

    /// <inheritdoc/>
    public float ToSingle(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return float.Parse(ToStringRaw(), provider);
            case "number":
                return ToSingle(_jsHandle);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to Single.");
        }
    }

    /// <inheritdoc/>
    public string ToString(IFormatProvider? provider)
    {
        return ToString();
    }

    /// <inheritdoc/>
    public object ToType(Type conversionType, IFormatProvider? provider)
    {
        switch (Type.GetTypeCode(conversionType))
        {
            case TypeCode.Boolean:
                return ToBoolean(provider);
            case TypeCode.Byte:
                return ToByte(provider);
            case TypeCode.Char:
                return ToChar(provider);
            case TypeCode.DateTime:
                return ToDateTime(provider);
            case TypeCode.Decimal:
                return ToDecimal(provider);
            case TypeCode.Double:
                return ToDouble(provider);
            case TypeCode.Int16:
                return ToInt16(provider);
            case TypeCode.Int32:
                return ToInt32(provider);
            case TypeCode.Int64:
                return ToInt64(provider);
            case TypeCode.Object:
                return this;
            case TypeCode.SByte:
                return ToSByte(provider);
            case TypeCode.Single:
                return ToSingle(provider);
            case TypeCode.String:
                return ToString(provider);
            case TypeCode.UInt16:
                return ToUInt16(provider);
            case TypeCode.UInt32:
                return ToUInt32(provider);
            case TypeCode.UInt64:
                return ToUInt64(provider);
            default:
                throw new InvalidCastException($"Conversion from JsObject to {conversionType} is not supported.");
        }
    }

    /// <inheritdoc/>
    public ushort ToUInt16(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return ushort.Parse(ToStringRaw(), provider);
            case "number":
                return ushort.Parse(ToString(), provider);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to UInt16.");
        }
    }

    /// <inheritdoc/>
    public uint ToUInt32(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return uint.Parse(ToStringRaw(), provider);
            case "number":
                return uint.Parse(ToString(), provider);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to UInt32.");
        }
    }

    /// <inheritdoc/>
    public ulong ToUInt64(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return ulong.Parse(ToStringRaw(), provider);
            case "number":
                return ulong.Parse(ToString(), provider);
            default:
                throw new InvalidCastException($"Cannot convert a JsObject of {ToString()} to UInt64.");
        }
    }
}
