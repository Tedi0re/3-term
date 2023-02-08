using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns.AdapterPattern
{
    public interface IName
    {
        string Name { get; }

        void SetName(string NewName);
    }
    public class Adapter : IName
    {
        public Library library;
        private string _name;

        public string Name => _name;
        
        public void SetName(string NewName) => this._name = NewName;

        public Adapter(Library library, string Name)
        {
            this._name = Name;
            this.library = library;
        }

        public override string ToString()
        {
            string books = "\n";
            foreach (var book in library._collectionBooks)
            {
                books += book.Name + "\n";
            }
            return  $"Название:{_name}\nБиблиотекарь: {library.librarist.Name}\nКниги: {books}";
        }
    }
}
