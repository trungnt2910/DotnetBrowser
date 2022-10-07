using System;
#if BROWSER
using Trungnt2910.Browser;
using Trungnt2910.Browser.Dom;
#elif WINDOWS
using System.IO;
#endif

Console.WriteLine("Hello World!");

#if BROWSER
Console.WriteLine(Window.Instance.Location.Href);

var document = JsObject.FromExpression("window.document").Cast<Document>();
var textNode = document.InvokeMember("createTextNode", "Hello world!");
document["body"].InvokeMember("appendChild", textNode);
#elif WINDOWS
Console.WriteLine(Directory.GetCurrentDirectory());
#endif