using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns
{
    public interface ILibraryBuilder
    {
        void BuildLibraryst(Librarist librarist);

        void BuildCollectionBooks(List<Book> books);

        Library GetLibrary();
    }
}
