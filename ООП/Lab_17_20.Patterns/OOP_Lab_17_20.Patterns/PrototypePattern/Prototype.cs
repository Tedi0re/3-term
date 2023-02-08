using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns.PrototypePattern
{
    class Prototype
    {
        private Library libraryClone;

        public Prototype(Library libraryIn)
        {
            
            Librarist librarist = new Librarist(libraryIn.librarist.Name);
            List<Book> Books = new List<Book>();
            for (int i = 0; i < libraryIn._collectionBooks.Count; i++)
            {
                Books.Add(new Book(libraryIn._collectionBooks[i].Name));
            }

            LibraryBuilder libraryBuilder = new LibraryBuilder();
            libraryBuilder.BuildCollectionBooks(Books);
            libraryBuilder.BuildLibraryst(librarist);
            libraryClone = libraryBuilder.GetLibrary();
        }


        public Library CloneLibrary()
        {
            return libraryClone;
        }
    }
}
