using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Lab_4_OOP
{
    public static class Task3
    {
        public static void XPath()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Path.GetFullPath(@"D:\3_SEM_LABS\OOP\Lab_13_OOP\Lab_4_OOP\bin\Debug\pointsx.xml"));    
            XmlElement xRoot = xDoc.DocumentElement;

            Console.WriteLine("\n\n\n\t\t\t  XPath for XML:\n");
            Console.WriteLine("Все дочерние элементы:");                              
            XmlNodeList childNodes = xRoot.SelectNodes("*");                    
            
            foreach (XmlNode n in childNodes)                                   
                Console.WriteLine(n.OuterXml);

            Console.WriteLine("\n<Width>:");                         
            XmlNodeList namesNodes = xRoot.SelectNodes("//Rectangle/width");
            
            foreach (XmlNode n in namesNodes)                                   
                Console.WriteLine(n.InnerText);                                 
        }
    }
}
