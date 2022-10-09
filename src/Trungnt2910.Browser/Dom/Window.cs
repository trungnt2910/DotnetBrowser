using System;
using Trungnt2910.Browser;
using Trungnt2910.Browser.Generators;

namespace Trungnt2910.Browser.Dom;

/// <summary>
/// The <see cref="Window"/> interface represents a window containing a DOM document; the <see cref="Document.DefaultView"/> property points to the DOM document loaded in that window.
/// </summary>
/// <remarks>
/// A <see cref="Window"/> for a given document can be obtained using the document.defaultView property.<br/>
/// 
/// A global variable, window, representing the window in which the script is running, is exposed to JavaScript code.<br/>
/// 
/// The <see cref="Window"/> interface is home to a variety of functions, namespaces, objects, and constructors which are not necessarily directly associated with the concept of a user interface window.
/// However, the <see cref="Window"/> interface is a suitable place to include these items that need to be globally available.
/// Many of these are documented in the JavaScript Reference and the DOM Reference.<br/>
/// 
/// In a tabbed browser, each tab is represented by its own <see cref="Window"/> object; the global window seen by JavaScript code running within a given tab always represents the tab in which the code is running.
/// That said, even in a tabbed browser, some properties and methods still apply to the overall window that contains the tab, such as <see cref="ResizeTo(int, int)"/> and <see cref="InnerHeight"/>.
/// Generally, anything that can't reasonably pertain to a tab pertains to the window instead.
/// </remarks>
[JsObject]
[JsObjectReadOnlyProperty("document", "Document", nameof(Document), Comments = "Returns a reference to the document that the window contains.")]
[NumericReadOnlyProperty("innerHeight", "InnerHeight", "double", Comments = "Gets the height of the content area of the browser window including, if rendered, the horizontal scrollbar.")]
[NumericReadOnlyProperty("innerWidth", "InnerWidth", "double", Comments = "Gets the width of the content area of the browser window including, if rendered, the vertical scrollbar.")]
[JsObjectProperty("location", "Location", nameof(Location), Comments = "Gets/sets the location, or current URL, of the window object.")]
[VoidMethod<int, int>("resizeTo", "ResizeTo", Param1 = "width", Param2 = "height", Comments = "Dynamically resizes window.")]
public partial class Window: EventTarget
{
    /// <summary>
    /// Gets the global <see cref="Window"/> instance.
    /// </summary>
    public static Window? Instance { get; }

    static Window()
    {
        _objectCache = new();
        Instance = FromExpression("window");
    }
}