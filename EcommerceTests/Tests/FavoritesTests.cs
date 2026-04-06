using Xunit;
using FluentAssertions;
using EcommerceTests.Core;
using EcommerceTests.Models;
using EcommerceTests.Pages;
using EcommerceTests.Utilities;

namespace EcommerceTests.Tests
{
    public class FavoritesTests : BaseTest
    {
        [Theory]
        [MemberData(nameof(TestDataProvider.ValidUsers), MemberType = typeof(TestDataProvider))]
        public void AddProductsToFavorites_ShouldDisplayThemInFavoritesPage(UserModel validUser)
        {
            LoggerHelper.Info("Starting Favorites test");

            // Arrange
            var loginPage = new LoginPage(driver);
            var productsPage = new ProductsPage(driver);
            var favoritesPage = new FavoritesPage(driver);
            const int expectedCount = 2;

            // Act
            loginPage.Login(validUser.Email, validUser.Password);
            productsPage.AddFirstNProductsToFavorites(expectedCount);
            loginPage.GoToFavorites();

            var actualCount = favoritesPage.GetFavoritesCount();

            // Assert
            loginPage.IsUserLoggedIn().Should().BeTrue("user should be logged in");
            actualCount.Should().Be(expectedCount, "favorites count should match added products");

            LoggerHelper.Info("Favorites test passed");
        }
    }
}