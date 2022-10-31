using AzureAms.Web;

var window = Window.Instance;
var document = window.Document;

document.Title = "AzureAms Programming Club";

// Tailwind CSS
var link1 = document.CreateElement("link").Cast<HTMLLinkElement>();
link1.Href = "css/tailwind.min.css";
link1.Rel = "stylesheet";
document.Head.AppendChild(link1);

// FontAwesome 5
var script1 = document.CreateElement("script").Cast<HTMLScriptElement>();
script1.CrossOrigin = "anonymous";
script1.Src = "https://kit.fontawesome.com/88fcee8aa9.js";
document.Head.AppendChild(script1);

// Google Fonts
var link2 = document.CreateElement("link").Cast<HTMLLinkElement>();
link2.Href = "https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;700&display=swap";
link2.Rel = "stylesheet";
document.Head.AppendChild(link2);

// Custom CSSes
var link3 = document.CreateElement("link").Cast<HTMLLinkElement>();
link3.Href = "css/style.css";
link3.Rel = "stylesheet";
document.Head.AppendChild(link3);
var link4 = document.CreateElement("link").Cast<HTMLLinkElement>();
link4.Href = "css/index.css";
link4.Rel = "stylesheet";
document.Head.AppendChild(link4);

// Logo
var link5 = document.CreateElement("link").Cast<HTMLLinkElement>();
link5.Href = "./assets/favicon_io/favicon.ico";
link5.Rel = "shortcut icon";
document.Head.AppendChild(link5);
var link6 = document.CreateElement("link").Cast<HTMLLinkElement>();
link6.Href = "./assets/favicon_io/favicon-16x16.png";
link6.Rel = "icon";
link6.Sizes.Add("16x16");
document.Head.AppendChild(link6);
var link7 = document.CreateElement("link").Cast<HTMLLinkElement>();
link7.Href = "./assets/favicon_io/favicon-32x32.png";
link7.Rel = "icon";
link7.Sizes.Add("32x32");
document.Head.AppendChild(link7);

document.Body = new Body();