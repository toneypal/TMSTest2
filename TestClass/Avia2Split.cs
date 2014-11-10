using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace RunEnviroment.TestClass
{
    [TestClass]
    public class Avia2Split
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private RemoteWebDriver driver;

        private string gateway;
        private string merchantId;
        private string merchantIdForLink;
        private static string orderIdForFilter;
        private string orderId;
        private string amount;
        private string currency;
        private string commission;
        private string pnr;
        private string idata;
        private string securityKey;
        private string privateSecurityKey;
        private string baseUrlForPayment;

        private string cardNumberA;
        private string cardNumberB;
        private string cardNumberC;
        private string cardNumberD;
        private string expDateMonth;
        private string expDateYear;
        private string cardHolderName;
        private string cardCVC;
        private string bankName;
        private string cardFormEmail;

        private string commissionTransactionStatus;
        private string gdsTransactionStatus;
        private string iDataTransactionStatus;
        private string routedMid;

        private string paymentParameters;
        private string paymentLink;

        [TestInitialize]
        public void SetUp()
        {
            string browserType = System.Environment.GetEnvironmentVariable("BrowserName");
            Console.WriteLine("browserType = {0}", browserType);

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, browserType != null ? browserType : "firefox");

            driver = RunEnviroment.EnviromentSelect.CreateLocalDriver(capabilities);

            orderIdForFilter = TestUtils.GetNewOrderId();
            orderId = "OrderId=" + orderIdForFilter;
            gateway = TestContext.DataRow["Gateway"].ToString();
            merchantId = TestContext.DataRow["MerchantId"].ToString();
            merchantIdForLink = "MerchantId=" + merchantId;
            amount = TestContext.DataRow["Amount"].ToString();
            currency = TestContext.DataRow["Currency"].ToString();
            commission = TestContext.DataRow["Commission"].ToString();
            pnr = TestContext.DataRow["PNR"].ToString();
            idata = TestContext.DataRow["IData"].ToString() + "           ";
            securityKey = TestContext.DataRow["SecurityKey"].ToString();
            baseUrlForPayment = Parameters.GetParameter("base-url-for-payment");

            commissionTransactionStatus = TestContext.DataRow["CommissionTransactionStatus"].ToString();
            gdsTransactionStatus = TestContext.DataRow["GDSTransactionStatus"].ToString();
            iDataTransactionStatus = TestContext.DataRow["IDataTransactionStatus"].ToString();
            routedMid = TestContext.DataRow["RoutedMid"].ToString();

            cardNumberA = Parameters.GetParameter("cardNumberA");
            cardNumberB = Parameters.GetParameter("cardNumberB");
            cardNumberC = Parameters.GetParameter("cardNumberC");
            cardNumberD = Parameters.GetParameter("cardNumberD");
            expDateMonth = Parameters.GetParameter("expDateMonth");
            expDateYear = Parameters.GetParameter("expDateYear");
            cardHolderName = Parameters.GetParameter("cardHolderName");
            cardCVC = Parameters.GetParameter("cardCVC");
            bankName = Parameters.GetParameter("bankName");
            cardFormEmail = Parameters.GetParameter("cardFormEmail");
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\resource\\paymentdata.csv", "paymentdata#csv", DataAccessMethod.Sequential), DeploymentItem("resource\\paymentdata.csv"), TestMethod]

        public void IDataRoutingOffCommissionDecline()
        {
            paymentParameters = TestUtils.GetPaymentParameters(merchantIdForLink, orderId, amount, currency, commission, pnr, securityKey);

            //calculating hash value
            privateSecurityKey = TestUtils.GetSecurityKeyString(paymentParameters);
            paymentLink = TestUtils.GetPaymentParameters(baseUrlForPayment, merchantIdForLink, orderId, amount, currency, commission, pnr, privateSecurityKey);

            driver.Navigate().GoToUrl(paymentLink);
            TestUtils.FillThePaymentForm(cardNumberA, cardNumberB, cardNumberC, cardNumberD, expDateMonth, expDateYear, cardHolderName, cardCVC, bankName, cardFormEmail, driver);
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            TestUtils.SetTheFilter(orderIdForFilter, driver);

            TestUtils.TransactionChoice1(driver);
            TestUtils.CheckMerchantInfoInAdmin(merchantId, orderIdForFilter, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);

            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            TestUtils.GoToTransactionCardInLkMerchant(orderIdForFilter, driver);
            TestUtils.CheckInfoInMerchant(merchantId, orderIdForFilter, commissionTransactionStatus, cardHolderName, cardFormEmail, driver);
            
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\resource\\gdsdecline.csv", "gdsdecline#csv", DataAccessMethod.Sequential), DeploymentItem("resource\\gdsdecline.csv"), TestMethod]

        public void IDataRoutingOffGDSDecline()
        {
            paymentParameters = TestUtils.GetPaymentParameters(merchantIdForLink, orderId, amount, currency, commission, pnr, securityKey);

            //calculating hash value
            privateSecurityKey = TestUtils.GetSecurityKeyString(paymentParameters);
            paymentLink = TestUtils.GetPaymentParameters(baseUrlForPayment, merchantIdForLink, orderId, amount, currency, commission, pnr, privateSecurityKey);

            driver.Navigate().GoToUrl(paymentLink);
            TestUtils.FillThePaymentForm(cardNumberA, cardNumberB, cardNumberC, cardNumberD, expDateMonth, expDateYear, cardHolderName, cardCVC, bankName, cardFormEmail, driver);
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            TestUtils.SetTheFilter(orderIdForFilter, driver);
            TestUtils.CommissionTransactionCard(driver);
            TestUtils.CheckInfoInAdmin(merchantId, orderIdForFilter, commissionTransactionStatus, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);
            TestUtils.SetTheFilterOneMoreTime(orderIdForFilter, driver);
            TestUtils.GDSTransactionCard(driver);
            TestUtils.CheckInfoInAdmin(merchantId, orderIdForFilter, gdsTransactionStatus, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);

            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            TestUtils.SetFilterInLkMerchant(orderIdForFilter, driver);
            TestUtils.TransactionChoice1InLkMerchant(driver);
            TestUtils.CheckMerchantInfoInMerchant(merchantId, orderIdForFilter, cardHolderName, cardFormEmail, driver);
            TestUtils.SetFilterInLkMerchantOneMoreTime(orderIdForFilter, driver);
            TestUtils.TransactionChoice2InLkMerchant(driver);
            TestUtils.CheckMerchantInfoInMerchant(merchantId, orderIdForFilter, cardHolderName, cardFormEmail, driver);
 
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\resource\\successall.csv", "successall#csv", DataAccessMethod.Sequential), DeploymentItem("resource\\successall.csv"), TestMethod]

        public void IDataRoutingOffSuccessAll()
        {
            paymentParameters = TestUtils.GetPaymentParameters(merchantIdForLink, orderId, amount, currency, commission, pnr, securityKey);

            //calculating hash value
            privateSecurityKey = TestUtils.GetSecurityKeyString(paymentParameters);
            paymentLink = TestUtils.GetPaymentParameters(baseUrlForPayment, merchantIdForLink, orderId, amount, currency, commission, pnr, privateSecurityKey);

            driver.Navigate().GoToUrl(paymentLink);
            TestUtils.FillThePaymentForm(cardNumberA, cardNumberB, cardNumberC, cardNumberD, expDateMonth, expDateYear, cardHolderName, cardCVC, bankName, cardFormEmail, driver);
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            TestUtils.SetTheFilter(orderIdForFilter, driver);
            TestUtils.CommissionTransactionCard(driver);
            TestUtils.CheckInfoInAdmin(merchantId, orderIdForFilter, commissionTransactionStatus, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);
            TestUtils.SetTheFilterOneMoreTime(orderIdForFilter, driver);
            TestUtils.GDSTransactionCard(driver);
            TestUtils.CheckInfoInAdmin(merchantId, orderIdForFilter, gdsTransactionStatus, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);

            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            TestUtils.SetFilterInLkMerchant(orderIdForFilter, driver);
            TestUtils.TransactionChoice1InLkMerchant(driver);
            TestUtils.CheckMerchantInfoInMerchant(merchantId, orderIdForFilter, cardHolderName, cardFormEmail, driver);
            TestUtils.SetFilterInLkMerchantOneMoreTime(orderIdForFilter, driver);
            TestUtils.TransactionChoice2InLkMerchant(driver);
            TestUtils.CheckMerchantInfoInMerchant(merchantId, orderIdForFilter, cardHolderName, cardFormEmail, driver);

        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\resource\\successzerocommission.csv", "successzerocommission#csv", DataAccessMethod.Sequential), DeploymentItem("resource\\successzerocommission.csv"), TestMethod]

        public void IDataRoutingOffSuccessZeroCommission()
        {
            paymentParameters = TestUtils.GetPaymentParameters(merchantIdForLink, orderId, amount, currency, commission, pnr, securityKey);

            privateSecurityKey = TestUtils.GetSecurityKeyString(paymentParameters);
            paymentLink = TestUtils.GetPaymentParameters(baseUrlForPayment, merchantIdForLink, orderId, amount, currency, commission, pnr, privateSecurityKey);

            driver.Navigate().GoToUrl(paymentLink);
            TestUtils.FillThePaymentForm(cardNumberA, cardNumberB, cardNumberC, cardNumberD, expDateMonth, expDateYear, cardHolderName, cardCVC, bankName, cardFormEmail, driver);
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            TestUtils.SetTheFilter(orderIdForFilter, driver);
            TestUtils.TransactionChoice1(driver);
            TestUtils.CheckInfoInAdmin(merchantId, orderIdForFilter, gdsTransactionStatus, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);

            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            TestUtils.GoToTransactionCardInLkMerchant(orderIdForFilter, driver);
            TestUtils.CheckInfoInMerchant(merchantId, orderIdForFilter, gdsTransactionStatus, cardHolderName, cardFormEmail, driver);

        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\resource\\declinezerocommission.csv", "declinezerocommission#csv", DataAccessMethod.Sequential), DeploymentItem("resource\\declinezerocommission.csv"), TestMethod]
        public void IDataRoutingOffDeclineZeroCommission()
        {
            paymentParameters = TestUtils.GetPaymentParameters(merchantIdForLink, orderId, amount, currency, commission, pnr, securityKey);

            privateSecurityKey = TestUtils.GetSecurityKeyString(paymentParameters);
            paymentLink = TestUtils.GetPaymentParameters(baseUrlForPayment, merchantIdForLink, orderId, amount, currency, commission, pnr, privateSecurityKey);

            driver.Navigate().GoToUrl(paymentLink);
            TestUtils.FillThePaymentForm(cardNumberA, cardNumberB, cardNumberC, cardNumberD, expDateMonth, expDateYear, cardHolderName, cardCVC, bankName, cardFormEmail, driver);
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            
            TestUtils.SetTheFilter(orderIdForFilter, driver);
            TestUtils.TransactionChoice1(driver);
            TestUtils.CheckInfoInAdmin(merchantId, orderIdForFilter, gdsTransactionStatus, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);

            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            TestUtils.GoToTransactionCardInLkMerchant(orderIdForFilter, driver);
            TestUtils.CheckInfoInMerchant(merchantId, orderIdForFilter, gdsTransactionStatus, cardHolderName, cardFormEmail, driver);

        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\resource\\roncomdecl.csv", "roncomdecl#csv", DataAccessMethod.Sequential), DeploymentItem("resource\\roncomdecl.csv"), TestMethod]
        public void IDataRoutingOnDeclineCommission()
        {
            paymentParameters = TestUtils.GetPaymentParameters(merchantIdForLink, orderId, amount, currency, commission, pnr, idata, securityKey);

            privateSecurityKey = TestUtils.GetSecurityKeyString(paymentParameters);
            paymentLink = TestUtils.GetPaymentParameters(baseUrlForPayment, merchantIdForLink, orderId, amount, currency, commission, pnr, idata, privateSecurityKey);

            driver.Navigate().GoToUrl(paymentLink);
            TestUtils.FillThePaymentForm(cardNumberA, cardNumberB, cardNumberC, cardNumberD, expDateMonth, expDateYear, cardHolderName, cardCVC, bankName, cardFormEmail, driver);
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            TestUtils.SetTheFilter(orderIdForFilter, driver);

            TestUtils.TransactionChoice1(driver);
            TestUtils.CheckMerchantInfoInAdmin(routedMid, orderIdForFilter, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);

            TestUtils.SetTheFilterOneMoreTime(orderIdForFilter, driver);
            TestUtils.TransactionChoice2(driver);
            TestUtils.CheckMerchantInfoInAdmin(merchantId, orderIdForFilter, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);
            TestUtils.CheckMerchantInfoInAdminWithRoutedMid(routedMid, driver);

            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            TestUtils.SetFilterInLkMerchant(orderIdForFilter, driver);
            TestUtils.TransactionChoice1InLkMerchant(driver);
            TestUtils.CheckMerchantInfoInMerchant(routedMid, orderIdForFilter, cardHolderName, cardFormEmail, driver);
            TestUtils.SetFilterInLkMerchantOneMoreTime(orderIdForFilter, driver);
            TestUtils.TransactionChoice2InLkMerchant(driver);
            TestUtils.CheckMerchantInfoInMerchant(merchantId, orderIdForFilter, cardHolderName, cardFormEmail, driver);

        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\resource\\rongdsdecl.csv", "rongdsdecl#csv", DataAccessMethod.Sequential), DeploymentItem("resource\\rongdsdecl.csv"), TestMethod]
        public void IDataRoutingOnDeclineGDS()
        {
            paymentParameters = TestUtils.GetPaymentParameters(merchantIdForLink, orderId, amount, currency, commission, pnr, idata, securityKey);

            privateSecurityKey = TestUtils.GetSecurityKeyString(paymentParameters);
            paymentLink = TestUtils.GetPaymentParameters(baseUrlForPayment, merchantIdForLink, orderId, amount, currency, commission, pnr, idata, privateSecurityKey);

            driver.Navigate().GoToUrl(paymentLink);
            TestUtils.FillThePaymentForm(cardNumberA, cardNumberB, cardNumberC, cardNumberD, expDateMonth, expDateYear, cardHolderName, cardCVC, bankName, cardFormEmail, driver);
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            TestUtils.SetTheFilter(orderIdForFilter, driver);
            TestUtils.TransactionChoice1(driver);
            TestUtils.CheckMerchantInfoInAdmin(routedMid, orderIdForFilter, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);
            TestUtils.SetTheFilterOneMoreTime(orderIdForFilter, driver);
            TestUtils.TransactionChoice2(driver);
            TestUtils.CheckMerchantInfoInAdmin(merchantId, orderIdForFilter, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);
            TestUtils.SetTheFilterOneMoreTime(orderIdForFilter, driver);
            TestUtils.TransactionChoice3(driver);
            TestUtils.CheckMerchantInfoInAdmin(merchantId, orderIdForFilter, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);
            TestUtils.CheckMerchantInfoInAdminWithRoutedMid(routedMid, driver);

            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            TestUtils.SetFilterInLkMerchant(orderIdForFilter, driver);
            TestUtils.TransactionChoice1InLkMerchant(driver);
            TestUtils.CheckMerchantInfoInMerchant(routedMid, orderIdForFilter, cardHolderName, cardFormEmail, driver);
            TestUtils.SetFilterInLkMerchantOneMoreTime(orderIdForFilter, driver);
            TestUtils.TransactionChoice2InLkMerchant(driver);
            TestUtils.CheckMerchantInfoInMerchant(merchantId, orderIdForFilter, cardHolderName, cardFormEmail, driver);

            TestUtils.SetFilterInLkMerchantOneMoreTime(orderIdForFilter, driver);
            TestUtils.TransactionChoice3InLkMerchant(driver);
            TestUtils.CheckMerchantInfoInMerchant(merchantId, orderIdForFilter, cardHolderName, cardFormEmail, driver);

        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\resource\\ronzerocomdecl.csv", "ronzerocomdecl#csv", DataAccessMethod.Sequential), DeploymentItem("resource\\ronzerocomdecl.csv"), TestMethod]
        public void IDataRoutingOnZeroCommissionDecline()
        {
            paymentParameters = TestUtils.GetPaymentParameters(merchantIdForLink, orderId, amount, currency, commission, pnr, idata, securityKey);

            privateSecurityKey = TestUtils.GetSecurityKeyString(paymentParameters);
            paymentLink = TestUtils.GetPaymentParameters(baseUrlForPayment, merchantIdForLink, orderId, amount, currency, commission, pnr, idata, privateSecurityKey);

            driver.Navigate().GoToUrl(paymentLink);
            TestUtils.FillThePaymentForm(cardNumberA, cardNumberB, cardNumberC, cardNumberD, expDateMonth, expDateYear, cardHolderName, cardCVC, bankName, cardFormEmail, driver);
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            TestUtils.SetTheFilter(orderIdForFilter, driver);

            TestUtils.TransactionChoice1(driver);
            TestUtils.CheckMerchantInfoInAdmin(routedMid, orderIdForFilter, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);
            TestUtils.SetTheFilterOneMoreTime(orderIdForFilter, driver);

            TestUtils.TransactionChoice2(driver);
            TestUtils.CheckMerchantInfoInAdmin(merchantId, orderIdForFilter, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);
            TestUtils.CheckMerchantInfoInAdminWithRoutedMid(routedMid, driver);

            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            TestUtils.SetFilterInLkMerchant(orderIdForFilter, driver);
            TestUtils.TransactionChoice1InLkMerchant(driver);
            TestUtils.CheckMerchantInfoInMerchant(routedMid, orderIdForFilter, cardHolderName, cardFormEmail, driver);
            TestUtils.SetFilterInLkMerchantOneMoreTime(orderIdForFilter, driver);
            TestUtils.TransactionChoice2InLkMerchant(driver);
            TestUtils.CheckMerchantInfoInMerchant(merchantId, orderIdForFilter, cardHolderName, cardFormEmail, driver);

        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\resource\\ronzerocomsuc.csv", "ronzerocomsuc#csv", DataAccessMethod.Sequential), DeploymentItem("resource\\ronzerocomsuc.csv"), TestMethod]
        public void IDataRoutingOnSuccessZeroCommission()
        {
            paymentParameters = TestUtils.GetPaymentParameters(merchantIdForLink, orderId, amount, currency, commission, pnr, idata, securityKey);

            privateSecurityKey = TestUtils.GetSecurityKeyString(paymentParameters);
            paymentLink = TestUtils.GetPaymentParameters(baseUrlForPayment, merchantIdForLink, orderId, amount, currency, commission, pnr, idata, privateSecurityKey);

            driver.Navigate().GoToUrl(paymentLink);
            TestUtils.FillThePaymentForm(cardNumberA, cardNumberB, cardNumberC, cardNumberD, expDateMonth, expDateYear, cardHolderName, cardCVC, bankName, cardFormEmail, driver);
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            TestUtils.SetTheFilter(orderIdForFilter, driver);
            TestUtils.TransactionChoice1(driver);
            TestUtils.CheckMerchantInfoInAdmin(merchantId, orderIdForFilter, expDateMonth, expDateYear, bankName, cardHolderName, cardFormEmail, driver);

            TestUtils.Autorize(Parameters.GetParameter("login-merchant"), Parameters.GetParameter("password-merchant"), driver);
            TestUtils.GoToTransactionCardInLkMerchant(orderIdForFilter, driver);
            TestUtils.CheckMerchantInfoInMerchant(merchantId, orderIdForFilter, cardHolderName, cardFormEmail, driver);

        }

        [TestCleanup]
        public void ShutDown()
        {
            driver.Close();
        }

    }
}