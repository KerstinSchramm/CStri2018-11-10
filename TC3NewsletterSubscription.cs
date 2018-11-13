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
    public class TC3NewsletterSubscription
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
        public void TheTC3NewsletterSubscriptionTest()
        {
            driver.Navigate().GoToUrl("http://magazine.trivago.com/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Please enter a valid e-mail address'])[2]/following::button[1]")).Click();
            Assert.AreEqual("Please enter a valid e-mail address", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Elevate your next hotel experience!'])[1]/following::div[3]")).Text);
            Assert.AreEqual("Please mark the checkbox.", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Please enter a valid e-mail address'])[1]/following::div[1]")).Text);
            Assert.AreEqual("off", driver.FindElement(By.Id("confirm")).GetAttribute("value"));
            driver.FindElement(By.Id("confirm")).Click();
            Assert.AreEqual("on", driver.FindElement(By.Id("confirm")).GetAttribute("value"));
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys("mymail@testmail.com");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Please enter a valid e-mail address'])[2]/following::button[1]")).Click();
            Assert.AreEqual("You are now checked-in!", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Southwest'])[3]/following::p[1]")).Text);
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
