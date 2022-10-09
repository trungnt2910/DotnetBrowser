using System;
using System.Threading.Tasks;
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
var textNode = document.CreateTextNode("Hello World!");
document.Body.InvokeMember("appendChild", textNode);

textNode.Cast<EventTarget>().AddEventListener("selectstart", (sender, jsEvent) =>
{
    Console.WriteLine("How dare you select me!");
});

await Task.Delay(-1);
#elif WINDOWS
Console.WriteLine(Directory.GetCurrentDirectory());
#endif