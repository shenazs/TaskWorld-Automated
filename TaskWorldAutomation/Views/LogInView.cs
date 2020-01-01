using OpenQA.Selenium;
using TaskWorldAutomation.Helper;
using NUnit.Framework;

namespace TaskWorldAutomation.Views
{
    class LogInView
    {
        #region Log In element locators
        private const string emailField = "//input[@type='email']";
        private const string passwordField = "//input[@type='password']";
        private const string logInButton = "//button[@type='submit']";
        private const string userMenu = "//div[contains(@class,'workspace-menu-button')]";
        #endregion

        internal void SetEmailAddress(string email)
        {
            IWebElement emailLocator = FrameworkHelper.GetElementByXpath(emailField);
            FrameworkHelper.SetText(emailLocator,email);
        }

        internal void SetPassword(string password)
        {
            IWebElement passwordLocator = FrameworkHelper.GetElementByXpath(passwordField);
            FrameworkHelper.SetText(passwordLocator, password);
        }

        internal void ClickLogInButton()
        {
            FrameworkHelper.ClickElementByXpath(logInButton);
        }

        internal void Login(string userName, string password)
        {
            SetEmailAddress(userName);
            SetPassword(password);
            ClickLogInButton();
            Assert.True(FrameworkHelper.GetElementByXpath(userMenu).Displayed, "Login is unsucessful, please check credentials");
        }
    }
}
