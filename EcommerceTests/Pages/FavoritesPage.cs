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
            LoggerHelper.Info("Retrieving favorites count");

            var container = WaitHelper.WaitForElementVisible(driver, productsContainer);
            var products = container.FindElements(productCards);

            var count = products.Count;

            LoggerHelper.Info($"Favorites count: {count}");

            return count;
        }
    }
}