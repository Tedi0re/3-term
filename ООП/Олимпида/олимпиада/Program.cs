using System;

namespace Ol
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            int sum = 0;
            int i = 1;
            int tmp = 0;
            int n = int.Parse(Console.ReadLine());
            while (true)
            {
                if (n % Math.Sqrt(n) == 0)
                {
                    ++tmp;
                }
                if (n % (i * i) == 0 && i != 1)
                {
                    if (tmp != 0)
                    {
                        ++tmp;
                        n -= i * i;
                        i = 1;
                    }
                    else
                    {
                        tmp = n / (i * i);
                        Console.WriteLine(tmp);
                        break;
                    }
                }
                else if (i * i < n)
                {
                    ++i;
                }
                else if (n <= 0)
                {
                    Console.WriteLine(tmp);
                    break;
                }
                else if (n == 1)
                {
                    ++tmp;
                    Console.WriteLine(tmp);
                    break;
                }
                else
                {
                    --i;
                    n -= i * i;
                    i = 1;
                    tmp++;
                }
            }

        }

    }
}
