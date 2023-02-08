using System;
using System.Collections.Generic;
using System.Text;

namespace лаб_2
{
    public partial class Customer
    {
        readonly int Id;
        private string SecondName;
        private string FirstName;
        private string FatherName;
        private string Adress;
        private int CardNumber;
        private int CardBalance;
        static int Counter;

        public int id
        {
            get { return Id; }
        }

        public string secondName
        {
            get { return SecondName; }
            set { SecondName = value; }
        }

        public string firstName
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        public string fatherName
        {
            get { return FatherName; }
            private set { FatherName = value; }
        }

        public string adress
        {
            get { return Adress; }
            set { Adress = value; }
        }

        public int cardNumber
        {
            get { return CardNumber; }
            set 
            {
                if (value >= 0)
                    cardNumber = value;
                else
                    Console.WriteLine("Неверный ввод");
            }
        }

        public int cardBalance
        {
            get { return CardBalance; }
            set { CardBalance = value; }
        }

        public Customer(string SecondName = "undefined", string FirstName = "undefined", string FatherName = "undefined", string Adress = "undefined", int CardNumber = 0, int CardBalance = 0)
        {
            Counter++;
            this.Id = GetHashCode();
            this.SecondName = SecondName;
            this.FirstName = FirstName;
            this.FatherName = FatherName;
            this.Adress = Adress;
            this.CardNumber = CardNumber;
            this.CardBalance = CardBalance;
            
        }

        static Customer()
        {
            Counter = 0;
        }

        private Customer()
        {

        }

        static void Info()
        {
            Console.WriteLine($"Создано объектов: {Counter}");
        }
    }



    public partial class Customer
    {
        public void Stonks(out int NewBalance)
        {
            this.cardBalance += 300;//three hundred bucks
            NewBalance = this.cardBalance;
        }

