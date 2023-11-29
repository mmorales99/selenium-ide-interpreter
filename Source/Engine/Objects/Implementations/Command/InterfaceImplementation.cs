using OpenQA.Selenium;
using System.Reflection;

namespace Engine.Objects.Implementations
{
    public partial class TestCommand
    {
        public override int Execute(IWebDriver? driver, IDictionary<string, object> testVars)
        {
            if (driver is null) return -1;
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));

            if (String.IsNullOrEmpty(this.Command)) return -1;

            MethodInfo method = GetMethod(this.Command); // Executes methods en CommandList folder
            if (method.GetParameters().Length > 0)
            {
                return (int)method.Invoke(this, new object?[] { testVars });
            }
            else
            {
                return (int)method.Invoke(this, null);
            }
        }
        public override void Dispose() 
        {
            this.driver?.Quit();
            this.driver?.Close();
            this.driver?.Dispose();
            this.driver = null;
            this.Targets?.Clear();
            this.Targets = null;
        }
    }
}
