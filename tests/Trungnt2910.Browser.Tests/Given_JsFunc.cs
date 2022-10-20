namespace Trungnt2910.Browser.Tests;

public class Given_JsFunc : Specification
{
    private JsFunc<int, int, int> _jsAdd = null!;
    private Random _random = null!;

    protected override void EstablishContext()
    {
        _jsAdd = JsFunc<int, int, int>.FromExpression("(a, b) => a + b")!;
        _random = new Random();
    }

    [Observation]
    public void When_InvokeFunction()
    {
        Assert.NotNull(_jsAdd);

        Assert.Equal(2, _jsAdd.Invoke(1, 1));
        Assert.Equal(-5, _jsAdd.Invoke(1, -6));

        var a = GetJsSafeRandomInt();
        var b = GetJsSafeRandomInt();

        Assert.Equal(a + b, _jsAdd.Invoke(a, b));
    }

    [Observation]
    public void When_UsedAsCsharpDelegate()
    {
        var addFunc = (Func<int, int, int>)_jsAdd;

        Assert.NotNull(addFunc);

        Assert.Equal(addFunc(1, 1), _jsAdd.Invoke(1, 1));
        Assert.Equal(addFunc(1, -6), _jsAdd.Invoke(1, -6));

        var a = GetJsSafeRandomInt();
        var b = GetJsSafeRandomInt();

        Assert.Equal(addFunc(a, b), _jsAdd.Invoke(a, b));
    }

    private int GetJsSafeRandomInt()
    {
        return _random.Next((int)-1e8, (int)1e8);
    }
}
