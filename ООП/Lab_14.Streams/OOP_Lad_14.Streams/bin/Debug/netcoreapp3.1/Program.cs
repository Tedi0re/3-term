using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA14
{
    public class Program
    {
        static object block = new object();
        static Mutex mutex_i = new Mutex();
        static StreamWriter test = new StreamWriter("Number_test.txt", true);
        public static void Calculation(Object Parametr)
        {
            try
            {
                using (StreamWriter stream = new StreamWriter("Calculation.txt", false))
                {
                    if (Parametr is int n)
                    {
                        for (int i = 1; i <= n; i++)
                        {
                            Console.WriteLine(i);
                            stream.WriteLine(i);
                            Thread.Sleep(200);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не то");
                    }
                };
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine((string)ex.ExceptionState);
            }
        }
        public static void EvenNumber(object number)
        {
            if (number is int length)
            {
                lock (block)
                {
                    using (StreamWriter fs = new StreamWriter("Number.txt", false))
                    {
                        for (int i = 0; i < length; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.WriteLine($"Поток номер 1. Число {i}");
                                fs.WriteLine($"Поток номер 1. Число {i}");
                            }
                            Thread.Sleep(100);
                        }
                    };
                }
            }
        }
        public static void OddNumber(object number)
        {
            if (number is int length)
            {
                lock (block)
                {
                    using (StreamWriter fs = new StreamWriter("Number.txt", false))
                    {
                        for (int i = 0; i < length; i++)
                        {
                            if ((i % 2) != 0)
                            {
                                Console.WriteLine($"Поток номер 2. Число {i}");
                                fs.WriteLine($"Поток номер 2. Число {i}");
                            }
                            Thread.Sleep(150);
                        }
                    };
                }
            }
        }
        public static void EvenNumber_ii(object number)
        {
            if (number is int length)
            {
                for (int i = 0; i <= length; i++)
                {
                    mutex_i.WaitOne();
                    if (i % 2 == 0)
                    {
                        Console.WriteLine($"Поток номер 3. Число {i}");
                        test.WriteLine($"{i},");
                    }
                    Thread.Sleep(100);
                    mutex_i.ReleaseMutex();
                }
            }
        }
        public static void OddNumber_ii(object number)
        {
            if (number is int length)
            {
                for (int i = 0; i <= length; i++)
                {
                    mutex_i.WaitOne();
                    if ((i % 2) != 0)
                    {
                        Console.WriteLine($"Поток номер 4. Число {i}");
                        test.WriteLine($"{i},");
                    }
                    Thread.Sleep(150);
                    mutex_i.ReleaseMutex();
                }
            }
        }
        public static void ShowTime(object? state)
        {
            Console.WriteLine($"Текущее время: {DateTime.Now.ToLocalTime()}");
        }
        //1. Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет, 
        //время запуска, текущее состояние, сколько всего времени использовал процессор и т.д
        public static void Main()
        {
            using (StreamWriter fs = new StreamWriter("info.txt", true))
            {
                var allProcess = Process.GetProcesses();
                foreach (var process in allProcess)
                {
                    Console.WriteLine($"ID: {process.Id}, Name: {process.ProcessName}, BasePriority: {process.BasePriority}");
                    fs.WriteLine($"ID: {process.Id}, Name: {process.ProcessName}, BasePriority: {process.BasePriority}");
                }
            }
            //2. Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки,
            //загруженные в домен.Создайте новый домен.Загрузите туда сборку.Выгрузите домен.
            AppDomain MyDomain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {MyDomain.FriendlyName}, \n Детали конфигурации: {MyDomain.SetupInformation}");
            Console.WriteLine("Cборки загруженные в домен");
            foreach (var item in MyDomain.GetAssemblies())
            {
                Console.WriteLine(item);
            }
            try
            {
                Console.WriteLine("============================");
                AppDomain appDomain = AppDomain.CreateDomain("New_Domen");
                Console.WriteLine(appDomain.Id);
                appDomain.Load(@"D:\УНИК\Семестр 3\ООП\OOP_git\Laba-OOP\LABA14\LABA14\bin\Debug\net6.0\LABA14.dll");
                AppDomain.Unload(appDomain);
                Console.WriteLine("============================");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("============================");
            }

            /*3. Создайте в отдельном потоке следующую задачу расчета (можно сделать sleep для 
            задержки) и записи в файл и на консоль простых чисел от 1 до n (задает пользователь). 
            Вызовите методы управления потоком (запуск, приостановка, возобновление и т.д.) Во 
            время выполнения выведите информацию о статусе потока, имени, приоритете, числовой 
            идентификатор и т.д.
            */
            Console.Clear();
            ParameterizedThreadStart param = new ParameterizedThreadStart(Calculation);
            Thread MyThread = new Thread(param);
            MyThread.Start(12);
            Console.WriteLine($"Запещен ли поток: {MyThread.IsAlive}");
            Console.WriteLine($"Имя потока: {MyThread.Name}");
            Console.WriteLine($"Id потокa: {MyThread.ManagedThreadId}");
            Console.WriteLine($"Приоритет потока: {MyThread.Priority}");
            Console.WriteLine($"Статус потока: {MyThread.ThreadState}");
            /*4. Создайте два потока. Первый выводит четные числа, второй нечетные до n и 
            записывают их в общий файл и на консоль. Скорость расчета чисел у потоков – разная.
            a. Поменяйте приоритет одного из потоков. 
            b. Используя средства синхронизации организуйте работу потоков, таким образом, 
            чтобы
            i. выводились сначала четные, потом нечетные числа
            ii. последовательно выводились одно четное, другое нечетное. */
            Thread.Sleep(7000);
            Console.Clear();
            Thread Even  = new Thread(new ParameterizedThreadStart(EvenNumber)); //две вариации записи
            Thread Odd = new Thread(OddNumber);
            Even.Priority = ThreadPriority.Lowest;
            Odd.Priority = ThreadPriority.Highest;
            Odd.Start(30);
            Even.Start(30);
            Thread.Sleep(9000);
            Console.Clear();
            Thread Even_ii = new Thread(EvenNumber_ii);
            Thread Odd_ii = new Thread(OddNumber_ii);
            Even_ii.Start(30);
            Odd_ii.Start(30);
            TimerCallback timeCB = new TimerCallback(ShowTime);
            Timer time = new Timer(timeCB, null, 0, 1000);
        }
    }
}
