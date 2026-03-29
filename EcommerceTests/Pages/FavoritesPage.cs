using OpenQA.Selenium;
using EcommerceTests.Utilities;

namespace EcommerceTests.Pages
{
    public class FavoritesPage : BasePage
    {
        public FavoritesPage(IWebDriver driver) : base(driver) { }

        // Locators

        private readonly By productsContainer = By.XPath("//div[contains(@class,'products')]");
        private readonly By productCards = By.XPath(".//div[contains(@class,'group')]");

        // Actions and Validations

        public int GetFavoritesCount()
        {
            LoggerHelper.Info("Getting favorites count");

            var container = WaitHelper.WaitForElementVisible(driver, productsContainer);

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(_ =>
            {
                var count = container.FindElements(productCards).Count;
                return count > 0;
            });

            var products = container.FindElements(productCards);

            LoggerHelper.Info($"Favorites count: {products.Count}");

            return products.Count;
        }
    }
}