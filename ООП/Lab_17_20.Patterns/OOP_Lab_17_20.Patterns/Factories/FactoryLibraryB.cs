using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns.Factories
{
    public class FactoryLibraryB : LibraryAbstactFactory
    {
        public Library CreateLibrary()
        {
            Librarist Librarist = new Librarist("B");
            Library Library = new Library();
            List<Book> books = new List<Book>();
            books.Add(new Book("B1"));
            books.Add(new Book("B2"));
            books.Add(new Book("B3"));
            books.Add(new Book("B4"));

            Library.librarist = Librarist;
            Library._collectionBooks = books;

            return Library;
        }

        public AdapterPattern.Adapter CreateLibraryWithName()
        {
            Librarist Librarist = new Librarist("B");
            string Name = "B";
            Library Library = new Library();
            List<Book> books = new List<Book>();

            books.Add(new Book("B1"));
            books.Add(new Book("B2"));
            books.Add(new Book("B3"));
            books.Add(new Book("B4"));

            Library.librarist = Librarist;
            Library._collectionBooks = books;
            AdapterPattern.Adapter adapter = new AdapterPattern.Adapter(Library, Name);

            return adapter;
        }
    }
}
