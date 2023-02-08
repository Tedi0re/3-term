using System;

namespace лаб_3_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<int> a = new Set<int>(), b = new Set<int>(), c = new Set<int>();
            Set<string> d = new Set<string>();

            for (int i = 0; i < 10; i++)
            {
                string str = i+ "a";
                a.Add(i);
                b.Add(i + 7);
                c.Add(i - 7);
                d.Add(str);
            }
            Console.Write("Множество 1: ");
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }
            Console.Write("\nМножество 2: ");
            foreach (var item in b)
            {
                Console.Write(item + " ");
            }
            Console.Write("\nМножество 3: ");
            foreach (var item in c)
            {
                Console.Write(item + " ");
            }
            Console.Write("\nМножество 4: ");
            foreach (var item in d)
            {
                Console.Write(item + " ");
            }

            var remove = a - 1;
            var intersection = a * b;
            var comparison = a < b;
            var subset = a > b;
            var union = b & c;

            Console.Write("\nУдаление элемента 1 из множества 1: ");
            foreach (var item in remove)
            {
                Console.Write(item + " ");
            }
            Console.Write("\nПересечение множеств 1 и 2: ");
            foreach (var item in intersection)
            {
                Console.Write(item + " ");
            }
            Console.Write("\nСравнение множеств 1 и 2: ");
            Console.Write(comparison);
            Console.Write("\nПроверка подмножеств 1 и 2 ");
            Console.Write(subset);
            Console.Write("\nОбъединение множеств 2 и 3");
            foreach (var item in union)
            {
                Console.Write(item + " ");
            }

            
            Console.Write("\nМножество 4: ");
            foreach (var item in d)
            {
                Console.Write(item + " ");
            }
            Set<int>.StaticOperation.DeleteNullElements(ref d);
            Console.Write("\nМножество 4 без нулевых элементов: ");
            foreach (var item in d)
            {
                Console.Write(item + " ");
            }
            Set<int>.StaticOperation.Point(ref d);
            Console.Write("\nМножество 4 с точками в конце: ");
            foreach (var item in d)
            {
                Console.Write(item + " ");
            }

            Set<int>.Developer developer = new Set<int>.Developer();
            Set<int>.Production production = new Set<int>.Production();
            Console.WriteLine(developer.ToString());
            Console.WriteLine(production.ToString());
            Console.Write("Множество 1: ");
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }
            Console.Write("\nМножество 2: ");
            foreach (var item in b)
            {
                Console.Write(item + " ");
            }
            Console.Write("\nМножество 3: ");
            foreach (var item in c)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Set<int> ab = null;
            bool flagA = false;
            try
            {
               
                Console.Write("Введите индекс:");
                a.Browse(Convert.ToInt32(Console.ReadLine()));
               // ab.Browse(0);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Попробуйте ввести другой индекс");
                flagA = true;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Объекта не существует");
            }
            finally
            {
                if(flagA) a.Browse((int)Console.Read());
            }

            ООП_лаб_4_5.Rose rose1 = new ООП_лаб_4_5.Rose("роза1"),
                rose2 = new ООП_лаб_4_5.Rose("роза2"),
                rose3 = new ООП_лаб_4_5.Rose("роза3"),
                rose4 = new ООП_лаб_4_5.Rose("роза4");
            Set<ООП_лаб_4_5.Rose> setRose = new Set<ООП_лаб_4_5.Rose>();
            setRose.Add(rose1);
            setRose.Add(rose2);
            setRose.Add(rose3);
            setRose.Add(rose4);
            setRose.Browse(2);
            Set<object> setJson= new Set<object>();
            setJson = Set<object>.Decerelization("D:/ООП/лаб_3/лаб_3/File.json");
            foreach(var item in setJson)
            {
                Console.Write(item + " ");
            }
            string DataJson = Set<object>.Cerelization(setJson);

        }
    }
}
