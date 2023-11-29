using Engine.Adapters.Selenium.Support.WebDriver;

namespace Engine.Runners.TestingProject
{
    public interface IWebDriverOptions 
    {
        public WebDriverKinds Kind { get; init; }
        public bool Headless { get; init; }
        public string RemoteServerUrl { get; init; }
    }
    public class WebDriverOptions : IWebDriverOptions 
    {
        public WebDriverKinds Kind { get; init; }
        public bool Headless { get; init; }
        public string RemoteServerUrl { get; init; }
    }
}
