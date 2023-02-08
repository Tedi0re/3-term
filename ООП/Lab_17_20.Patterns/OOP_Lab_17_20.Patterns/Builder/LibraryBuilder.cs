using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns
{
    public class LibraryBuilder : ILibraryBuilder
    {
        private Library library = new Library();

        public void BuildLibraryst(Librarist librarist = null)
        {
            if (librarist == null)
                library.librarist = new Librarist("Librarist");
            else
                library.librarist = new Librarist(librarist.Name);
        }

        public void BuildCollectionBooks(List<Book> books)
        {
            library._collectionBooks = new List<Book>();
            foreach (var book in books)
            {
                library._collectionBooks.Add(new Book(book.Name));
            }
        }

        public Library GetLibrary()
        {
            return library;
        }
    }
}
