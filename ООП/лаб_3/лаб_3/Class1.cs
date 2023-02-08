using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace лаб_3_7
{
    public interface IAddRemove<T>
    {
        public void Add(T item);
        public void Remove(T item);
        public void Browse(int index);
    }

    public partial class Set<T> : IEnumerable, IAddRemove<T> where T: notnull
    {
        private List<T> _items = new List<T>();
        public int Count => _items.Count;//

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }

        public void Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (!_items.Contains(item))
            {
                throw new KeyNotFoundException($"Элемент {item} не найден в множестве.");
            }
            _items.Remove(item);
        }

        public void Browse(int index)
        {
            if (index > Count)
            {
                throw new System.NullReferenceException("Нет элемента с таким индексом");
            }
            Console.WriteLine($"Элемент с индексом {index}: {_items[index]}");
        }

        private static Set<T> Intersection(Set<T> set1, Set<T> set2)
        {
            if(set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }
            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }

            var resultSet = new Set<T>();

            if (set1.Count < set2.Count)
            {
                foreach(var item in set1._items)
                {
                    if (set2._items.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in set2._items)
                {
                    if (set1._items.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }

            return resultSet;
        }

        private static bool Comparison(Set<T> set1, Set<T> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }
            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }

            bool result = set1._items.All(s => set2._items.Contains(s));
            if (set1.Count != set2.Count)
            {
                result = false;
            }
            return result;
        }

        private static bool Subset(Set<T> set1, Set<T> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }
            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }

            bool result = set1._items.All(s => set2._items.Contains(s));
            return result;
        }

        private static Set<T> Union(Set<T> set1, Set<T> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }
            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }

            var resultSet = new Set<T>();
            var items = new List<T>();

            if(set1._items != null && set1._items.Count > 0)
            {
                items.AddRange(new List<T>(set1._items));
            }

            if (set2._items != null && set2._items.Count > 0)
            {
                items.AddRange(new List<T>(set2._items));
            }

            resultSet._items = items.Distinct().ToList();

            return resultSet;
        }

        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }

    public partial class Set<T>
    {
        public static Set<T> operator -(Set<T> set, T item)
        {
            set.Remove(item);
            return set;
        }

        public static Set<T> operator *(Set<T> set1, Set<T> set2)
        {
            return Intersection(set1, set2);
        }

        public static bool operator <(Set<T> set1, Set<T> set2)
        {
            return Comparison(set1, set2);
        }

        public static bool operator >(Set<T> set1, Set<T>set2)
        {
            return Subset(set1, set2);
        }

        public static Set<T> operator &(Set<T> set1, Set<T> set2)
        {
            return Union(set1, set2);
        }
    }

    public partial class Set<T>
    {
        public class Production
        {
            static string nameOrganization = "BSTU";
            int id;
            static int counter;

            static Production()
            {
                counter = 0;
            }

            public Production()
            {
                counter++;
                id = counter;
            }

            public override string ToString()
            {
                return nameOrganization;
            }
        }

        public class Developer
        {
            static string nameDeveloper = "Andrey";
            int id;
            static int counter;

            static Developer()
            {
                counter = 0;
            }

            public Developer()
            {
                counter++;
                id = counter;
            }

            public override string ToString()
            {
                return nameDeveloper;
            }
        }

        public static class StaticOperation
        {
            public static void Point(ref Set<string> set)
            {
                for (int i = 0; i < set._items.Count; i++)
                {
                    set._items[i] += ".";
                }
            }

            public static void DeleteNullElements(ref Set<string> set)
            {
                for (int i = 0; i < set._items.Count; i++)
                {
                    if(set._items[i] == "0")
                    {
                        set._items[i].Remove(i);
                        i--;
                    }
                }
            }
        }


    }
}