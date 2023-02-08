using System;
using System.Collections.Generic;
using System.Text;

namespace ООП_лаб_4_5
{
    public sealed class Cactus : Flower
    {
        private string Name;
        private string Color;
        private bool Alive;
        private uint Age;
        private uint NumberOfPetals;
        private uint Cost;

        public override string name
        {
            get => Name;
            set => Name = value;
        }
        public override string color
        {
            get => color;
            set => Color = value;
        }
        public override bool alive
        {
            get => Alive;
            set
            {
                if (value == true)
                {
                    Alive = true;
                }
                else
                {
                    Alive = false;
                    Color = "серый";
                }
            }
        }
        public override uint age
        {
            get => Age;
            set => Age = value;
        }
        public override uint numberOfPetals
        {
            get => NumberOfPetals;
            set => NumberOfPetals = value;
        }
        public override uint cost
        {
            get => Cost;
            set => Cost = value;
        }

        public override void Info()
        {
            Console.Write($"Имя: {Name}\nЦвет: {Color}\nСтоимость: {Cost}\nЖивой: {Alive}\nВозраст: {Age}\nКоличество лепестков: {NumberOfPetals}\nЦветение: ");
            Blomming();
            Console.Write('\n');
        }

        public override void Blomming()
        {
            Console.WriteLine("пунь-пунь");
        }

        public override string ToString()
        {
            Info();
            Console.WriteLine(GetType().Name);
            return GetType().Name;
        }

        public Cactus(string name, uint age = 0, bool alive = true, string color = "белый", uint cost = 0)
        {
            NumberOfPetals = 44;
            Name = name;
            Age = age;
            Cost = cost;
            if (Age < 10)
            {
                Alive = alive;
                Color = color;
            }
            else if(Age < 20)
            {
                Alive = false;
                Color = "серый";
            }
            else
            {
                throw new ExceptionAge("Слишком большой возраст кактуса. Он уже рассыпался", Age);
            }

        }
    }
}
