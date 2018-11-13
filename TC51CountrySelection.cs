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
    public class TC51CountrySelection
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
        public void TheTC51CountrySelectionTest()
        {
            driver.Navigate().GoToUrl("http://magazine.trivago.com/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Southwest'])[3]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Southwest'])[3]/following::select[1]"))).SelectByText("Italia");
            driver.FindElement(By.Id("it_IT")).Click();
            Assert.AreEqual("http://magazine.trivago.it/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Clicca qui per maggiori informazioni'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Clicca qui per maggiori informazioni'])[1]/following::select[1]"))).SelectByText("España");
            driver.FindElement(By.Id("es_ES")).Click();
            Assert.AreEqual("http://magazine.trivago.es/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Aquí tienes más información'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Aquí tienes más información'])[1]/following::select[1]"))).SelectByText("Deutschland");
            driver.FindElement(By.Id("de_DE")).Click();
            Assert.AreEqual("http://magazine.trivago.de/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Hier finden Sie mehr Informationen dazu.'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Hier finden Sie mehr Informationen dazu.'])[1]/following::select[1]"))).SelectByText("France");
            driver.FindElement(By.Id("fr_FR")).Click();
            Assert.AreEqual("http://magazine.trivago.fr/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Plus d’informations ici'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Plus d’informations ici'])[1]/following::select[1]"))).SelectByText("USA");
            driver.FindElement(By.Id("en_US")).Click();
            Assert.AreEqual("http://magazine.trivago.com/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Southwest'])[3]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Southwest'])[3]/following::select[1]"))).SelectByText("Canada");
            Assert.AreEqual("http://magazine.trivago.ca/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign me up!'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign me up!'])[1]/following::select[1]"))).SelectByText("香港");
            Assert.AreEqual("http://magazine.trivago.hk/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='完成'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='完成'])[1]/following::select[1]"))).SelectByText("Australia");
            Assert.AreEqual("http://magazine.trivago.com.au/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Inspire me'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Inspire me'])[1]/following::select[1]"))).SelectByText("Suomi");
            Assert.AreEqual("http://magazine.trivago.fi/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Rekisteröidy'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Rekisteröidy'])[1]/following::select[1]"))).SelectByText("Türkiye");
            Assert.AreEqual("http://magazine.trivago.com.tr/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Burada daha fazla bilgiye ulaşabilirsiniz.'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Burada daha fazla bilgiye ulaşabilirsiniz.'])[1]/following::select[1]"))).SelectByText("Brasil");
            Assert.AreEqual("http://magazine.trivago.com.br/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Eu quero!'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Eu quero!'])[1]/following::select[1]"))).SelectByText("Portugal");
            Assert.AreEqual("http://magazine.trivago.pt/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Clique aqui para obter mais informações.'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Clique aqui para obter mais informações.'])[1]/following::select[1]"))).SelectByText("México");
            Assert.AreEqual("http://magazine.trivago.com.mx/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Suscribir'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Suscribir'])[1]/following::select[1]"))).SelectByText("Ireland");
            Assert.AreEqual("http://magazine.trivago.ie/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign me up'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign me up'])[1]/following::select[1]"))).SelectByText("United Kingdom");
            Assert.AreEqual("http://magazine.trivago.co.uk/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Here is more information'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Here is more information'])[1]/following::select[1]"))).SelectByText("Ελλάδα");
            Assert.AreEqual("http://magazine.trivago.gr/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Εδώ θα βρείτε περισσότερες πληροφορίες.'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Εδώ θα βρείτε περισσότερες πληροφορίες.'])[1]/following::select[1]"))).SelectByText("Danmark");
            Assert.AreEqual("http://magazine.trivago.dk/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Find flere oplysninger her'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Find flere oplysninger her'])[1]/following::select[1]"))).SelectByText("Norge");
            Assert.AreEqual("http://magazine.trivago.no/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Her finner du mer informasjon.'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Her finner du mer informasjon.'])[1]/following::select[1]"))).SelectByText("Sverige");
            Assert.AreEqual("http://magazine.trivago.se/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Läs mer här.'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Läs mer här.'])[1]/following::select[1]"))).SelectByText("Singapore");
            driver.FindElement(By.Id("sg")).Click();
            Assert.AreEqual("http://magazine.trivago.sg/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign Up'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign Up'])[1]/following::select[1]"))).SelectByText("Argentina");
            driver.FindElement(By.Id("es_AR")).Click();
            Assert.AreEqual("http://magazine.trivago.com.ar/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Suscribir'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Suscribir'])[1]/following::select[1]"))).SelectByText("Nederland");
            driver.FindElement(By.Id("nl_NL")).Click();
            Assert.AreEqual("http://magazine.trivago.nl/", driver.Url);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sturen'])[1]/following::select[1]")).Click();
            new SelectElement(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sturen'])[1]/following::select[1]"))).SelectByText("USA");
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
