using System;

namespace лаб_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int NewBalance;
            Customer[] customers = new Customer[3];

            for (int i = 0; i < customers.Length; i++)
            {
                customers[i] = new Customer("undefined");
            }

            customers[0].firstName = "Андрей";
            customers[1].firstName = "Илья";
            customers[2].firstName = "Олег";

            customers[0].cardBalance = 10000;
            customers[1].cardBalance = 0;
            customers[2].cardBalance = 00000;

            customers[0].Stonks(out NewBalance);
            Console.WriteLine(NewBalance);
            customers[1].NotStonks(out NewBalance);
            Console.WriteLine(NewBalance);
            customers[0].info();
            customers[0].ToString();

            void sort( ref Customer[] customers)
            {
                for (int i = 0; i < customers.Length; i++)
                {
                    for (int j = 0; j < customers.Length - 1; j++)
                    {
                        if(customers[j].firstName[0] > customers[j +1].firstName[0])
                        {
                            string buff = customers[j].firstName;
                            customers[j].firstName = customers[j + 1].firstName;
                            customers[j + 1].firstName = buff;
                        }
                    }
                }
            }

            sort(ref customers);

            for (int i = 0; i < customers.Length; i++)
            {
                Console.WriteLine(customers[i].firstName);
            }

            void range(ref Customer[] customers, int leftBorder, int RightBorder)
            {
                for (int i = 0; i < customers.Length; i++)
                {
                    if(customers[i].cardNumber < leftBorder || customers[i].cardNumber > RightBorder)
                    {
                        Console.WriteLine($"Покупатель {customers[i].id} не имеет номера карты в заданном интервале");
                    }
                    else
                    {
                        Console.WriteLine($"Покупатель {customers[i].id} имеет номер карты {customers[i].cardNumber} ");
                    }
                }
            }

            range(ref customers, 0, 1000);

            var obj = new { second_name = "asd", first_name = " dsf", father_name = "sd", adress = "dfds", number_card = 3, card_balance = 0 };
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.first_name + " " + obj.second_name);
        }
    }
}
