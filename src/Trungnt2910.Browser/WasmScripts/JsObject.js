var Trungnt2910;
(function (Trungnt2910) {
    var Browser;
    (function (Browser) {
        class JsObject {
            static async JsObject() {
                // Why do they even have to make getAssemblyExports async?????
                let exports = await getDotnetRuntime(0).getAssemblyExports(JsObject._assemblyName);
                // This piece of code is executing in a very dumb context, probably during the
                // initialization of the managed Trungnt2910.Browser module, but before any JSExport
                // stuff gets to run.
                while (!exports.Trungnt2910) {
                    exports = await getDotnetRuntime(0).getAssemblyExports(JsObject._assemblyName);
                }
                // If any of these ever contains the old value returned by BindStaticMethodDeprecatedFallback,
                // replace them.
                JsObject._managedDispatchEvent = exports.Trungnt2910.Browser.Dom.EventTarget.DispatchEvent;
                JsObject._managedDispatchFulfilled = exports.Trungnt2910.Browser.Promise.DispatchFulfilled;
                JsObject._managedDispatchRejected = exports.Trungnt2910.Browser.Promise.DispatchRejected;
            }
            static CreateHandle(obj) {
                if (JsObject._referencedObjectsMap.has(obj)) {
                    const index = JsObject._referencedObjectsMap.get(obj);
                    if (index === undefined) {
                        return null;
                    }
                    return index;
                }
                if (JsObject._freeIds.size) {
                    const index = JsObject._freeIds.values().next().value;
                    JsObject._freeIds.delete(index);
                    JsObject.ReferencedObjects[index] = obj;
                    JsObject._referencedObjectsMap.set(obj, index);
                    JsObject._referenceCount[index] = 0;
                    return index;
                }
                if (!obj) {
                    return null;
                }
                JsObject.ReferencedObjects.push(obj);
                const index = JsObject.ReferencedObjects.length - 1;
                JsObject._referencedObjectsMap.set(obj, index);
                JsObject._referenceCount.push(0);
                return index;
            }
            static IncrementReferenceCount(index) {
                ++JsObject._referenceCount[index];
            }
            static DecrementReferenceCount(index) {
                if ((--JsObject._referenceCount[index]) === 0) {
                    const oldObj = JsObject.ReferencedObjects[index];
                    delete JsObject.ReferencedObjects[index];
                    JsObject._referencedObjectsMap.delete(oldObj);
                    JsObject._freeIds.add(index);
                }
            }
            static SetupEventListener(index, type) {
                let currentEventList = JsObject._objectsWithEvents.get(index);
                if (currentEventList === undefined) {
                    currentEventList = new Map();
                    JsObject._objectsWithEvents.set(index, currentEventList);
                }
                if (!currentEventList.has(type)) {
                    currentEventList.set(type, function (e) {
                        JsObject.DispatchEvent(index, type, e);
                    });
                    JsObject.ReferencedObjects[index].addEventListener(type, currentEventList.get(type));
                }
            }
            static CleanupEventListener(index, type) {
                const currentEventList = JsObject._objectsWithEvents.get(index);
                if (currentEventList !== undefined) {
                    if (currentEventList.has(type)) {
                        JsObject.ReferencedObjects[index].removeEventListener(type, currentEventList.get(type));
                        currentEventList.delete(type);
                    }
                    if (currentEventList.size == 0) {
                        JsObject._objectsWithEvents.delete(index);
                    }
                }
            }
            static DispatchEvent(index, type, event) {
                JsObject._managedDispatchEvent = JsObject._managedDispatchEvent || JsObject.BindStaticMethodDeprecatedFallback("Trungnt2910.Browser.Dom.EventTarget", "DispatchEvent");
                JsObject._managedDispatchEvent(index, type, JsObject.CreateHandle(event));
            }
            static SetupPromiseHandlers(index) {
                const obj = JsObject.ReferencedObjects[index];
                const promise = obj;
                promise.then((result) => {
                    JsObject.DispatchFulfilled(index, result);
                }, (reason) => {
                    JsObject.DispatchRejected(index, reason);
                });
            }
            static DispatchFulfilled(index, result) {
                JsObject._managedDispatchFulfilled = JsObject._managedDispatchFulfilled || JsObject.BindStaticMethodDeprecatedFallback("Trungnt2910.Browser.Promise", "DispatchFulfilled");
                JsObject._managedDispatchFulfilled(index, JsObject.CreateHandle(result));
            }
            static DispatchRejected(index, reason) {
                JsObject._managedDispatchRejected = JsObject._managedDispatchRejected || JsObject.BindStaticMethodDeprecatedFallback("Trungnt2910.Browser.Promise", "DispatchRejected");
                JsObject._managedDispatchRejected(index, reason);
            }
            static BindStaticMethodDeprecatedFallback(className, name) {
                return (getDotnetRuntime(0).BINDING.bind_static_method(`[${JsObject._assemblyName}] ${className}:${name}`));
            }
        }
        JsObject.ReferencedObjects = [];
        JsObject._freeIds = new Set();
        JsObject._referenceCount = [];
        JsObject._referencedObjectsMap = new Map();
        JsObject._objectsWithEvents = new Map();
        JsObject._assemblyName = "Trungnt2910.Browser";
        Browser.JsObject = JsObject;
    })(Browser = Trungnt2910.Browser || (Trungnt2910.Browser = {}));
})(Trungnt2910 || (Trungnt2910 = {}));
Trungnt2910.Browser.JsObject.JsObject();
