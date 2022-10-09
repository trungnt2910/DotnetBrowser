using Gobie;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"{nameof(JsObject)}Attribute", Namespace = "Trungnt2910.Browser.Generators")]
internal sealed class JsObjectGenerator: GobieClassGenerator
{
    [GobieTemplate]
    const string ClassTemplate = @"
        private static readonly global::System.Collections.Generic.Dictionary<int, global::System.WeakReference<{{ClassName}}>> _objectCache = new();

        /// <summary>
        /// Constructs a <see cref=""{{ClassName}}""/> from a JavaScript handle.
        /// </summary>
        /// <param name=""handle"">The JavaScript handle</param>
        /// <remarks>
        /// This constructor is for internal purposes only. The preferred way of getting
        /// an object from a handle is <see cref=""FromHandle(int)""/>
        /// </remarks>
        protected {{ClassName}}(int handle) : base(handle) {}

        /// <summary>
        /// Creates a <see cref=""{{ClassName}}""/> from a raw JavaScript expression.
        /// </summary>
        /// <param name=""jsExpression"">The JavaScript expression as a <see langword=""string""/>.</param>
        /// <returns>A <see cref=""{{ClassName}}""/> representing the expression's result, or <see langword=""null""/> if the expression evaluates to <c>null</c> or <c>undefined</c>.</returns>
        new public static {{ClassName}}? FromExpression(string jsExpression)
        {
            var objectHandleString = global::Uno.Foundation.WebAssemblyRuntime.InvokeJS($""Trungnt2910.Browser.JsObject.ConstructObject({jsExpression})"");
            if (objectHandleString == null)
            {
                return null;
            }
            return FromHandle(int.Parse(objectHandleString));
        }

        /// <summary>
        /// Returns a <see cref=""{{ClassName}}""/> from a JavaScript handle.
        /// </summary>
        /// <param name=""objectHandle"">The JavaScript handle.</param>
        /// <returns>A <see cref=""{{ClassName}}""/> or <see langword=""null""/> if the handle is invalid.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        new public static {{ClassName}} FromHandle(int objectHandle)
        {
            {{ClassName}}? obj;
            if (_objectCache.ContainsKey(objectHandle))
            {
                if (_objectCache[objectHandle].TryGetTarget(out obj))
                {
                    return obj;
                }
                obj = new {{ClassName}}(objectHandle);
                _objectCache[objectHandle].SetTarget(obj);
            }
            obj = new {{ClassName}}(objectHandle);
            _objectCache.Add(objectHandle, new global::System.WeakReference<{{ClassName}}>(obj));
            return obj;
        }

        partial void FinalizerPartial();

        /// <inheritdoc/>
        ~{{ClassName}}()
        {
            if (_objectCache.TryGetValue(JsHandle, out var reference) && 
                reference.TryGetTarget(out {{ClassName}}? obj) && 
                obj == this)
            {
                _objectCache.Remove(JsHandle);
            }

            FinalizerPartial();
        }
    ";
}
