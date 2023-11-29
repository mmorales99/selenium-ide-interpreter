using Engine.Adapters.Selenium.Helpers.WebDriver;
using OpenQA.Selenium;

namespace Engine.Objects.Implementations
{
    public partial class TestCommand
    {
        public override int Click(IDictionary<string, object> vars)
        {
            try
            {
                IsVarsPresent(vars);
                IsDriverPresent();
                if (OpensWindow)
                {
                    vars["WindowHandles"] = driver.WindowHandles;
                }
                IWebElement? element = driver.TryGetElement(this);
                if (element != null) { element.Click(); }
                if (OpensWindow)
                {
                    vars[WindowHandleName] = driver.WaitForWindow(WindowTimeout, vars);
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR al ejecutar un comando del tipo: {Command}\n" +
                    $"Error: {ex.Message}");
                return -1;
            }
        }
    }
}
