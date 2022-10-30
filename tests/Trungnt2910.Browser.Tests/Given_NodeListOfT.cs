namespace Trungnt2910.Browser.Tests;

public class Given_NodeListOfT : Specification
{
    private HTMLDivElement _mainDiv = null!;
    private NodeListOf<Element> _mainDivElements = null!;
    private Element[] _mainDivElementsArray = null!;
    private Element _element1 = null!;
    private Element _element2 = null!;
    private Element _element3 = null!;

    protected override void EstablishContext()
    {
        var window = Window.Instance!;
        var document = window.Document!;
        _mainDiv = document.CreateElement("div")?.Cast<HTMLDivElement>()!;
        document.Body?.AppendChild(_mainDiv);

        _element1 = document.CreateElement("a")!;
        _element2 = document.CreateElement("div")!;
        _element3 = document.CreateElement("button")!;

        _mainDiv.ReplaceChildren(_element1, _element2, _element3);
        _mainDivElements = _mainDiv.QuerySelectorAll<Element>("*")!;

        _mainDivElementsArray = new[] { _element1, _element2, _element3 };

        Assert.NotNull(_mainDiv);
        Assert.NotNull(_element1);
        Assert.NotNull(_element2);
        Assert.NotNull(_element3);
        Assert.NotNull(_mainDivElements);
    }

    protected override void DestroyContext()
    {
        Window.Instance?.Document?.Body?.RemoveChild(_mainDiv);
        _mainDiv = null!;
        _mainDivElements = null!;
        _mainDivElementsArray = null!;
        _element1 = _element2 = _element3 = null!;
    }

    [Observation]
    public void When_AccessLengthProperties()
    {
        Assert.Equal(_mainDivElementsArray.Length, _mainDivElements.Count);
        Assert.Equal(_mainDivElements.Length, _mainDivElements.Count);
    }

    [Observation]
    public void When_AccessElementsByIndex()
    {
        for (var i = 0; i < _mainDivElementsArray.Length; ++i)
        {
            Assert.Equal(_mainDivElementsArray[i], _mainDivElements[i]);
        }
    }

    [Observation]
    public void When_AccessElementsByForEach()
    {
        var tempList = new List<Element?>();

        foreach (var elem in _mainDivElements)
        {
            tempList.Add(elem?.Cast<Element>());
        }

        Assert.True(_mainDivElementsArray.SequenceEqual(tempList));
    }

    [Observation]
    public void When_UsedWithLinq()
    {
        Assert.True(_mainDivElements.SequenceEqual(_mainDivElementsArray));
        Assert.True(_mainDivElements.SequenceEqual(_mainDivElements.ToList()));
        Assert.True(_mainDivElements.Zip(_mainDivElementsArray).Aggregate(true, (result, elemPair) => result && (elemPair.First == elemPair.Second)));
    }
}
