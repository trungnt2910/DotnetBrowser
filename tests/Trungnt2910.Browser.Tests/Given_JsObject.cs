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
}
