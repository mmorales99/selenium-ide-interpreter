using Engine.Objects.Definitions.Interfaces;
using OpenQA.Selenium;
using System.Collections;

namespace Engine.Objects.Definitions.Abstracts
{
    public abstract class AbsTest : ITest
    {
        public abstract string? Id { get; set; }
        public abstract string? Name { get; set; }
        public abstract string? Description { get; set; }
        public abstract string? ParentSuite { get; set; }
        public IList? Commands { get; set; }
        public IDictionary<string, object>? TestVars { get; set; }
        public abstract void Run(IWebDriver? driver);
        public abstract void Dispose();
    }
}
