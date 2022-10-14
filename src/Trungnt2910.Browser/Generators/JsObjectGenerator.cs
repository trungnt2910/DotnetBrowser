using Gobie;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"{nameof(JsObject)}Attribute", Namespace = "Trungnt2910.Browser.Generators")]
internal sealed class JsObjectGenerator: GobieClassGenerator
{
    [GobieTemplate]
    const string ClassTemplate = @"
        private static readonly global::System.Collections.Generic.Dictionary<int, global::System.WeakReference<{{ClassName}}>> _objectCache = new();

        /// <summary>
        /// Constructs a <see cref=""{{ClassNameWithoutGenericParameters}}""/> from a JavaScript handle.
        /// </summary>
        /// <param name=""handle"">The JavaScript handle</param>
        /// <remarks>
        /// This constructor is for internal purposes only. The preferred way of getting
        /// an object from a handle is <see cref=""FromHandle(int)""/>
        /// </remarks>
        protected {{ClassNameWithoutGenericParameters}}(int handle) : base(handle) {}

        /// <summary>
        /// Creates a <see cref=""{{ClassNameWithoutGenericParameters}}""/> from a <see cref=""global::System.Runtime.InteropServices.JavaScript.JSObject""/>.
        /// </summary>
        /// <param name=""obj"">The <see cref=""global::System.Runtime.InteropServices.JavaScript.JSObject""/>.</param>
        /// <returns>A <see cref=""{{ClassNameWithoutGenericParameters}}""/> representing an equivalent object, or <see langword=""null""/> if the passed object is invalid.</returns>
        new public static {{ClassName}}? FromSystemJSObject(global::System.Runtime.InteropServices.JavaScript.JSObject obj)
        {
            if (obj.IsDisposed)
            {
                return null;
            }
            var objectHandle = global::Trungnt2910.Browser.JsObject.CreateHandle(obj);
            if (objectHandle == null)
            {
                return null;
            }
            return FromHandle(objectHandle.Value);
        }

        /// <summary>
        /// Creates a <see cref=""{{ClassNameWithoutGenericParameters}}""/> from a raw JavaScript expression.
        /// </summary>
        /// <param name=""jsExpression"">The JavaScript expression as a <see langword=""string""/>.</param>
        /// <returns>A <see cref=""{{ClassNameWithoutGenericParameters}}""/> representing the expression's result, or <see langword=""null""/> if the expression evaluates to <c>null</c> or <c>undefined</c>.</returns>
        new public static {{ClassName}}? FromExpression(string jsExpression)
        {
            // TODO: Which one is faster? This?
            var objectHandle = global::Trungnt2910.Browser.WebAssemblyRuntime.IntOrNullFromJs($""Trungnt2910.Browser.JsObject.CreateHandle({jsExpression})"");
            // or this?
            // using var systemObj = global::Trungnt2910.Browser.WebAssemblyRuntime.ObjectOrNullFromJs(jsExpression);
            // var objectHandle = global::Trungnt2910.Browser.JsObject.CreateHandle(systemObj);
            // Currently we're choosing the first method. The second method pollutes the JavaScript object with a
            // custom handle property, even after the managed object is disposed.
            if (objectHandle == null)
            {
                return null;
            }
            return FromHandle(objectHandle.Value);
        }

        /// <summary>
        /// Returns a <see cref=""{{ClassNameWithoutGenericParameters}}""/> from a JavaScript handle.
        /// </summary>
        /// <param name=""objectHandle"">The JavaScript handle.</param>
        /// <returns>A <see cref=""{{ClassNameWithoutGenericParameters}}""/> or <see langword=""null""/> if the handle is invalid.</returns>
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        new public static {{ClassName}} FromHandle(int objectHandle)
        {
            {{ClassName}}? obj;
            if (_objectCache.TryGetValue(objectHandle, out var weakReference))
            {
                if (_objectCache[objectHandle].TryGetTarget(out obj))
                {
                    return obj;
                }
                obj = new {{ClassName}}(objectHandle);
                weakReference.SetTarget(obj);
                return obj;
            }
            obj = new {{ClassName}}(objectHandle);
            _objectCache.Add(objectHandle, new global::System.WeakReference<{{ClassName}}>(obj));
            return obj;
        }

        partial void FinalizerPartial();

        /// <inheritdoc/>
        ~{{ClassNameWithoutGenericParameters}}()
        {
            if (_objectCache.TryGetValue(JsHandle, out var reference) && 
                reference.TryGetTarget(out {{ClassName}}? obj) && 
                ReferenceEquals(obj, this))
            {
                _objectCache.Remove(JsHandle);
            }

            FinalizerPartial();
        }
    ";
}
