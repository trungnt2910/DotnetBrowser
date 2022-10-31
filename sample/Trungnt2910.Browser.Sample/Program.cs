using System;
#if BROWSER
using System.Linq;
using System.Threading.Tasks;
using Trungnt2910.Browser;
using Trungnt2910.Browser.Dom;
using Console = System.Console;
#elif WINDOWS
using System.IO;
#endif

Console.WriteLine("Hello World!");

#if BROWSER
Console.WriteLine(Window.Instance.Location.Href);

var document = Window.Instance.Document;
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
var anchorElement1 = document.CreateElement("a");
anchorElement1.SetValue("href", "https://github.com/trungnt2910/DotnetBrowser");
anchorElement1.TextContent = "here";
div.AppendChild(anchorElement1);
div.AppendChild(document.CreateTextNode("."));
div.AppendChild(document.CreateElement("br"));
div.AppendChild(document.CreateTextNode("For an example of using .NET Browser with Tailwind to create a responsive site using just C# and CSS, see the "));
var anchorElement2 = document.CreateElement("a");
anchorElement2.SetValue("href", "AzureAms");
anchorElement2.TextContent = "AzureAms";
div.AppendChild(anchorElement2);
div.AppendChild(document.CreateTextNode(" sample."));
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
        Window.Instance.Alert("Please stop selecting me.");
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
        Window.Instance.Console.Log("Pasted characters: ", jsArr);
        var intArr = JsArray<int>.FromExpression("[]");
        for (int i = 0; i < text.Length; ++i)
        {
            intArr.Add(text[i]);
        }
        Window.Instance.Console.Log("Pasted characters' codes: ", intArr);
        Console.WriteLine($"Pasted characters' codes (C# side): {{{string.Join(", ", intArr)}}}");
    }
    else
    {
        Console.WriteLine("Did not paste any text.");
    }
};

var promise = Window.Instance
    .InvokeMember("eval", "new Promise((resolve, reject) => setTimeout(() => { console.log(\"This is a delayed hello from a JavaScript promise!\"); resolve(); }, 1000))")
    .Cast<Promise>();
await promise;
Console.WriteLine("Nice to meet you, JavaScript promise!");

var numberPromise = Promise<int>
    .FromExpression("new Promise((resolve, reject) => setTimeout(() => { console.log(\"Returning a delayed number from a JavaScript promise!\"); resolve(2910); }, 1000))");
var number = await numberPromise;
Console.WriteLine($"Got a number from JavaScript: {number}.");

var windowPromise = Promise<Window>
    .FromExpression("new Promise((resolve, reject) => setTimeout(() => { console.log(\"Returning a delayed window from a JavaScript promise!\"); resolve(window); }, 1000))");
var window = await windowPromise;
Console.WriteLine($"Got a window from JavaScript: {window.Location.Href}");

var fetchResult = await Window.Instance.Fetch("https://www.randomnumberapi.com/api/v1.0/random?min=100&max=1000&count=5", null);
var fetchResultString = await fetchResult.Text();
Console.WriteLine($"Array of random numbers: {fetchResultString}");

await Task.Delay(-1);
#elif WINDOWS
Console.WriteLine(Directory.GetCurrentDirectory());
new Rickroller.Rickroll().Start();
#endif