using System;
using System.Collections.Generic;
using System.Text;

namespace Контрольная
{
    class Challenge : ICheck
    {
        public string Name { get; set; }
        public uint Time { get; set; }
        public string Date;
        public Dif dif;

        public enum Dif 
        { 
            easy,
            hard
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public Challenge(string name,string date, uint time, Dif dif)
        {
            if (name == null || name == "")
            {
                throw new Ex("Не указано имя");
            }
            else
            {
                Name = name;
                Time = time;
                Date = date;
                this.dif = dif;

            }
        }

        public void info()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Time);
            Console.WriteLine(Date);
            Console.WriteLine(dif);
        }

        public void Check()
        {
            Console.WriteLine(Time);
        }
    }

    public class Ex : Exception
    {
        public string message;

        public Ex(string message)
        {
            this.message = message;
        }
    }

    internal class Test : Challenge, ICheck
    {
        public Test(string name,string date, uint time,  Dif dif) : base( name, date,time, dif)
        {

        }

        public new void Check()//неправильно, но никто не заметил)))
        {
            Console.WriteLine(Date);
        }
    }

    public interface ICheck
    {
        public void Check();
    }



}
