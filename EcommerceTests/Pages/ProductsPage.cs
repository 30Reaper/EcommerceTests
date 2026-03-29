using EcommerceTests.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace EcommerceTests.Pages
{
    public class ProductsPage : BasePage
    {
        public ProductsPage(IWebDriver driver) : base(driver) { }

        // Locators

        private readonly By productsContainer = By.XPath("//div[contains(@class,'products')]");

        private readonly By favoriteButtons = By.XPath(".//span[@role='button']/button");

        private readonly By sortDropdown = By.XPath("//button[@role='combobox']");
        private readonly By sortLowToHigh = By.XPath("//div[@role='option' and @data-value='low']");

        private readonly By productPrices = By.XPath(".//span[starts-with(text(),'$')]");

        // Actions

        public void AddFirstNProductsToFavorites(int count)
        {
            LoggerHelper.Info($"Adding {count} products to favorites");

            var container = WaitHelper.WaitForElementVisible(driver, productsContainer);
            var elements = container.FindElements(favoriteButtons);

            for (int i = 0; i < count && i < elements.Count; i++)
            {
                elements[i].Click();
                LoggerHelper.Info($"Added product index: {i}");
            }
        }

        public void SortByLowToHigh()
        {
            LoggerHelper.Info("Opening sort dropdown");

            WaitHelper.WaitForElementVisible(driver, sortDropdown).Click();

            LoggerHelper.Info("Selecting 'Low to High'");

            WaitHelper.WaitForElementVisible(driver, sortLowToHigh).Click();

            WaitForSortingToApply();

            LoggerHelper.Info("Sorting applied");
        }

        // Assert helper to verify prices are sorted correctly

        public List<decimal> GetProductPrices()
        {
            var container = WaitHelper.WaitForElementVisible(driver, productsContainer);
            var elements = container.FindElements(productPrices);

            return elements
                .Select(el => el.Text.Replace("$", "").Trim())
                .Select(text => decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var price) ? price : 0)
                .Where(price => price > 0)
                .ToList();
        }

        private void WaitForSortingToApply()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(_ =>
            {
                var prices = GetProductPrices();

                return prices.Count > 1 &&
                       prices.Zip(prices.Skip(1), (a, b) => a <= b).All(x => x);
            });
        }
    }
}