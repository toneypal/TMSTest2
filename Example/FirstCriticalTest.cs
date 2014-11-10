using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enviroment;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace RunEnviroment
{
    [TestClass]
    public class FirstTest
    {
        public RemoteWebDriver driver;
        private string driverParameter = "FireFox";
        
        [TestInitialize]
        public void SetUp()
        {
            driver = Enviroment.WebDriverFactory.Create(driverParameter);
        }

        [TestMethod]
        public void TestMethodFirst()
        {
            
            //TestUtils.Autorize(login, password, driver);
            TestUtils.Autorize(Parameters.GetParameter("login-admin"), Parameters.GetParameter("password-admin"), driver);
            //driver.FindElementById("ctl00_content_LeftMenu1_mhlTransactions").Click();
            //Assert.IsTrue(driver.FindElementByXPath("//h2").Text.Contains("Транзакции"));
        }

        [TestCleanup]
        public void ShutDown()
        {
            //driver.Close();   
        }

    }
}
