using LibDomTypeScriptParser.Utilities;

namespace ParserTests;

public class Given_JavaScriptName
{
    private static object[] ElementNameCases = new object[]
    {
        new object[]{ "onanimationend", "OnAnimationEnd" },
        new object[]{ "AT_TARGET", "AT_TARGET" },
        new object[]{ "inputBuffer", "InputBuffer" },
        new object[]{ "string", "String" },
        new object[]{ "type", "Type" },
        new object[] { "ongotpointercapture", "OnGotPointerCapture" },
        new object[] { "onsecuritypolicyviolation", "OnSecurityPolicyViolation" },
        new object[] { "onwebkitanimationend", "OnWebkitAnimationEnd" },
        new object[] { "compositionstart", "CompositionStart" },
        new object[] { "gamepaddisconnected", "GamepadDisconnected" }
    };

    private static object[] ParamNameCases = new object[]
    {
        new object[]{ "string", "@string" },
        new object[]{ "type", "type" }
    };

    [Test]
    [TestCaseSource(nameof(ElementNameCases))]
    public void When_ConvertToCSharpElementName(string original, string expected)
    {
        Assert.That(NameHelpers.ToCSharpElementName(original), Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(ParamNameCases))]
    public void When_ConvertToCSharpParamName(string original, string expected)
    {
        Assert.That(NameHelpers.ToCSharpParamName(original), Is.EqualTo(expected));
    }
}