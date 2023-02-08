using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns
{
    public partial class Library
    {
        private IMessage message;

        public void PrintMessage()
        {
            if (message == null) Console.WriteLine("Закрыто до понедельника");
            else message.PrintMessage();
        }

        public void GetMessage(IMessage message)
        {
            this.message = message;
        }
    }
}
