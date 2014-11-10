using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;

namespace RunEnviroment.TestClass
{
    //[TestClass]
    public class Authorized
    {

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        public RemoteWebDriver driver;
        private string driverParameter = "FireFox";
        private string login;
        private string password;
        private string parameter;


        [TestInitialize]
        public void SetUp()
        {
            driver = Enviroment.WebDriverFactory.Create(driverParameter);
            login = TestContext.DataRow["Login"].ToString();
            password = TestContext.DataRow["Password"].ToString();
            parameter = TestContext.DataRow["Parameter"].ToString();
        }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\resource\\auth.csv", "auth#csv", DataAccessMethod.Sequential), DeploymentItem("resource\\auth.csv"), TestMethod]
        public void Positive()
        {
            TestUtils.Autorize(login, password, driver);
            Assert.IsTrue(driver.FindElementById(parameter).Displayed, "Parameter is not displayed!!!");
    
        }

        [TestCleanup]
        public void ShutDown()
        {
            driver.Close();
        }
    }
}
