using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace RunEnviroment
{
    public class EnviromentSelect
    {
         public static RemoteWebDriver CreateLocalDriver(DesiredCapabilities capabilities)
        {
            string browserType = capabilities.BrowserName;
            if (browserType == DesiredCapabilities.Firefox().BrowserName)
            {
                capabilities = DesiredCapabilities.Firefox();
                capabilities.SetCapability(CapabilityType.BrowserName, "firefox");

                return new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
            }
            if (browserType == DesiredCapabilities.InternetExplorer().BrowserName)
            {
                capabilities = DesiredCapabilities.InternetExplorer();
                capabilities.SetCapability(CapabilityType.BrowserName, "internet explorer");
                return new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
            }
            if (browserType == DesiredCapabilities.Chrome().BrowserName)
            {
                capabilities = DesiredCapabilities.Chrome();
                capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
                return new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
            }

            throw new Exception("Unrecognized browser type: " + browserType);
        }


    }
}