        /*  
⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣛⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⡉⣤⣿⡀⡿⠶⣇⠹⣧⠘⣿⣿⣿⣇⣀⣠⣤⣶⣶⣿⣿⡏⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠟⢛⣛⣩⣭⣴⣶⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⣸⣿⣡⣘⣿⣿⣇⢣⣌⢣⠀⣶⡈⡆⢻⡆⢹⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⣿⡿⠿⠿⣟⣛⣭⣭⣤⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠛⢿⠟⠋⠁⠀⠀⠙⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⣿⠿⠛⠉⠻⠿⣿⡿⠋⠀⠀⠉⠙⠻⠘⣦⣙⣃⣿⣦⣴⣾⣿⢻⣿⣿⣿⡿⢿⣛⣛⣩⣭⡍⣶⣿⣿⣿⣿⣿⣿⣿⣿⠿⣿⣿⣿⣿⣿⠿⠀⢹⣿⠏⠀⠐⠀⠀⠀⠀⠀⠀⠀⣀⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⡇⠈⠻⠟⠁⠀⠀⠀⠀⠀⣾⠀⠀⠀⠀⠀⠀⠀⠘⢿⣿⣿⠿⣿⣻⣻⣿⣽⣷⣶⣾⣿⣿⣿⣿⣿⣿⣿⣻⣿⣿⣿⣿⣿⣿⡏⢠⣤⠀⢻⣿⣿⡧⠤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿
⣾⢽⣹⡿⣿⣿⣿⣿⣧⡤⠂⠀⠀⠀⠀⠀⠀⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠈⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠙⢿⣿⣿⣿⡏⣿⣿⣿⣿⣿⣿⡇⠀⣿⡇⠀⣿⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿
⣶⣿⣿⣹⣟⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⢠⣿⣧⠀⠀⣠⠶⣦⣄⠀⠀⣀⣸⡟⢛⡛⣿⢰⣎⣻⣷⣿⣿⣿⡏⠀⠀⠙⢿⣿⣿⣻⣿⣿⣿⣿⣿⣿⠀⢸⡇⠀⣿⠛⢳⣦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣿⣿⣿
⣾⣷⣿⣿⣿⣿⣿⣿⡏⠀⠀⠀⠀⠀⠀⢀⣾⣿⣿⡀⠀⠀⠶⠈⠉⠀⠘⢹⡟⢳⡜⢃⠻⡈⢠⡌⢿⡟⣿⣿⣀⣤⣤⣤⣤⣿⣿⣏⣿⣿⣿⣿⣿⣿⣷⣤⣤⣴⣿⣶⣾⣿⡟⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣙⣉⣩⣭⣤
⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣇⢻⡧⢱⣘⠟⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⣿⣿⣿⣿⣿⠿⠿⣿⣛⣛⣻⣍⣉⠀⠀⠀⠀⠀⠀⠀⢄⡀⠀⠀⠀⠀⢹⣿⣿⣿⣿
⣿⣿⣹⣗⣞⣟⣿⣿⣧⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⠀⠀⠀⠀⢀⣼⣶⣾⣷⣶⣿⣿⣿⣿⣿⢯⣿⣿⣛⣛⣛⣿⣿⣭⣿⣯⣶⣶⣶⣾⣿⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀⠀⠀⠀⠠⠅⠛⠛⢶⡤⠀⠀⠈⠙⣿⣿⣿
⣿⣻⣿⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⣴⣶⡴⣾⣿⣯⣭⣭⣿⣿⣿⣾⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣹⣿⣿⡿⠛⢻⣿⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠐⡄⠀⡿⠦⢼⣧⣤⡿⠇⢀⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠰⣦⣽⣯⣤⣼⣿⣿⡿⢛⠻⡟⢉⠛⡟⢩⠉⠣⠙⠛⠛⠉⠉⠛⠉⣽⣿⣿⣿⣿⣶⡄⠸⣿⣿⡟⠁⠀⠀⢀⣀⣀⠀⠀⠈⡇⠀⣴⣦⠀⢹⠿⣷⣶⠀⢹⣿⣿
⣿⣿⣿⣿⣿⣿⣿⡿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠈⠙⠉⢠⣿⡆⣿⣷⡽⠃⠁⠈⠃⠀⠀⠀⣀⣤⣄⠀⠀⠀⠀⠐⠛⠛⠻⠘⠿⠿⠓⠀⠛⠋⠀⠀⠀⢰⡏⠉⢹⡇⠀⠀⠈⠀⠘⠛⠀⠘⠀⠈⠋⣀⣼⣿⣿
⣿⣿⣿⣿⣿⣧⣛⣷⣽⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣆⠀⢀⣾⣿⠡⠿⠋⠀⣀⣀⣀⣀⣀⣀⣼⠉⠀⣿⣀⡀⠀⣀⣀⣀⣀⣀⡀⠀⣀⣀⣀⣀⣀⣀⣀⡀⢸⡇⠀⢸⡇⣀⣀⣀⣀⢀⣀⣀⣀⣀⡀⠀⠙⠿⠿⠿
⣿⣿⣿⣿⣿⣿⣿⣛⣿⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡶⠀⠀⡾⠉⠀⣀⣀⢸⣿⠀⠀⠀⠀⢸⣷⠞⠉⠀⠀⠀⠉⠻⣆⣿⠀⠀⠋⠀⠀⠈⢿⣼⡇⠀⢸⡿⠃⠀⣠⣿⠋⠁⢀⣀⠀⣿⠀⠀⢰⣾⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠀⣧⠀⠈⠛⠻⢿⡝⢻⠀⠀⣿⠛⡟⠀⠀⣾⠋⢷⠀⠀⣿⣿⠀⠀⣿⢻⡆⠀⢸⣿⡇⠀⠘⠁⠀⣴⠟⢿⡀⠀⠙⠛⢿⣏⠀⠀⠘⢻⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣮⡻⠿⢿⣿⣿⣿⠟⠋⢻⣿⣿⣿⣿⠛⠟⠀⠀⡼⢿⣶⡦⠀⠀⣿⣾⠀⠀⢿⣤⣧⠀⠀⠿⣤⠞⠀⠀⣿⣿⠀⠀⣿⢸⡇⠀⢸⣿⡇⠀⢰⣄⠀⠙⢷⣼⢿⣶⣦⠄⠀⢹⡆⠀⢀⣾⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠙⡿⠋⠀⠀⢸⣿⣿⣿⣷⣦⣄⠀⠀⣧⣀⣀⣀⣠⣴⠟⠸⣦⣀⣀⣸⡟⢦⣄⣀⣀⣀⣤⡾⠋⣿⣀⣀⣿⢸⣇⣀⣸⣿⣇⣀⣸⡿⣆⣀⣈⣻⣀⣀⣀⣀⣴⡿⠀⠀⣰⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣆⠀⠀⠠⢤⡀⢸⣿⣿⣿⣿⣿⣿⣷⣀⠈⠉⠉⠉⠉⠀⠀⠀⠈⠉⠉⠉⠁⠀⠈⠉⠉⠉⠁⠀⠀⠈⠉⠉⠁⠀⠉⠉⠉⠀⠉⠉⠉⠀⠈⠉⠉⠉⠉⠉⠉⠉⠀⠀⢀⣤⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣄⠀⢀⠿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣴⣶⣦⡀⠀⠀⠀⠀⠀⢀⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣄⣀⣀⣙⣛⣛⣛⣛
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡈⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡯⣧⢻⣿⢸⣧⢜⢿⣏⣿⡿⣱⡆⠠⣤⢂⣼⣿⣿⣿⣿⣿⣿⡿⢛⡻⢿⣿⣿⡿⠿⠿⢿⣿⣿⡿⠿⣿⣿⣿⡿⢿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣄⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡁⢿⢸⣿⢸⣊⢿⡟⡵⠟⠀⠀⣠⢿⣿⣧⣿⣿⣿⣿⣿⣷⣾⠗⢨⣿⣿⣷⣾⠿⢀⣿⡟⢠⠀⣿⣿⠏⡀⠀⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣿⢏⠦⠹⢿⢟⣵⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⠲⠛⢿⡛⢿⡛⢿⠆⢹⣀⣛⡀⢘⡏⠐⠓⠀⢻
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡝⢿⣿⣿⢫⣶⠶⡄⢦⣾⣿⣿⣿⣯⣭⣭⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣾⣿⣿⣿⣤⣽
         */

