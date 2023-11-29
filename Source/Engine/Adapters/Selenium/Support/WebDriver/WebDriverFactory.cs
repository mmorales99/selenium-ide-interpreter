using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Engine.Adapters.Selenium.Support.WebDriver
{
    public static class WebDriverFactory
    {
        public static IWebDriver Create(WebDriverKinds kind, bool headless = false, string remoteServerUrl = "")
        {
            IWebDriver wd = null;
            DriverOptions options = null;
            switch (kind)
            {
                case WebDriverKinds.InternetExplorer:
                    options = new InternetExplorerOptions()
                    {
                        AcceptInsecureCertificates = true,
                        EnsureCleanSession = true,
                    };
                    wd = new InternetExplorerDriver((InternetExplorerOptions)options);
                    break;
                case WebDriverKinds.FireFox:
                    options = new FirefoxOptions()
                    {
                        AcceptInsecureCertificates = true,
                    };
                    if (!headless)
                    {
                        ((FirefoxOptions)options).AddArguments(new List<string>() { "headless" });
                    }
                    wd = new FirefoxDriver((FirefoxOptions)options);
                    break;
                case WebDriverKinds.MicrosoftEdge:
                    options = new EdgeOptions()
                    {
                        AcceptInsecureCertificates = true,
                    };
                    if (!headless)
                    {
                        ((EdgeOptions)options).AddArguments(new List<string>() { "headless" });
                    }
                    wd = new EdgeDriver((EdgeOptions)options);
                    break;
                case WebDriverKinds.Chrome:
                    options = new ChromeOptions()
                    {
                        AcceptInsecureCertificates = true,
                    };
                    if (!headless)
                    {
                        ((ChromeOptions)options).AddArguments(new List<string>() { "headless" });
                    }
                    wd = new ChromeDriver((ChromeOptions)options);
                    break;
                case WebDriverKinds.RemoteChrome:
                    options = new ChromeOptions()
                    {
                        AcceptInsecureCertificates = true,
                    };
                    ((ChromeOptions)options).AddArguments(new List<string>() { "headless" });
                    wd = new RemoteWebDriver(new Uri(remoteServerUrl), options);
                    break;
                case WebDriverKinds.RemoteFirefox:
                    options = new FirefoxOptions()
                    {
                        AcceptInsecureCertificates = true,
                    };
                    ((FirefoxOptions)options).AddArguments(new List<string>() { "headless" });
                    wd = new RemoteWebDriver(new Uri(remoteServerUrl), options);
                    break;
                case WebDriverKinds.None:
                default:
                    throw new ArgumentException("No WebDriverKind Present. Please specify a WebDriverKind.");
            }
            return wd;
        }
    }
}
