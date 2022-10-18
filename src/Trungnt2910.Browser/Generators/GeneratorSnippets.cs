using System;
using System.Linq;

namespace Trungnt2910.Browser.Generators;

/// <summary>
/// A class that contains misc code snippets used for one-time manual code generation.
/// These snippets do not have any value in the library (they're removed by the post-processor), but will be useful when the types
/// need to be re-generated for any reason.
/// </summary>
internal class GeneratorSnippets
{
    public static void GenerateUnions()
    {
        const string s = @"
/// <summary>
/// A union type is a type formed from two or more other types, representing values that may be any one of those types.
/// </summary>
[JsObject]
{{Attributes}}
public partial class Union<
{{TypeParameters}}
    >: JsObject
{
}
";

        for (int i = 2; i <= 8; ++i)
        {
            Console.WriteLine(s
                .Replace("{{Attributes}}", string.Join("\n", Enumerable.Range(1, i).Select(i => $"[Union(\"T{i}\")]")))
                .Replace("{{TypeParameters}}", string.Join(",\n", Enumerable.Range(1, i).Select(i => $"    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T{i}"))));
        }
    }

    public static void GenerateActions()
    {
        const string s = @"
/// <summary>
/// Encapsulates a JavaScript function that has {0} parameters and does not return a value.
/// </summary>
[JsObject]
public partial class JsAction<{1}> : Function
{
    /// <summary>
    /// Invokes this <see cref=""JsAction{{1}}""/>.
    /// </summary>
    public void Invoke({2})
    {
        ((JsObject)this).Invoke({3});
    }

    /// <summary>
    /// Gets a managed <see cref=""Action{{1}}""/> from this JavaScript <see cref=""JsAction{{1}}""/>.
    /// </summary>
    /// <param name=""func"">The action.</param>
    public static implicit operator Action<{1}>(JsAction<{1}> func)
    {
        return func.Invoke;
    }
}
";

        var numbers = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen" };

        for (int i = 2; i <= 8; ++i)
        {
            Console.WriteLine(s
                .Replace("{0}", numbers[i])
                .Replace("{1}", string.Join(",", Enumerable.Range(1, i).Select(i => $"T{i}")))
                .Replace("{2}", string.Join(",", Enumerable.Range(1, i).Select(i => $"T{i} arg{i}")))
                .Replace("{3}", string.Join(",", Enumerable.Range(1, i).Select(i => $"arg{i}")))
                );
        }
    }

    public static void GenerateFunctions()
    {
        const string s = @"
/// <summary>
/// Encapsulates a JavaScript function that has {0} parameters and returns a value of the type specified by the <typeparamref name=""TResult""/> parameter.
/// </summary>
[JsObject]
public partial class JsFunc<{1}, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TResult> : Function
{
    /// <summary>
    /// Invokes this <see cref=""JsFunc{{1}, TResult}""/>.
    /// </summary>
    public TResult? Invoke({2})
    {
        return WebAssemblyRuntime<TResult>.ValueOrNullFromJs($""{_jsThis}({3})"");
    }

    /// <summary>
    /// Gets a managed <see cref=""Func{{1}, TResult}""/> from this JavaScript <see cref=""JsFunc{{1}, TResult}""/>.
    /// </summary>
    /// <param name=""func"">The function.</param>
    public static implicit operator Func<{1}, TResult?>(JsFunc<{1}, TResult> func)
    {
        return func.Invoke;
    }
}
";

        var numbers = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen" };

        for (int i = 2; i <= 8; ++i)
        {
            Console.WriteLine(s
                .Replace("{0}", numbers[i])
                .Replace("{1}", string.Join(",", Enumerable.Range(1, i).Select(i => $"T{i}")))
                .Replace("{2}", string.Join(",", Enumerable.Range(1, i).Select(i => $"T{i} arg{i}")))
                .Replace("{3}", string.Join(",", Enumerable.Range(1, i).Select(i => $"{{ToJsObjectString(arg{i})}}")))
                );
        }
    }
}
