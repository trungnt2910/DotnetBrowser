using Gobie;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"{nameof(JsObject)}Attribute", Namespace = "Trungnt2910.Browser.Generators")]
internal sealed class JsObjectGenerator: GobieClassGenerator
{
    [GobieTemplate]
    const string ClassTemplate = @"
        private static readonly global::System.Collections.Generic.Dictionary<int, global::System.WeakReference<{{ClassName}}>> _objectCache = new();
        protected {{ClassName}}(int handle) : base(handle) {}

        new public static {{ClassName}}? FromExpression(string jsExpression)
        {
            var objectHandleString = global::Uno.Foundation.WebAssemblyRuntime.InvokeJS($""Trungnt2910.Browser.JsObject.ConstructObject({jsExpression})"");
            if (objectHandleString == null)
            {
                return null;
            }
            return FromHandle(int.Parse(objectHandleString));
        }

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

        ~{{ClassName}}()
        {
            if (_objectCache.TryGetValue(_handle, out var reference) && 
                reference.TryGetTarget(out {{ClassName}}? obj) && 
                obj == this)
            {
                _objectCache.Remove(_handle);
            }
        }
    ";
}
