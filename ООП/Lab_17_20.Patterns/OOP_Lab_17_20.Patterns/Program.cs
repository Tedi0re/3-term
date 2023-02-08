using System;
using System.Collections.Generic;
using OOP_Lab_17_20.Patterns.Factories;
using OOP_Lab_17_20.Patterns.SingletonPattern;
using OOP_Lab_17_20.Patterns.PrototypePattern;
using OOP_Lab_17_20.Patterns.AdapterPattern;
using OOP_Lab_17_20.Patterns.DecoratorPattern;
using OOP_Lab_17_20.Patterns.StatePattern;

namespace OOP_Lab_17_20.Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader("Andrey", status: Status.SeasonTicket);
            LibraryBuilder libraryBuilder = new LibraryBuilder();
            List<Book> books = new List<Book>();
            books.Add(new Book("1"));
            books.Add(new Book("2"));
            books.Add(new Book("3"));
            books.Add(new Book("6"));
            books.Add(new Book("19"));
            books.Add(new Book("27"));
            libraryBuilder.BuildCollectionBooks(books);
            libraryBuilder.BuildLibraryst();
            Library library = libraryBuilder.GetLibrary();
            reader.SearchBook(library, new Book("1"));

            FactoryLibraryA factoryA= new FactoryLibraryA();
            FactoryLibraryB factoryB= new FactoryLibraryB();

            Library libraryA = factoryA.CreateLibrary();
            Adapter libraryB = factoryB.CreateLibraryWithName();

            Console.WriteLine(libraryA.ToString());
            Console.WriteLine(libraryB.ToString());

            Console.ReadKey();
            Console.Clear();

            Singleton singleton = Singleton.Initialize("Hello, World!");
            Console.WriteLine(singleton.message);
            Singleton singleton1 = Singleton.Initialize("Goodbye, World!");
            Console.WriteLine(singleton1.message);

            Prototype prototypeLib = new Prototype(library);

            Library library1 = prototypeLib.CloneLibrary();

            library1._collectionBooks.Clear();

            Console.WriteLine(library.ToString());
            Console.WriteLine(library1.ToString());
            Console.WriteLine("КОНЕЦ ЛАБЫ!");
            Console.ReadKey();
            Console.Clear();
            //Lab_19_20

            Adapter LibWithName = new Adapter(library," БГТУ");
            Console.WriteLine(LibWithName.ToString());

            Decorator decoratorLib = new Decorator(LibWithName);
            Console.WriteLine(decoratorLib.ToString());

            Welcome welcome = new Welcome();
            Hello hello = new Hello();
            Hi hi = new Hi();
            library.GetMessage(welcome);
            library.PrintMessage();
            library.GetMessage(hello);
            library.PrintMessage();
            library.GetMessage(hi);
            library.PrintMessage();
            library.GetMessage(null);
            library.PrintMessage();

            Context context1 = new Context();
            Console.WriteLine(context1.Start(library));
            Console.WriteLine(context1.Start(library));
            Console.WriteLine(context1.Start(LibWithName));
            Console.WriteLine(context1.Start(LibWithName));
            Console.WriteLine(context1.Start(library));

            List<Book> booksMemento = new List<Book>();
            booksMemento.Add(new Book("1"));
            booksMemento.Add(new Book("2"));
            booksMemento.Add(new Book("3"));
            booksMemento.Add(new Book("4"));
            libraryBuilder.BuildCollectionBooks(booksMemento);
            libraryBuilder.BuildLibraryst();
            Library libraryMemento = libraryBuilder.GetLibrary();

            Console.WriteLine(libraryMemento.ToString());
            LibHistory history = new LibHistory();
            history.History.Push(libraryMemento.SaveLib());
            libraryMemento.LoseBook();
            libraryMemento.LoseBook();
            libraryMemento.LoseBook();
            libraryMemento.LoseBook();
            libraryMemento.LoseBook();
            Console.WriteLine(libraryMemento.ToString());
            libraryMemento.RestoreLib(history.History.Pop());
            Console.WriteLine(libraryMemento.ToString());
        }
    }
}
