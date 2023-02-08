using System;
using System.Collections.Generic;
using System.Text;

namespace ООП_лаб_4_5
{
    public interface IInfo
    {
        void Info();
    }

    [Serializable]
    public abstract class Plant
    {
        public abstract string name { get; set; }
        public abstract string color { get; set; }
        public abstract bool alive { get; set; } 
        public abstract uint age { get; set; }

        public abstract void Info();

    }

    

    public class A
    { 
        public A()
        {

        }
    }

    public class B : A
    { 
       
        public B() : base()
        {
   
        }
    }

    enum ColorFlowers
    {
        Red,
        Gray,
        Purple,
        Green,
        White,
        Blue,
        Yellow
    }

    struct Struct
    {
        public int FirstElement;
        string SecondElement;
    }
}
