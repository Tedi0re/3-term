using System;
using System.Collections.Generic;
using System.Text;

namespace ООП_лаб_4_5
{
    public class Bush : Plant
    {
        private string Name;
        private string Color;
        private bool Alive;
        private uint Age;

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
                if(value == true)
                {
                    Alive = true;
                }
                else
                {
                    Alive = false;
                    Color = "желтый";
                }
            }
        }
        public override uint age
        {
            get => Age;
            set => Age = value;
        }

        public override void Info()
        {
            Console.WriteLine($"Имя: {Name}\nЦвет: {Color}\nЖивой: {Alive}\nВозраст: {Age}");
        }

        public override string ToString()
        {
            Info();
            Console.WriteLine(GetType().Name);
            return GetType().Name;
        }

        public Bush(string name, uint age = 0, bool alive = true, string color = "зеленый")
        {
            Name = name;
            Age = age;
            if(Age < 30)
            {
                Alive = alive;
                Color = color;
            }
            else if(Age < 50)
            {
                Alive = false;
                Color = "желтый";
            } 
            else
            {
                throw new ExceptionAge("Слишком большой возраст куста. Он уже рассыпался", Age);
            }
        }
    }
}
