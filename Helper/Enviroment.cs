using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.IE;

namespace Enviroment
{
    public class WebDriverFactory
    {
        public static RemoteWebDriver Create(string driver)
        {
            switch (driver)
            {
                case "IE":
                    return new InternetExplorerDriver();
                case "FireFox":
                    return new FirefoxDriver();
                case "Safari":
                    return new SafariDriver();
                default:
                    throw new ArgumentException("Unsupported driver", "driver");
            }
        }

    }
}

