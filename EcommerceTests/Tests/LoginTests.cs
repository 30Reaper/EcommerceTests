using Xunit;
using FluentAssertions;
using EcommerceTests.Core;
using EcommerceTests.Pages;
using EcommerceTests.Utilities;

namespace EcommerceTests.Tests
{
    public class LoginTests : BaseTest
    {
        [Fact]
        public void Login_WithInvalidCredentials_ShouldShowErrors()
        {
            LoggerHelper.Info("Starting invalid login test");

            // Arrange
            var loginPage = new LoginPage(driver);

            // Act
            loginPage.Login("wrong@email.com", "wrongpassword");

            LoggerHelper.Info("Login attempt completed");

            var emailError = loginPage.GetEmailError();
            var passwordError = loginPage.GetPasswordError();

            // Assert
            emailError.Should().Be("Username is incorrect.", "invalid email should trigger error message");
            passwordError.Should().Be("Password is incorrect.", "invalid password should trigger error message");

            LoggerHelper.Info("Invalid login assertions passed");
        }
    }
}