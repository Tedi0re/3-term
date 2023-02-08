using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns
{
    public partial class  Library
    {
        public void LoseBook()
        {
            if(_collectionBooks.Count > 0)
            {
                Console.WriteLine($"Книга {_collectionBooks[0].Name} утеряна");
                _collectionBooks.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("Все книги в библиотеке утеряны!");
            }
        }

        public LibMemento SaveLib()
        {
            Console.WriteLine($"Сохранение библиотеки");
            List<Book> books = new List<Book>();
            foreach (var book in _collectionBooks)
            {
                books.Add(new Book(book.Name));
            }
            return new LibMemento(books);
        }

        public void RestoreLib(LibMemento memento)
        {
            List<Book> books = new List<Book>();
            foreach (var book in memento.Books)
            {
                books.Add(new Book(book.Name));
            }
            this._collectionBooks = books;
            Console.WriteLine($"Восстановление библиотеки");
        }
    }

    public class LibMemento
    {
        public List<Book> Books { get; private set; }
        

        public LibMemento(List<Book> books)
        {
            this.Books = books;
        }
    }

    public class LibHistory
    {
        public Stack<LibMemento> History { get; private set; }
        public LibHistory()
        {
            History = new Stack<LibMemento>();
        }
    }
}
