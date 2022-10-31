namespace AzureAms.Web;

public class Header: HTMLElement
{
    private HTMLAnchorElement _indexAnchor;
    private HTMLAnchorElement _newsAnchor;
    private HTMLAnchorElement _aboutAnchor;

    public Header()
        : base(Window.Instance.Document.CreateElement("nav").Handle)
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        var document = Window.Instance.Document;

        ClassList.Add("shadow-md", "z-10", "sticky", "top-0", "navbar", "nav-active", "bg-white");

        var div1 = document.CreateElement("div");
        div1.ClassList.Add("max-w-6xl", "mx-auto", "flex", "justify-between");

        var div1_icon = document.CreateElement("div");

        var div1_icon_link = document.CreateElement("a").Cast<HTMLAnchorElement>();
        div1_icon_link.Href = "./index.html";

        var div1_icon_image = document.CreateElement("img").Cast<HTMLImageElement>();
        div1_icon_image.Src = "./assets/logo.png";
        div1_icon_image.Alt = "logo";
        div1_icon_image.ClassList.Add("w-16", "my-2", "mx-4");

        div1_icon_link.ReplaceChildren(div1_icon_image);

        div1_icon.ReplaceChildren(div1_icon_link);

        var div1_desktopview = document.CreateElement("div");
        div1_desktopview.ClassList.Add("hidden", "sm:flex", "items-center", "pr-10", "text-3xl", "font-light", "uppercase", "hrefs");

        _indexAnchor = document.CreateElement("a").Cast<HTMLAnchorElement>();
        _indexAnchor.Href = "./index.html";
        _indexAnchor.ClassList.Add("mx-6", "text-center", "middle", "active");
        _indexAnchor.Text = "Trang chủ";

        _newsAnchor = document.CreateElement("a").Cast<HTMLAnchorElement>();
        _newsAnchor.Href = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
        _newsAnchor.ClassList.Add("mx-6", "text-center", "middle");
        _newsAnchor.Text = "News & Blogs";

        _aboutAnchor = document.CreateElement("a").Cast<HTMLAnchorElement>();
        _aboutAnchor.Href = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
        _aboutAnchor.ClassList.Add("mx-6", "text-center", "middle");
        _aboutAnchor.Text = "Về CLB";

        div1_desktopview.ReplaceChildren(_indexAnchor, _newsAnchor, _aboutAnchor);

        var div1_mobilemenubutton = document.CreateElement("button");
        div1_mobilemenubutton.Id = "mobile-menu-button";
        div1_mobilemenubutton.ClassList.Add("sm:hidden", "flex", "items-center");

        var div1_mobilemenubutton_icon1 = document.CreateElement("i");
        div1_mobilemenubutton_icon1.ClassList.Add("fas", "fa-bars", "m-2", "text-3xl", "mr-5");

        div1_mobilemenubutton.ReplaceChildren(div1_mobilemenubutton_icon1);

        div1.ReplaceChildren(div1_icon_image, div1_desktopview, div1_mobilemenubutton);

        var mobilemenu = document.CreateElement("div");
        mobilemenu.ClassList.Add("sm:hidden", "flex", "flex-col", "hidden", "text-2xl", "uppercase");

        var mobilemenu_anchor1 = document.CreateElement("a").Cast<HTMLAnchorElement>();
        mobilemenu_anchor1.Href = "./index.html";
        mobilemenu_anchor1.ClassList.Add("mx-6", "text-center", "middle", "active");
        mobilemenu_anchor1.Text = "Trang chủ";

        var mobilemenu_anchor2 = document.CreateElement("a").Cast<HTMLAnchorElement>();
        mobilemenu_anchor2.Href = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
        mobilemenu_anchor2.ClassList.Add("mx-6", "text-center", "middle");
        mobilemenu_anchor2.Text = "News & Blogs";

        var mobilemenu_anchor3 = document.CreateElement("a").Cast<HTMLAnchorElement>();
        mobilemenu_anchor3.Href = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
        mobilemenu_anchor3.ClassList.Add("mx-6", "text-center", "middle");
        mobilemenu_anchor3.Text = "Về CLB";

        mobilemenu.ReplaceChildren(mobilemenu_anchor1, mobilemenu_anchor2, mobilemenu_anchor3);

        ReplaceChildren(div1, mobilemenu);
    }
}
