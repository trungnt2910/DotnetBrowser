using System;
#if BROWSER
using Trungnt2910.Browser;
#elif WINDOWS
using System.IO;
#endif

Console.WriteLine("Hello World!");

#if BROWSER
using var window = JsObject.ConstructObject("window");
using var location = window["location"];
using var href = location["href"];

Console.WriteLine(href.ToString());
#elif WINDOWS
Console.WriteLine(Directory.GetCurrentDirectory());
#endif