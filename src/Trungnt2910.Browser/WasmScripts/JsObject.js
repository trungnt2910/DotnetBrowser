var Trungnt2910;
(function (Trungnt2910) {
    var Browser;
    (function (Browser) {
        class JsObject {
            static ConstructObject(obj) {
                if (JsObject._freeIds.size) {
                    const index = JsObject._freeIds.values().next().value;
                    JsObject._freeIds.delete(index);
                    JsObject.ReferencedObjects[index] = obj;
                    return index;
                }
                JsObject.ReferencedObjects.push(obj);
                return JsObject.ReferencedObjects.length - 1;
            }
            static DisposeObject(index) {
                delete JsObject.ReferencedObjects[index];
                JsObject._freeIds.add(index);
            }
        }
        JsObject.ReferencedObjects = [];
        JsObject._freeIds = new Set();
        Browser.JsObject = JsObject;
    })(Browser = Trungnt2910.Browser || (Trungnt2910.Browser = {}));
})(Trungnt2910 || (Trungnt2910 = {}));
