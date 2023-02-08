using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_8
{
    delegate void PositionJob();
    delegate void Change();
    public enum Stat
    {
        terrible = 0,
        bad = 1,
        normal = 2,
        good = 3,
        excellent = 4
    }

    class Person
    {
        public string Name { get; set; }
        public Stat Status { get; set; }
        public int Money { get; set; }

        public virtual void Salary() => Money += 100;
        public virtual void Fine() => Money -= 100;
        public void Increase() => Status = Status + 1;
        public void Reduction() => Status = Status - 1;
        public void Prize() => Money += 10 * (int)Status;

        public Person(string name, Stat status, int money)
        {
            Name = name;
            Status = status;
            Money = money;
        }
    }
    sealed class Director
    {
        public string Name;

        public Director(string name)
        {
            Name = name;
        }

        public event PositionJob increase = null;
        public event PositionJob reduction = null;
        public event Change salary = null;
        public event Change fine = null;
        public event Change prize = null;

        public void Increase(Person person)
        {
            if(person.Status < 0)
            {
                if (increase != null)
                    increase.Invoke();
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                Console.WriteLine("Нельзя больше повышать рейтинг");
                Console.ResetColor(); // сбрасываем в стандартный
            }
        }

        public void Reduction(Person person)
        {
            if(person.Status > 0)
            {
                if (reduction != null)
                    reduction.Invoke();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                Console.WriteLine("Нельзя больше понижать рейтинг");
                Console.ResetColor(); // сбрасываем в стандартный
                
            }
            
        }

        public void Salary()
        {
            if (salary != null)
                salary.Invoke();
        }

        public void Fine(Person person)
        {
            if (fine != null)
            {
                fine.Invoke();
                if(person.Money < 0)
                {
                    person.Salary();
                    Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                    Console.WriteLine("Нельзя больше штрафовать");
                    Console.ResetColor(); // сбрасываем в стандартный
                }
            }    
                
        }

        public void Prize()
        {
            if (prize != null)
                prize.Invoke();
        }
    }

    sealed class Student : Person
    {
        public Student(string name, Stat status, int money) : base(name, status, money) { }

        public override void Salary() => Money += 50;
        public override void Fine() => Money -= 50;
    }

    sealed class Turner : Person
    {
        public Turner(string name, Stat status, int money) : base(name, status, money) { }
    }
}
