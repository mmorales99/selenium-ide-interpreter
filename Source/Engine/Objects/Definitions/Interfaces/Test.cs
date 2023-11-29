using OpenQA.Selenium;
using System.Collections;

namespace Engine.Objects.Definitions.Interfaces
{
    public interface ITest
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ParentSuite { get; set; }
        public IList? Commands { get; set; }
        public IDictionary<string, object>? TestVars { get; set; }

        public void Run(IWebDriver? driver);
    }
}
