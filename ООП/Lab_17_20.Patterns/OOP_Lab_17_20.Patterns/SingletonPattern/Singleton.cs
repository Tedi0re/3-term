using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_17_20.Patterns.SingletonPattern
{
    public class Singleton
    {
        private static Singleton single = null;
        public string message;

        private Singleton(string message)
        {
            this.message = message;
        }

        private Singleton() { }

        public static Singleton Initialize(string message)
        {
            if (single == null)
                single = new Singleton(message);
            return single;

        }
    }
}
