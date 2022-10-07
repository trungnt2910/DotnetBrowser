namespace Trungnt2910.Browser {
    export class JsObject {
        public static readonly ReferencedObjects: any[] = [];
        private static readonly _freeIds: Set<number> = new Set<number>();

        public static ConstructObject(obj: any): number {
            if (JsObject._freeIds.size) {
                const index = JsObject._freeIds.values().next().value;
                JsObject._freeIds.delete(index);
                JsObject.ReferencedObjects[index] = obj;
                return index;
            }

            JsObject.ReferencedObjects.push(obj);
            return JsObject.ReferencedObjects.length - 1;
        }

        public static DisposeObject(index: number) {
            delete JsObject.ReferencedObjects[index];
            JsObject._freeIds.add(index);
        }
    }
}