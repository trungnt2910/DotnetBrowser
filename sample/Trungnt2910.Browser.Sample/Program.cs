using System;
#if BROWSER
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using Trungnt2910.Browser;
using Trungnt2910.Browser.Dom;
#elif WINDOWS
using System.IO;
#endif

Console.WriteLine("Hello World!");

#if BROWSER
Console.WriteLine(Window.Instance.Location.Href);

var document = JsObject.FromExpression("window.document").Cast<Document>();
var header = document.CreateElement("h1");
header.TextContent = "Hello World!";
document.Body.AppendChild(header);

var div = document.CreateElement("div");
div.AppendChild(document.CreateTextNode($"This website is running on "));
var codeElement = document.CreateElement("code");
codeElement.TextContent = $"net{Environment.Version.ToString(2)}-browser";
div.AppendChild(codeElement);
div.AppendChild(document.CreateTextNode(" target framework."));
div.AppendChild(document.CreateElement("br"));
div.AppendChild(document.CreateTextNode("You can build and install the (unofficial) .NET Browser workload "));
var anchorElement = document.CreateElement("a");
anchorElement.SetValue("href", "https://github.com/trungnt2910/DotnetBrowser");
anchorElement.TextContent = "here";
div.AppendChild(anchorElement);
div.AppendChild(document.CreateTextNode("."));
div.AppendChild(document.CreateElement("br"));
div.AppendChild(document.CreateTextNode("Thanks for visiting my website!"));

document.Body.AppendChild(div);

var para = document.CreateElement("p");
var em = document.CreateElement("em");
em.TextContent = "Hint: Try clicking on the bold \"Hello World!\" text 16 times to unlock the page's secret content!";

para.AppendChild(em);

document.Body.AppendChild(para);

int count = 0;

header.SelectStart += (sender, jsEvent) =>
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
        var jsArr = JsObject.FromExpression("[]").Cast<JsArray>();
        jsArr.Push(text.Cast<object>().ToArray());
        Window.Instance["console"].InvokeMember("log", "Pasted characters: ", jsArr);
        var intArr = JsArray<int>.FromExpression("[]");
        for (int i = 0; i < text.Length; ++i)
        {
            intArr.Add(text[i]);
        }
        Window.Instance["console"].InvokeMember("log", "Pasted characters' codes: ", intArr);
        Console.WriteLine($"Pasted characters' codes (C# side): {{{string.Join(", ", intArr)}}}");
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