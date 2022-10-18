using System;
using System.Diagnostics.CodeAnalysis;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// Encapsulates a JavaScript function that has no parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
/// </summary>
[JsObject]
public partial class JsFunc<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TResult> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsFunc{TResult}"/>.
    /// </summary>
    public TResult? Invoke()
    {
        return WebAssemblyRuntime<TResult>.ValueOrNullFromJs($"{_jsThis}()");
    }

    /// <summary>
    /// Gets a managed <see cref="Func{TResult}"/> from this JavaScript <see cref="JsFunc{TResult}"/>.
    /// </summary>
    /// <param name="func">The function.</param>
    public static implicit operator Func<TResult?>(JsFunc<TResult> func)
    {
        return func.Invoke;
    }
}

/// <summary>
/// Encapsulates a JavaScript function that has one parameter and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
/// </summary>
[JsObject]
public partial class JsFunc<T, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TResult> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsFunc{T, TResult}"/>.
    /// </summary>
    public TResult? Invoke(T arg)
    {
        return WebAssemblyRuntime<TResult>.ValueOrNullFromJs($"{_jsThis}({ToJsObjectString(arg)})");
    }

    /// <summary>
    /// Gets a managed <see cref="Func{T, TResult}"/> from this JavaScript <see cref="JsFunc{T, TResult}"/>.
    /// </summary>
    /// <param name="func">The function.</param>
    public static implicit operator Func<T, TResult?>(JsFunc<T, TResult> func)
    {
        return func.Invoke;
    }
}

/// <summary>
/// Encapsulates a JavaScript function that has two parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
/// </summary>
[JsObject]
public partial class JsFunc<T1, T2, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TResult> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsFunc{T1,T2, TResult}"/>.
    /// </summary>
    public TResult? Invoke(T1 arg1, T2 arg2)
    {
        return WebAssemblyRuntime<TResult>.ValueOrNullFromJs($"{_jsThis}({ToJsObjectString(arg1)},{ToJsObjectString(arg2)})");
    }

    /// <summary>
    /// Gets a managed <see cref="Func{T1,T2, TResult}"/> from this JavaScript <see cref="JsFunc{T1,T2, TResult}"/>.
    /// </summary>
    /// <param name="func">The function.</param>
    public static implicit operator Func<T1, T2, TResult?>(JsFunc<T1, T2, TResult> func)
    {
        return func.Invoke;
    }
}


/// <summary>
/// Encapsulates a JavaScript function that has three parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
/// </summary>
[JsObject]
public partial class JsFunc<T1, T2, T3, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TResult> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsFunc{T1,T2,T3, TResult}"/>.
    /// </summary>
    public TResult? Invoke(T1 arg1, T2 arg2, T3 arg3)
    {
        return WebAssemblyRuntime<TResult>.ValueOrNullFromJs($"{_jsThis}({ToJsObjectString(arg1)},{ToJsObjectString(arg2)},{ToJsObjectString(arg3)})");
    }

    /// <summary>
    /// Gets a managed <see cref="Func{T1,T2,T3, TResult}"/> from this JavaScript <see cref="JsFunc{T1,T2,T3, TResult}"/>.
    /// </summary>
    /// <param name="func">The function.</param>
    public static implicit operator Func<T1, T2, T3, TResult?>(JsFunc<T1, T2, T3, TResult> func)
    {
        return func.Invoke;
    }
}


/// <summary>
/// Encapsulates a JavaScript function that has four parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
/// </summary>
[JsObject]
public partial class JsFunc<T1, T2, T3, T4, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TResult> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsFunc{T1,T2,T3,T4, TResult}"/>.
    /// </summary>
    public TResult? Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        return WebAssemblyRuntime<TResult>.ValueOrNullFromJs($"{_jsThis}({ToJsObjectString(arg1)},{ToJsObjectString(arg2)},{ToJsObjectString(arg3)},{ToJsObjectString(arg4)})");
    }

    /// <summary>
    /// Gets a managed <see cref="Func{T1,T2,T3,T4, TResult}"/> from this JavaScript <see cref="JsFunc{T1,T2,T3,T4, TResult}"/>.
    /// </summary>
    /// <param name="func">The function.</param>
    public static implicit operator Func<T1, T2, T3, T4, TResult?>(JsFunc<T1, T2, T3, T4, TResult> func)
    {
        return func.Invoke;
    }
}


