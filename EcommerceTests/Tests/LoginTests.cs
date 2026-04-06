using Xunit;
using FluentAssertions;
using EcommerceTests.Core;
using EcommerceTests.Models;
using EcommerceTests.Pages;
using EcommerceTests.Utilities;

namespace EcommerceTests.Tests
{
    public class LoginTests : BaseTest
    {
        [Theory]
        [MemberData(nameof(TestDataProvider.InvalidUsers), MemberType = typeof(TestDataProvider))]
        public void Login_WithInvalidCredentials_ShouldShowErrors(UserModel invalidUser, string expectedEmailError, string expectedPasswordError)
        {
            LoggerHelper.Info("Starting invalid login test");

            // Arrange
            var loginPage = new LoginPage(driver);

            // Act
            loginPage.Login(invalidUser.Email, invalidUser.Password);

            LoggerHelper.Info("Login attempt completed");

            var emailError = loginPage.GetEmailError();
            var passwordError = loginPage.GetPasswordError();

            // Assert
            emailError.Should().Be(expectedEmailError);
            passwordError.Should().Be(expectedPasswordError);

            LoggerHelper.Info("Invalid login assertions passed");
        }
    }
}