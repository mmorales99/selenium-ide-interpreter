using Engine.Objects.Definitions.Interfaces;
using OpenQA.Selenium;

namespace Engine.Adapters.Selenium.Helpers.WebDriver
{
    public static class Helpers
    {
        private static readonly Dictionary<string, Func<IWebDriver, string, IWebElement>> SelectorDictionary = new Dictionary<string, Func<IWebDriver, string, IWebElement>> 
        {
            { "id", (driver, selector)=> driver.FindElement(By.Id(selector)) },
            { "name", (driver, selector)=> driver.FindElement(By.Name(selector)) },
            { "tagName", (driver, selector)=> driver.FindElement(By.TagName(selector)) },
            { "linkText", (driver, selector)=> driver.FindElement(By.LinkText(selector)) },
            { "partialLinkText", (driver, selector)=> driver.FindElement(By.PartialLinkText(selector)) },
            { "css", (driver, selector)=> driver.FindElement(By.CssSelector(selector)) },
            { "className", (driver, selector)=> driver.FindElement(By.ClassName(selector)) },
            { "xpath", (driver, selector)=> driver.FindElement(By.XPath(selector)) },
        };

        public static string WaitForWindow(this IWebDriver driver, int timeout, IDictionary<string, object> vars)
        {
            try
            {
                Thread.Sleep(timeout);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            var whNow = ((IReadOnlyCollection<object>)driver.WindowHandles).ToList();
            var whThen = ((IReadOnlyCollection<object>)vars["WindowHandles"]).ToList();
            if (whNow.Count > whThen.Count)
            {
                return whNow.Except(whThen).First().ToString();
            }
            else
            {
                return whNow.First().ToString();
            }
        }
        public static IWebElement? TryGetElement(this IWebDriver driver, ICommand command)
        {
            IWebElement? element = driver.TryGetElement(command.Target);
            if (element == null)
            {
                foreach (string[] target in command.Targets)
                {
                    string selectorValue = (string)target[0].Split('=')[1];
                    string selectionType = (string)target[1];
                    element = driver.TryGetElement(selectionType, selectorValue);
                    if (element != null) break;
                }
            }
            return element;
        }
        public static IWebElement? TryGetElement(this IWebDriver driver, string selectorValue)
        {
            (string elementSearchCriteria, string elementSearchValue) = selectorValue.Split('=') switch { var arr => (arr[0], arr[1]) };
            return driver.TryGetElement(elementSearchCriteria, elementSearchValue);
        }
        public static IWebElement? TryGetElement(this IWebDriver driver, string selectorType, string selectorValue)
        {
            IWebElement? element = null;
            if (selectorType.Contains(':')) 
            {
                selectorType = selectorType.Split(':')[0];
            } 
            element = SelectorDictionary[selectorType].Invoke(driver, selectorValue);
            //switch (selectorType)
            //{
            //    case "name":
            //        element = driver.FindElement(By.Name(selectorValue));
            //        break;
            //    case "css:finder":
            //        element = driver.FindElement(By.CssSelector(selectorValue));
            //        break;
            //    case "xpath:attributes":
            //        element = driver.FindElement(By.XPath(selectorValue));
            //        break;
            //    case "xpath:idRelative":
            //        element = driver.FindElement(By.XPath(selectorValue));
            //        break;
            //    case "xpath:position":
            //        element = driver.FindElement(By.XPath(selectorValue));
            //        break;
            //}
            return element;
        }
    }
}
