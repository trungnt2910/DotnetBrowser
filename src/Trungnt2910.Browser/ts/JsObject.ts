declare interface Binding {
    bind_static_method<T>(name: string): T;
}

declare interface DotnetRuntime {
    BINDING: Binding
}

declare function getDotnetRuntime(index: number): DotnetRuntime;

namespace Trungnt2910.Browser {
    export class JsObject {
        public static readonly ReferencedObjects: any[] = [];
        private static readonly _freeIds = new Set<number>();
        private static readonly _referenceCount: number[] = [];
        private static readonly _referencedObjectsMap = new Map<any, number>();
        private static readonly _objectsWithEvents = new Map<number, Map<string, EventListener>>();
        private static _managedDispatchEvent: (index: number, type: string, eventHandle: number) => void;

        public static CreateHandle(obj: any): number | null {
            if (JsObject._referencedObjectsMap.has(obj)) {
                const index = JsObject._referencedObjectsMap.get(obj);
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
                (JsObject.ReferencedObjects[index] as EventTarget).addEventListener(type, currentEventList.get(type));
            }
        }

        public static CleanupEventListener(index: number, type: string) {
            const currentEventList = JsObject._objectsWithEvents.get(index);
            if (currentEventList !== undefined) {
                if (currentEventList.has(type)) {
                    (JsObject.ReferencedObjects[index] as EventTarget).removeEventListener(type, currentEventList.get(type));
                    currentEventList.delete(type);
                }
                if (currentEventList.size == 0) {
                    JsObject._objectsWithEvents.delete(index);
                }
            }
        }

        private static DispatchEvent(index: number, type: string, event: Event) {
            JsObject._managedDispatchEvent = JsObject._managedDispatchEvent || getDotnetRuntime(0).BINDING.bind_static_method("[Trungnt2910.Browser] Trungnt2910.Browser.Dom.EventTarget:DispatchEvent");
            JsObject._managedDispatchEvent(index, type, JsObject.CreateHandle(event));
        }
    }
}