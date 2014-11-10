using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace RunEnviroment
{
    class TestUtils
    {
        public static void Autorize(String login, String password, RemoteWebDriver driver)
        {
            driver.Navigate().GoToUrl(@Parameters.GetParameter("url-login"));
            driver.FindElementById("ctl00_content_tbLogin").SendKeys(login);
            driver.FindElementById("ctl00_content_tbPassword").SendKeys(password);
            driver.FindElementById("ctl00_content_cptCaptcha_captchaText").SendKeys(Enviroment.Captcha.HackCaptcha(driver));
            driver.FindElementById("ctl00_content_ibtnLogon").Click();
        }

        internal static void FillThePaymentForm(string cardNumberAparam, string cardNumberBparam, string cardNumberCparam, string cardNumberDparam, string expDateMonthparam, string expDateYearparam, string cardHolderNameparam, string cardCVCparam, string bankNameparam, string cardFormEmailparam, RemoteWebDriver driver)
        {
            driver.FindElementById("ctl00_content_cardForm_cardNumberA").SendKeys(cardNumberAparam);
            driver.FindElementById("ctl00_content_cardForm_cardNumberB").SendKeys(cardNumberBparam);
            driver.FindElementById("ctl00_content_cardForm_cardNumberC").SendKeys(cardNumberCparam);
            driver.FindElementById("ctl00_content_cardForm_cardNumberD").SendKeys(cardNumberDparam);
            new SelectElement(driver.FindElement(By.Id("ctl00_content_cardForm_expDateMonth"))).SelectByText(expDateMonthparam);
            new SelectElement(driver.FindElement(By.Id("ctl00_content_cardForm_expDateYear"))).SelectByText(expDateYearparam);
            driver.FindElementById("ctl00_content_cardForm_cardHolderName").SendKeys(cardHolderNameparam);
            driver.FindElementById("ctl00_content_cardForm_cardCVC").SendKeys(cardCVCparam);
            driver.FindElementById("ctl00_content_cardForm_bankName").SendKeys(bankNameparam);
            driver.FindElementById("ctl00_content_cardForm_email").SendKeys(cardFormEmailparam);
            driver.FindElementById("ctl00_content_cardForm_cmdProcess").Click();
            
        }

        internal static string GetPaymentParameters(params string[] parameter)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < parameter.Length; i++)
            {
                builder.Append(parameter[i].ToString() + "&");
            }

            return builder.ToString().Substring(0, builder.ToString().Length - 1);
        }

        internal static void GoToTransactionCardInLkMerchant(string orderId, RemoteWebDriver driver)
        {
            driver.FindElementById("ctl00_ctl11_mhlTransactions").Click();
            driver.FindElementById("ctl00_content_all").Click();
            driver.FindElementById("ctl00_content_filter_orderNumber").SendKeys(orderId);
            driver.FindElementById("ctl00_content_filter_cmdSelect").Click();
            driver.FindElementByCssSelector("table#list_transactions tr[id^='tr'] td a").Click();
        }

        internal static void CheckInfoInAdmin(string merchantId, string orderIdForFilter, string status, string expDateMonth, string expDateYear, string bankName, string cardHolderName, string cardFormEmail, RemoteWebDriver driver)
        {
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[1]//td").Text.Contains(merchantId));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[7]//td").Text.Contains(orderIdForFilter));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[8]//td").Text.Contains("Purchase"));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[9]//td").Text.Contains(status));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[14]//td").Text.Contains(expDateMonth + " / " + expDateYear));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[15]//td").Text.Contains(bankName));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[2]//tr[1]//td").Text.Contains(cardHolderName));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[2]//tr[9]//td").Text.Contains(cardFormEmail));
        }

        internal static void CheckInfoInMerchant(string merchantId, string orderIdForFilter, string status, string cardHolderName, string cardFormEmail, RemoteWebDriver driver)
        {
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[3]//td").Text.Contains(merchantId));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[5]//td").Text.Contains(orderIdForFilter));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[7]//td").Text.Contains("Purchase"));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[8]//td").Text.Contains(status));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[13]//td").Text.Contains(cardHolderName));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[2]//tr[7]//td").Text.Contains(cardFormEmail));
        }

        internal static void SetTheFilter(string orderId, RemoteWebDriver driver)
        {
            driver.FindElementById("ctl00_content_LeftMenu1_mhlTransactions").Click();
            driver.FindElementById("ctl00_content_all").Click();
            driver.FindElementById("ctl00_content_filter_orderNumber").SendKeys(orderId);
            driver.FindElementById("ctl00_content_filter_cmdSelect").Click();
        }

        internal static void CommissionTransactionCard(RemoteWebDriver driver)
        {
            driver.FindElementByXPath("//table[@id='list_transactions']//tr[2]//td[2]//a").Click();
        }

        internal static void GDSTransactionCard(RemoteWebDriver driver)
        {
            driver.FindElementByXPath("//table[@id='list_transactions']//tr[3]//td[2]//a").Click();
        }

        internal static void TransactionChoice1(RemoteWebDriver driver)
        {
            driver.FindElementByXPath("//table[@id='list_transactions']//tr[2]//td[2]//a").Click();
        }

        internal static void TransactionChoice2(RemoteWebDriver driver)
        {
            driver.FindElementByXPath("//table[@id='list_transactions']//tr[3]//td[2]//a").Click();
        }

        internal static void TransactionChoice3(RemoteWebDriver driver)
        {
            driver.FindElementByXPath("//table[@id='list_transactions']//tr[4]//td[2]//a").Click();
        }

        internal static void CheckMerchantInfoInAdmin(string merchantId, string orderIdForFilter, string expDateMonth, string expDateYear, string bankName, string cardHolderName, string cardFormEmail, RemoteWebDriver driver)
        {
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[1]//td").Text.Contains(merchantId));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[7]//td").Text.Contains(orderIdForFilter));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[8]//td").Text.Contains("Purchase"));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[14]//td").Text.Contains(expDateMonth + " / " + expDateYear));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[15]//td").Text.Contains(bankName));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[2]//tr[1]//td").Text.Contains(cardHolderName));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[2]//tr[9]//td").Text.Contains(cardFormEmail));
        }

        internal static void CheckMerchantInfoInAdminWithRoutedMid(string routedMid, RemoteWebDriver driver)
        {
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[11]//td").Text.Contains("200: Транзакция маршрутизирована, создана новая транзакция с MerchantID: " + routedMid));
        }

        internal static void SetFilterInLkMerchant(string orderId, RemoteWebDriver driver)
        {
            driver.FindElementById("ctl00_ctl11_mhlTransactions").Click();
            driver.FindElementById("ctl00_content_all").Click();
            driver.FindElementById("ctl00_content_filter_orderNumber").SendKeys(orderId);
            driver.FindElementById("ctl00_content_filter_cmdSelect").Click();
        }

        internal static void TransactionChoice1InLkMerchant(RemoteWebDriver driver)
        {
            driver.FindElementByXPath("//table[@id='list_transactions']//tr[2]//td[3]//a").Click();
        }

        internal static void TransactionChoice2InLkMerchant(RemoteWebDriver driver)
        {
            driver.FindElementByXPath("//table[@id='list_transactions']//tr[3]//td[3]//a").Click();
        }

        internal static void CheckMerchantInfoInMerchant(string merchantId, string orderIdForFilter, string cardHolderName, string cardFormEmail, RemoteWebDriver driver)
        {
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[3]//td").Text.Contains(merchantId));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[5]//td").Text.Contains(orderIdForFilter));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[7]//td").Text.Contains("Purchase"));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[1]//tr[13]//td").Text.Contains(cardHolderName));
            Assert.IsTrue(driver.FindElementByXPath("//div[@id='view-top']/table[2]//tr[7]//td").Text.Contains(cardFormEmail));
        }

        internal static void TransactionChoice3InLkMerchant(RemoteWebDriver driver)
        {
            driver.FindElementByXPath("//table[@id='list_transactions']//tr[4]//td[3]//a").Click();
        }

        internal static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        internal static void SetTheFilterOneMoreTime(string orderIdForFilter, RemoteWebDriver driver)
        {
            driver.FindElementById("ctl00_content_filter_cmdSelect").Click();
        }

        internal static void SetFilterInLkMerchantOneMoreTime(string orderIdForFilter, RemoteWebDriver driver)
        {
            driver.FindElementById("ctl00_content_filter_cmdSelect").Click();
        }

        internal static string GetNewOrderId()
        {
            Random rnd = new Random();
            return (rnd.Next(302, 401).ToString());
        }

        internal static string GetSecurityKeyString(string paymentParameters)
        {
            return("SecurityKey=" + TestUtils.GetMd5Hash(paymentParameters));
        }
    }
    
}
