using System;

namespace Контрольная
{
    class Program
    {
        static void Main(string[] args)
        {
            //вариант 9
            //1
            Console.WriteLine(Byte.MaxValue);
            int a = 1;
            double b = 1.3;
            byte c = 4;
            char d = '2';
            b = a;
            a = c;
            b = c;
            d = (char)a;
            d = (char)c;
            //2-3
            Challenge challenge = new Challenge("Andrey","20.10.2022",30, 0);
            Test test = new Test("Aвыаываыв", "21", 5, 0);
            challenge.info();
            test.info();
            challenge.Check();
            test.Check();
        }
    }
}
