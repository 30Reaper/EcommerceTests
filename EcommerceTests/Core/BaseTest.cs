using OpenQA.Selenium;
using EcommerceTests.Core.Driver;

namespace EcommerceTests.Core
{
    public class BaseTest : IDisposable
    {
        protected IWebDriver driver;
        private bool disposed = false;

        public BaseTest()
        {
            driver = DriverFactory.GetDriver("chrome");
            driver.Navigate().GoToUrl("https://practice.qabrains.com/ecommerce");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DriverFactory.QuitDriver();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}