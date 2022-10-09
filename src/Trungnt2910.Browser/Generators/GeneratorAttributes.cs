using System;

namespace Trungnt2910.Browser.Generators;

[AttributeUsage(AttributeTargets.Assembly)]
internal class MethodGeneratorGeneratorAttribute : Attribute
{
    public const string DefaultBaseName = "MethodGenerator";

    public const int DefaultMaxParams = 8;

    public string BaseName { get; set; } = DefaultBaseName;

    public int MaxParams { get; set; } = DefaultMaxParams;

    public string Template { get; set; } = string.Empty;
}
