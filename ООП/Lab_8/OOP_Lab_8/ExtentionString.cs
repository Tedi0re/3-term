using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OOP_Lab_8
{
    public static class ExtentionString
    {
        //func
        public static string EndPoint(string str)
        {
            Console.WriteLine(str + ".");
            return str+ ".";
        }
        public static string UpSymbols(string str)
        {
            Console.WriteLine(str.ToUpper());
            return str.ToUpper();
        }

        public static string Reverse(string str)
        {
            Console.WriteLine(str.ToCharArray().Reverse().ToArray());
            return  new string( str.ToCharArray().Reverse().ToArray());
        }

        public static string DoubleString(string str)
        {
            Console.WriteLine(str + str);
            return str + str;
        }
        public static string Print(string str)
        {
            Console.WriteLine(str);
            return str;
        }
        //action
        public static void RedString( string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public static void GreenString(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public static void BlueString( string str)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        //predicate
        public static bool HavePoints(string str)
        {
            if (str.Contains('.'))
            {
                Console.WriteLine("true");
                return true;
            }      
            else
            {
                Console.WriteLine("false");
                return false;
            }
               
        }
        public static bool NullOrEmpty(string str)
        {
            if (str == null || str == "")
            {
                Console.WriteLine("true");
                return true;
            }
            else
            {
                Console.WriteLine("false");
                return false;
            }
        }
        //delegates
    }

}
