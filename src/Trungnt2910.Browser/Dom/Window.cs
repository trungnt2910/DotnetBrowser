using System;
using Trungnt2910.Browser;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser.Dom;

[JsObject]
[JsObjectReadOnlyProperty("document", "Document", nameof(Document))]
[JsObjectProperty("location", "Location", nameof(Location))]
public partial class Window: EventTarget
{
    public static Window? Instance { get; }

    static Window()
    {
        _objectCache = new();
        Instance = FromExpression("window");
    }
}