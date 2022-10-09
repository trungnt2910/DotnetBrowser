﻿using System;
using System.Collections.Generic;
using Trungnt2910.Browser.Generators;
using Uno.Foundation;

namespace Trungnt2910.Browser.Dom;

/// <summary>
/// The <see cref="EventTarget"/> interface is implemented by objects that can receive events and may have listeners for them. In other words, any target of events implements the three methods associated with this interface.
/// </summary>
[JsObject]
[VoidMethod<string, JsObject>("addEventListener", "AddEventListener", Param1 = "type", Param2 = "listener", Comments = "Registers an event handler of a specific event type on the <see cref=\"EventTarget\"/>.")]
[VoidMethod<string, JsObject, JsObject>("addEventListener", "AddEventListener", Param1 = "type", Param2 = "listener", Param3 = "options", Comments = "Registers an event handler of a specific event type on the <see cref=\"EventTarget\"/>.")]
[VoidMethod<string, JsObject, bool>("addEventListener", "AddEventListener", Param1 = "type", Param2 = "listener", Param3 = "useCapture", Comments = "Registers an event handler of a specific event type on the <see cref=\"EventTarget\"/>.")]
public partial class EventTarget: JsObject
{
    private const string _jsType = "Trungnt2910.Browser.JsObject";
    private static readonly Dictionary<int, Dictionary<string, HashSet<EventHandler<Event>>>> _objectsWithEvents = new();

    /// <summary>
    /// Registers an event handler of a specific event type on the <see cref="EventTarget"/>.
    /// </summary>
    /// <param name="type">The event type.</param>
    /// <param name="listener">The C# listener.</param>
    public void AddEventListener(string type, EventHandler<Event> listener)
    {
        if (!_objectsWithEvents.TryGetValue(JsHandle, out var currentEventDict))
        {
            currentEventDict = new();
            _objectsWithEvents.Add(JsHandle, currentEventDict);
        }

        if (!currentEventDict.TryGetValue(type, out var currentEventTypeSet))
        {
            SetupEventListener(type);
            currentEventTypeSet = new();
            currentEventDict.Add(type, currentEventTypeSet);
        }

        currentEventTypeSet.Add(listener);
    }

    /// <summary>
    /// Removes an event listener from the <see cref="EventTarget"/>.
    /// </summary>
    /// <param name="type">The event type.</param>
    /// <param name="listener">The C# listener.</param>
    public void RemoveEventListener(string type, EventHandler<Event> listener)
    {
        if (_objectsWithEvents.TryGetValue(JsHandle, out var currentEventDict))
        {
            if (currentEventDict.TryGetValue(type, out var currentEventTypeSet))
            {
                currentEventTypeSet.Remove(listener);
                if (currentEventTypeSet.Count == 0)
                {
                    currentEventDict.Remove(type);
                    CleanupEventListener(type);
                }
            }
            if (currentEventDict.Count == 0)
            {
                _objectsWithEvents.Remove(JsHandle);
            }
        }
    }

    private void SetupEventListener(string type)
    {
        WebAssemblyRuntime.InvokeJS($"{_jsType}.SetupEventListener({JsHandle}, \"{WebAssemblyRuntime.EscapeJs(type)}\")");
    }

    private void CleanupEventListener(string type)
    {
        WebAssemblyRuntime.InvokeJS($"{_jsType}.CleanupEventListener({JsHandle}, \"{WebAssemblyRuntime.EscapeJs(type)}\")");
    }

    internal static void DispatchEvent(int handle, string type, int eventArgsHandle)
    {
        if (_objectsWithEvents.TryGetValue(handle, out var currentEventDict))
        {
            if (currentEventDict.TryGetValue(type, out var currentEventTypeSet))
            {
                var eventArgs = Event.FromHandle(eventArgsHandle);
                foreach (var listener in currentEventTypeSet)
                {
                    listener?.Invoke(FromHandle(handle), eventArgs);
                }
            }
        }
    }

    partial void FinalizerPartial()
    {
        if (_objectsWithEvents.TryGetValue(JsHandle, out var currentEventDict))
        {
            foreach (var kvp in currentEventDict)
            {
                CleanupEventListener(kvp.Key);
            }
        }
    }
}
