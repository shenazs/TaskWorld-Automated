using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWorldAutomation.Helper
{
    public static class FrameworkHelper
    {
        public static IWebDriver _driver;
        public static BrowserType DriverBrowserType;
        public static IWebDriver driver
        {
            get { return _driver; }
            set
            {
                _driver = value;
                if (_driver != null)
                {
                    if(_driver is ChromeDriver)
                    {
                        DriverBrowserType = BrowserType.Chrome;
                    }
                    else
                    {
                        DriverBrowserType = BrowserType.InternetExplorer;
                    }
                }
            }
        }

        public static WebDriverWait wait;

        public const string url = "https://enterprise.taskworld.com/";

        public static void ClickElement(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }

        public static void ClickElementByXpath(string xpath)
        {
            driver.FindElement(By.XPath(xpath)).Click();
        }

        public static IWebElement GetElementById(string xPath)
        {
            return driver.FindElement(By.Id(xPath));
        }
        public static IWebElement GetElementByXpath(string xPath)
        {
            return driver.FindElement(By.XPath(xPath));
        }
        public static void SetText(IWebElement element,string text, bool clearExistingtext = true)
        {
            element.Click();
            if (clearExistingtext)
            {
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Delete);
            }
            element.SendKeys(text);
        }
        
        public static void WaitForLoading()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var grid = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='tw-collapsible-section__header --expanded']")));

        }

    }
}
