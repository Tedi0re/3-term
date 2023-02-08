using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Экзамен
{
    class Program
    {

        AnyDayTimeTable timeTable = new AnyDayTimeTable { Day = WeekDay.Monday };


        public static void Print1(CancellationToken token)
        {
            Console.WriteLine("Hello");
        }

        public static void Print2(CancellationToken token)
        {
            Console.WriteLine("world");
        }


        static void Main()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Task task = new Task(() => Print1(token));
            Task task1 = new Task(() => Print2(token));

            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(1000);
                Console.Clear();
                task1.Start();
                task.Start();
                //task.Wait();
                //task.Wait();
                Console.WriteLine("the end");
            }
           
            

            

            
        }

        

    }

   
}
