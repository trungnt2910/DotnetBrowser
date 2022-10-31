namespace Trungnt2910.Browser.Tests;

public class Given_Promise : Specification
{
    private Promise<int> _intPromise1 = null!;
    private Promise<int> _intPromise2 = null!;
    private Promise<Window> _windowPromise = null!;

    protected override void EstablishContext()
    {
        _intPromise1 = Promise<int>.FromExpression("new Promise((resolve, reject) => setTimeout(() => resolve(1), 1000))")!;
        _intPromise2 = Promise<int>.FromExpression("new Promise((resolve, reject) => setTimeout(() => resolve(2), 2000))")!;
        _windowPromise = Promise<Window>.FromExpression("new Promise((resolve, reject) => setTimeout(() => resolve(globalThis), 1500))")!;
    }

    [Observation]
    public async void When_Await()
    {
        Assert.NotNull(_intPromise1);
        Assert.Equal(1, await _intPromise1);

        Assert.NotNull(_windowPromise);
        Assert.Equal(Window.Instance, await _windowPromise);
    }

    [Observation]
    public async void When_AwaitAgain()
    {
        Assert.Equal(1, await _intPromise1);
        Assert.Equal(Window.Instance, await _windowPromise);
    }

    [Observation]
    public async void When_UsedWithTaskApi()
    {
        var arr = await Task.WhenAll(_intPromise1, _intPromise2, Task.FromResult(3));
        Assert.True(arr.SequenceEqual(new[] { 1, 2, 3 }));
    }
}