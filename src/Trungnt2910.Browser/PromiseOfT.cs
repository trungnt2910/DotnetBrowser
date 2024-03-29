﻿using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// The <see cref="Promise{T}"/> object represents the eventual completion (or failure) of an asynchronous operation and its resulting value.
/// </summary>
[JsObject]
public partial class Promise<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>: Promise
{
    /// <summary>
    /// Returns a <see cref="TaskAwaiter{T}"/> so that this <see cref="Promise{T}"/> could be used with <see langword="await"/>.
    /// </summary>
    /// <returns>A <see cref="TaskAwaiter{T}"/>.</returns>
    new public TaskAwaiter<T?> GetAwaiter()
    {
        return ((Task<T?>)this).GetAwaiter();
    }

    /// <summary>
    /// Converts this <see cref="Promise{T}"/> to a managed <see cref="Task{T}"/>
    /// </summary>
    /// <param name="promise">The promise to convert.</param>
    public static implicit operator Task<T?>(Promise<T> promise)
    {
        return (Task<T?>)(Task)(Promise)promise;
    }

    private protected override Task ProcessTaskReturnValue(Task<int?> input)
    {
        return input.ContinueWith((task) =>
        {
            if (task.Result != null)
            {
                if (_fromHandle != null)
                {
                    return (T?)_fromHandle.Invoke(null, new object[] { (IntPtr)task.Result.Value });
                }
                // The harm's already done: A handle has already been created on the JavaScript
                // side, so we'll just have to consume it with a JsObject.
                var obj = JsObject.FromHandle(task.Result.Value);
                return (T?)obj.ToType(typeof(T), null);
            }
            return default;
        });
    }

    private static readonly MethodInfo? _fromHandle = typeof(T).GetMethod(nameof(FromHandle), BindingFlags.Static | BindingFlags.Public);
}

/// <summary>
/// Used by TypeScript code for types that look like a <see cref="Promise{T}"/>.
/// </summary>
[JsObject]
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class PromiseLike<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>: PromiseLike
{
    /// <summary>
    /// Converts this <see cref="PromiseLike{T}"/> instance to a <see cref="Promise{T}"/>.
    /// </summary>
    /// <param name="self">The <see cref="PromiseLike{T}"/> instance.</param>
    public static implicit operator Promise<T>(PromiseLike<T> self)
    {
        return self.Cast<Promise<T>>();
    }

    /// <summary>
    /// Converts this <see cref="Promise{T}"/> instance to a <see cref="PromiseLike{T}"/>.
    /// </summary>
    /// <param name="self">The <see cref="Promise{T}"/> instance.</param>
    public static implicit operator PromiseLike<T>(Promise<T> self)
    {
        return self.Cast<PromiseLike<T>>();
    }
}