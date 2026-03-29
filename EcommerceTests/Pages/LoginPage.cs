using OpenQA.Selenium;
using EcommerceTests.Utilities;

namespace EcommerceTests.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        // Locators

        private readonly By emailInput = By.XPath("//input[@type='email']");
        private readonly By passwordInput = By.XPath("//input[@type='password']");
        private readonly By loginButton = By.XPath("//button[@type='submit']");

        private readonly By emailError = By.XPath("//p[normalize-space()='Username is incorrect.']");
        private readonly By passwordError = By.XPath("//p[normalize-space()='Password is incorrect.']");

        private readonly By userMenu = By.XPath("//button[.//span[contains(@class,'user-name')]]");
        private readonly By favoritesButton = By.XPath("//div[@role='menuitem' and normalize-space()='Favorites']");

        // Actions

        public void Login(string email, string password)
        {
            LoggerHelper.Info($"Typing email: {email}");

            var emailField = WaitHelper.WaitForElementVisible(driver, emailInput);
            emailField.Clear();
            emailField.SendKeys(email);

            LoggerHelper.Info("Typing password");

            var passwordField = WaitHelper.WaitForElementVisible(driver, passwordInput);
            passwordField.Clear();
            passwordField.SendKeys(password);

            LoggerHelper.Info("Clicking login button");

            WaitHelper.WaitForElementVisible(driver, loginButton).Click();
        }

        public void GoToFavorites()
        {
            LoggerHelper.Info("Opening user menu");

            WaitHelper.WaitForElementVisible(driver, userMenu).Click();

            LoggerHelper.Info("Navigating to Favorites");

            WaitHelper.WaitForElementVisible(driver, favoritesButton).Click();
        }

        // Assertions 

        public string GetEmailError()
        {
            return WaitHelper.WaitForElementVisible(driver, emailError).Text;
        }

        public string GetPasswordError()
        {
            return WaitHelper.WaitForElementVisible(driver, passwordError).Text;
        }

        public bool IsUserLoggedIn()
        {
            var elements = driver.FindElements(userMenu);
            return elements.Count > 0 && elements[0].Displayed;
        }
    }
}