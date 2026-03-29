using Xunit;
using FluentAssertions;
using EcommerceTests.Core;
using EcommerceTests.Pages;
using EcommerceTests.Utilities;

namespace EcommerceTests.Tests
{
    public class SortingTests : BaseTest
    {
        [Fact]
        public void Products_ShouldBeSortedByPrice_LowToHigh()
        {
            LoggerHelper.Info("Starting sorting test");

            // Arrange
            var loginPage = new LoginPage(driver);
            var productsPage = new ProductsPage(driver);

            // Act
            loginPage.Login("test@qabrains.com", "Password123");

            productsPage.SortByLowToHigh();

            var prices = productsPage.GetProductPrices();

            LoggerHelper.Info($"Prices after sorting: {string.Join(", ", prices)}");

            // Assert
            loginPage.IsUserLoggedIn().Should().BeTrue("user should be logged in");

            prices.Should().NotBeEmpty("product list should not be empty");

            prices.Should().BeInAscendingOrder("products should be sorted from low to high");

            LoggerHelper.Info("Sorting test passed");
        }
    }
}