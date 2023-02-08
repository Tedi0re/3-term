using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns.Factories
{
    public class FactoryLibraryA : LibraryAbstactFactory
    {
        public Library CreateLibrary()
        {
            Librarist Librarist = new Librarist("A");
            Library Library = new Library();
            List<Book> books = new List<Book>();
            books.Add(new Book("A1"));
            books.Add(new Book("A2"));
            books.Add(new Book("A3"));
            books.Add(new Book("A4"));

            Library.librarist = Librarist;
            Library._collectionBooks = books;

            return Library;
        }

        public AdapterPattern.Adapter CreateLibraryWithName()
        {
            Librarist Librarist = new Librarist("A");
            string Name = "A";
            Library Library = new Library();
            List<Book> books = new List<Book>();
            
            books.Add(new Book("A1"));
            books.Add(new Book("A2"));
            books.Add(new Book("A3"));
            books.Add(new Book("A4"));

            Library.librarist = Librarist;
            Library._collectionBooks = books;
            AdapterPattern.Adapter adapter = new AdapterPattern.Adapter(Library, Name);

            return adapter;
        }

        
    }
}
