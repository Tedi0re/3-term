using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns
{
    public interface IMessage
    {
        void PrintMessage();
    }


    class Welcome : IMessage
    {
        void IMessage.PrintMessage()
        {
            Console.WriteLine("Добро пожаловать!");
        }
    }

    class Hello : IMessage
    {
        void IMessage.PrintMessage()
        {
            Console.WriteLine("Привет!");
        }
    }

    class Hi: IMessage
    {
        void IMessage.PrintMessage()
        {
            Console.WriteLine("Здарова");
        }
    }
}
