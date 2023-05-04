using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;

namespace Trungnt2910.Browser;

public partial class JsObject
{
    [JSImport($"globalThis.{_jsType}.{nameof(InvokeMember)}")]
    private static partial int? InvokeMember(int handle, string name, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    [JSImport($"globalThis.{_jsType}.{nameof(Invoke)}")]
    private static partial int? Invoke(int handle, [JSMarshalAs<JSType.Array<JSType.Any>>] object?[] args);

    /// <summary>
    /// Gets or sets a member of the current object.
    /// </summary>
    /// <param name="index">The member name</param>
    /// <returns>A <see cref="JsObject"/> representing the corresponding JavaScript member, or <see langword="null"/> if the member is equal to <c>null</c> or <c>undefined</c>.</returns>
    /// <remarks>
    /// This function should only be used when strongly-typed C# bindings are not available yet.
    /// </remarks>
    public JsObject? this[string index]
    {
        get
        {
            int? handle = __GetMember(_jsHandle, index);
            if (handle == null)
            {
                return null;
            }
            return FromHandle(handle.Value);
        }
        set
        {
            if (value == null)
            {
                __SetMemberRaw(_jsHandle, index, null);
            }
            else
            {
                __SetMember(_jsHandle, index, value._jsHandle);
            }
        }
    }

    /// <summary>
    /// Marshals the arguments contained in <see cref="args"/> into the form accepted by the JavaScript counterpart.
    /// </summary>
    /// <param name="args">The managed arguments.</param>
    /// <param name="masks">The masks indicating whether a handle or a value is passed.</param>
    /// <param name="objects">The handles or objects passed to the JavaScript function.</param>
    /// <remarks>This function serves the purpose of source generators only. Do not use this function.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    private static void __MarshalArgs(object?[] args, out List<object?> masks, out List<object?> objects)
    {
        masks = new List<object?>();
        objects = new List<object?>();

        int currentMask = 0;
        int i = 0;
        bool clean = true;

        foreach (var arg in args)
        {
            if (i == 31)
            {
                currentMask |= 1 << 31;
                masks.Add(currentMask);
                currentMask = 0;
                i = 0;
                clean = true;
            }

            if (arg is JsObject obj)
            {
                currentMask |= 1 << i;
                objects.Add(obj._jsHandle);
            }
            else
            {
                objects.Add(arg);
            }

            clean = false;
            ++i;
        }

        if (!clean)
        {
            masks.Add(currentMask);
        }
    }

    /// <summary>
    /// Invokes the current object as a JavaScript function.
    /// </summary>
    /// <param name="args">The function's arguments.</param>
    /// <returns>A <see cref="JsObject"/> representing the function's result, or <see langword="null"/> if the function evaluates to <c>null</c> or <c>undefined</c>.</returns>
    public JsObject? Invoke(params object?[]? args)
    {
        int? result;

        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = Invoke(_jsHandle, masks.Concat(objects).ToArray());
        }
        else
        {
            result = Invoke(_jsHandle, Array.Empty<object>());
        }

        return result.HasValue ? FromHandle(result.Value) : null;
    }

    /// <summary>
    /// Invokes a member of the current object as a JavaScript function.
    /// </summary>
    /// <param name="index">The function's name.</param>
    /// <param name="args">The function's arguments.</param>
    /// <returns>A <see cref="JsObject"/> representing the function's result, or <see langword="null"/> if the function evaluates to <c>null</c> or <c>undefined</c>.</returns>
    public JsObject? InvokeMember(string index, params object?[]? args)
    {
        int? result;

        if (args != null)
        {
            __MarshalArgs(args, out var masks, out var objects);
            result = InvokeMember(_jsHandle, index, masks.Concat(objects).ToArray());
        }
        else
        {
            result = InvokeMember(_jsHandle, index, Array.Empty<object>());
        }

        return result.HasValue ? FromHandle(result.Value) : null;
    }

    /// <summary>
    /// Sets the value of the current object's JavaScript property to something other than a <see cref="JsObject"/>
    /// </summary>
    /// <param name="index">The property's name.</param>
    /// <param name="value">The new value.</param>
    /// <remarks>
    /// <see cref="this[string]"/> is preferred the value is a <see cref="JsObject"/>.
    /// </remarks>
    public void SetValue(string index, object value)
    {
        __SetMemberRaw(_jsHandle, index, value);
    }
}
