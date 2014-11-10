using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace RunEnviroment.TestClass
{
    //[TestClass]
    public class LkMerchant
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private RemoteWebDriver driver;
        private string driverParameter = "FireFox";

        [TestInitialize]
        public void SetUp()
        {
            driver = Enviroment.WebDriverFactory.Create(driverParameter);
        }


        [TestMethod]
        public void ItemLkMerchantSites()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            Assert.IsTrue(driver.FindElementById("ctl00_logon_companyName").Displayed, "Fail open item sites!");

        }

        [TestMethod]
        public void ItemLkMerchantAllPayments()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlAllPayments").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_siteList").Displayed, "Fail open item ItemAllPayments!");
        }

        [TestMethod]
        public void ItemLkMerchantTransactions()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlTransactions").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_holder").Displayed, "Fail open item Transactions!");
        }

        [TestMethod]
        public void ItemLkMerchantChargebacks()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlChargebacks").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_holder").Displayed, "Fail open item Chargebacks!");
        }

        [TestMethod]
        public void ItemLkMerchantQiwi()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlQiwi").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_siteList").Displayed, "Fail open item Qiwi!");
        }

        [TestMethod]
        public void ItemLkMerchantWebMoney()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlWebMoney").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_wmPurse").Displayed, "Fail open item WebMoney!");
        }

        [TestMethod]
        public void ItemLkMerchantPayMaster()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlPayMaster").Click();
            Assert.IsTrue(driver.FindElementById("filterInfo").Displayed, "Fail open item PayMaster!");
        }

        [TestMethod]
        public void ItemLkMerchantPlatron()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlPlatron").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_siteList").Displayed, "Fail open item Platron!");
        }

        [TestMethod]
        public void ItemLkMerchantsmsmobile()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlsmsmobile").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_amountTill").Displayed, "Fail open item smsmobile!");
        }

        [TestMethod]
        public void ItemLkMerchantYandexMoney()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlYandexMoney").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_ymPaymentPayerCode").Displayed, "Fail open item YandexMoney!");
        }

        [TestMethod]
        public void ItemLkMerchantCashTerminals()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlCashTerminals").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_terminal").Displayed, "Fail open item CashTerminals!");
        }

        [TestMethod]
        public void ItemLkMerchantcard2card()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlcard2card").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_Filter_PanSenderFirst").Displayed, "Fail open item card2card!");
        }

        [TestMethod]
        public void ItemLkMerchantStatements()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlStatements").Click();
            Assert.IsTrue(driver.FindElementById("gray_border").Displayed, "Fail open item Statements!");
        }

        [TestMethod]
        public void ItemLkMerchantRevenue()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementByCssSelector("a[href~='../revenue/']").Click();
            Assert.IsTrue(driver.FindElementById("filterInfo").Displayed, "Fail open item Revenue!");
        }

        [TestMethod]
        public void ItemLkMerchantUsers()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementByCssSelector("a[href~='../users/']").Click();
            Assert.IsTrue(driver.FindElementById("gray_border").Displayed, "Fail open item Users!");
        }

        [TestMethod]
        public void ItemLkMerchantRoles()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementByCssSelector("a[href~='../roles/']").Click();
            Assert.IsTrue(driver.FindElementById("gray_border").Displayed, "Fail open item Roles!");
        }

        [TestMethod]
        public void ItemLkMerchantTools()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlTools").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_ddlSiteList").Displayed, "Fail open item Tools!");
        }

        [TestMethod]
        public void ItemLkMerchantNews()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlNews").Click();
            Assert.IsTrue(driver.FindElementByCssSelector("td.title").Text.Contains("Информационное сообщение"), "Fail open item News!");
        }

        [TestMethod]
        public void ItemLkMerchantAccountSettings()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlAccount").Click();
            Assert.IsTrue(driver.FindElementByClassName("infoBlock").Displayed, "Fail open item AccountSettings!");
        }

        [TestMethod]
        public void ItemLkMerchantDocs()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlDocs").Click();
            Assert.IsTrue(driver.FindElementByClassName("doc_banner").Displayed, "Fail open item Docs!");
        }

        [TestMethod]
        public void ItemLkMerchantSupport()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            driver.FindElementById("ctl00_ctl11_mhlSupport").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_subject").Displayed, "Fail open item Support!");
        }

        [TestCleanup]
        public void ShutDown()
        {
            driver.Close();
        }
    }
}
