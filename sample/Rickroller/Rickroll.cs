#if BROWSER
using Trungnt2910.Browser.Dom;
#elif WINDOWS
using System.Diagnostics;
#endif

namespace Rickroller
{
    public class Rickroll
    {
        private const string Url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";

        public void Start()
        {
#if BROWSER
            var location = Window.Instance?.Location;
            if (location != null)
            {
                location.Href = Url;
            }
#elif WINDOWS
            var ps = new ProcessStartInfo(Url)
            { 
                UseShellExecute = true, 
                Verb = "open" 
            };
            Process.Start(ps);
#endif
        }
    }
}