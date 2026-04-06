using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace EcommerceTests.Core.Driver
{
    public static class DriverFactory
    {
        public static IWebDriver GetDriver(string browser = "chrome")
        {
            IWebDriver driver = browser.ToLower() switch
            {
                "firefox" => CreateFirefoxDriver(),
                _ => CreateChromeDriver()
            };

            driver.Manage().Window.Maximize();
            return driver;
        }

        private static IWebDriver CreateChromeDriver()
        {
            return new ChromeDriver();
        }

        private static IWebDriver CreateFirefoxDriver()
        {
            return new FirefoxDriver();
        }
    }
}