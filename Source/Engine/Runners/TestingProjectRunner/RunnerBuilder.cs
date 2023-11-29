using Engine.Adapters.Selenium.Support.WebDriver;
using Engine.Objects.Implementations;
using OpenQA.Selenium;

namespace Engine.Runners.TestingProject
{
    public class RunnerBuilder 
    {
        internal List<DotSIDEImplementation> dotSIDEImplementations;
        internal IWebDriver driver;
        internal string BaseTargetUri;
        internal uint ExecutionSpeed;
        public RunnerBuilder() { }

        public RunnerBuilder Configure(Action<RunnerOptions> action)
        {
            var options = new RunnerOptions();
            action.Invoke(options);
            switch (options.TestOriginType)
            {
                case TestOrigins.File:
                case TestOrigins.Folder:
                    ConfigureOriginPath(options.TestOrigin.Path);
                    break;
                case TestOrigins.Literal:
                case TestOrigins.Database:
                    throw new NotImplementedException(
                        @"
                        This is a development version of the final product.
                        Some of the expected functionality may not be implemented or not stable enough to be released.
                        If you hitted this exception, please, contact to mjmorales.mcv+dev@gmail.com with the configuration you where using when crashed.
                        ");
            }
            ConfigureBaseUri(options.BaseTargetUrl);
            ConfigureExecutionSpeed(options.ExecutionSpeed);
            ConfigureBrowserDriver(options.WebDriverOptions);

            return this;
        }
        public RunnerBuilder ConfigureExecutionSpeed(int speed)
        {
            if (speed < 0) 
            {
                throw new ArgumentOutOfRangeException("Argument "+nameof(speed)+" MUST be 0 or higher");
            }
            ConfigureExecutionSpeed((uint)speed);
            return this;
        }
        public RunnerBuilder ConfigureExecutionSpeed(uint speed) 
        {
            ExecutionSpeed = speed;
            return this;
        }
        public RunnerBuilder ConfigureBaseUri(string path)
        {
            BaseTargetUri = path;
            return this;
        }
        public RunnerBuilder ConfigureBaseUri(Uri path)
        {
            ConfigureBaseUri(path.OriginalString);
            return this;
        }
        public RunnerBuilder ConfigureOriginPath(string path) 
        {
            if (Directory.Exists(path))
            {
                dotSIDEImplementations = DotSIDEImplementation.LoadFromDirectory(path);
            }
            else if (File.Exists(path)) 
            {
                dotSIDEImplementations = new List<DotSIDEImplementation>
                {
                    DotSIDEImplementation.LoadFromFile(path)
                };
            }
            return this;
        }
        public RunnerBuilder ConfigureBrowserDriver(IWebDriverOptions webDriverOptions) 
        {
            return ConfigureBrowserDriver(webDriverOptions.Kind, webDriverOptions.Headless, webDriverOptions.RemoteServerUrl);
        }
        public RunnerBuilder ConfigureBrowserDriver(string browserName, bool headless = false, string remoteServerUrl = "")
        {
            var webBrowserKind = WebDriverKindsHelper.TryParse(browserName, out WebDriverKinds kind);
            if (webBrowserKind)
            {
                return ConfigureBrowserDriver(kind, headless, remoteServerUrl);
            }
            else
            {
                throw new Exception($"Browser name is not recognised. Try com of this: {WebDriverKindsHelper.GetNamesString()}");
            }
        }
        public RunnerBuilder ConfigureBrowserDriver(WebDriverKinds browserName, bool headless = false, string remoteServerUrl = "") 
        {
            driver = WebDriverFactory.Create(browserName, headless, remoteServerUrl);
            return this;
        }
        public TestingProjectRunner Build() 
        {
            TestingProjectRunner runner = new TestingProjectRunner()
            {
                ExecutionSpeed = this.ExecutionSpeed,
                BaseTargetUri = this.BaseTargetUri,
                TestingProjects = this.dotSIDEImplementations ,
                Driver = this.driver
            };
            return runner;
        }
    }
}
