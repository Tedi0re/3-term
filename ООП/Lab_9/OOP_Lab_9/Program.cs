using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;



namespace OOP_Lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            Employee employee1 = new Employee("Андрей");
            Employee employee2 = new Employee("Олег");
            Employee employee3 = new Employee("Антон");
            Employee employee4 = new Employee("Влад");
            Employee employee5 = new Employee("Илья");
            employee1.AddTool(new Employee.Tool("Пила"));
            employee1.AddTool(new Employee.Tool("Молоток"));
            employee2.AddTool(new Employee.Tool("Молоток"));
            employee2.AddTool(new Employee.Tool("Гвозди"));
            employee3.AddTool(new Employee.Tool("Шуруповерт"));
            employee4.AddTool(new Employee.Tool("Лобзик"));

            hashtable.Add(employee1.GetHashCode(), employee1);
            hashtable.Add(employee2.GetHashCode(), employee2);
            hashtable.Add(employee3.GetHashCode(), employee3);
            hashtable.Add(employee4.GetHashCode(), employee4);
            hashtable.Add(employee5.GetHashCode(), employee5);

            Console.WriteLine(hashtable[employee1.GetHashCode()]);
            Console.WriteLine(hashtable[employee2.GetHashCode()]);
            Console.WriteLine(hashtable[employee3.GetHashCode()]);
            Console.WriteLine(hashtable[employee4.GetHashCode()]);
            Console.WriteLine(hashtable[employee5.GetHashCode()]);
            Console.WriteLine("-------------------------------");
            hashtable.Remove(employee5.GetHashCode());

            Console.WriteLine(hashtable[employee1.GetHashCode()]);
            Console.WriteLine(hashtable[employee2.GetHashCode()]);
            Console.WriteLine(hashtable[employee3.GetHashCode()]);
            Console.WriteLine(hashtable[employee4.GetHashCode()]);
            Console.WriteLine(hashtable[employee5.GetHashCode()]);

            list<int> listInt = new list<int>();
            listInt.Add(1);
            listInt.Add(3);
            listInt.Add(5);
            listInt.Add(6);
            listInt.Add(1);
            foreach (var item in listInt)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------");
            listInt.Remove(0);
            listInt.Remove(3);
           
            
            foreach (var item in listInt)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------");
            listInt.Browse(0);
            Console.WriteLine("-------------------------------");
            List<int> lst = new List<int>();
            foreach (int item in listInt)
            {
                lst.Add(item);
            }
            
            foreach (int item in lst)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine(lst[0]);
            Console.WriteLine("-------------------------------");
            var os = new ObservableCollection<int>();
            {
                list<int>l = new list<int>();
            }
            os.CollectionChanged += list<int>.print;
            os.CollectionChanged += list<int>.Item_CollectionChanged;
            os.Add(1);
            os.Add(3);
            os.Add(5);
            os.Remove(1);
        }
        
    }


}
