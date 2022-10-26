using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser;

/// <summary>
/// The <see cref="Promise"/> object represents the eventual completion (or failure) of an asynchronous operation and its resulting value.
/// </summary>
[JsObject]
public partial class Promise: JsObject
{
    private const string _jsType = "Trungnt2910.Browser.JsObject";
    private static readonly Dictionary<int, TaskCompletionSource<int?>> _taskCompletionSources = new();

    private Task? _task;

    /// <summary>
    /// Returns a <see cref="TaskAwaiter"/> so that this <see cref="Promise"/> could be used with <see langword="await"/>.
    /// </summary>
    /// <returns>A <see cref="TaskAwaiter"/>.</returns>
    public TaskAwaiter GetAwaiter()
    {
        _task ??= GetTaskForThis();
        return _task.GetAwaiter();
    }

    /// <summary>
    /// Converts this <see cref="Promise"/> to a managed <see cref="Task"/>
    /// </summary>
    /// <param name="promise">The promise to convert.</param>
    public static implicit operator Task(Promise promise)
    {
        promise._task ??= promise.GetTaskForThis();
        return promise._task;
    }

    private Task GetTaskForThis()
    {
        var tcs = new TaskCompletionSource<int?>();
        _taskCompletionSources.Add(JsHandle, tcs);
        SetupPromiseHandlers(JsHandle);
        return ProcessTaskReturnValue(tcs.Task);
    }

    /// <summary>
    /// Given a task containing a handle, process its return value.
    /// </summary>
    /// <param name="input">The task with a int handle.</param>
    /// <returns>A task containing the managed result.</returns>
    /// <remarks>Should be overrided by <see cref="Promise{T}"/> to return the desired value to awaiters.</remarks>
    private protected virtual Task ProcessTaskReturnValue(Task<int?> input)
    {
        return input.ContinueWith((task) =>
        {
            if (task.Result != null)
            {
                // Immediately dispose of the result.
                JsObject.IncrementReferenceCount(task.Result.Value);
                JsObject.DecrementReferenceCount(task.Result.Value);
            }
        });
    }

    [JSImport($"globalThis.{_jsType}.SetupPromiseHandlers")]
    private static partial void SetupPromiseHandlers(int handle);

    [JSExport]
    internal static void DispatchFulfilled(int handle, int? valueHandle)
    {
        if (_taskCompletionSources.TryGetValue(handle, out var tcs))
        {
            tcs.SetResult(valueHandle);
            _taskCompletionSources.Remove(handle);
        }
    }

    [JSExport]
    internal static void DispatchRejected(int handle, Exception? exception)
    {
        if (_taskCompletionSources.TryGetValue(handle, out var tcs))
        {
            tcs.SetException(exception ?? new JSException("An unspecified error has occurred during JavaScript promise handling."));
            _taskCompletionSources.Remove(handle);
        }
    }
}

/// <summary>
/// Used by TypeScript code for types that look like a <see cref="Promise"/>.
/// </summary>
[JsObject]
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class PromiseLike: JsObject
{
    /// <summary>
    /// Converts this <see cref="PromiseLike"/> instance to a <see cref="Promise"/>.
    /// </summary>
    /// <param name="self">The <see cref="PromiseLike"/> instance.</param>
    public static implicit operator Promise(PromiseLike self)
    {
        return self.Cast<Promise>();
    }

    /// <summary>
    /// Converts this <see cref="Promise"/> instance to a <see cref="PromiseLike"/>.
    /// </summary>
    /// <param name="self">The <see cref="Promise"/> instance.</param>
    public static implicit operator PromiseLike(Promise self)
    {
        return self.Cast<PromiseLike>();
    }
}