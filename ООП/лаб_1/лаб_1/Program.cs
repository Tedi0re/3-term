using System;
using System.Text;

namespace лаб_1
{
    class Program
    {
        static void Main(string[] args)
        {
/*
true
1
1
w
1
1
1
1
1
1
1
1
1
*/
            bool b = Convert.ToBoolean( Console.ReadLine());
            byte by = Convert.ToByte(Console.ReadLine());
            sbyte sby = Convert.ToSByte(Console.ReadLine());
            char c = Convert.ToChar(Console.ReadLine());
            decimal d = Convert.ToDecimal(Console.ReadLine());
            double dou = Convert.ToDouble(Console.ReadLine());
            float f = Convert.ToSingle(Console.ReadLine());
            int i = Convert.ToInt32(Console.ReadLine());
            uint ui = Convert.ToUInt32(Console.ReadLine());
            //nint ni;
            // nuint nui;
            long l = Convert.ToInt64(Console.ReadLine());
            ulong ul = Convert.ToUInt64(Console.ReadLine());
            short s = Convert.ToInt16(Console.ReadLine());
            ushort us = Convert.ToUInt16(Console.ReadLine());
            object ob;
            dynamic dy;

            //неявные преобразования
            l = i;
            l = s;
            ul = ui;
            i = s;
            ui = us;

            //явные преобразования
            i = (int)d;
            //i = (int)f;
            dou = (double)i;
            c = (char)i;
            d = (decimal)dou;

            //упаковка и распаковка
            object o = c;
            c = (char)o;
           
            // неявная типизация
            object obj = 5;
            dynamic dyn = 5;
            dyn = "d";

            //nullable
            string str_n = null;
            string str_e = "";
            //int i_n = null;
            int? i_n = null;
            //HasValue;
            //Value;

            //var
            var a = 5;
           // a = 5.0;
            //строки
            string str_1 = "Hello", str_2 = ",",str_3 = "world";

            Console.WriteLine("Сравнение строк");
            Console.WriteLine(string.Compare(str_1, str_2));
            Console.WriteLine(string.Compare(str_1, str_3));
            Console.WriteLine(string.Compare(str_3, str_2));//сравнение строк

            Console.WriteLine(str_1);
            Console.WriteLine(str_2);
            Console.WriteLine(str_3);

            //конкатенация строк
            Console.WriteLine("конкатенация строк ");
            str_1 = str_1+" "+str_2 + " "+ str_3;//
            // str_1 = String.Concat(str_1, str_2, " ", str_3);
            //str_1 = String.Join(str_1, str_2, str_3);
            Console.WriteLine(str_1);

            //копирование строк
            Console.WriteLine("копирование строк");
            string buff;
            buff = String.Copy(str_1);
            Console.WriteLine(buff);

            //выделение подстроки 
            //разделение строки на слова
            Console.WriteLine("выделение подстроки ");
            Console.WriteLine(str_1);
            string[] str_m = str_1.Split();
            Console.WriteLine(str_m[0]);
            Console.WriteLine(str_m[1]);
            Console.WriteLine(str_m[2]);

            //вставка подстроки в заданную позицию
            Console.WriteLine("вставка подстроки в заданную позицию ");
            buff = str_m[0];
            buff = buff.Insert(5, str_m[2]);
            Console.WriteLine(buff);

            //удаление заданной подстроки
            Console.WriteLine("удаление подстроки из заданной позиции ");
            buff = buff.Remove(5,5);
            Console.WriteLine(buff);

            //интерполяция
            Console.WriteLine("интерполяция ");
            Console.WriteLine($"три строки: {str_m[0]} {str_m[1]} {str_m[2]}");

            // string.IsNullOrEmpty
            Console.WriteLine(string.IsNullOrEmpty(str_n));
            Console.WriteLine(string.IsNullOrEmpty(str_e));
            Console.WriteLine(string.IsNullOrEmpty(str_1));

            //StringBuilder
            Console.WriteLine("StringBuilder");
            StringBuilder sb = new StringBuilder("ривет мир");
            Console.WriteLine(sb);
            sb = sb.Insert(0, "П");//добавляет подстроку, начиная с индекса
            Console.WriteLine(sb);
            sb = sb.Replace("и", "м");//заменяет одну подстроку на другую
            Console.WriteLine(sb);
            sb = sb.Remove(9, 1);//удаляет символы, начиная с индекса
            Console.WriteLine(sb);
            sb.Append("м");//добавляет подстроку в конец строки
            Console.WriteLine(sb);

            //массивы
            Console.WriteLine("Матрица");
            int[,] matrix = { { 1, 2, 3, 4, 5 }, { 2, 3, 4, 5, 6 }, { 3, 4, 5, 6, 7 }, { 4, 5, 6, 7, 8 }, { 5, 6, 7, 8, 9 } };
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    Console.Write(matrix[j, k] + " ");
                }
                Console.Write('\n');
            }

