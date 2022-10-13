using System;
using System.Threading.Tasks;
#if BROWSER
using System.Runtime.InteropServices.JavaScript;
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
document.Body.AppendChild(textNode);

int count = 0;

textNode.SelectStart += (sender, jsEvent) =>
{
    Console.WriteLine("How dare you select me!");
    ++count;

    if (count > 10)
    {
        JsObject.FromSystemJSObject(JSHost.GlobalThis).InvokeMember("alert", "Please stop selecting me.");
    }

    if (count > 15)
    {
        new Rickroller.Rickroll().Start();
    }
};

document.Paste += (sender, clipboardEvent) =>
{
    var dataTransfer = clipboardEvent.ClipboardData;

    var text = dataTransfer.GetData("text/plain");

    if (!string.IsNullOrEmpty(text))
    {
        Console.WriteLine($"Pasted string: {text}");
    }
    else
    {
        Console.WriteLine("Did not paste any text.");
    }
};

await Task.Delay(-1);
#elif WINDOWS
Console.WriteLine(Directory.GetCurrentDirectory());
new Rickroller.Rickroll().Start();
#endif