using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace OOP_Lab_9
{
    public interface IAddRemove<T>
    {
        public void Add(T item);
        public void Remove(int index);
        public void Browse(int index);
    }

    public partial class list<T> : IEnumerable, IAddRemove<T> where T : notnull
    {
        private List<T> _items = new List<T>();
        public int Count => _items.Count;//

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _items.Add(item);
        }

        public void Remove(int index)
        {
            if (index > Count)
            {
                throw new KeyNotFoundException("Нет элемента с таким индексом");
            }
            _items.RemoveAt(index);
        }

        public void Browse(int index)
        {
            if (index > Count)
            {
                throw new System.NullReferenceException("Нет элемента с таким индексом");
            }
            Console.WriteLine($"Элемент с индексом {index}: {_items[index]}");
        }

        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public static void Item_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is T newItem)
                        Console.WriteLine($"Добавлен новый объект: {newItem}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is T oldItem)
                        Console.WriteLine($"Удален объект: {oldItem}");
                    break;
                
            }
        }

        public static void print(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Что-то происходит...");
        }
    }
}
    

