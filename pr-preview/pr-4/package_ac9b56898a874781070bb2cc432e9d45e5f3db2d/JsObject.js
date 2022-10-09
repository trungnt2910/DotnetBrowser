var Trungnt2910;
(function (Trungnt2910) {
    var Browser;
    (function (Browser) {
        class JsObject {
            static ConstructObject(obj) {
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
            static DisposeObject(index) {
                if ((--JsObject._referenceCount[index]) === 0) {
                    const oldObj = JsObject.ReferencedObjects[index];
                    delete JsObject.ReferencedObjects[index];
                    JsObject._referencedObjectsMap.delete(oldObj);
                    JsObject._freeIds.add(index);
                }
            }
        }
        JsObject.ReferencedObjects = [];
        JsObject._freeIds = new Set();
        JsObject._referenceCount = [];
        JsObject._referencedObjectsMap = new Map();
        Browser.JsObject = JsObject;
    })(Browser = Trungnt2910.Browser || (Trungnt2910.Browser = {}));
})(Trungnt2910 || (Trungnt2910 = {}));
