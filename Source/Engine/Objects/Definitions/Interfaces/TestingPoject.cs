using OpenQA.Selenium;
using System.Collections;

namespace Engine.Objects.Definitions.Interfaces.TestingProject
{
    public interface ITestingPoject
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Version { get; set; }
        public string? Url { get; set; }
        public IList? Urls { get; set; }
        public IList? Tests { get; set; }
        public IList? Suites { get; set; }

        public void Run(IWebDriver? driver);
    }
}
