using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;

namespace OOP_Lab_15.TPL
{
    class Program
    {
        public static void Count(ref Task task)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            do
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Идентификатор задачи: {task.Id}");
                Console.WriteLine($"Текущее состояние задачи: {task.Status}");
                Console.WriteLine($"Затраченное время: {timer.Elapsed}");
                if (task.IsCompleted || task.IsCanceled || task.IsFaulted ) break;
            } while (true);
            timer.Stop();
        }

        public static int Func1(int a)
        {
            int result = ++a;
            Console.WriteLine("Func1: " + result);
            return result;
        }

        public static int Func2(int a)
        {
            int result = a + 2;
            Console.WriteLine("Func2: " + result);
            return result;
        }

        public static int Func3(int a)
        {
            int result = ~a;
            
            Console.WriteLine("Func3: " + result);
            return result;
            
        }

        public static void Square(int a)
        {
            //Console.WriteLine($"{a}*{a} = {a*a}");
            long result = a * a;
        }

        static void Main(string[] args)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            //задание 1
            SieveEratosthenes SieveComplete = new SieveEratosthenes(100);
            Task SieveTaskComplete = new Task(() => SieveComplete.GetPrimeNumber(ref token));
            Task TimerTask1 = new Task(() => Count(ref SieveTaskComplete));
            SieveTaskComplete.Start();
            TimerTask1.Start();
            SieveTaskComplete.Wait();
            TimerTask1.Wait();
            //задание 2
            Console.ReadKey();
            Console.Clear();
            SieveEratosthenes SieveCancel = new SieveEratosthenes(100);
            Task SieveTaskCancel = new Task(() => SieveCancel.GetPrimeNumber(ref token));
            Task TimerTask2 = new Task(() => Count(ref SieveTaskCancel));
            SieveTaskCancel.Start();
            TimerTask2.Start();
            Thread.Sleep(5000);
            source.Cancel();
            SieveTaskCancel.Wait();
            TimerTask2.Wait();
            //задание 3-4
            Console.ReadKey();
            Console.Clear();
            Task<int> TaskContinueWith1 = new Task<int>(() => Func1(1));
            Task<int> TaskContinueWith2 = TaskContinueWith1.ContinueWith(task => Func2(TaskContinueWith1.Result));
            Task<int> TaskContinueWith3 = TaskContinueWith2.ContinueWith(task => Func3(TaskContinueWith2.Result));
            TaskContinueWith1.Start();
            TaskContinueWith3.Wait();
            Console.ReadKey();
            Console.Clear();
            Task<int> TaskContinueWith11 = new Task<int>(() => Func1(1));
            var awaiter1 = TaskContinueWith11.GetAwaiter();
            Task<int> TaskContinueWith22 = TaskContinueWith1.ContinueWith(task => Func2(awaiter1.GetResult()));
            var awaiter2 = TaskContinueWith22.GetAwaiter();
            Task<int> TaskContinueWith33 = TaskContinueWith2.ContinueWith(task => Func3(awaiter2.GetResult()));
            TaskContinueWith11.Start();
            TaskContinueWith33.Wait();
            //задание 5-6
            Console.ReadKey();
            Console.Clear();
            Stopwatch timer1 = new Stopwatch();
            Stopwatch timer2 = new Stopwatch();
            Stopwatch timer3 = new Stopwatch();
            int size = 10000000;
            timer1.Start();
            Parallel.For(1, size, Square);
            timer1.Stop();
            Console.WriteLine($"Время выполнения: {timer1.Elapsed}");
            Console.ReadKey();
            Console.Clear();
            timer2.Start();
            for (int i = 1; i < size; i++)
            {
                Square(i);
            }
            timer2.Stop();
            Console.WriteLine($"Время выполнения: {timer2.Elapsed}");
            Console.ReadKey();
            Console.Clear();
            Action[] actions = new Action[size];
            List<int> list = new List<int>() { 1,2,3,4,5,6,7,8,9};
            Action<int> action = (i) => Console.WriteLine("1");
            Parallel.ForEach(list,action);
            Console.ReadKey();
            for (int i = 0; i < size; i++)
            {
                actions[i] += () => Square(i);
            }
            timer3.Start();
            Parallel.Invoke(actions);
            timer3.Stop();
            Console.WriteLine($"Время выполнения: {timer3.Elapsed}");
            Console.ReadKey();
            Console.Clear();
            //задание 7
            Task_7.task_7();

            PrintAsync();

        }

        

        static void Print()
        {
            Thread.Sleep(3000);     // имитация продолжительной работы
            Console.WriteLine("Hello");
        }

        // определение асинхронного метода
        static async Task PrintAsync()
        {
            Console.WriteLine("Начало метода PrintAsync"); // выполняется синхронно
            await Task.Run(() => Print());                // выполняется асинхронно
            Console.WriteLine("Конец метода PrintAsync");
        }
    }
}
