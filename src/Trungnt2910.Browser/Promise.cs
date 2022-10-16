using System;
using System.Collections.Generic;
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
        if (_task == null)
        {
            var tcs = new TaskCompletionSource<int?>();
            _taskCompletionSources.Add(JsHandle, tcs);
            _task = tcs.Task;
            SetupPromiseHandlers(JsHandle);
        }

        return _task.GetAwaiter();
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
