namespace Trungnt2910.Browser {
    export class JsObject {
        public static readonly ReferencedObjects: any[] = [];
        private static readonly _freeIds: Set<number> = new Set<number>();
        private static readonly _referenceCount: number[] = [];
        private static readonly _referencedObjectsMap: Map<any, number> = new Map<any, number>();

        public static ConstructObject(obj: any): number {
            if (JsObject._referencedObjectsMap.has(obj)) {
                const index = JsObject._referencedObjectsMap.get(obj);
                ++JsObject._referenceCount[index];
                return index;
            }

            if (JsObject._freeIds.size) {
                const index = JsObject._freeIds.values().next().value;
                JsObject._freeIds.delete(index);
                JsObject.ReferencedObjects[index] = obj;
                JsObject._referencedObjectsMap.set(obj, index);
                JsObject._referenceCount[index] = 1;
                return index;
            }

            JsObject.ReferencedObjects.push(obj);
            const index = JsObject.ReferencedObjects.length - 1;
            JsObject._referencedObjectsMap.set(obj, index);
            JsObject._referenceCount.push(1);
            return index;
        }

        public static DisposeObject(index: number) {
            if ((--JsObject._referenceCount[index]) === 0) {
                const oldObj = JsObject.ReferencedObjects[index];
                delete JsObject.ReferencedObjects[index];
                JsObject._referencedObjectsMap.delete(oldObj);
                JsObject._freeIds.add(index);
            }
        }
    }
}