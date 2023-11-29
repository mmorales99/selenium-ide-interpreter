using Engine.Objects.Definitions.Interfaces;
using OpenQA.Selenium;
using System.Collections;

namespace Engine.Objects.Definitions.Abstracts
{
    public abstract class AbsSuite : ISuite
    {
        public abstract string? Id { get; set; }
        public abstract string? Name { get; set; }
        public abstract string? Description { get; set; }
        public abstract bool PersistSession { get; set; }
        public abstract bool Parallel { get; set; }
        public abstract int TimeOut { get; set; }
        public IList? Tests { get; set; }
        public IList? TestsObjectList { get; set; }
        public abstract void Run(IWebDriver? driver);
        public abstract void Dispose();
    }
}
