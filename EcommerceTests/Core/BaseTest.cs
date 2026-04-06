using OpenQA.Selenium;
using EcommerceTests.Core.Config;
using EcommerceTests.Core.Driver;

namespace EcommerceTests.Core
{
    public class BaseTest : IDisposable
    {
        protected IWebDriver driver;
        private bool disposed = false;

        public BaseTest()
        {
            driver = DriverFactory.GetDriver(TestSettings.Browser);
            driver.Navigate().GoToUrl(TestSettings.BaseUrl);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    driver.Quit();
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