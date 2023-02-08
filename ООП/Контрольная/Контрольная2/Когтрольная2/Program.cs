using System;
using System.Linq;

namespace Когтрольная2
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperList<string> list = new SuperList<string>();

            try
            {
                Console.WriteLine(list + "a");
                Console.WriteLine(list + "b");
                Console.WriteLine(list + "c");
                Console.WriteLine(list + "d");
                Console.WriteLine(list + "e");
                Console.WriteLine(list + "f");

            }
            catch (IndexOutOfRangeException)
            {

                Console.WriteLine("Превышен размер контейнера");
            }
            finally
            {
                foreach (var item in list.l)
                {
                    Console.WriteLine(item);
                }
            }

            var select = (from selected in list.l
                          where selected.StartsWith('A')
                          select selected).Take(1);
            foreach (var item in select)
            {
                Console.WriteLine(item);
            }

            Doctor doctor = new Doctor();
            Person person = new Person(false);

            doctor.help += person.help;
            doctor.HELP(person);
            doctor.help -= person.help;
            person.GiveTemp();
            doctor.help += person.help;
            doctor.HELP(person);
            doctor.help -= person.help;


        }
    }
}
