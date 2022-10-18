using System;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// Encapsulates a JavaScript function that has no parameters and does not return a value.
/// </summary>
[JsObject]
public partial class JsAction : Function
{
    /// <summary>
    /// Invokes this <see cref="JsAction"/>.
    /// </summary>
    public void Invoke()
    {
        ((JsObject)this).Invoke();
    }

    /// <summary>
    /// Gets a managed <see cref="Action"/> from this JavaScript <see cref="JsAction"/>.
    /// </summary>
    /// <param name="func">The action.</param>
    public static implicit operator Action(JsAction func)
    {
        return func.Invoke;
    }
}

/// <summary>
/// Encapsulates a JavaScript function that has a single parameter and does not return a value.
/// </summary>
[JsObject]
public partial class JsAction<T> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsAction{T}"/>.
    /// </summary>
    public void Invoke(T obj)
    {
        ((JsObject)this).Invoke(obj);
    }

    /// <summary>
    /// Gets a managed <see cref="Action{T}"/> from this JavaScript <see cref="JsAction{T}"/>.
    /// </summary>
    /// <param name="func">The action.</param>
    public static implicit operator Action<T>(JsAction<T> func)
    {
        return func.Invoke;
    }
}


/// <summary>
/// Encapsulates a JavaScript function that has two parameters and does not return a value.
/// </summary>
[JsObject]
public partial class JsAction<T1, T2> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsAction{T1,T2}"/>.
    /// </summary>
    public void Invoke(T1 arg1, T2 arg2)
    {
        ((JsObject)this).Invoke(arg1, arg2);
    }

    /// <summary>
    /// Gets a managed <see cref="Action{T1,T2}"/> from this JavaScript <see cref="JsAction{T1,T2}"/>.
    /// </summary>
    /// <param name="func">The action.</param>
    public static implicit operator Action<T1, T2>(JsAction<T1, T2> func)
    {
        return func.Invoke;
    }
}


/// <summary>
/// Encapsulates a JavaScript function that has three parameters and does not return a value.
/// </summary>
[JsObject]
public partial class JsAction<T1, T2, T3> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsAction{T1,T2,T3}"/>.
    /// </summary>
    public void Invoke(T1 arg1, T2 arg2, T3 arg3)
    {
        ((JsObject)this).Invoke(arg1, arg2, arg3);
    }

    /// <summary>
    /// Gets a managed <see cref="Action{T1,T2,T3}"/> from this JavaScript <see cref="JsAction{T1,T2,T3}"/>.
    /// </summary>
    /// <param name="func">The action.</param>
    public static implicit operator Action<T1, T2, T3>(JsAction<T1, T2, T3> func)
    {
        return func.Invoke;
    }
}


/// <summary>
/// Encapsulates a JavaScript function that has four parameters and does not return a value.
/// </summary>
[JsObject]
public partial class JsAction<T1, T2, T3, T4> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsAction{T1,T2,T3,T4}"/>.
    /// </summary>
    public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        ((JsObject)this).Invoke(arg1, arg2, arg3, arg4);
    }

    /// <summary>
    /// Gets a managed <see cref="Action{T1,T2,T3,T4}"/> from this JavaScript <see cref="JsAction{T1,T2,T3,T4}"/>.
    /// </summary>
    /// <param name="func">The action.</param>
    public static implicit operator Action<T1, T2, T3, T4>(JsAction<T1, T2, T3, T4> func)
    {
        return func.Invoke;
    }
}


/// <summary>
/// Encapsulates a JavaScript function that has five parameters and does not return a value.
/// </summary>
[JsObject]
public partial class JsAction<T1, T2, T3, T4, T5> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsAction{T1,T2,T3,T4,T5}"/>.
    /// </summary>
    public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        ((JsObject)this).Invoke(arg1, arg2, arg3, arg4, arg5);
    }

    /// <summary>
    /// Gets a managed <see cref="Action{T1,T2,T3,T4,T5}"/> from this JavaScript <see cref="JsAction{T1,T2,T3,T4,T5}"/>.
    /// </summary>
    /// <param name="func">The action.</param>
    public static implicit operator Action<T1, T2, T3, T4, T5>(JsAction<T1, T2, T3, T4, T5> func)
    {
        return func.Invoke;
    }
}


/// <summary>
/// Encapsulates a JavaScript function that has six parameters and does not return a value.
/// </summary>
[JsObject]
public partial class JsAction<T1, T2, T3, T4, T5, T6> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsAction{T1,T2,T3,T4,T5,T6}"/>.
    /// </summary>
    public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        ((JsObject)this).Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
    }

    /// <summary>
    /// Gets a managed <see cref="Action{T1,T2,T3,T4,T5,T6}"/> from this JavaScript <see cref="JsAction{T1,T2,T3,T4,T5,T6}"/>.
    /// </summary>
    /// <param name="func">The action.</param>
    public static implicit operator Action<T1, T2, T3, T4, T5, T6>(JsAction<T1, T2, T3, T4, T5, T6> func)
    {
        return func.Invoke;
    }
}


/// <summary>
/// Encapsulates a JavaScript function that has seven parameters and does not return a value.
/// </summary>
[JsObject]
public partial class JsAction<T1, T2, T3, T4, T5, T6, T7> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsAction{T1,T2,T3,T4,T5,T6,T7}"/>.
    /// </summary>
    public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
        ((JsObject)this).Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }

    /// <summary>
    /// Gets a managed <see cref="Action{T1,T2,T3,T4,T5,T6,T7}"/> from this JavaScript <see cref="JsAction{T1,T2,T3,T4,T5,T6,T7}"/>.
    /// </summary>
    /// <param name="func">The action.</param>
    public static implicit operator Action<T1, T2, T3, T4, T5, T6, T7>(JsAction<T1, T2, T3, T4, T5, T6, T7> func)
    {
        return func.Invoke;
    }
}


/// <summary>
/// Encapsulates a JavaScript function that has eight parameters and does not return a value.
/// </summary>
[JsObject]
public partial class JsAction<T1, T2, T3, T4, T5, T6, T7, T8> : Function
{
    /// <summary>
    /// Invokes this <see cref="JsAction{T1,T2,T3,T4,T5,T6,T7,T8}"/>.
    /// </summary>
    public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
    {
        ((JsObject)this).Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    }

    /// <summary>
    /// Gets a managed <see cref="Action{T1,T2,T3,T4,T5,T6,T7,T8}"/> from this JavaScript <see cref="JsAction{T1,T2,T3,T4,T5,T6,T7,T8}"/>.
    /// </summary>
    /// <param name="func">The action.</param>
    public static implicit operator Action<T1, T2, T3, T4, T5, T6, T7, T8>(JsAction<T1, T2, T3, T4, T5, T6, T7, T8> func)
    {
        return func.Invoke;
    }
}