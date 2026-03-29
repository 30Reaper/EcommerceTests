using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EcommerceTests.Utilities
{
    public static class WaitHelper
    {
        public static IWebElement WaitForElementVisible(IWebDriver driver, By by, int timeout = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}