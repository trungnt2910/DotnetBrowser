using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Uno.Foundation;

namespace Trungnt2910.Browser;

public class JsObject : IConvertible
{
    private const string _jsType = "Trungnt2910.Browser.JsObject";
    private static readonly Dictionary<int, WeakReference<JsObject>> _objectCache = new();

    protected readonly int _handle;
    protected string? _type;
    internal readonly string _jsThis;

    protected JsObject(int handle)
    {
        _handle = handle;
        _jsThis = $"{_jsType}.ReferencedObjects[{_handle}]";
    }

    public static JsObject? FromExpression(string jsExpression)
    {
        var objectHandleString = WebAssemblyRuntime.InvokeJS($"{_jsType}.ConstructObject({jsExpression})");
        if (objectHandleString == null)
        {
            return null;
        }
        return FromHandle(int.Parse(objectHandleString));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static JsObject FromHandle(int objectHandle)
    {
        JsObject? obj;
        if (_objectCache.ContainsKey(objectHandle))
        {
            if (_objectCache[objectHandle].TryGetTarget(out obj))
            {
                return obj;
            }
            obj = new JsObject(objectHandle);
            _objectCache[objectHandle].SetTarget(obj);
        }
        obj = new JsObject(objectHandle);
        _objectCache.Add(objectHandle, new WeakReference<JsObject>(obj));
        return obj;
    }

    internal static string ToJsObjectString(object? obj)
    {
        switch (obj)
        {
            case null:
                return "null";
            case string:
            case char:
                return $"\"{WebAssemblyRuntime.EscapeJs(obj.ToString()!)}\"";
            case sbyte:
            case byte:
            case short:
            case ushort:
            case int:
            case uint:
            case long:
            case ulong:
            case float:
            case double:
            case decimal:
                return obj.ToString()!;
            case JsObject jsObj:
                return jsObj._jsThis;
            default:
                return JsonSerializer.Serialize(obj);
        }
    }

    public JsObject? this[string index]
    {
        get => FromExpression($"{_jsThis}[\"{WebAssemblyRuntime.EscapeJs(index)}\"]");
        set => WebAssemblyRuntime.InvokeJS($"{_jsThis}[\"{WebAssemblyRuntime.EscapeJs(index)}\"] = {value?._jsThis ?? "null"}");
    }

    public JsObject? Invoke(params object?[]? args)
    {
        var argsStringList = args?.Select(a => ToJsObjectString(a));
        return FromExpression($"{_jsThis}({string.Join(",", argsStringList ?? Array.Empty<string>())})");
    }

    public JsObject? InvokeMember(string index, params object?[]? args)
    {
        var argsStringList = args?.Select(a => ToJsObjectString(a));
        return FromExpression($"{_jsThis}[\"{WebAssemblyRuntime.EscapeJs(index)}\"]({string.Join(",", argsStringList ?? Array.Empty<string>())})");
    }

    public void SetValue(string index, object value)
    {
        WebAssemblyRuntime.InvokeJS($"{_jsThis}[\"{WebAssemblyRuntime.EscapeJs(index)}\"] = {ToJsObjectString(value)}");
    }

    public string GetJsType()
    {
        return _type ??= WebAssemblyRuntime.InvokeJS($"typeof {_jsThis}");
    }

    public override string ToString()
    {
        if (GetJsType() == "string")
        {
            return WebAssemblyRuntime.InvokeJS(_jsThis);
        }
        return WebAssemblyRuntime.InvokeJS($"JSON.stringify({_jsThis})");
    }

    private string ToStringRaw()
    {
        return WebAssemblyRuntime.InvokeJS(_jsThis);
    }

    public T Cast<T>() where T: JsObject
    {
        var fromHandle = typeof(T).GetMethod(nameof(FromHandle), BindingFlags.Static | BindingFlags.Public);
        return (T)fromHandle!.Invoke(null, new object[] { _handle })!;
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

    public bool ToBoolean(IFormatProvider? provider)
    {
        return bool.Parse(WebAssemblyRuntime.InvokeJS($"({_jsThis}) ? true : false"));
    }

    public byte ToByte(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return byte.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    public char ToChar(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return ToStringRaw()[0];
            case "number":
                return (char)int.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    public DateTime ToDateTime(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
                return DateTime.Parse(ToStringRaw(), provider);
            case "number":
                return DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(ToStringRaw())).DateTime;
            default:
                throw new NotSupportedException();
        }
    }

    public decimal ToDecimal(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return decimal.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    public double ToDouble(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return double.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    public short ToInt16(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return short.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    public int ToInt32(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return int.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    public long ToInt64(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return long.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    public sbyte ToSByte(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return sbyte.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    public float ToSingle(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return float.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    public string ToString(IFormatProvider? provider)
    {
        return ToString();
    }

    public object ToType(Type conversionType, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public ushort ToUInt16(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return ushort.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    public uint ToUInt32(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return uint.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }

    public ulong ToUInt64(IFormatProvider? provider)
    {
        switch (GetJsType())
        {
            case "string":
            case "number":
                return ulong.Parse(ToStringRaw(), provider);
            default:
                throw new NotSupportedException();
        }
    }
    #endregion

    ~JsObject()
    {
        if (_objectCache.TryGetValue(_handle, out var reference) && 
            reference.TryGetTarget(out JsObject? obj) && 
            obj == this)
        {
            _objectCache.Remove(_handle);
        }
        WebAssemblyRuntime.InvokeJS($"{_jsType}.DisposeObject({_handle})");
    }
}
