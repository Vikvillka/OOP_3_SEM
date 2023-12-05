using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
using System.Web.Services.Protocols;
using System.Runtime.Serialization.Formatters.Soap;


namespace Lab_4_OOP
{
    public class CustomSerialize
    {
        public static void SerializeToBinary(Rectangle rectangle)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("binary.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, rectangle);
            }
        }

        public static void DeserializeFromBinary()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("binary.dat", FileMode.OpenOrCreate))
            {
                Rectangle newR = (Rectangle)formatter.Deserialize(fs);
                Console.WriteLine(newR.ToString());
            }
        }

        public static void SerializeToXML(Rectangle rectangle)
        {
            XmlSerializer xSer = new XmlSerializer(typeof(Rectangle));

            using (FileStream fs = new FileStream("pointsx.xml", FileMode.OpenOrCreate))
            {
                xSer.Serialize(fs, rectangle);
            }
        }

        public static void DeserializeFromXML()
        {
            XmlSerializer xSer = new XmlSerializer(typeof(Rectangle));

            using (FileStream fs = new FileStream("pointsx.xml", FileMode.OpenOrCreate))
            {
                Rectangle newR = xSer.Deserialize(fs) as Rectangle;
                Console.WriteLine(newR.ToString());
            }
        }

        public static void SerializeToSOAP(Rectangle rectangle)
        {
            SoapFormatter formatter = new SoapFormatter();

            using (FileStream fs = new FileStream("points.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, rectangle);
            }
        }

        public static void DeserializeFromSOAP()
        {
            SoapFormatter formatter = new SoapFormatter();

            using (FileStream fs = new FileStream("points.xml", FileMode.OpenOrCreate))
            {
                Rectangle newR = formatter.Deserialize(fs) as Rectangle;
                Console.WriteLine(newR.ToString());
            }
        }

        public static void SerializeToJSON(Rectangle rectangle)
        {
            string jsonString = JsonSerializer.Serialize(rectangle);
            File.WriteAllText("points.json", jsonString);
        }

        public static void DeserializeFromJSON()
        {
            string jsonString = File.ReadAllText("points.json");
            Rectangle newR = JsonSerializer.Deserialize<Rectangle>(jsonString);
            Console.WriteLine(newR.ToString());
        }
        
    }
}
