using Engine.Objects.Definitions.Interfaces;
using OpenQA.Selenium;

namespace Engine.Objects.Implementations
{
    public partial class Suite : ISuite 
    {
        public override void Run(IWebDriver? driver)
        {
            Console.WriteLine($"Corriendo suite: {this.Name} (Tests: {this.Tests.Count})");
            int i = 1;
            foreach (Test test in this.TestsObjectList)
            {
                Console.WriteLine($"Corriendo test: {this.Name}-{test.Name}({test.Id}) ({i}/{this.TestsObjectList.Count})");
                test.Run(driver);
                i++;
            }
        }
        public override void Dispose()
        {
            this.Tests?.Clear();
            this.Tests = null;
            foreach (var t in this.TestsObjectList) { t.Dispose(); }
            this.TestsObjectList?.Clear();
            this.TestsObjectList = null;
        }
    }
}
