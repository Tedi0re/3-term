using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns
{
     public partial class Library
    {
        public Librarist librarist;

        public List<Book> _collectionBooks;

        public Library()
        {
            librarist = new Librarist("1");
            _collectionBooks = new List<Book>();
        }

        public override string ToString()
        {
            string books = "\n";
            foreach (var book in _collectionBooks)
            {
                books += book.Name + "\n";
            }
            return $"Библиотекарь: {librarist.Name}\nКниги: {books}";
        }
    }
}
