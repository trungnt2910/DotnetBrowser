# Dotnet Browser - custom TFM and workload for .NET 7

An attempt to create a .NET SDK workload that provides the `net7.0-browser` TFM.

## Features
- Run .NET applications in the browser.
- Multi-target .NET applications and libraries with other platforms, using the browser-specific `net7.0-browser` TFM.
- Access JavaScript APIs (work in progress)

## How to install
.NET SDK 7.0 or later is required, as well as the additional `wasm-experimental` workload.

Use `cake` to build this project (on a privileged shell):

```
dotnet workload install wasm-experimental
dotnet tool restore
dotnet cake build.cake --target=InstallWorkload
```

## How to use in your projects
Simply set your project's `TargetFramework` to `net7.0-browser`:

```xml
    <TargetFramework>net7.0-browser</TargetFramework>
```

In the future you might need to replace `7.0` with the .NET version you're using.

## Sample project
The repo includes a sample project that multi-targets Windows and Browser WebAssembly.

## Built-in classes
The project aims to provide a full binding of the browser's JavaScript API in C#.
Currently, only a small subset of this API is implemented. You can call the implemented classes in a way similar to the code in this example:

```C#
using Trungnt2910.Browser.Dom;

// The global "window" object can be accessed using Window.Instance 
Console.WriteLine(Window.Instance.Location.Href);

// Alternatively, you can use `Document.FromExpression("window.document")`,
// or directly access `Window.Instance.Document`.
var document = JsObject.FromExpression("window.document").Cast<Document>();

// `createTextNode` is not implemented yet, so you must manually call the function.
var textNode = document.InvokeMember("createTextNode", "Hello world!");

// Same for `document.body`, and `document.body.appendChild`.
document["body"].InvokeMember("appendChild", textNode);

// Events are supported! Here's how you can use one of them.
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
```

## Why?
This project is created mostly for multi-targeting purposes.
Imagine the pain of building Uno Platform applications and/or libraries and then managing several different projects, from `Bruh.Skia.Gtk`, `Bruh.Skia.Wpf` to `Bruh.Wasm`.
Using this project, a single multi-targeted project can be created:

```xml
    <TargetFrameworks>net7.0-gtk;net7.0-browser;net7.0-windows7.0</TargetFrameworks>
```

## What happened to `net6.0-browser`?
.NET 6 support has been dropped after moving from Uno-based `Uno.Foundation.WebAssembly` to the official .NET `wasm-experimental` implementation, as `WebAssemblyRuntime` functions heavily depend on the new [`System.Runtime.InteropServices.JavaScript`](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.javascript?view=net-7.0&viewFallbackFrom=net-6.0) namespace, which is only available on .NET 7 or later versions.

## Plans
- Implement all JavaScript Web API bindings on C#, either manually (easy but time consuming) or generated through TypeScript declarations (very challenging due to the numerous differences between C# and TypeScript).
- Investigate WASM debugging support.
- ~~Build MAUI on top of this workload.~~ Nah, just kidding, this task is too time-consuming.