using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.JavaScript;

namespace Trungnt2910.Browser;

public partial class JsObject
{
    [JSImport($"globalThis.{_jsType}.InvokeMemberRaw")]
    private static partial void InvokeMemberVoid(int handle, string name, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    [JSImport($"globalThis.{_jsType}.InvokeRaw")]
    private static partial void InvokeVoid(int handle, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    /// <summary>
    /// Invokes the current object as a JavaScript function.
    /// </summary>
    /// <param name="args">The arguments passed to this function.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeRaw(object?[]? args)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            InvokeVoid(_jsHandle, masks.Concat(objects).ToArray());
        }
        else
        {
            InvokeVoid(_jsHandle, Array.Empty<object>());
        }
    }

    /// <summary>
    /// Invokes the JavaScript member function with the name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="args">The arguments passed to this function.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeMemberRaw(string name, object?[]? args)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            InvokeMemberVoid(_jsHandle, name, masks.Concat(objects).ToArray());
        }
        else
        {
            InvokeMemberVoid(_jsHandle, name, Array.Empty<object>());
        }
    }

    [JSImport($"globalThis.{_jsType}.InvokeMemberRaw")]
    private static partial byte? InvokeMemberByte(int handle, string name, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    [JSImport($"globalThis.{_jsType}.InvokeRaw")]
    private static partial byte? InvokeByte(int handle, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    /// <summary>
    /// Invokes the current object as a JavaScript function.
    /// </summary>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeRaw(object?[]? args, out byte? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeByte(_jsHandle, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeByte(_jsHandle, Array.Empty<object>());
        }
    }

    /// <summary>
    /// Invokes the JavaScript member function with the name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeMemberRaw(string name, object?[]? args, out byte? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeMemberByte(_jsHandle, name, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeMemberByte(_jsHandle, name, Array.Empty<object>());
        }
    }

    [JSImport($"globalThis.{_jsType}.InvokeMemberRaw")]
    private static partial short? InvokeMemberInt16(int handle, string name, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    [JSImport($"globalThis.{_jsType}.InvokeRaw")]
    private static partial short? InvokeInt16(int handle, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    /// <summary>
    /// Invokes the current object as a JavaScript function.
    /// </summary>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeRaw(object?[]? args, out short? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeInt16(_jsHandle, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeInt16(_jsHandle, Array.Empty<object>());
        }
    }

    /// <summary>
    /// Invokes the JavaScript member function with the name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeMemberRaw(string name, object?[]? args, out short? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeMemberInt16(_jsHandle, name, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeMemberInt16(_jsHandle, name, Array.Empty<object>());
        }
    }

    [JSImport($"globalThis.{_jsType}.InvokeMemberRaw")]
    private static partial int? InvokeMemberInt32(int handle, string name, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    [JSImport($"globalThis.{_jsType}.InvokeRaw")]
    private static partial int? InvokeInt32(int handle, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    /// <summary>
    /// Invokes the current object as a JavaScript function.
    /// </summary>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeRaw(object?[]? args, out int? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeInt32(_jsHandle, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeInt32(_jsHandle, Array.Empty<object>());
        }
    }

    /// <summary>
    /// Invokes the JavaScript member function with the name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeMemberRaw(string name, object?[]? args, out int? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeMemberInt32(_jsHandle, name, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeMemberInt32(_jsHandle, name, Array.Empty<object>());
        }
    }

    [JSImport($"globalThis.{_jsType}.InvokeMemberRaw")]
    private static partial float? InvokeMemberSingle(int handle, string name, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    [JSImport($"globalThis.{_jsType}.InvokeRaw")]
    private static partial float? InvokeSingle(int handle, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    /// <summary>
    /// Invokes the current object as a JavaScript function.
    /// </summary>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeRaw(object?[]? args, out float? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeSingle(_jsHandle, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeSingle(_jsHandle, Array.Empty<object>());
        }
    }

    /// <summary>
    /// Invokes the JavaScript member function with the name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeMemberRaw(string name, object?[]? args, out float? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeMemberSingle(_jsHandle, name, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeMemberSingle(_jsHandle, name, Array.Empty<object>());
        }
    }

    [JSImport($"globalThis.{_jsType}.InvokeMemberRaw")]
    private static partial double? InvokeMemberDouble(int handle, string name, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    [JSImport($"globalThis.{_jsType}.InvokeRaw")]
    private static partial double? InvokeDouble(int handle, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    /// <summary>
    /// Invokes the current object as a JavaScript function.
    /// </summary>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeRaw(object?[]? args, out double? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeDouble(_jsHandle, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeDouble(_jsHandle, Array.Empty<object>());
        }
    }

    /// <summary>
    /// Invokes the JavaScript member function with the name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeMemberRaw(string name, object?[]? args, out double? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeMemberDouble(_jsHandle, name, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeMemberDouble(_jsHandle, name, Array.Empty<object>());
        }
    }

    [JSImport($"globalThis.{_jsType}.InvokeMemberRaw")]
    private static partial bool? InvokeMemberBoolean(int handle, string name, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    [JSImport($"globalThis.{_jsType}.InvokeRaw")]
    private static partial bool? InvokeBoolean(int handle, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    /// <summary>
    /// Invokes the current object as a JavaScript function.
    /// </summary>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeRaw(object?[]? args, out bool? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeBoolean(_jsHandle, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeBoolean(_jsHandle, Array.Empty<object>());
        }
    }

    /// <summary>
    /// Invokes the JavaScript member function with the name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeMemberRaw(string name, object?[]? args, out bool? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeMemberBoolean(_jsHandle, name, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeMemberBoolean(_jsHandle, name, Array.Empty<object>());
        }
    }

    [JSImport($"globalThis.{_jsType}.InvokeMemberRaw")]
    private static partial char? InvokeMemberChar(int handle, string name, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    [JSImport($"globalThis.{_jsType}.InvokeRaw")]
    private static partial char? InvokeChar(int handle, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    /// <summary>
    /// Invokes the current object as a JavaScript function.
    /// </summary>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeRaw(object?[]? args, out char? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeChar(_jsHandle, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeChar(_jsHandle, Array.Empty<object>());
        }
    }

    /// <summary>
    /// Invokes the JavaScript member function with the name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeMemberRaw(string name, object?[]? args, out char? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeMemberChar(_jsHandle, name, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeMemberChar(_jsHandle, name, Array.Empty<object>());
        }
    }

    [JSImport($"globalThis.{_jsType}.InvokeMemberRaw")]
    private static partial string? InvokeMemberString(int handle, string name, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    [JSImport($"globalThis.{_jsType}.InvokeRaw")]
    private static partial string? InvokeString(int handle, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    /// <summary>
    /// Invokes the current object as a JavaScript function.
    /// </summary>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeRaw(object?[]? args, out string? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeString(_jsHandle, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeString(_jsHandle, Array.Empty<object>());
        }
    }

    /// <summary>
    /// Invokes the JavaScript member function with the name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeMemberRaw(string name, object?[]? args, out string? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeMemberString(_jsHandle, name, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeMemberString(_jsHandle, name, Array.Empty<object>());
        }
    }

    [JSImport($"globalThis.{_jsType}.InvokeMemberRaw")]
    private static partial nint? InvokeMemberIntPtr(int handle, string name, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    [JSImport($"globalThis.{_jsType}.InvokeRaw")]
    private static partial nint? InvokeIntPtr(int handle, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    /// <summary>
    /// Invokes the current object as a JavaScript function.
    /// </summary>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeRaw(object?[]? args, out nint? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeIntPtr(_jsHandle, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeIntPtr(_jsHandle, Array.Empty<object>());
        }
    }

    /// <summary>
    /// Invokes the JavaScript member function with the name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="args">The arguments passed to this function.</param>
    /// <param name="result">The function's result.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __InvokeMemberRaw(string name, object?[]? args, out nint? result)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeMemberIntPtr(_jsHandle, name, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeMemberIntPtr(_jsHandle, name, Array.Empty<object>());
        }
    }

    /// <summary>
    /// Invokes the current object as a JavaScript function.
    /// </summary>
    /// <param name="args">The arguments passed to this function.</param>
    /// <returns>A handle to the result.</returns>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected int? __Invoke(object?[]? args)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            return Invoke(_jsHandle, masks.Concat(objects).ToArray());
        }
        else
        {
            return Invoke(_jsHandle, Array.Empty<object>());
        }
    }

    /// <summary>
    /// Invokes the JavaScript member function with the name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The function name.</param>
    /// <param name="args">The arguments passed to this function.</param>
    /// <returns>A handle to the result.</returns>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected int? __InvokeMember(string name, object?[]? args)
    {
        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            return InvokeMember(_jsHandle, name, masks.Concat(objects).ToArray());
        }
        else
        {
            return InvokeMember(_jsHandle, name, Array.Empty<object>());
        }
    }

    /// <summary>
    /// An internal class used by source generators. Do not use this class.
    /// </summary>
    /// <typeparam name="T">Any type derived from <see cref="JsObject"/>.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected class __HandleFactory<T> where T : JsObject
    {
        private static readonly Func<IntPtr, T> _fromHandle
            = typeof(T).GetMethod(nameof(FromHandle), BindingFlags.Static | BindingFlags.Public)?
              .CreateDelegate<Func<IntPtr, T>>()!;

        /// <summary>
        /// Constructs an object of type T from a native JavaScript handle specified in <paramref name="handle"/>
        /// </summary>
        /// <typeparam name="T">The target class.</typeparam>
        /// <param name="handle">The handle.</param>
        /// <returns>A newly constructed object of type T.</returns>
        /// <remarks>Do not use this function. This is only used by source generators because of its large overhead.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T? FromHandle(int handle)
        {
            return _fromHandle((IntPtr)handle);
        }
    };

    /// <summary>
    /// Sets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The object containing the name of the member to set.</param>
    /// <param name="valueHandle">The handle to the member's new value.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [JSImport($"globalThis.{_jsType}.SetMember")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected static partial void __SetMember(int handle, [JSMarshalAs<JSType.Any>] object name, int valueHandle);

    /// <summary>
    /// Sets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The name of the member to set.</param>
    /// <param name="valueHandle">The handle to the member's new value.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [JSImport($"globalThis.{_jsType}.SetMember")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected static partial void __SetMember(int handle, string name, int valueHandle);

    /// <summary>
    /// Sets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The object containing the name of the member to set.</param>
    /// <param name="value">The object containing the new value.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [JSImport($"globalThis.{_jsType}.SetMemberRaw")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected static partial void __SetMemberRaw(int handle, [JSMarshalAs<JSType.Any>] object name, [JSMarshalAs<JSType.Any>] object value);

    /// <summary>
    /// Sets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The name of the member to set.</param>
    /// <param name="value">The object containing the new value.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [JSImport($"globalThis.{_jsType}.SetMemberRaw")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected static partial void __SetMemberRaw(int handle, string name, [JSMarshalAs<JSType.Any>] object? value);

    /// <summary>
    /// Gets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The name of the member to get.</param>
    /// <returns>A handle to the member's value.</returns>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [JSImport($"globalThis.{_jsType}.GetMember")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected static partial int? __GetMember(int handle, string name);

    [JSImport($"globalThis.{_jsType}.GetMemberRaw")]
    private static partial byte? GetMemberByte(int handle, string name);

    /// <summary>
    /// Gets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The name of the member to get.</param>
    /// <param name="result">A variable to store member's value.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __GetMemberRaw(string name, out byte? result)
    {
        result = GetMemberByte(_jsHandle, name);
    }

    [JSImport($"globalThis.{_jsType}.GetMemberRaw")]
    private static partial short? GetMemberInt16(int handle, string name);

    /// <summary>
    /// Gets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The name of the member to get.</param>
    /// <param name="result">A variable to store member's value.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __GetMemberRaw(string name, out short? result)
    {
        result = GetMemberInt16(_jsHandle, name);
    }

    [JSImport($"globalThis.{_jsType}.GetMemberRaw")]
    private static partial int? GetMemberInt32(int handle, string name);

    /// <summary>
    /// Gets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The name of the member to get.</param>
    /// <param name="result">A variable to store member's value.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __GetMemberRaw(string name, out int? result)
    {
        result = GetMemberInt32(_jsHandle, name);
    }

    [JSImport($"globalThis.{_jsType}.GetMemberRaw")]
    private static partial float? GetMemberSingle(int handle, string name);

    /// <summary>
    /// Gets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The name of the member to get.</param>
    /// <param name="result">A variable to store member's value.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __GetMemberRaw(string name, out float? result)
    {
        result = GetMemberSingle(_jsHandle, name);
    }

    [JSImport($"globalThis.{_jsType}.GetMemberRaw")]
    private static partial double? GetMemberDouble(int handle, string name);

    /// <summary>
    /// Gets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The name of the member to get.</param>
    /// <param name="result">A variable to store member's value.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __GetMemberRaw(string name, out double? result)
    {
        result = GetMemberDouble(_jsHandle, name);
    }

    [JSImport($"globalThis.{_jsType}.GetMemberRaw")]
    private static partial bool? GetMemberBoolean(int handle, string name);

    /// <summary>
    /// Gets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The name of the member to get.</param>
    /// <param name="result">A variable to store member's value.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __GetMemberRaw(string name, out bool? result)
    {
        result = GetMemberBoolean(_jsHandle, name);
    }

    [JSImport($"globalThis.{_jsType}.GetMemberRaw")]
    private static partial string? GetMemberString(int handle, string name);

    /// <summary>
    /// Gets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The name of the member to get.</param>
    /// <param name="result">A variable to store member's value.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __GetMemberRaw(string name, out string? result)
    {
        result = GetMemberString(_jsHandle, name);
    }

    [JSImport($"globalThis.{_jsType}.GetMemberRaw")]
    private static partial char? GetMemberChar(int handle, string name);

    /// <summary>
    /// Gets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The name of the member to get.</param>
    /// <param name="result">A variable to store member's value.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __GetMemberRaw(string name, out char? result)
    {
        result = GetMemberChar(_jsHandle, name);
    }

    [JSImport($"globalThis.{_jsType}.GetMemberRaw")]
    private static partial nint? GetMemberIntPtr(int handle, string name);

    /// <summary>
    /// Gets the member of a JavaScript object.
    /// </summary>
    /// <param name="handle">The native handle.</param>
    /// <param name="name">The name of the member to get.</param>
    /// <param name="result">A variable to store member's value.</param>
    /// <remarks>Do not use this function. This is only used by source generators.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void __GetMemberRaw(string name, out nint? result)
    {
        result = GetMemberIntPtr(_jsHandle, name);
    }
}
