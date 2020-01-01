using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TaskWorldAutomation.Helper;

namespace TaskWorldAutomation
{
    public enum BrowserType {
        Chrome,
        InternetExplorer}

    class UITestFixtureBase
    {
        private BrowserType _browserType;

        public UITestFixtureBase(BrowserType browserType)
        {
            _browserType = browserType;
        }

        [SetUp]
        public virtual void TestSetUp()
        {
            switch (_browserType)
            {
                case BrowserType.Chrome:
                    FrameworkHelper.driver = new ChromeDriver();
                    break;

                case BrowserType.InternetExplorer:
                    FrameworkHelper.driver = new InternetExplorerDriver();
                    break;

            }
            OpenBrowser(FrameworkHelper.url);
            
        }

        internal void OpenBrowser(String url)
        {
            FrameworkHelper.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            FrameworkHelper.driver.Navigate().GoToUrl(url);
            FrameworkHelper.driver.Manage().Window.Maximize();
            FrameworkHelper.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
        }

        [TearDown]
        public void closeBrowser()
        {
            FrameworkHelper.driver.Quit();
        }
    }
}
