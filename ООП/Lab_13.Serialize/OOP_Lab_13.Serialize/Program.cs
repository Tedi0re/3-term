using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba_13
{
    public class Programm
    {
        public static void Main()
        {
            //-------------------------------1 задание -------------------------------------//
            //Goods cakeBinary = new Cake(11230, "BSTU", "XZ", "OOO Dostavka.by", "Imperatriza");
            ООП_лаб_4_5.Rose roseBinary = new ООП_лаб_4_5.Rose("rose");
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("BinaryFormat.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, roseBinary);
            };
            using (FileStream fs = new FileStream("BinaryFormat.dat", FileMode.OpenOrCreate))
            {
                ООП_лаб_4_5.Rose roseBinaryDes = (ООП_лаб_4_5.Rose)binaryFormatter.Deserialize(fs);
                Console.WriteLine("=====Дисериализация BinaryFormatter=====");
                Console.WriteLine(roseBinaryDes.ToString());
                Console.WriteLine("========================");
            };
            ООП_лаб_4_5.Rose roseSoap = new ООП_лаб_4_5.Rose("roze");
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fl = new FileStream("SoapFormat.xml", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fl, roseSoap);
            };
            using (FileStream fl = new FileStream("SoapFormat.xml", FileMode.OpenOrCreate))
            {
                Console.WriteLine("=====Дисериализация SoapFormatter=====");
                ООП_лаб_4_5.Rose roseSoapFormat = (ООП_лаб_4_5.Rose)soapFormatter.Deserialize(fl);
                Console.WriteLine(roseSoapFormat.ToString());
                Console.WriteLine("========================");
            }
            ООП_лаб_4_5.Rose roseJSON = new ООП_лаб_4_5.Rose("rose");
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(ООП_лаб_4_5.Rose));
            using (FileStream fs = new FileStream("JsonFormat.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fs, roseJSON);
            };
            using (FileStream fs = new FileStream("JsonFormat.json", FileMode.OpenOrCreate))
            {
                Console.WriteLine("=====Дисериализация DataContractJsonSerializer=====");
                ООП_лаб_4_5.Rose roseJSONform = (ООП_лаб_4_5.Rose)jsonSerializer.ReadObject(fs);
                Console.WriteLine(roseJSONform.ToString());
                Console.WriteLine("========================");
            };

            ООП_лаб_4_5.Rose roseXML = new ООП_лаб_4_5.Rose("rose");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ООП_лаб_4_5.Rose));
            using (FileStream fs = new FileStream("XmlFormat.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, roseXML);
            };
            using (FileStream fs = new FileStream("XmlFormat.xml", FileMode.OpenOrCreate))
            {
                Console.WriteLine("=====Дисериализация XmlSerializer=====");
                ООП_лаб_4_5.Rose xmlrose = (ООП_лаб_4_5.Rose)xmlSerializer.Deserialize(fs);
                Console.WriteLine(xmlrose.ToString());
                Console.WriteLine("========================");
            };

            //---------------------- 2 задание -------------------------// 
            ООП_лаб_4_5.Rose[] arrRose = new ООП_лаб_4_5.Rose[] { roseBinary, roseSoap, roseXML };
            XmlSerializer xmlSerializerArr = new XmlSerializer(typeof(ООП_лаб_4_5.Rose[]));
            using (FileStream fs = new FileStream("arrCakeXml.xml", FileMode.OpenOrCreate))
            {
                xmlSerializerArr.Serialize(fs, arrRose);
            }
            using (FileStream fs = new FileStream("arrCakeXml.xml", FileMode.OpenOrCreate))
            {
                Console.WriteLine("=====Дисериализация массива Cake=====");
                ООП_лаб_4_5.Rose[]? newRose = xmlSerializerArr.Deserialize(fs) as ООП_лаб_4_5.Rose[];
                if (newRose != null)
                {
                    foreach (ООП_лаб_4_5.Rose good in newRose)
                    {
                        Console.WriteLine(good.ToString());
                    }
                }
                Console.WriteLine("========================");
            };
            //---------------------- 3 задание -------------------------// 
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("arrCakeXml.xml");
            XmlElement? xRoot = xDoc.DocumentElement;
            XmlNodeList? nodes = xRoot?.SelectNodes("Cake");
            if (nodes != null)
            {
                foreach (XmlNode nod in nodes)
                    Console.WriteLine(nod.OuterXml);
            }
            XmlNodeList? node = xRoot?.SelectNodes("*");
            if (nodes != null)
            {
                foreach (XmlNode nod in node)
                    Console.WriteLine(nod.OuterXml);
            }
            //---------------------- 4 задание -------------------------//
            Console.WriteLine("=====================Задание 4======================");
            XDocument xDoc2 = new XDocument();
            XElement root = new XElement("Rose");
            XElement Rose;
            XElement color;

            var list = new List<ООП_лаб_4_5.Rose>();
            list.Add(roseXML);
            list.Add(roseJSON);
            list.Add(roseSoap);
            foreach (var item in list)
            {
                if (item is ООП_лаб_4_5.Rose)
                {
                    Rose = new XElement("Rose");
                    color = new XElement("red");
                    color.Value = item.color;
                    Rose.Add(color);
                    root.Add(Rose);
                }
                else
                {
                    Console.WriteLine("Лох");
                }
            }
            xDoc2.Add(root);
            var elements = from p in root.Elements("Cake").Where(p => Convert.ToInt32(p.Attribute("Cost").Value) < 10000) 
                           select p;
            foreach (var item in elements)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
