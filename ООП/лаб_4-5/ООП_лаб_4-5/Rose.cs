using System;
using System.Collections.Generic;
using System.Text;

namespace ООП_лаб_4_5
{
    [Serializable]
    sealed public class Rose : Flower,IInfo
    {
        public string Name;
        
        public string Color;
        public bool Alive;
        public uint Age;
        public uint NumberOfPetals;
        [NonSerialized]
        public uint Cost;
        
        public override string name
        {
            get => Name;
            set => Name = value;
        }
        public override string color
        {
            get => Color;
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

        public override string ToString()
        {
            return Name;
        }

        public void info(IInfo iinfo)
        {
            iinfo.Info();
        }
        void IInfo.Info() => Console.WriteLine("Это роза");

        public override void Blomming()
        {
            Console.WriteLine("шр-шр-шр");
        }

        public Rose(string name, uint age = 0, bool alive = true, string color = "красный", uint cost = 1)
        {
            NumberOfPetals = 10;
            Name = name;
            Age = age;
            if(cost < 1 || cost > 10000)
            {
                throw new ExceptionCost("Роза не может стоить столько", cost);
            }
            else
            {
                Cost = cost;
            }
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
                throw new ExceptionAge("Слишком большой возраст розы. Она уже рассыпалась", Age);
            }
            
        }

        public Rose()
        {

        }
        
    }
}
