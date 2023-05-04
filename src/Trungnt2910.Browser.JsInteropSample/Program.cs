using System;
using Trungnt2910.Browser.JsInterop;
using Dummy = System.String;

namespace Trungnt2910.Browser.JsInteropSample;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

[JsImport]
public partial class Location
{
    [JsImport(Accessibility = JsImportAccessibility.Public, IsReadOnly = false)]
    partial void prop_Href(string value);

    [JsImport(Accessibility = JsImportAccessibility.Public)]
    public override partial string ToString();
}

[JsImport]
public partial class Test<T>
{
    [JsImport]
    partial void prop_Lolz(T lol);

    [JsImport]
    public partial Dummy Dummy(T lol);

    [JsImport]
    public partial P Lol<P>(T lol, params int[] i) where P : T;

    [JsImport]
    public partial T GetT(Dummy? name = null);
}