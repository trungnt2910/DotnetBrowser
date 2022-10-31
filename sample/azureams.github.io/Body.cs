namespace AzureAms.Web;

public class Body: HTMLBodyElement
{
    public Body()
        : base(Window.Instance.Document.CreateElement("body").Handle)
    {
        var document = Window.Instance.Document;

        var div1 = document.CreateElement("div");
        div1.ClassList.Add("view", "bg-gray-50");

        div1.ReplaceChildren(new Header(), new LandingSection());

        ReplaceChildren(div1, new Footer());
    }
}
