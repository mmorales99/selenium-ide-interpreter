using Engine.Adapters.Selenium.Helpers.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Engine.Objects.Implementations
{
    public partial class TestCommand
    {
        public override int MouseUp()
        {
            try
            {
                IsDriverPresent();
                IWebElement? element = driver.TryGetElement(this);
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Release().Perform();
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
