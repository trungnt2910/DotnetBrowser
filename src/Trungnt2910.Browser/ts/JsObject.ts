declare interface Binding {
    bind_static_method<T>(name: string): T;
}

declare interface DotnetRuntime {
    BINDING: Binding,
    getAssemblyExports(assemblyName: string): Promise<any>;
}

declare function getDotnetRuntime(index: number): DotnetRuntime;

namespace Trungnt2910.Browser {
    export class JsObject {
        public static readonly ReferencedObjects: any[] = [];
        private static readonly _freeIds = new Set<number>();
        private static readonly _referenceCount: number[] = [];
        private static readonly _referencedObjectsMap = new Map<any, number>();
        private static readonly _objectsWithEvents = new Map<number, Map<string, EventListener>>();

        private static readonly _assemblyName = "Trungnt2910.Browser";
        private static _managedDispatchEvent: (index: number, type: string, eventHandle: number | null) => void;
        private static _managedDispatchFulfilled: (index: number, valueIndex: number | null) => void;
        private static _managedDispatchRejected: (index: number, reason: any) => void;

        public static async JsObject() {
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

        public static CreateHandle(obj: any): number | null {
            if (obj === null || obj === undefined) {
                return null;
            }

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

            JsObject.ReferencedObjects.push(obj);
            const index = JsObject.ReferencedObjects.length - 1;
            JsObject._referencedObjectsMap.set(obj, index);
            JsObject._referenceCount.push(0);
            return index;
        }

        public static IncrementReferenceCount(index: number) {
            ++JsObject._referenceCount[index];
        }

        public static DecrementReferenceCount(index: number) {
            if ((--JsObject._referenceCount[index]) === 0) {
                const oldObj = JsObject.ReferencedObjects[index];
                delete JsObject.ReferencedObjects[index];
                JsObject._referencedObjectsMap.delete(oldObj);
                JsObject._freeIds.add(index);
            }
        }

        public static SetupEventListener(index: number, type: string) {
            let currentEventList = JsObject._objectsWithEvents.get(index);
            if (currentEventList === undefined) {
                currentEventList = new Map<string, EventListener>();
                JsObject._objectsWithEvents.set(index, currentEventList);
            }
            if (!currentEventList.has(type)) {
                currentEventList.set(type, function (e) {
                    JsObject.DispatchEvent(index, type, e);
                });
                (JsObject.ReferencedObjects[index] as EventTarget).addEventListener(type, <EventListener>currentEventList.get(type));
            }
        }

        public static CleanupEventListener(index: number, type: string) {
            const currentEventList = JsObject._objectsWithEvents.get(index);
            if (currentEventList !== undefined) {
                if (currentEventList.has(type)) {
                    (JsObject.ReferencedObjects[index] as EventTarget).removeEventListener(type, <EventListener>currentEventList.get(type));
                    currentEventList.delete(type);
                }
                if (currentEventList.size == 0) {
                    JsObject._objectsWithEvents.delete(index);
                }
            }
        }

        private static DispatchEvent(index: number, type: string, event: Event) {
            JsObject._managedDispatchEvent = JsObject._managedDispatchEvent || JsObject.BindStaticMethodDeprecatedFallback("Trungnt2910.Browser.Dom.EventTarget", "DispatchEvent");
            JsObject._managedDispatchEvent(index, type, JsObject.CreateHandle(event));
        }

        public static SetupPromiseHandlers(index: number) {
            const obj = JsObject.ReferencedObjects[index];
            const promise = <Promise<any>>obj;
            promise.then((result) => {
                JsObject.DispatchFulfilled(index, result);
            }, (reason) => {
                JsObject.DispatchRejected(index, reason);
            });
        }

        private static DispatchFulfilled(index: number, result: any) {
            JsObject._managedDispatchFulfilled = JsObject._managedDispatchFulfilled || JsObject.BindStaticMethodDeprecatedFallback("Trungnt2910.Browser.Promise", "DispatchFulfilled");
            JsObject._managedDispatchFulfilled(index, JsObject.CreateHandle(result));
        }

        private static DispatchRejected(index: number, reason: any) {
            JsObject._managedDispatchRejected = JsObject._managedDispatchRejected || JsObject.BindStaticMethodDeprecatedFallback("Trungnt2910.Browser.Promise", "DispatchRejected");
            JsObject._managedDispatchRejected(index, reason);
        }

        private static BindStaticMethodDeprecatedFallback<T>(className: string, name: string): T {
            return <T>(getDotnetRuntime(0).BINDING.bind_static_method(`[${JsObject._assemblyName}] ${className}:${name}`));
        }
    }
}

Trungnt2910.Browser.JsObject.JsObject();