using System;
using System.IO;

namespace OOP_Lab_11.Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
           
            person person1 = new person("sdd", 2);
            лаб_2.Customer customer = new лаб_2.Customer();
            ООП_лаб_4_5.Rose rose = new ООП_лаб_4_5.Rose("роза");
            Data PersonData = new Data
                (Reflector.GetAssemblyName(person1.GetType()),
                Reflector.PublicConstuctors(person1.GetType()),
                Reflector.GetSetFieldInfo(person1.GetType()),
                Reflector.InterfaceInfo(person1.GetType()),
                Reflector.AllMethods(person1.GetType()));
            Data CustomerData = new Data
                (Reflector.GetAssemblyName(customer.GetType()),
                Reflector.PublicConstuctors(customer.GetType()),
                Reflector.GetSetFieldInfo(customer.GetType()),
                Reflector.InterfaceInfo(customer.GetType()),
                Reflector.AllMethods(customer.GetType()));
            Data RoseData = new Data
                (Reflector.GetAssemblyName(rose.GetType()),
                Reflector.PublicConstuctors(rose.GetType()),
                Reflector.GetSetFieldInfo(rose.GetType()),
                Reflector.InterfaceInfo(rose.GetType()),
                Reflector.AllMethods(rose.GetType()));
            PersonData.Print("D:\\ООП\\Lab_11.Reflection\\OOP_Lab_11.Reflection\\bin\\Debug\\netcoreapp3.1\\person.txt");
            CustomerData.Print("D:\\ООП\\Lab_11.Reflection\\OOP_Lab_11.Reflection\\bin\\Debug\\netcoreapp3.1\\customer.txt");
            RoseData.Print("D:\\ООП\\Lab_11.Reflection\\OOP_Lab_11.Reflection\\bin\\Debug\\netcoreapp3.1\\rose.txt");
            object[] parameters = { };
            Reflector.Invoke(person1, "BirthDay", parameters);
            string path = "D:\\ООП\\Lab_11.Reflection\\OOP_Lab_11.Reflection\\bin\\Debug\\netcoreapp3.1\\param.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string text = reader.ReadToEnd();
                object[] p = text.Split(' ');
                object[] p2 = { 2 };
                Reflector.Invoke(person1, "numberParameter", p2);
            }
            dynamic[] CParam = { (string)"Name", (int)1 ,(int)2};
            try
            {
                person? person2 = (person)Reflector.Create(person1.GetType(), CParam);
                Console.WriteLine(person2.Name);
                Console.WriteLine(person2.Age);
                Console.WriteLine(person2.money);
            }
            catch (Exception) { Console.WriteLine("Не удалось создать объект"); }
            
            

        }
    }
}
