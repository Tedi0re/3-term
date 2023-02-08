using System;
using System.Collections.Generic;
using System.Text;

namespace Когтрольная2
{
    class SuperList<T> : List<T> where T:class
    {
        public List<T> l;

        public static bool operator +(SuperList<T> list,T element)
        {
            if (element == null) return false;
            if (list.l.Count > 5)  throw new IndexOutOfRangeException();
            list.l.Add(element);
            return true;
        }

        public SuperList()
        {
            l = new List<T>();
        }
    }
}
