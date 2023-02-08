using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ООП_лаб_4_5
{
    public class Paper : Plant
    {
        private string Name;
        private string Color;
        private bool Alive;
        private uint Age;
        private string Material;

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
                Console.WriteLine("Бумагу нельзя воскресить(");
            }
        }
        public override uint age
        {
            get => Age;
            set => Age = value;
        }

        public string material
        {
            get => material;
        }

        public override void Info()
        {
            Console.WriteLine($"Имя: {Name}\nЦвет: {Color}\nМатериал: {Material}\nВозраст растения, из которого изготовлена бумага: {Age}");
        }

        public override string ToString()
        {
            Info();
            Console.WriteLine(GetType().Name);
            return GetType().Name;
        }

        public Paper(string name, string material, uint age = 0, string color = "белый")
        {
            Name = name;
            Material = material;
            Debug.Assert(age > 5, "Бумага не может быть из дерева, младше 5 лет");
            Age = age;
            Color = color;
            Alive = false;  
        }
    }
}
