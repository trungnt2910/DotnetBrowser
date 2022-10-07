# Dotnet Browser - custom TFM and workload for .NET 6

An attempt to create a .NET SDK workload that provides the `net6.0-browser` TFM.

## Features
- Run .NET applications in the browser.
- Multi-target .NET applications and libraries with other platforms, using the browser-specific `net6.0-browser` TFM.
- Access JavaScript APIs (work in progress)

## How to install
Use `cake` to build this project (on a privileged shell):

```
dotnet tool restore
dotnet cake build.cake --target=InstallWorkload
```

## Sample project
The repo includes a sample project that multi-targets Windows and Browser WebAssembly.

## Why?
This project is created mostly for multi-targeting purposes.
Imagine the pain of building Uno Platform applications and/or libraries and then managing several different projects, from `Bruh.Skia.Gtk`, `Bruh.Skia.Wpf` to `Bruh.Wasm`.
Using this project, a single multi-targeted project can be created:

```xml
    <TargetFrameworks>net6.0-gtk;net6.0-browser;net6.0-windows7.0</TargetFrameworks>
```

## Plans
- Implement all JavaScript Web API bindings on C#, either manually (easy but time consuming) or generated through TypeScript declarations (very challenging due to the numerous differences between C# and TypeScript).
- Investigate WASM debugging support.
- ~~Build MAUI on top of this workload.~~ Nah, just kidding, this task is too time-consuming.