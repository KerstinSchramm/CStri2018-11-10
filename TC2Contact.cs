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
    public class TC2Contact
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
        public void TheTC2ContactTest()
        {
            driver.Navigate().GoToUrl("http://magazine.trivago.com/");
            driver.FindElement(By.LinkText("Contact")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_1 | ]]
            Assert.AreEqual("http://magazine.trivago.com/contact/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='All Fields are required.'])[1]/following::button[1]")).Click();
            Assert.AreEqual("Please mark the checkbox.", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='By submitting a message on our contact form you are sharing what you write with trivago.'])[1]/following::span[1]")).Text);
            driver.FindElement(By.Id("confirm")).Click();
            Assert.AreEqual("All Fields are required.", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Please provide a valid email address.'])[1]/following::span[1]")).Text);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your Message'])[1]/following::textarea[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your Message'])[1]/following::textarea[1]")).Clear();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your Message'])[1]/following::textarea[1]")).SendKeys("my messsage");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='All Fields are required.'])[1]/following::button[1]")).Click();
            Assert.AreEqual("All Fields are required.", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Please provide a valid email address.'])[1]/following::span[1]")).Text);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Full Name'])[1]/following::input[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Full Name'])[1]/following::input[1]")).Clear();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Full Name'])[1]/following::input[1]")).SendKeys("my name");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='All Fields are required.'])[1]/following::button[1]")).Click();
            Assert.AreEqual("All Fields are required.", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Please provide a valid email address.'])[1]/following::span[1]")).Text);
            driver.FindElement(By.Id("contact-email")).Click();
            driver.FindElement(By.Id("contact-email")).Clear();
            driver.FindElement(By.Id("contact-email")).SendKeys("mymail@testmail.com");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='All Fields are required.'])[1]/following::button[1]")).Click();
            Assert.AreEqual("Message Sent Successfully!", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Whether your idea of romantic getaways in Florida is a weeke...'])[1]/following::p[1]")).Text);
            driver.Close();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_local | ]]
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
