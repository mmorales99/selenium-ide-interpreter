using Engine.Adapters.Selenium.Helpers.WebDriver;
using OpenQA.Selenium;

namespace Engine.Objects.Implementations
{
    public partial class TestCommand
    {
        public override int Type()
        {
            try
            {
                IsDriverPresent();
                IWebElement? element = driver.TryGetElement(this);
                if (element != null) { element.SendKeys(Value); }
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
