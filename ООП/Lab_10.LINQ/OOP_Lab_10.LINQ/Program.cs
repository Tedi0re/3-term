using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace OOP_Lab_10.LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Mounths= { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            Console.WriteLine("Введите размер слова:");
            int CurrentLength = Convert.ToInt32(Console.ReadLine());
            //1.1
            var SelectMounts = from selected in Mounths
                               where selected.Length < CurrentLength + 1
                               select selected;
            foreach (var Mounth in SelectMounts)
            {
                Console.WriteLine("{0}",Mounth);
            }
            //1.2
            SelectMounts = from selected in Mounths
                           where selected == "January" || selected == "February" || selected == "December"
                           select selected;
            Console.WriteLine("\nЗимние месяцы");
            foreach (var Mounth in SelectMounts)
            {
                
                Console.WriteLine("{0}", Mounth);
            }
            //1.3
            SelectMounts = from selected in Mounths
                           where selected == "June" || selected == "July" || selected == "August"
                           select selected;
            Console.WriteLine("\nЛетние месяцы");
            foreach (var Mounth in SelectMounts)
            {

                Console.WriteLine("{0}", Mounth);
            }
            //1.4
            SelectMounts = from selected in Mounths
                           orderby selected
                           select selected;
            Console.WriteLine("\nНазвание месяцев в алфавитном порядке");
            foreach (var Mounth in SelectMounts)
            {

                Console.WriteLine("{0}", Mounth);
            }
            //1.5
            SelectMounts = from selected in Mounths
                           where selected.Contains("u")
                           orderby selected
                           select selected;
            Console.WriteLine("\nНазвание месяцев в которых встречается буква \"u\" ");
            foreach (var Mounth in SelectMounts)
            {

                Console.WriteLine("{0}", Mounth);
            }
            //2
            List<лаб_2.Customer> customers = new List<лаб_2.Customer>();

            customers.Add(new лаб_2.Customer(FirstName: "Andrey", CardNumber: 100, CardBalance: 1000));
            customers.Add(new лаб_2.Customer(FirstName: "Oleg", CardNumber: 101, CardBalance: 100));
            customers.Add(new лаб_2.Customer(FirstName: "Nikita", CardNumber: 102, CardBalance: 0));
            customers.Add(new лаб_2.Customer(FirstName: "Vladislave", CardNumber: 103, CardBalance: 999));
            customers.Add(new лаб_2.Customer(FirstName: "Anton", CardNumber: 104, CardBalance: 500));
            customers.Add(new лаб_2.Customer(FirstName: "Ilya", CardNumber: 105, CardBalance: 10));
            customers.Add(new лаб_2.Customer(FirstName: "Alexander", CardNumber: 106, CardBalance: 1));
            customers.Add(new лаб_2.Customer(FirstName: "Ekaterina", CardNumber: 107, CardBalance: 990));
            customers.Add(new лаб_2.Customer(FirstName: "Natalya", CardNumber: 108, CardBalance: 888));
            customers.Add(new лаб_2.Customer(FirstName: "Alina", CardNumber: 109, CardBalance: 5));
            customers.Add(new лаб_2.Customer(FirstName: "Angelina", CardNumber: 110, CardBalance: 6));
            //3.1
            var SelectedCustomers = from selected in customers
                                    orderby selected.firstName 
                                    select selected;
            Console.WriteLine("Покупатели в алфавитном порядке");
            foreach (var customer in SelectedCustomers)
            {
                Console.WriteLine(customer.firstName);
            }
            //3.2
            var CardNumberSelectedCustomers = from selected in customers
                                    where selected.cardNumber >= 100 && selected.cardNumber <= 105
                                    select selected;
            Console.WriteLine("Покупатели с диапазонами карт от 100 до 105");
            foreach (var customer in CardNumberSelectedCustomers)
            {
                Console.WriteLine(customer.firstName + ": " +  customer.cardNumber);
            }
            //3.3
            var MaxCustomer = from selected in customers where selected.cardBalance == customers.Max(selected => selected.cardBalance) select selected;
            Console.WriteLine("Покупатель с максимальным балансом на счету");
            foreach (var customer in MaxCustomer)
            {
                Console.WriteLine(customer.firstName + ": " + customer.cardBalance);
            }
            //3.4
            var RichCustomers = (from seleted in customers
                                  orderby seleted.cardBalance descending
                                 select seleted).Take(5);
            Console.WriteLine("Самые богатые покупатели");
            foreach (var customer in RichCustomers)
            {
                Console.WriteLine(customer.firstName + ": " + customer.cardBalance);
            }
            //4
            var Selected = from selected in customers
                           where selected.cardNumber < 105
                           where selected.firstName.Contains('A')
                           where selected.cardBalance > 500
                           orderby selected.cardBalance descending
                           group selected by selected.firstName;
            Console.WriteLine("произвольный запрос");
            foreach (var customer in Selected)
            {
                Console.WriteLine(customer.Key);
            }
            List<лаб_2.Customer> customers1 = new List<лаб_2.Customer>();

            customers1.Add(new лаб_2.Customer(FirstName: "Andrey", FatherName: "Alexandrovich", SecondName: "Simonov"));
            customers1.Add(new лаб_2.Customer(FirstName: "Oleg", FatherName: "Dmitrievich", SecondName: "Kozak"));
            var CustomersFIO = customers.Join(customers1,
                customers => customers.firstName,
                customers1 => customers1.firstName,
                (customers, customers1) => new { 
                    firstName = customers.firstName,
                    secondName = customers1.secondName, 
                    fatherName = customers1.fatherName, 
                    cardNumber = customers.cardNumber,
                    cardBalance = customers.cardBalance });
            Console.WriteLine("ФИО покупателей");
            foreach (var customer in CustomersFIO)
            {
                Console.WriteLine(customer.secondName  + " " + customer.firstName + " " + customer.fatherName + " " + customer.cardNumber + " " + customer.cardBalance);
            }

        }
    }
}
