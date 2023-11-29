using OpenQA.Selenium;
using System.Collections;

namespace Engine.Objects.Definitions.Interfaces
{
    public interface ISuite
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool PersistSession { get; set; }
        public bool Parallel { get; set; }
        public int TimeOut { get; set; }
        public IList? Tests { get; set; }
        public IList? TestsObjectList { get; set; }

        public void Run(IWebDriver? driver);
    }
}
