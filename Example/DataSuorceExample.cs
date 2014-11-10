using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System.Data;


namespace RunEnviroment
{
    [TestClass]
    public class DataSuorceExample
    {
        

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get{return testContextInstance;}
            set{testContextInstance = value;}
        }

        public RemoteWebDriver driver;
        private string driverParameter = "FireFox";

        [TestInitialize]
        public void SetUp()
        {
            //driver = Enviroment.WebDriverFactory.Create(driverParameter);
        }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\resource\\data.csv", "data#csv", DataAccessMethod.Sequential), DeploymentItem("resource\\data.csv"), TestMethod]
        public void TestParametr()
        {

            //string paramVal = TestContext.DataRow["Test"].ToString();
            string paramVal2 = TestContext.DataRow["Login"].ToString();
            string paramVal = TestContext.DataRow["Password"].ToString();
            //TestUtils.Autorize(paramVal, paramVal2, driver);
            Console.WriteLine(paramVal2);
            Console.WriteLine(paramVal);
            
        }
    }
}