/// <summary>
/// Encapsulates a JavaScript function that has five parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
/// </summary>
[JsObject]
public partial class JsFunc<T1, T2, T3, T4, T5, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TResult> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsFunc{T1,T2,T3,T4,T5, TResult}"/>.
    /// </summary>
    public TResult? Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        return WebAssemblyRuntime<TResult>.ValueOrNullFromJs($"{_jsThis}({ToJsObjectString(arg1)},{ToJsObjectString(arg2)},{ToJsObjectString(arg3)},{ToJsObjectString(arg4)},{ToJsObjectString(arg5)})");
    }

    /// <summary>
    /// Gets a managed <see cref="Func{T1,T2,T3,T4,T5, TResult}"/> from this JavaScript <see cref="JsFunc{T1,T2,T3,T4,T5, TResult}"/>.
    /// </summary>
    /// <param name="func">The function.</param>
    public static implicit operator Func<T1, T2, T3, T4, T5, TResult?>(JsFunc<T1, T2, T3, T4, T5, TResult> func)
    {
        return func.Invoke;
    }
}


/// <summary>
/// Encapsulates a JavaScript function that has six parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
/// </summary>
[JsObject]
public partial class JsFunc<T1, T2, T3, T4, T5, T6, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TResult> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsFunc{T1,T2,T3,T4,T5,T6, TResult}"/>.
    /// </summary>
    public TResult? Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        return WebAssemblyRuntime<TResult>.ValueOrNullFromJs($"{_jsThis}({ToJsObjectString(arg1)},{ToJsObjectString(arg2)},{ToJsObjectString(arg3)},{ToJsObjectString(arg4)},{ToJsObjectString(arg5)},{ToJsObjectString(arg6)})");
    }

    /// <summary>
    /// Gets a managed <see cref="Func{T1,T2,T3,T4,T5,T6, TResult}"/> from this JavaScript <see cref="JsFunc{T1,T2,T3,T4,T5,T6, TResult}"/>.
    /// </summary>
    /// <param name="func">The function.</param>
    public static implicit operator Func<T1, T2, T3, T4, T5, T6, TResult?>(JsFunc<T1, T2, T3, T4, T5, T6, TResult> func)
    {
        return func.Invoke;
    }
}


/// <summary>
/// Encapsulates a JavaScript function that has seven parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
/// </summary>
[JsObject]
public partial class JsFunc<T1, T2, T3, T4, T5, T6, T7, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TResult> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsFunc{T1,T2,T3,T4,T5,T6,T7, TResult}"/>.
    /// </summary>
    public TResult? Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
        return WebAssemblyRuntime<TResult>.ValueOrNullFromJs($"{_jsThis}({ToJsObjectString(arg1)},{ToJsObjectString(arg2)},{ToJsObjectString(arg3)},{ToJsObjectString(arg4)},{ToJsObjectString(arg5)},{ToJsObjectString(arg6)},{ToJsObjectString(arg7)})");
    }

    /// <summary>
    /// Gets a managed <see cref="Func{T1,T2,T3,T4,T5,T6,T7, TResult}"/> from this JavaScript <see cref="JsFunc{T1,T2,T3,T4,T5,T6,T7, TResult}"/>.
    /// </summary>
    /// <param name="func">The function.</param>
    public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, TResult?>(JsFunc<T1, T2, T3, T4, T5, T6, T7, TResult> func)
    {
        return func.Invoke;
    }
}


/// <summary>
/// Encapsulates a JavaScript function that has eight parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
/// </summary>
[JsObject]
public partial class JsFunc<T1, T2, T3, T4, T5, T6, T7, T8, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TResult> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsFunc{T1,T2,T3,T4,T5,T6,T7,T8, TResult}"/>.
    /// </summary>
    public TResult? Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
    {
        return WebAssemblyRuntime<TResult>.ValueOrNullFromJs($"{_jsThis}({ToJsObjectString(arg1)},{ToJsObjectString(arg2)},{ToJsObjectString(arg3)},{ToJsObjectString(arg4)},{ToJsObjectString(arg5)},{ToJsObjectString(arg6)},{ToJsObjectString(arg7)},{ToJsObjectString(arg8)})");
    }

    /// <summary>
    /// Gets a managed <see cref="Func{T1,T2,T3,T4,T5,T6,T7,T8, TResult}"/> from this JavaScript <see cref="JsFunc{T1,T2,T3,T4,T5,T6,T7,T8, TResult}"/>.
    /// </summary>
    /// <param name="func">The function.</param>
    public static implicit operator Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult?>(JsFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
    {
        return func.Invoke;
    }
}