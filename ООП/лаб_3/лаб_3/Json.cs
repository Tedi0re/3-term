using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace лаб_3_7
{
    public partial class Set<T> 
    {
        public static Set<T> Decerelization(string path)
        {
            Set<T> set = new Set<T>();
            var settings = new JsonSerializerSettings//объект настройки сериализации(десериализации)
            {
                TypeNameHandling = TypeNameHandling.All,//настройка типа данных
            };
            try
            {
                using var stream = new StreamReader(path);//поток чтения
                string JsonData = stream.ReadToEnd();//запись из потока в строку

                List<T> deserializedList = JsonConvert.DeserializeObject<List<T>>(JsonData, settings);//?
                foreach (var item in deserializedList)
                {
                    set.Add(item);
                }
                return set;
            }
            catch
            {
                Console.WriteLine("Файл не открыт!");
                return set;
            }
        }

        public static string Cerelization(Set<T> set, string path = "D:/ООП/лаб_3/лаб_3/Out.json")
        {
            string JsonData = JsonConvert.SerializeObject(set._items[0]);
            using (FileStream stream = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(JsonData);
                stream.Write(info, 0, info.Length);
                return JsonData;
            }
        }
    }
}
