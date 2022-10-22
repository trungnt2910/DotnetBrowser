namespace Trungnt2910.Browser.Tests;

public class Given_Union : Specification
{
    private JsFunc<Union<int, bool>, string> _jsToString = null!;
    private Union<int, Window> _intOrWindow = null!;

    protected override void EstablishContext()
    {
        _jsToString = JsFunc<Union<int, bool>, string>.FromExpression("(a) => a.toString()")!;
        _intOrWindow = 69;
    }

    [Observation]
    public void When_ImplicitConvertToUnion()
    {
        Assert.Equal("true", _jsToString.Invoke(true));
        Assert.Equal("false", _jsToString.Invoke(false));
        Assert.Equal("-3", _jsToString.Invoke(-3));
        Assert.Equal("69420", _jsToString.Invoke(69420));
    }

    [Observation]
    public void When_ExplicitConvertFromUnion()
    {
        Assert.Equal(69, (int)_intOrWindow);
        _intOrWindow = Window.Instance!;
        Assert.Equal(Window.Instance!, _intOrWindow);
        Assert.ThrowsAny<Exception>(() => (int)_intOrWindow);
        _intOrWindow = 69;
        Assert.Equal(69, (int)_intOrWindow);
    }
}
