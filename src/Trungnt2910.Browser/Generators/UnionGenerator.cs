using Gobie;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"UnionAttribute", Namespace = "Trungnt2910.Browser.Generators", AllowMultiple = true)]

internal sealed class UnionGenerator: GobieClassGenerator
{
    [Required]
    public string Type { get; set; } = string.Empty;

    [GobieTemplate]
    const string Template = @"
        private static global::System.Func<{{ClassName}}, {{Type}}>? _to{{Type}};

        /// <summary>
        /// Converts the union to the member type <typeparamref name=""{{Type}}""/>.
        /// </summary>
        public static explicit operator {{Type}}({{ClassName}} union)
        {
            if (_to{{Type}} == null)
            {
                if (typeof(global::Trungnt2910.Browser.JsObject).IsAssignableFrom(typeof({{Type}})))
                {
                    _to{{Type}} = (global::System.Func<{{ClassName}}, {{Type}}>)global::System.Delegate.CreateDelegate(
                        typeof(global::System.Func<{{ClassName}}, {{Type}}>),
                        typeof(JsObject).GetMethod(nameof(JsObject.Cast))!.MakeGenericMethod(typeof({{Type}})),
                        true)!;
                }
                else
                {
                    var stringTo{{Type}} = (global::System.Func<string, {{Type}}>)global::System.Delegate.CreateDelegate(
                        typeof(global::System.Func<string, {{Type}}>),
                        typeof(WebAssemblyRuntime<{{Type}}>),
                        nameof(WebAssemblyRuntime<{{Type}}>.ValueFromJs),
                        false,
                        true
                        )!;
                    _to{{Type}} = u => stringTo{{Type}}(u._jsThis);
                }
            }

            return _to{{Type}}(union);
        }

        private static global::System.Func<{{Type}}, {{ClassName}}>? _from{{Type}};

        /// <summary>
        /// Converts the object of member type <typeparamref name=""{{Type}}""/> to a union.
        /// </summary>
        public static implicit operator {{ClassName}}({{Type}} member)
        {
            if (_from{{Type}} == null)
            {
                if (typeof(global::Trungnt2910.Browser.JsObject).IsAssignableFrom(typeof({{Type}})))
                {
                    _from{{Type}} = (obj) => ((global::Trungnt2910.Browser.JsObject)(object)obj!)!.Cast<{{ClassName}}>()!;
                }
                else
                {
                    _from{{Type}} = (obj) => {{ClassName}}.FromExpression(ToJsObjectString(obj))!;
                }
            }

            return _from{{Type}}(member);
        }
    ";
}
