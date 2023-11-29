using OpenQA.Selenium;
using TestFuncional;
using System.Diagnostics;
using Engine.Runners.TestingProject;

internal class Program
{
    private static void Main(string[] args)
    {
        IWebDriver driver = null;
        try
        {
            Configuration.LoadConfiguration(args);

            if (String.IsNullOrEmpty(Configuration.Url) || !Uri.IsWellFormedUriString(Configuration.Url, UriKind.Absolute))
            {
                Debugger.Break();
                Console.WriteLine("Se neceista una url válida para poder ejecutar el programa.");
                Environment.Exit(-1);
            }

            var testsPath = Path.GetFullPath(Configuration.SeleniumTestsUrl);

            TestingProjectRunner runner = new RunnerBuilder()
                .Configure(options => {
                    options.TestOriginType = TestOrigins.Folder;
                    options.TestOrigin = new FolderOrigin(testsPath);
                    options.BaseTargetUrl = new Uri(Configuration.Url);
                    options.ExecutionSpeed = (uint)Configuration.StepsPerSeconds;
                    options.WebDriverOptions = new WebDriverOptions()
                    {
                        Kind = Configuration.Buscador,
                        Headless = Configuration.MostrarBuscador
                    };
                })                
                .Build();
            runner.Run();
        }
        catch
        {
            throw;
        }
        finally 
        {
            if (driver != null) 
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}