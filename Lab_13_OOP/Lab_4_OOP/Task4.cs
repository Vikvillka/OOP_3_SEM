using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace Lab_4_OOP
{
    class Task4
    {
        public static XDocument CreateXML()
        {
            XDocument xdoc = new XDocument(new XElement("phones",                   
                new XElement("phone",
                    new XAttribute("name", "iPhone 13"),
                    new XElement("company", "Apple"),
                    new XElement("price", "1999$")),
                new XElement("phone",
                    new XAttribute("name", "Pixel 5A"),
                    new XElement("company", "Google"),
                    new XElement("price", "1499$"))));
            xdoc.Save(Path.GetFullPath(@"D:\3_SEM_LABS\OOP\Lab_13_OOP\Lab_4_OOP\bin\Debug\xxml.xml"));    
            return xdoc;
        }


        public static void CoutXML(XDocument xdoc)                                 
        {
            Console.WriteLine("\n\n\t\t\t   Linq to XML:");
            foreach (XElement phoneElement in xdoc.Element("phones").Elements("phone"))
            {
                XAttribute nameAttribute = phoneElement.Attribute("name");
                XElement companyElement = phoneElement.Element("company");
                XElement priceElement = phoneElement.Element("price");

                if (nameAttribute != null && companyElement != null && priceElement != null)
                {
                    Console.WriteLine($"Смартфон: {nameAttribute.Value}");
                    Console.WriteLine($"Компания: {companyElement.Value}");
                    Console.WriteLine($"Цена: {priceElement.Value}");
                }
                Console.WriteLine();
            }
        }


        public static void LinqXML(XDocument xdoc)
        {
            var items = from xe in xdoc.Element("phones").Elements("phone")         
                        where xe.Element("company").Value == "Google"                
                        select new Phone                                           
                        {                                                           
                            Name = xe.Attribute("name").Value,
                            Price = xe.Element("price").Value
                        };

            foreach (var item in items)
                Console.WriteLine($"{item.Name} - {item.Price}");


            var items1 = from xe in xdoc.Element("phones").Elements("phone")        
                         where xe.Element("price").Value == "1999$"                 
                         select new Phone
                         {
                             Name = xe.Attribute("name").Value,
                             Price = xe.Element("price").Value
                         };

            foreach (var item in items1)                                           
                Console.WriteLine($"{item.Name} - {item.Price}");                   
        }
    }

    public class Phone
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}

