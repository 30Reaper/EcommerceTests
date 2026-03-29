using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace EcommerceTests.Core.Driver
{
    public static class DriverFactory
    {
        private static readonly ThreadLocal<IWebDriver?> driver = new();

        public static IWebDriver GetDriver(string browser = "chrome")
        {
            if (driver.Value == null)
            {
                driver.Value = browser.ToLower() switch
                {
                    "edge" => new EdgeDriver(),
                    _ => new ChromeDriver()
                };

                driver.Value.Manage().Window.Maximize();
            }

            return driver.Value!;
        }

        public static void QuitDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value = null;
            }
        }
    }
}