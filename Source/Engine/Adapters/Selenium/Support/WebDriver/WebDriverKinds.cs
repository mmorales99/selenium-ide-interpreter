using System.Collections;

namespace Engine.Adapters.Selenium.Support.WebDriver
{
    public enum WebDriverKinds
    {
        None = 0,
        // "chrome", "firefox", "edge", "internet-explorer","ch", "ff", "ed", "ie"
        Chrome = 1,
        GC = 1,
        FireFox = 2,
        FF = 2,
        MicrosoftEdge = 3,
        ME = 3,
        InternetExplorer = 4,
        IE = 4,
        RemoteChrome = 5,
        RemoteFirefox = 6,
    }

    public static class WebDriverKindsHelper
    {
        public static string GetName(string name) 
        {
            return GetNames().Where(x => x.Equals(name)).FirstOrDefault();
        }
        public static string[] GetNames() 
        {
            return Enum.GetNames(typeof(WebDriverKinds));
        }
        public static string GetNamesString() 
        {
            return string.Join(',',GetNames());
        }
        public static IList GetValues() 
        {
            return Enum.GetValues(typeof(WebDriverKinds));
        }
        public static bool TryParse(string value, out WebDriverKinds b) 
        {
            b = WebDriverKinds.None;
            if (String.IsNullOrEmpty(value)) 
                return false;
            object? bb = b;
            bool res = Enum.TryParse(typeof(WebDriverKinds), value, true, out bb );
            if(bb == null) b = WebDriverKinds.None;
            else b = (WebDriverKinds)bb;
            return res;
        }
        public static bool IsDefined(string value) 
        {
            if (WebDriverKindsHelper.TryParse(value, out WebDriverKinds b)) 
            {
                return Enum.IsDefined(typeof(WebDriverKinds), b);
            }
            return false;
        }
    }
}
