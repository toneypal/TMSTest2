using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RunEnviroment
{
    
    public class Parameters
    {

        public static String GetParameter(string parameter)
        {   
            XmlDocument doc = new XmlDocument();
            doc.Load("c:\\secureParametersAutotest\\parameters.xml");

            XmlNodeList elemList = doc.GetElementsByTagName(parameter);
            for (int i = 0; i < elemList.Count; i++)
            {
                Console.WriteLine(elemList[i].InnerXml);
                return elemList[i].InnerXml;
            }
            return null;
        }

        //public static String GetParametrValue(string name)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load("c:\\secureParametersAutotest\\gridparameters.xml");

        //    XmlNodeList elemList = doc.LoadXml(name);
        //    for (int i = 0; i < elemList.Count; i++)
        //    {
        //        for (int j = 0; i <)
        //        Console.WriteLine(elemList[i].InnerXml);
        //        return elemList[i].InnerXml;
        //    }
        //    return null; 
        //}
        
    }
}
