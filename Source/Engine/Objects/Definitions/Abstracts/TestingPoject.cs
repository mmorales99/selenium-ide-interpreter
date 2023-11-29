using Engine.Objects.Definitions.Interfaces.TestingProject;
using OpenQA.Selenium;
using System.Collections;

namespace Engine.Objects.Definitions.Abstracts.TestingProject
{
    public abstract class AbsTestingPoject : ITestingPoject, IDisposable
    {
        public abstract string? Id { get; set; }
        public abstract string? Name { get; set; }
        public abstract string? Version { get; set; }
        public abstract string? Url { get; set; }
        public IList? Urls { get; set; }
        public IList? Tests { get; set; }
        public IList? Suites { get; set; }

        public abstract void Run(IWebDriver? driver);
        public abstract void Dispose();
    }
}
