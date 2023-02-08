using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OOP_Lab_17_20.Patterns
{
    public enum Status
    {
        ReadingRoom,
        SeasonTicket
    }
    public class Reader
    {
        public string Name;
        public Book book;
        public Status status;

        public bool SearchBook(Library library, Book book)
        {
            foreach (var bookLibrary in library._collectionBooks)
            {
                if (bookLibrary.Name == book.Name)
                {
                    Console.WriteLine($"Книга {book.Name} найдена") ;
                    Console.WriteLine("Хотите заказать книгу?(0 1)");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            OrderBook(library, book, status);
                            return true;
                        default:
                            return true;
                    }


                }
            }
            Console.WriteLine($"Книга {book.Name} отсутствует в каталоге");
            return false;
        }

        public Book OrderBook(Library library,Book book, Status status)
        {
            this.book = book;
            return library.librarist.GetBook(library, book, status);
        }

        public Reader(string name, Book book = null, Status status = 0)
        {
            Name = name;
            this.book = book;
            this.status = status;
        }
    }

    public class Librarist
    {
        public string Name;
        public Librarist(string name)
        {
            Name = name;
        }
        public Book GetBook(Library library, Book book, Status status)
        {
            library._collectionBooks.Remove(book);
            if (status == 0) Console.WriteLine("Книга выдана на читальный зал");
            else Console.WriteLine("Книга выдана на абонемент");
            return book;
                  
        }
    }
}
