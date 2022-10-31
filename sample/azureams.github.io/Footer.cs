namespace AzureAms.Web;

public class Footer: HTMLElement
{
    public Footer()
        : base(Window.Instance.Document.CreateElement("footer").Handle)
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        var document = Window.Instance.Document;

        var div1 = document.CreateElement("div");
        div1.ClassList.Add("flex", "flex-col", "md:flex-row", "justify-between", "bg-black");

        var div1_icon = document.CreateElement("div");
        div1_icon.ClassList.Add("order-2", "my-auto", "hidden", "md:block");
        
        var div1_icon_image = document.CreateElement("img").Cast<HTMLImageElement>();
        div1_icon_image.Src = "./assets/logo.png";
        div1_icon_image.Alt = "logo";
        div1_icon_image.ClassList.Add("w-40", "mx-20");

        div1_icon.ReplaceChildren(div1_icon_image);

        var div1_contacts = document.CreateElement("div");
        div1_contacts.ClassList.Add("order-1", "mx-auto", "md:mx-12", "md:my-6");

        var div1_contacts_p1 = document.CreateElement("p");
        div1_contacts_p1.ClassList.Add("text-gray-300", "font-light", "text-center", "text-lg", "md:text-2xl", "mt-4", "md:mt-0");
        div1_contacts_p1.TextContent = "Liên hệ";

        var div1_contacts_div1 = document.CreateElement("div");
        div1_contacts_div1.ClassList.Add("flex", "flex-col", "m-2");

        var div1_contacts_div1_div1 = document.CreateElement("div");
        div1_contacts_div1_div1.ClassList.Add("flex", "my-2");

        var div1_contacts_div1_div1_icon1 = document.CreateElement("i");
        div1_contacts_div1_div1_icon1.ClassList.Add("fas", "fa-phone-alt", "text-gray-300", "text-lg", "md:text-xl");

        var div1_contacts_div1_div1_p1 = document.CreateElement("p");
        div1_contacts_div1_div1_p1.ClassList.Add("text-gray-300", "mx-4", "font-light", "text-xs", "md:text-base" ,"mt-1", "md:mt-0");
        div1_contacts_div1_div1_p1.TextContent = "(+84) 975 277 777";

        div1_contacts_div1_div1.ReplaceChildren(div1_contacts_div1_div1_icon1, div1_contacts_div1_div1_p1);

        var div1_contacts_div1_div2 = document.CreateElement("div");
        div1_contacts_div1_div2.ClassList.Add("flex", "my-2");

        var div1_contacts_div1_div2_anchor1 = document.CreateElement("a").Cast<HTMLAnchorElement>();
        div1_contacts_div1_div2_anchor1.Href = "https://mail.google.com/mail/u/0/?fs=1&tf=cm&source=mailto&to=azureamsprogrammingclub@gmail.com";

        var div1_contacts_div1_div2_anchor1_icon1 = document.CreateElement("i");
        div1_contacts_div1_div2_anchor1_icon1.ClassList.Add("far", "fa-envelope", "text-gray-300", "text-lg", "md:text-xl");

        div1_contacts_div1_div2_anchor1.ReplaceChildren(div1_contacts_div1_div2_anchor1_icon1);

        var div1_contacts_div1_div2_p1 = document.CreateElement("p");
        div1_contacts_div1_div2_p1.ClassList.Add("text-gray-300", "mx-4", "font-light", "text-xs", "md:text-base", "mt-1", "md:mt-0");
        div1_contacts_div1_div2_p1.TextContent = "azureamsprogrammingclub@gmail.com";

        div1_contacts_div1_div2.ReplaceChildren(div1_contacts_div1_div2_anchor1, div1_contacts_div1_div2_p1);

        var div1_contacts_div1_div3 = document.CreateElement("div");
        div1_contacts_div1_div3.ClassList.Add("flex", "my-2");

        var div1_contacts_div1_div3_anchor1 = document.CreateElement("a").Cast<HTMLAnchorElement>();
        div1_contacts_div1_div3_anchor1.Href = "https://www.facebook.com/azureamsprogramming";

        var div1_contacts_div1_div3_anchor1_icon1 = document.CreateElement("i");
        div1_contacts_div1_div3_anchor1_icon1.ClassList.Add("fab", "fa-facebook", "text-gray-300", "text-lg", "md:text-xl");

        div1_contacts_div1_div3_anchor1.ReplaceChildren(div1_contacts_div1_div3_anchor1_icon1);

        var div1_contacts_div1_div3_anchor2 = document.CreateElement("a").Cast<HTMLAnchorElement>();
        div1_contacts_div1_div3_anchor2.Href = "https://www.facebook.com/azureamsprogramming";

        var div1_contacts_div1_div3_anchor2_p1 = document.CreateElement("p");
        div1_contacts_div1_div3_anchor2_p1.ClassList.Add("text-gray-300", "mx-4", "font-light", "hover:text-white", "text-xs", "md:text-base", "mt-1", "md:mt-0");
        div1_contacts_div1_div3_anchor2_p1.TextContent = "https://www.facebook.com/azureamsprogramming";

        div1_contacts_div1_div3_anchor2.ReplaceChildren(div1_contacts_div1_div3_anchor2_p1);

        div1_contacts_div1_div3.ReplaceChildren(div1_contacts_div1_div3_anchor1, div1_contacts_div1_div3_anchor2);

        div1_contacts_div1.ReplaceChildren(div1_contacts_div1_div1, div1_contacts_div1_div2, div1_contacts_div1_div3);

        div1_contacts.ReplaceChildren(div1_contacts_p1, div1_contacts_div1);

        div1.ReplaceChildren(div1_icon, div1_contacts);

        ReplaceChildren(div1);
    }
}
