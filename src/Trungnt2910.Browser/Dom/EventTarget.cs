using System;
using System.Collections.Generic;
using Trungnt2910.Browser.Generators;
using Trungnt2910.Browser;
using System.Runtime.InteropServices.JavaScript;

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
    private static readonly Dictionary<EventTarget, Dictionary<string, HashSet<EventHandler<Event?>>>> _objectsWithEvents = new();

    /// <summary>
    /// Registers an event handler of a specific event type on the <see cref="EventTarget"/>.
    /// </summary>
    /// <param name="type">The event type.</param>
    /// <param name="listener">The C# listener.</param>
    public void AddEventListener(string type, EventHandler<Event?> listener)
    {
        if (!_objectsWithEvents.TryGetValue(this, out var currentEventDict))
        {
            currentEventDict = new();
            _objectsWithEvents.Add(this, currentEventDict);
        }

        if (!currentEventDict.TryGetValue(type, out var currentEventTypeSet))
        {
            SetupEventListener(JsHandle, type);
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
    public void RemoveEventListener(string type, EventHandler<Event?> listener)
    {
        if (_objectsWithEvents.TryGetValue(this, out var currentEventDict))
        {
            if (currentEventDict.TryGetValue(type, out var currentEventTypeSet))
            {
                currentEventTypeSet.Remove(listener);
                if (currentEventTypeSet.Count == 0)
                {
                    currentEventDict.Remove(type);
                    CleanupEventListener(JsHandle, type);
                }
            }
            if (currentEventDict.Count == 0)
            {
                _objectsWithEvents.Remove(this);
            }
        }
    }

    [JSImport($"globalThis.{_jsType}.{nameof(SetupEventListener)}")]
    private static partial void SetupEventListener(int handle, string type);

    [JSImport($"globalThis.{_jsType}.{nameof(CleanupEventListener)}")]
    private static partial void CleanupEventListener(int handle, string type);

    [JSExport]
    internal static void DispatchEvent(int handle, string type, int? eventArgsHandle)
    {
        var sender = FromHandle(handle);
        if (_objectsWithEvents.TryGetValue(sender, out var currentEventDict))
        {
            if (currentEventDict.TryGetValue(type, out var currentEventTypeSet))
            {
                var eventArgs = eventArgsHandle != null ? Event.FromHandle((int)eventArgsHandle) : null;
                foreach (var listener in currentEventTypeSet)
                {
                    listener?.Invoke(sender, eventArgs);
                }
            }
        }
    }
}
