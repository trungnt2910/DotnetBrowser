namespace Trungnt2910.Browser.Tests;

public class Given_IntPromise : Specification
{
    private Promise<int> _promise1 = null!;
    private Promise<int> _promise2 = null!;

    protected override void EstablishContext()
    {
        _promise1 = Promise<int>.FromExpression("new Promise((resolve, reject) => setTimeout(() => resolve(1), 1000))")!;
        _promise2 = Promise<int>.FromExpression("new Promise((resolve, reject) => setTimeout(() => resolve(2), 2000))")!;
    }

    [Observation]
    public async void When_Await()
    {
        Assert.NotNull(_promise1);
        Assert.Equal(1, await _promise1);
    }

    [Observation]
    public async void When_AwaitAgain()
    {
        Assert.Equal(1, await _promise1);
    }

    [Observation]
    public async void When_UsedWithTaskApi()
    {
        var arr = await Task.WhenAll(_promise1, _promise2, Task.FromResult(3));
        Assert.True(arr.SequenceEqual(new[] { 1, 2, 3 }));
    }
}