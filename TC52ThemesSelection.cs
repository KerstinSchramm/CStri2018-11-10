using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class TC52ThemesSelection
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;
        
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
        }
        
        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        
        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }
        
        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [TestMethod]
        public void TheTC52ThemesSelectionTest()
        {
            driver.Navigate().GoToUrl("http://magazine.trivago.com/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Destinations'])[1]/preceding::div[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Southeast'])[1]/following::div[6]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Themes'])[1]/following::div[6]")).Click();
            Assert.AreEqual("http://magazine.trivago.com/theme/family-vacations/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Destinations'])[1]/preceding::span[3]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Family Vacations'])[1]/following::div[3]")).Click();
            Assert.AreEqual("http://magazine.trivago.com/theme/budget/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Destinations'])[1]/preceding::div[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Budget'])[1]/following::div[3]")).Click();
            Assert.AreEqual("http://magazine.trivago.com/theme/best-weekend-getaways/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Destinations'])[1]/preceding::div[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Weekend Getaways'])[1]/following::div[3]")).Click();
            Assert.AreEqual("http://magazine.trivago.com/theme/best-us-cities-to-visit/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Destinations'])[1]/preceding::span[3]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Themes'])[1]/following::div[6]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Destinations'])[1]/preceding::div[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Destinations'])[1]/preceding::span[2]")).Click();
            driver.Close();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
