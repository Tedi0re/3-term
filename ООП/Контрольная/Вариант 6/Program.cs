using System;

namespace Вариант_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "You.are.amazing";
            string[] strings = str.Split('.');//разбиение строки
            foreach(var item in strings)//перебор массива строк strings[]
            {
                Console.WriteLine(item);
            }

            Bus bus1 = new Bus(3);
            Bus bus2 = new Bus(4);
            Console.WriteLine(bus1 < bus2);
            Console.WriteLine(bus1 > bus2);
            Console.WriteLine(bus1 == bus2);

        }
    }
}
