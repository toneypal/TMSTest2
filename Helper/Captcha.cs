using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using System.Collections;
using OpenQA.Selenium.Remote;

namespace Enviroment
{
    public class Captcha
    {

        private String result;

        public static String HackCaptcha(RemoteWebDriver driver)
        
        {
            Hashtable data = new Hashtable();
            string line;
            System.IO.StreamReader file =new System.IO.StreamReader(@"C:\secureParametersAutotest\captcha_list.txt");
            while ((line = file.ReadLine()) != null)
            {
                String[] parameters = line.Split(';');
                data.Add(parameters[0], parameters[1]);
            }
            file.Close();
            String key = driver.FindElementByName("captchaCode").GetAttribute("value");
            return data[key].ToString(); 
        }

        
    }



}
