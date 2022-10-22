using System.Runtime.InteropServices.JavaScript;

namespace Trungnt2910.Browser.Tests;

public class Given_JsObject : Specification
{
    private JsObject _systemGlobalThis = null!;
    private JsObject _windowInstance = null!;
    private JsObject _dummy = null!;

    protected override void EstablishContext()
    {
        _windowInstance = Window.Instance!;
        _systemGlobalThis = JsObject.FromSystemJSObject(JSHost.GlobalThis)!;
        _dummy = JsObject.FromExpression("[]")!;
    }

    [Observation]
    public void When_CompareSystemAndLibraryJsObject()
    {
        Assert.NotNull(_systemGlobalThis);
        Assert.NotNull(_windowInstance);
        Assert.Equal(_systemGlobalThis, _windowInstance);
        Assert.NotEqual(_systemGlobalThis, _dummy);
    }

    [Observation]
    public void When_NullOrUndefinedFromExpression()
    {
        Assert.Null(JsObject.FromExpression("undefined"));
        Assert.Null(JsObject.FromExpression("null"));
        Assert.NotNull(JsObject.FromExpression("false"));
        Assert.NotNull(JsObject.FromExpression("0"));
        Assert.NotNull(JsObject.FromExpression("[]"));
    }

    [Observation]
    public void When_SameObjectFromExpression()
    {
        // _systemGlobalThis is constructed in JsObject's context.
        Assert.True(ReferenceEquals(_systemGlobalThis, JsObject.FromExpression("globalThis")));
        // _windowInstance is constructed in Window's context.
        Assert.True(ReferenceEquals(_windowInstance, Window.FromExpression("window")));
    }

    [Observation]
    public void When_BooleanToJsObjectString()
    {
        Assert.Equal("true", JsObject.ToJsObjectString(true));
        Assert.Equal("false", JsObject.ToJsObjectString(false));
    }

    [Observation]
    public void When_UndefinedFromExpressionAfterGarbageCollection()
    {
        int? handle = WebAssemblyRuntime.Int32OrNullFromJs("Trungnt2910.Browser.JsObject.CreateHandle({})");
        Assert.NotNull(handle);
        // Simulates a JsObject being created.
        WebAssemblyRuntime.InvokeJS($"Trungnt2910.Browser.JsObject.IncrementReferenceCount({handle})");
        // Simulates a JsObject being finalized.
        WebAssemblyRuntime.InvokeJS($"Trungnt2910.Browser.JsObject.DecrementReferenceCount({handle})");

        // Now there should be a "undefined" slot in the JavaScript object pool.
        Assert.Null(JsObject.FromExpression("undefined"));
    }
}
