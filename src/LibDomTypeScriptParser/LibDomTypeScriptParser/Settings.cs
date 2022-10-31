namespace LibDomTypeScriptParser;

public static class Settings
{
    public static string DestinationNamespace { get; set; } = "Trungnt2910.Browser.Dom";

    public static string InputFile { get; set; } = "lib.dom.d.ts";

    public static string OutputFolder { get; set; } = "lib.dom";

    public static string ExistingLibrary { get; set; } = "Trungnt2910.Browser.dll";

    public static string GlobalInterfaceName { get; set; } = "Window";
}
