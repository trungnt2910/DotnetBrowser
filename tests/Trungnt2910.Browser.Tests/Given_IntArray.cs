namespace Trungnt2910.Browser.Tests;

public class Given_IntArray : Specification
{
    private JsArray<int> _array = null!;

    protected override void EstablishContext()
    {
        _array = JsArray<int>.FromExpression("[1, 2, 3]")!;
    }

    [Observation]
    public void When_GetProperties()
    {
        Assert.NotNull(_array);
        Assert.NotEmpty(_array);
        Assert.Equal(3, _array.Length);
        Assert.Equal(3, _array.Count);
    }

    [Observation]
    public void When_GetElementByIndex()
    {
        Assert.Equal(1, _array[0]);
        Assert.Equal(2, _array[1]);
        Assert.Equal(3, _array[2]);
        Assert.ThrowsAny<Exception>(() => _array[3]);
        Assert.ThrowsAny<Exception>(() => _array[-1]);
    }

    [Observation]
    public void When_SetElementFromManagedCode()
    {
        Assert.Equal(1, _array[0]);
        _array[0] = 69420;
        Assert.Equal(69420, _array[0]);
        _array[0] = 1;
        Assert.Equal(1, _array[0]);
    }

    [Observation]
    public void When_UsedWithLinq()
    {
        Assert.True(_array.SequenceEqual(new[] { 1, 2, 3 }));
    }
}
