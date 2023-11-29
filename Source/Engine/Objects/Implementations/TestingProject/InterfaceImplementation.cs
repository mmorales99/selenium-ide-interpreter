using OpenQA.Selenium;

namespace Engine.Objects.Implementations
{
    public partial class DotSIDEImplementation
    {
        public override void Run(IWebDriver? driver)
        {
            Console.WriteLine($"Corriendo SideFile: {Name}");
            foreach (Suite suite in Suites)
            {
                suite.TestsObjectList = Tests.Where(x => suite.Tests.Contains(x.Id)).ToList();
                suite.Run(driver);
            }
        }
        public override void Dispose()
        {
            foreach (var t in Tests) { t.Dispose(); }
            this.Tests?.Clear();
            this.Tests = null;
            
            foreach (var s in Suites) { s.Dispose(); }
            this.Suites?.Clear();
            this.Suites = null;
            
            this.Urls?.Clear();
            this.Urls = null;
        }
    }
}
