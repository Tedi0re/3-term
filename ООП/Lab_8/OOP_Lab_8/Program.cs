using System;

namespace OOP_Lab_8
{
    class Program
    {
        static void Main()
        {
            Predicate<string> predicate = ExtentionString.NullOrEmpty;
            predicate += ExtentionString.HavePoints;

            Func<string,string> func = ExtentionString.EndPoint;
            func += ExtentionString.UpSymbols;
            func += ExtentionString.Reverse;
            func += ExtentionString.DoubleString;
            func += ExtentionString.Print;

            Action<string> action = ExtentionString.RedString;
            action += ExtentionString.GreenString;
            action += ExtentionString.BlueString;
            string s = "объектно-ориентированное программирование";
            func(s);
            predicate(s);
            action(s);
            
            Director director = new Director("Шиман");

            Turner turner1 = new Turner("Петрович", Stat.good, 1000);
            Turner turner2 = new Turner("Михалыч", Stat.excellent, 200);
            Turner turner3 = new Turner("Белодед Николай Иванович", Stat.bad, 300);

            Student student1 = new Student("Андрей", Stat.good, 80);
            Student student2 = new Student("Олег", Stat.normal, 100);
            Student student3 = new Student("Никита", Stat.excellent, 150);

            director.salary += student1.Salary;
            director.salary += student2.Salary;
            director.salary += student3.Salary;
            director.salary += turner1.Salary;
            director.salary += turner2.Salary;
            director.salary += turner3.Salary;

            int time = 0;
            ConsoleKey key;
            while (true)
            {
                if(time%3 == 0)
                {
                    director.Salary();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("----------Пришла заработная плата-----------");
                    Console.ResetColor();
                    PersonInfo(student1);
                    PersonInfo(student2);
                    PersonInfo(student3);
                    PersonInfo(turner1);
                    PersonInfo(turner2);
                    PersonInfo(turner3);
                }
                Console.WriteLine("Выберите действие:\nI - Повышение\nD - Понижение\nF - Штраф\nP - Премия");
                key = Console.ReadKey().Key;
                Person person;
                switch (key)
                {
                    case ConsoleKey.I:
                        {
                            person = Choice();
                            if (person == null)
                            {
                                Console.WriteLine("Нет такого человека");
                                break;
                            }
                            director.increase += person.Increase;
                            director.Increase(person);
                            director.increase -= person.Increase;
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            person = Choice();
                            if (person == null)
                            {
                                Console.WriteLine("Нет такого человека");
                                break;
                            }
                            director.reduction += person.Reduction;
                            director.Reduction(person);
                            director.reduction -= person.Reduction;
                            break;
                        }
                    case ConsoleKey.F:
                        {
                            person = Choice();
                            if (person == null)
                            {
                                Console.WriteLine("Нет такого человека");
                                break;
                            }
                            director.fine += person.Fine;
                            director.Fine(person);
                            director.fine -= person.Fine;
                            break;
                        }
                    case ConsoleKey.P:
                        {
                            person = Choice();
                            if (person == null)
                            {
                                Console.WriteLine("Нет такого человека");
                                break;
                            }
                            director.prize += person.Prize;
                            director.Prize();
                            director.salary -= person.Prize;
                            break;
                        }
                }
                time++;
            }

            Person Choice()
            {
                string choice;
                Console.WriteLine("\nВведите имя студента или токаря");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "Андрей":
                        {
                            return student1;
                        }
                    case "Олег":
                        {
                            return student2;
                        }
                    case "Никита":
                        {
                            return student3;
                        }
                    case "Петрович":
                        {
                            return turner1;
                        }
                    case "Михалыч":
                        {
                            return turner2;
                        }
                    case "Белодед":
                        {
                            return turner3;
                        }
                }
                return null;
            }
            
            void PersonInfo(Person person)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Имя: "+ person.Name);
                Console.WriteLine("Социальный статус: "+ person.Status);
                Console.WriteLine("Деньги: "+ person.Money + "\n");
            }
        }
    }
}
