namespace Trungnt2910.Browser.Tests;

public class Given_HTMLElement : Specification
{
    private HTMLDivElement _mainDiv = null!;
    private HTMLStyleElement _style = null!;

    protected override void EstablishContext()
    {
        var window = Window.Instance!;
        var document = window.Document!;
        _mainDiv = document.CreateElement("div")?.Cast<HTMLDivElement>()!;
        document.Body?.AppendChild(_mainDiv);

        _style = document.CreateElement("style")?.Cast<HTMLStyleElement>()!;
        _style.InnerText = @"
            .class1 {
                background: #007FFF;
                color: #FFFFFF;
            }
            .class2 {
                font-weight: bold;
            }
        ";
        document.Head?.AppendChild(_style);
    }

    protected override void DestroyContext()
    {
        Window.Instance?.Document?.Body?.RemoveChild(_mainDiv);
        Window.Instance?.Document?.Head?.RemoveChild(_style);
    }

    [Observation]
    public void When_InitializeDone()
    {
        Assert.NotNull(Window.Instance);
        Assert.NotNull(Window.Instance!.Document);
        Assert.NotNull(_mainDiv);
        Assert.Equal<JsObject>(_mainDiv.ParentNode, Window.Instance.Document.Body);
        Assert.False(_mainDiv.HasChildNodes());
    }

    [Observation]
    public void When_AddChildren()
    {
        var document = Window.Instance!.Document!;

        var button = document.CreateElement("button")!.Cast<HTMLButtonElement>()!;

        const string buttonId = "btn1";
        button.Id = buttonId;
        button.TextContent = "Click me!";

        try
        {
            _mainDiv.Append("Hello World!", button);
            Assert.Equal(@"<div>Hello World!<button id=""btn1"">Click me!</button></div>", _mainDiv.OuterHTML);

            var foundButtonById = document.GetElementById(buttonId);
            Assert.NotNull(foundButtonById);
            Assert.Equal(button, foundButtonById);

            var foundButtonsByName = _mainDiv.GetElementsByTagName("button");
            Assert.NotNull(foundButtonsByName);
            Assert.Equal(1, foundButtonsByName.Length);
            Assert.Equal(button, foundButtonsByName[0]);
        }
        finally
        {
            _mainDiv.ReplaceChildren();
        }
    }

    [Observation]
    public void When_ApplyClass()
    {
        var window = Window.Instance!;
        var document = window.Document!;

        var div1 = document.CreateElement("div")!.Cast<HTMLDivElement>();
        var div2 = document.CreateElement("div")!.Cast<HTMLDivElement>();
        var div12 = document.CreateElement("div")!.Cast<HTMLDivElement>();

        div1.ClassList?.Add("class1");
        div2.ClassList?.Add("class2");
        div12.ClassList?.Add("class1", "class2");

        try
        {
            _mainDiv.ReplaceChildren(div1, div2, div12);

            var class1Elements = document.GetElementsByClassName("class1");
            var class2Elements = _mainDiv.GetElementsByClassName("class2");
            var class12Elements = document.QuerySelectorAll<HTMLDivElement>(".class1.class2");

            Assert.NotNull(class1Elements);
            Assert.NotNull(class2Elements);
            Assert.NotNull(class12Elements);

            Assert.Equal(2, class1Elements.Length);
            Assert.Equal(2, class2Elements.Length);
            Assert.Equal(1, class12Elements.Length);

            var div1Style = window.GetComputedStyle(div1, null);
            var div2Style = window.GetComputedStyle(div2, null);
            var div12Style = window.GetComputedStyle(div12, null);

            Assert.Equal("rgb(0, 127, 255)", div1Style?.BackgroundColor);
            Assert.Equal("rgb(255, 255, 255)", div1Style?.Color);

            Assert.Equal("700", div2Style?.FontWeight);

            Assert.Equal("rgb(0, 127, 255)", div12Style?.BackgroundColor);
            Assert.Equal("rgb(255, 255, 255)", div12Style?.Color);
            Assert.Equal("700", div12Style?.FontWeight);
        }
        finally
        {
            _mainDiv.ReplaceChildren();
        }
    }

    [Observation]
    public async Task When_RaiseEvent()
    {
        var tcs = new TaskCompletionSource();

        int count = 0;

        _mainDiv.Clicked += (s, e) => 
        {
            ++count;
            if (count == 2)
            {
                tcs.SetResult();
            }
        };

        _mainDiv.Click();
        var clickEvent = MouseEvent.FromExpression(@"new MouseEvent(""click"", {})");
        _mainDiv.DispatchEvent(clickEvent);

        await Task.WhenAny(Task.Delay(5000), tcs.Task);
        Assert.True(tcs.Task.IsCompleted);
    }
}