        public void NotStonks( out int NewBalance)
        {
            this.cardBalance -= 300;
            NewBalance = this.cardBalance;
        }

        /*
⣿⣿⣿⣿⣿⣿⣿⣿⡏⠘⠛⠛⣿⣿⣿⣿⣿⣿⣿⡿⠙⣿⣿⣿⣿⣿⣿⣿⠏⣲⠷⣯⣿⣿⣿⣿⣿⡿⣿⡻⠏⣛⣻⡍⣾⣿⣷⣦⣣⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⢿⢼⣿⢾⢽⢿⢛⣟⣿⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⡿⣰⡀⡀⠀⠈⠁⠀⠀⠀⠀⠁⠀⠄⠸⣿⣿⡟⢻⣿⣿⣿⣾⣿⢟⣻⣿⣿⣟⣻⣃⣯⣚⣶⣽⣶⣿⣿⣿⣿⡿⡛⣿⣿⣯⣆⢕⣸⣿⣿⣿⣿⣿⣿⣯⣼⣷⣿⣿⣿⣿⣿⣿⣿⡿⠟⣻⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⡟⡿⠟⣱⣿⡗⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⠛⢀⠸⣿⣿⣿⡿⠀⠈⠉⢹⣿⣿⣿⣿⡿⡻⠿⣛⢿⡍⣽⣿⣭⣍⣖⣟⣿⣿⣼⣶⣾⣿⣿⣿⣿⣿⣿⡿⣻⢿⣫⢝⣷⣶⣯⣿⢾⣷⣠⣿⣿⣿⡿⣿⠿⣟
⣿⣿⣿⡿⠀⠁⣸⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⢬⡄⢠⣿⠀⣿⣿⣿⢁⣷⣤⣆⠘⣿⣿⣿⠼⣟⣪⣹⣽⣤⣷⣿⣿⣿⣿⠿⣿⣿⡿⡟⡯⣿⣿⣿⣿⣿⣯⣽⣟⢶⣝⣟⣳⣿⣼⣿⣿⣾⣿⣿⢿⢻⠵⠏⣩⠘⠃
⣿⣿⣿⡇⡇⢀⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣄⠈⠛⠃⣾⣿⣿⣿⡀⢻⡿⠋⢻⣿⡻⡛⠛⢿⡍⣽⣿⣟⣳⠅⠮⣿⣇⣪⣗⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢿⡿⢛⡿⢿⢛⡍⠈⢸⠰⠒⡃⠴⠘⡁
⡿⠉⠉⢰⡇⢸⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⢠⣯⣿⣿⣿⣦⠀⣼⣿⣿⣿⣿⣇⠘⢀⣤⠀⢻⣿⣿⣣⣭⣿⣿⣿⣿⣿⣾⣿⢿⣿⢿⡟⣿⣿⣿⣿⣿⡿⡿⡏⣒⢼⡏⠃⠃⠉⠓⣰⠻⢶⢠⠸⠐⡃⡅⠐⠀⡁
⣱⣧⡀⣸⣿⣿⣿⣿⣿⡄⠀⠀⠀⡀⠀⠀⠀⠀⠀⠤⠀⣾⣯⣽⣧⣾⣿⣵⣻⣻⣿⣿⣿⣿⠀⠚⠋⠃⠀⠉⠙⠛⠛⠋⠉⣀⣀⠈⠒⠾⠛⠃⠈⠀⣀⡀⠙⠛⠛⠛⠛⠓⠉⠐⠃⠀⡖⢲⠀⠐⠈⠉⠀⠘⠈⡅⠆⢈⡀⠄
⣿⣿⣧⣿⣿⣿⣿⣿⣿⣧⠀⠀⠸⠙⣷⣤⣀⠀⠀⠀⣼⣿⣿⣿⡿⢿⣿⣿⣻⣿⣿⣿⣿⣿⠁⠐⠲⢒⠒⢄⡠⠒⣒⠲⣴⡃⢘⣲⠀⠀⡔⢒⡒⣞⠀⣓⣢⠖⣒⡒⢦⣰⠲⢒⠒⢄⡇⢸⡔⢒⡶⢒⡒⡆⠀⠄⠊⢈⡀⠔
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠈⠙⢻⣷⣶⣖⣿⡿⡭⣾⣷⣿⣿⣶⣿⣼⣭⣿⣿⣿⠀⠀⢰⠉⡇⢸⡃⢌⠈⡇⢸⡇⢸⠀⠀⠀⢧⣉⠛⣽⠀⡏⠉⢰⠁⢹⠀⣿⢰⠉⡇⢸⡇⢈⠰⡍⠣⣈⠛⢇⠀⠂⣉⣠⡤⠖
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣤⡀⠀⠀⠀⠈⠻⣿⣿⣿⣿⣿⢿⡿⣿⣿⢿⢝⣻⣿⣙⣿⣿⠀⢠⣸⠀⢇⡸⠣⣌⣉⡠⠊⠣⣈⣹⠀⠀⢍⣉⡡⠟⢄⣉⡽⢤⣉⣡⠜⢹⣸⠀⢇⡸⢇⡸⠣⣈⣯⣉⣡⠎⠀⣉⣩⠠⠆⠒
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣵⣾⣶⣶⣿⣿⣧⣤⣤⣤⣤⣤⣤⣄⣀⣤⣤⣤⣀⠀⠀⣀⣀⡀⣀⣀⢀⣀⣀⣀⣀⣀⡤⠀⠄⣠⣀⣀⡀⣀⢀⠀⢀⢀⠀⣀⡄⣥⠰⠠⠆⠚
⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡀⠀⠢⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⢽⠯⠯⣯⣽⣿⣿⣿⣻⡐⣿⣻⣻⣿⣿⣿⣿⣿⣯⡥⠀⠹⣿⡇⣾⣟⣾⣿⣿⣿⣿⣿⣷⣟⣟⣽⣏⣍⣷⣶⣨⣺⣠⣹⣥⡅⡆⠶⠸⠀⡃⢘
⡏⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣽⣷⣶⣷⣿⣿⣿⣿⣿⣶⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⡿⠿⡿⠿⠿⢿⠼⠾⠶⠖⡗⢛⢘⡋⣋⣈
⣿⠙⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡯⣻⣯⣏⣿⣿⣿⣟⣛⠃⣿⡪⣒⣿⣿⣿⣿⣿⣿⣿⣅⣧⡀⠘⣿⡥⣿⣿⣿⣿⣿⣿⣿⣿⣗⢾⡷⡗⡷⣿⢲⢞⠾⣇⡀⣀⣏⣹⣹⣉⣯⣈
⣿⠐⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣶⣶⣾⣿⣿⣿⣿⣷⣶⣾⣶⣾⣾⣿⣿⣿⣿⣿⣷⣷⣶⡀⠘⢾⣾⣿⣿⣿⣿⣿⣿⣿⣿⣶⣷⣶⣿⣶⣷⣿⣶⣯⣧⣧⣯⣽⣬⣅⣭⣨
⣿⡧⠺⣿⣿⣿⣿⣿⡿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣡⢵⢽⣿⣿⣟⣛⣖⣿⡪⢉⡭⣫⡍⣿⣿⣿⣿⣿⣿⣿⣷⡀⠈⢿⠿⣿⣿⣿⣿⣿⣯⣭⣹⣟⣍⣛⣽⠛⢻⢟⡟⠗⠷⣿⣾⣼⣧⣽⣬
⣿⣷⠀⢙⣿⣿⣿⣿⣿⣄⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣶⣾⣾⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠈⢠⠹⣿⣿⣿⣿⣾⣇⣟⣿⣒⣏⠶⠿⣧⠟⣿⣄⣾⣿⣾⡷⡷⣾⣤
⣿⣿⣆⠘⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡍⠙⠻⢿⣿⣿⣿⣿⣷⣹⣿⣿⣟⣻⠂⡿⠍⡭⣛⢿⡛⣻⣿⣿⣿⣿⣿⣿⣿⣿⣟⡀⠀⠂⠘⠟⣿⣿⣿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⣿⣿⢾⡦
⣿⣿⣿⣧⡨⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⢈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣿⣷⣭⣵⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⡯⢶⡄⠀⠀⠀⢸⣿⣻⢙⢹⡟⢴⣼⣶⣉⡹⣫⣟⠛⢛⣿⣿⣟⣿⢻⡷
⣿⣿⣿⣷⣿⠙⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⢝⣿⢝⢍⡛⢿⡿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣟⠋⠉⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣼⣭⣿⣷⣭⣿⣧⣾⣿⣿⣏⣻⠻⠷
⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣷⣽⣭⣷⣭⣧⣿⣿⣿⣿⣿⣿⣿⣿⣿⡷⣶⣄⠀⠀⠀⢸⣿⣿⢻⣿⣿⣛⢿⣿⣿⣿⣿⣿⣿⣿⣻⠶⣇⣛⠙⠷
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣛⠛⠛⠛⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣻⣻⣿⢝⡟⠿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣿⣿⣿⣷⣄⠀⠀⣿⣿⣴⣸⣟⠿⢺⣭⣷⠾⣵⣷⠉⢉⣻⠓⠇⠈⠀⠂
⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⣯⣽⣶⣫⣚⣇⣾⣿⣿⣻⣟⣷⢎⣿⡯⣫⣿⣿⣿⣿⣿⣦⣿⣿⣿⣿⣿⣿⣿⣶⣷⣿⣦⣿⣷⢾⠉⠁⠀⠀⠀⠀
         */
        public void info()
        {
            Info();
        }

        public override bool Equals(object obj)
        {
            if (obj is Customer customer)
            {
                return customer.adress == this.adress && customer.cardBalance == this.cardBalance &&
                customer.cardNumber == this.cardNumber && customer.fatherName == this.fatherName &&
                customer.firstName == this.firstName && customer.secondName == this.secondName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Customer.Counter * Customer.Counter + Customer.Counter / 2;
        }

        public override string ToString()
        {
            info();
            Console.WriteLine($"Объект: {this.Id}");
            Console.WriteLine($"Имя: {this.firstName}");
            Console.WriteLine($"Фамилия {this.secondName}");
            Console.WriteLine($"Отчество: {this.fatherName}");
            Console.WriteLine($"Адрес: {this.adress}");
            Console.WriteLine($"Номер карты: {this.cardNumber}");
            Console.WriteLine($"Счет на карте: {this.cardBalance}");
            return this.firstName;
        }


    }
}




