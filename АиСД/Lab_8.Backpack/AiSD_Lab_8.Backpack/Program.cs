using System;
using System.Collections.Generic;

namespace AiSD_Lab_8.Backpack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер рюкзака");
            uint Size = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Введите предметы (имя, размер, стоимость через пробел)\n(для выхода нажмите Enter)");
            List<Item> items = new List<Item>();
            while (true)
            {
                try
                {
                    string[] info = Console.ReadLine().Split(); 
                    if (info[0] == "") break;
                    items.Add(new Item(info[0], 
                        Convert.ToUInt32(info[1]), 
                        Convert.ToUInt32(info[2])));
                }
                catch (Exception)
                {
                    Console.WriteLine("Неправильный ввод!");
                }
                
                

            }

            Console.WriteLine("-------------------------------------");
            foreach (Item item in items)
            {
                Console.WriteLine($"{item.Name}\nРазмер {item.Size}\nСтоимость {item.Cost}");
                Console.WriteLine("-------------------------------------");
            }

            Backpack backpack = new Backpack(Size, items);
            backpack.Print();
        }
    }
}
