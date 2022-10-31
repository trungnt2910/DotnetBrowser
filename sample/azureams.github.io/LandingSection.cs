namespace AzureAms.Web;

public class LandingSection: HTMLDivElement
{
    public LandingSection()
        : base(Window.Instance.Document.CreateElement("div").Handle)
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        var document = Window.Instance.Document;

        ClassList.Add("bg-cover", "bg-center", "bg-no-repeat", "grid", "grid-col-1", "grid-rows-1", "justify-center");
        Id = "landing-section";

        var bg_image_container = document.CreateElement("div");
        bg_image_container.ClassList.Add("bg", "row-start-1", "col-start-1");
        bg_image_container.Id = "bg-img-container";

        var bg_image_container_img1 = document.CreateElement("img").Cast<HTMLImageElement>();
        bg_image_container_img1.Alt = "";
        bg_image_container_img1.Src = "./assets/cover.png";

        bg_image_container.ReplaceChildren(bg_image_container_img1);

        var div1 = document.CreateElement("div").Cast<HTMLDivElement>();
        div1.ClassList.Add(
            "backdrop-filter", "backdrop-brightness-50", "mx-auto", "row-start-1", "col-start-1", 
            "grid", "grid-cols-1", "md:grid-cols-2", "grid-rows-1", "gap-0", "justify-center",
            "lg:px-24", "px-2");
        div1.Style.ZIndex = "2";

        var div1_div1 = document.CreateElement("div");
        div1_div1.ClassList.Add("self-center");

        var div1_div1_h11 = document.CreateElement("h1");
        div1_div1_h11.ClassList.Add("text-3xl", "pt-3", "lg:pt-0", "lg:text-5xl", "text-white", "pb-3", "font-bold", "lg:text-left", "text-center");
        div1_div1_h11.TextContent = "Đây KHÔNG phải trang web chính thức của CLB AzureAms";

        var div1_div1_p1 = document.CreateElement("p");
        div1_div1_p1.ClassList.Add("text-white", "lg:text-2xl", "text-md", "text-center", "lg:text-left");
        div1_div1_p1.TextContent = "This is NOT the official page of AzureAms Programming Club. This is just a demo of Dotnet Browser - a custom workload that allows creating webpages using ONLY C#.";

        var div1_div1_div1 = document.CreateElement("div");
        div1_div1_div1.ClassList.Add("text-2xl", "lg:text-3xl", "text-white", "pb-3", "font-bold", "text-center", "pt-9", "hover:shadow-xl", "link-app", "lg:text-left");

        var joinnowbtn = document.CreateElement("button").Cast<HTMLButtonElement>();
        joinnowbtn.ClassList.Add("hover:shadow-xl", "text-white", "font-bold", "py-2", "px-4", "mt-4");
        joinnowbtn.Id = "join-now-btn";
        joinnowbtn.Clicked += JoinNowBtn_Clicked;

        var joinnowbtn_icon1 = document.CreateElement("i");
        joinnowbtn_icon1.ClassList.Add("fas", "fa-angle-right", "pl-1");

        joinnowbtn.ReplaceChildren("Install Dotnet Browser now!", joinnowbtn_icon1);

        div1_div1_div1.ReplaceChildren(joinnowbtn);

        div1_div1.ReplaceChildren(div1_div1_h11, div1_div1_p1, div1_div1_div1);

        var logo_container = document.CreateElement("div").Cast<HTMLDivElement>();
        logo_container.ClassList.Add("hidden", "md:flex", "justify-center", "self-center", "pt-5", "pb-5");
        logo_container.Id = "logo-container";
        logo_container.Style.Height = "fit-content";

        var logo_container_image1 = document.CreateElement("img").Cast<HTMLImageElement>();
        logo_container_image1.Src = "./assets/logo.png";
        logo_container_image1.Style.Height = "35vw";

        logo_container.ReplaceChildren(logo_container_image1);

        div1.ReplaceChildren(div1_div1, logo_container);

        ReplaceChildren(bg_image_container, div1);
    }

    private void JoinNowBtn_Clicked(object sender, MouseEvent e)
    {
        Window.Instance.Open("https://github.com/trungnt2910/DotnetBrowser", "_blank", null);
    }
}
