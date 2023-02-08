using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns.DecoratorPattern
{
    class Decorator
    {
        private AdapterPattern.Adapter lib;

        public Decorator(AdapterPattern.Adapter adapter)
        {
            lib = adapter;
        }

        private string ToStringHeader()
        {
            return "-----------------LIB---------------------";
        }

        private string ToStringFooter()
        {
            return "-----------------------------------------";
        }

        public override string ToString()
        {
            string books = "\n";
            foreach (var book in lib.library._collectionBooks)
            {
                books += book.Name + "\n";
            }
            return ToStringHeader() + $"\nНазвание:{lib.Name}\nБиблиотекарь: {lib.library.librarist.Name}\nКниги: {books}" + ToStringFooter();
        }

    }
}
