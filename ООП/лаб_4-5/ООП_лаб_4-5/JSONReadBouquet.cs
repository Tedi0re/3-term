using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace ООП_лаб_4_5
{
    static partial class BouquetControler
    {
        public static Bouquet ReadBouquetFromJSON(string path)
        {
            bouquet = new Bouquet();
            var settings = new JsonSerializerSettings//объект настройки сериализации(десериализации)
            {
                TypeNameHandling = TypeNameHandling.All,//настройка типа данных
            };
            try
            {
                using var stream = new StreamReader(path);//поток чтения
                string JsonData = stream.ReadToEnd();//запись из потока в строку

                List<Flower> deserializedList = JsonConvert.DeserializeObject<List<Flower>>(JsonData, settings);//?
                foreach (var item in deserializedList)
                {
                    bouquet.Add(item);
                }
                return bouquet;
            }
            catch
            {
                Console.WriteLine("Файл не открыт!");
                return bouquet;
            }

            
        }
        
    }
}


