using System;
using Uno.Foundation;

namespace Trungnt2910.Browser;

public class JsObject : IDisposable, IConvertible
{
    private const string _jsType = "Trungnt2910.Browser.JsObject";
    private string _jsThis => $"{_jsType}.ReferencedObjects[{_handle}]";

    private readonly int _handle;

    internal JsObject(int handle)
    {
        _handle = handle;
    }

    public static JsObject ConstructObject(string jsExpression)
    {
        return new JsObject(int.Parse(WebAssemblyRuntime.InvokeJS($"{_jsType}.ConstructObject({jsExpression})")));
    }

    public JsObject this[string index]
    {
        get => ConstructObject($"{_jsThis}[\"{WebAssemblyRuntime.EscapeJs(index)}\"]");
    }

    public string GetJsType()
    {
        return WebAssemblyRuntime.InvokeJS($"typeof {_jsThis}");
    }

    public override string ToString()
    {
        if (GetJsType() == "string")
        {
            return WebAssemblyRuntime.InvokeJS(_jsThis);
        }
        return WebAssemblyRuntime.InvokeJS($"JSON.stringify({_jsThis})");
    }

    #region IConvertible
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

    public bool ToBoolean(IFormatProvider provider)
    {
        return bool.Parse(WebAssemblyRuntime.InvokeJS($"({_jsThis}) ? true : false"));
    }

    public byte ToByte(IFormatProvider provider)
    {
        return byte.Parse(WebAssemblyRuntime.InvokeJS($"{_jsThis}"), provider);
    }

    public char ToChar(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public DateTime ToDateTime(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public decimal ToDecimal(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public double ToDouble(IFormatProvider provider)
    {
        return double.Parse(WebAssemblyRuntime.InvokeJS($"{_jsThis}"), provider);
    }

    public short ToInt16(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public int ToInt32(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public long ToInt64(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public sbyte ToSByte(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public float ToSingle(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public string ToString(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public object ToType(Type conversionType, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public ushort ToUInt16(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public uint ToUInt32(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public ulong ToUInt64(IFormatProvider provider)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region IDisposable
    private bool _disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            WebAssemblyRuntime.InvokeJS($"{_jsType}.DisposeObject({_handle})");
            _disposedValue = true;
        }
    }

    // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    ~JsObject()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    #endregion
}
