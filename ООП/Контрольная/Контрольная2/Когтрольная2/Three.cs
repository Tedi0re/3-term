using System;
using System.Collections.Generic;
using System.Text;

namespace Когтрольная2
{
    delegate void Help(); 
    class Doctor
    {
        public event Help help= null;

        public void HELP(Person person)
        {
            if (person.GetTemp() == true)
            {
                if (help != null)
                    help.Invoke();
                Console.WriteLine("Температура снята");
            }
            else
            {
                Console.WriteLine("температуры не было");
            }

        }
    }

    class Person
    {
        bool temperature;

        public Person(bool Temp)
        {
            temperature = Temp;
        }

        public void GiveTemp()
        {
            temperature = true;
        }

        public bool GetTemp()
        {
            return temperature;
        }

        public void help()
        {
            temperature = false;
        }
    }

}