            Console.WriteLine("Массив строк");
            string[] mas_str = { "Типы", "Строки", "Массивы", "Кортежи" };
            Console.WriteLine($"Длина массива: {mas_str.Length}");
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine(mas_str[j]);
            }

            int line, col;
            string symbol;
            Console.WriteLine("Введите номер строки и номер символа, которой хотите изменить, а также сам символ");
            line = Convert.ToInt32(Console.ReadLine());
            col = Convert.ToInt32(Console.ReadLine());
            symbol = Console.ReadLine();
            buff = mas_str[line];
            buff = buff.Remove(col, 1);
            buff = buff.Insert(col, symbol);
            buff = mas_str[line] = buff;

            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine(mas_str[j]);
            }

            double[][] arr = new double[3][];
            arr[0] = new double[2];
            arr[1] = new double[3];
            arr[2] = new double[4];
            for(int j = 0; j < 3; j++)
            {
                Console.WriteLine($"Введите строку {j}");
                for (int k = 0; k < arr[j].Length; k++)
                {
                    arr[j][k] = Convert.ToDouble(Console.ReadLine());
                }
            }

            Console.WriteLine("Ступенчатый массив:");
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < arr[j].Length; k++)
                {
                    Console.Write(arr[j][k] + " ");
                }
                Console.Write('\n');
            }

            buff = "str";
            object str_o = buff;
            object array = arr;

            //кортежи
            (int, string, char, string, ulong) tuple = (1, "m", 'm', "m", 342313124);
            Console.WriteLine("Кортеж: ");
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item2);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);
            Console.WriteLine(tuple.Item5 + '\n');
            bool flag = true;
            Console.WriteLine("Введите номер поля, к которому хотите обратиться:");
            while (flag)
            {
                char choice;
                choice =Convert.ToChar(Console.ReadLine());
                switch(choice)
                {
                    case '1':
                        Console.WriteLine(tuple.Item1);
                        break;
                    case '2':
                        Console.WriteLine(tuple.Item2);
                        break;
                    case '3':
                        Console.WriteLine(tuple.Item3);
                        break;
                    case '4':
                        Console.WriteLine(tuple.Item4);
                        break;
                    case '5':
                        Console.WriteLine(tuple.Item5);
                        break;       
                    default:
                        flag = false;
                        break;
                }
            }
           
            var(name, age) = ("Andrey", 18);
            var t = (name:"Andrey", age: 19);
            Console.WriteLine(name);
            Console.WriteLine(age);
            var firstTuple = (3, 9);
            var secondTuple = (9, 3);
            Console.WriteLine($"Сравнение кортежей: {firstTuple == secondTuple}");


            //локальная функция
            (int, int, char) func(int[] arr, string str)
            {
                (int, int, char) Tuple;

                for (int j = 1; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int buff = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = buff;
                    }
                }
                for (int j = arr.Length - 1; j > 0; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int buff = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = buff;
                    }
                }

                Tuple.Item1 = arr[0];
                Tuple.Item2 = arr[arr.Length - 1];
                Tuple.Item3 = str[0];
                return Tuple;
            }
            int[] func_arr = { 4, 2, 6, 1, 5 };
            string func_str = "dsadasd";
            (int, int, char) T = func(func_arr, func_str);
            Console.WriteLine(T.Item1);
            Console.WriteLine(T.Item2);
            Console.WriteLine(T.Item3);

            //Работа с checked/unchecked
            void max_int(int i)
            {
                checked
                {
                    Console.WriteLine(i + 2);
                }
            }
            void max_float(float f)
            {
                unchecked
                {
                    Console.WriteLine(f + 2);
                }
            }

            max_int(int.MaxValue);
            max_float(float.MaxValue);

        }
    }
}
