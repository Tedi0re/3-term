using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Linq;

namespace Экзамен
{
    public enum WeekDay
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    public class AnyDayTimeTable
    {

        private WeekDay day;

        public WeekDay Day
        {
            get => day;
            set
            {
                if (value >= WeekDay.Monday && value <= WeekDay.Sunday)
                {
                    day = value;
                    return;
                }
                throw new Exception(message: "Неправильно введен день");
            }
        }



        public override bool Equals(object obj)
        {
            if (obj is AnyDayTimeTable day1)
            {
                return day1.day == this.day;
            }
            return false;
        }


        public static bool operator ==(AnyDayTimeTable day1, AnyDayTimeTable day2)
        {
            return day1.Equals(day2);
        }

        public static bool operator !=(AnyDayTimeTable day1, AnyDayTimeTable day2)
        {
            return !day1.Equals(day2);
        }




    }

    public static class Reflector
    {
        public static void GetConstructors(Type Class)
        {
            ConstructorInfo[] ctor = Class.GetConstructors();
            for (int i = 0; i < ctor.Length; i++)
            {
                Console.WriteLine(ctor[i]);
            }
        }

        public static void GetProperties(Type Class)
        {
            PropertyInfo[] properties = Class.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                Console.WriteLine(properties[i]);
            }
        }
    }

    public class TimeTable<T> where T : AnyDayTimeTable
    {
        public List<T> list = new List<T>();

        public void GetDay()
        {
            var Selected = (from selected in this.list
                            group selected by selected.Day
                           into g
                            orderby g.Count() descending
                            select g).Take(1);

            foreach (var item in Selected)
            {
                Console.WriteLine(item.Key);
            }

        }
    }

    public class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        public static Singleton Instance
        {
            get { return instance; }
        }
        protected Singleton() { }
    }
}
