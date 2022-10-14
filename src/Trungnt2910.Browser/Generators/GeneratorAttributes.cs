using System;

namespace Trungnt2910.Browser.Generators;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal class MethodGeneratorGeneratorAttribute : Attribute
{
    public const string DefaultBaseName = "MethodGenerator";

    public const bool DefaultIncludeReturnTypeParam = true;

    public const bool DefaultIncludeRestTypeParam = false;
    
    public const int DefaultMaxParams = 8;

    public string BaseName { get; set; } = DefaultBaseName;

    public bool IncludeReturnTypeParam { get; set; } = true;

    public bool IncludeRestTypeParam { get; set; } = false;

    public int MaxParams { get; set; } = DefaultMaxParams;

    public string Template { get; set; } = string.Empty;
}
