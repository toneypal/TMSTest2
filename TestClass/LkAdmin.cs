using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace RunEnviroment.TestClass
{
    //[TestClass]
    public class LkAdmin
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
        public void ItemClient()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_merchantId").Displayed, "Fail open item client!");

        }

        [TestMethod]
        public void ItemFilters()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlFilters").Click();
            Assert.IsTrue(driver.FindElementByClassName("filters").Displayed, "Fail open item filters!");

        }

        [TestMethod]
        public void ItemGateways()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_MutableHyperLink1").Click();
            Assert.IsTrue(driver.FindElementByClassName("filters").Displayed, "Fail open item gateways!");

        }

        [TestMethod]
        public void ItemPayments()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlPayments").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_payedDateFrom$year").Displayed, "Fail open item paymets!");

        }

        [TestMethod]
        public void ItemTransactions()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlTransactions").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_cbRebill").Displayed, "Fail open item transaction!");

        }

        [TestMethod]
        public void ItemPaymentsQiwi()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlPaymentsQiwi").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_expired").Displayed, "Fail open item PaymentsQiwi!");
        }

        [TestMethod]
        public void ItemPaymentsWm()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlPaymentsWm").Click();
            Assert.IsTrue(driver.FindElementByTagName("h2").Text.Contains("Счета WebMoney"), "Fail open item PaymentsWm!");
        }

        [TestMethod]
        public void ItemPaymentsPayMaster()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlPaymentPayMaster").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_refunds").Displayed, "Fail open item PaymentsPayMaster!");
        }

        [TestMethod]
        public void ItemPaymentsPlatron()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlPaymentsPlatron").Click();
            Assert.IsTrue(driver.FindElementByTagName("h2").Text.Contains("Счета Platron"), "Fail open item PaymentsPlatron!");
        }

        [TestMethod]
        public void ItemPaymentsYm()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlPaymentsYm").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_refunds").Displayed, "Fail open item PaymentsYm!");
        }

        [TestMethod]
        public void ItemCard2Card()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlCard2Card").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_Filter_PanSenderFirst").Displayed, "Fail open item Card2Card!");
        }

        [TestMethod]
        public void ItemCreditRequests()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlCreditRequests").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_dateFrom$spn").Displayed, "Fail open item CreditRequests!");
        }

        [TestMethod]
        public void ItemTransactionsFlat()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlTransactionsFlat").Click();
            Assert.IsTrue(driver.FindElementById("form1").Displayed, "Fail open item TransactionsFlat!");
        }

        [TestMethod]
        public void ItemTransactionsFlatOld()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlTransactionsFlatOld").Click();
            Assert.IsTrue(driver.FindElementById("form1").Displayed, "Fail open item TransactionsFlatOld!");
        }

        [TestMethod]
        public void ItemPresentments()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlPresentments").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_dateFrom$spn").Displayed, "Fail open item Presentments!");
        }

        [TestMethod]
        public void ItemPresentmentsPos()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlPresentmentsPos").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_gatewaysList").Displayed, "Fail open item PresentmentsPos!");
        }

        [TestMethod]
        public void ItemPresentmentsMerchant()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlPresentmentsMerchant").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_gatewaysList").Displayed, "Fail open item PresentmentsMerchant!");
        }

        [TestMethod]
        public void ItemChargebacks()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlChargebacks").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_list_headers_ctl06_lnkHeader").Displayed, "Fail open item Chargebacks!");
        }

        [TestMethod]
        public void ItemFraudReports()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlFraudReports").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_cardType").Displayed, "Fail open item FraudReports!");
        }

        [TestMethod]
        public void ItemRetrievalRequest()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlRetrievalRequest").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_documentsProvided").Displayed, "Fail open item RetrievalRequest!");
        }

        [TestMethod]
        public void ItemUsers()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlUsers").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_ctl00_filter_login").Displayed, "Fail open item Users!");
        }

        [TestMethod]
        public void ItemStatements()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlStatements").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_paymentDocumentNumber").Displayed, "Fail open item Statements!");
        }

        [TestMethod]
        public void ItemRevenues()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlRevenues").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_drCurrency").Displayed, "Fail open item Revenues!");
        }

        [TestMethod]
        public void ItemGatewayRevenues()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlGatewayRevenues").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_weeks").Displayed, "Fail open item GatewayRevenues!");
        }

        [TestMethod]
        public void ItemDifferentialRevenues()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlDifferentialRevenues").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_date$spn").Displayed, "Fail open item DifferentialRevenues!");
        }

        [TestMethod]
        public void ItemLookups()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_leftMenu1_mhlLookups").Click();
            Assert.IsTrue(driver.FindElementByClassName("filters").Displayed, "Fail open item Lookups!");
        }

        [TestMethod]
        public void ItemBlackList()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlBlackList").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_ctl00_countryCode").Displayed, "Fail open item BlackList!");
        }

        [TestMethod]
        public void ItemWhiteList()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_leftMenu1_mhlWhiteList").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_ctl00_tbSearchCardNumber").Displayed, "Fail open item WhiteList!");
        }

        [TestMethod]
        public void ItemSettings()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_leftMenu1_mhlSettings").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_ptaSettings_rptFilterViewSettings_ctl00_ctl00").Displayed, "Fail open item Settings!");
        }

        [TestMethod]
        public void ItemAudit()
        {
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            driver.FindElementById("ctl00_content_LeftMenu1_mhlAudit").Click();
            Assert.IsTrue(driver.FindElementById("ctl00_content_filter_objectId").Displayed, "Fail open item Audit!");
        }

        //[TestCleanup]
        //public void ShutDown()
        //{
        //    driver.Close();   
        //}
    }
}
