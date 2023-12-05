using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace Lab_4_OOP
{

    class Program
    {
        
        public static void Main()
        {

            Rectangle rectangle = new Rectangle((float)4.1, (float)4.1, (float)2, (float)7);

            CustomSerialize.SerializeToBinary(rectangle);
            CustomSerialize.DeserializeFromBinary();
            CustomSerialize.SerializeToXML(rectangle);
            CustomSerialize.DeserializeFromXML();
            CustomSerialize.SerializeToJSON(rectangle);
            CustomSerialize.DeserializeFromJSON();
            CustomSerialize.SerializeToSOAP(rectangle);
            CustomSerialize.DeserializeFromSOAP();

            Console.WriteLine("\nЗадание 2: \n");
            Rectangle rectangle2 = new Rectangle((float)1, (float)4, (float)4, (float)5);

            Rectangle[] rectangles = { rectangle, rectangle2 };

            foreach(Rectangle rec in rectangles)
            {
                CustomSerialize.SerializeToBinary(rec);
                CustomSerialize.DeserializeFromBinary();
            }

            Task3.XPath();

            XDocument xdoc = Task4.CreateXML();     
            Task4.CoutXML(xdoc);                    
            Task4.LinqXML(xdoc);
        }
    }
}



