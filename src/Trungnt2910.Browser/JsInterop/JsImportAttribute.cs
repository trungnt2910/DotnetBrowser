using System;

namespace Trungnt2910.Browser.JsInterop;

/// <summary>
/// Marks this member as being imported from JavaScript.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class JsImportAttribute : Attribute
{
    /// <summary>
    /// The JavaScript name of this member.
    /// </summary>
    public string? Name { get; set; } = null;

    /// <summary>
    /// The accessibility modifier of the generated C# member.
    /// </summary>
    public string Accessibility { get; set; } = "public";

    /// <summary>
    /// Whether a generated property should be read-only.
    /// </summary>
    public bool IsReadOnly { get; set; } = false;
}
