using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ООП_лаб_4_5
{
    class Bouquet: IInfo, IEnumerable
    {
        public List<Flower> _flowers = new List<Flower>();
        public uint CostOfBouquet;
        public uint NumberOfFlowers;

        public void Add(Flower obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                _flowers.Add(obj);
                NumberOfFlowers++;
                CostOfBouquet += obj.cost;
            }
        }

        public void Delete(Flower obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                if(_flowers.Contains(obj))
                {
                    _flowers.Remove(obj);
                    NumberOfFlowers--;
                    CostOfBouquet -= obj.cost;
                }
                else
                {
                    Console.WriteLine($"Элемент {obj} не найден");
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _flowers.GetEnumerator();
        }

        public void Info()
        {
            Console.WriteLine("------------------информация-------------------");
            Console.WriteLine($"Стоимость букета: {CostOfBouquet}");
            Console.WriteLine($"Количество цветов в букете: {NumberOfFlowers}");
            Console.WriteLine("Все цветы, входящие в букет:");
            foreach (var item in _flowers)
            {
                Console.WriteLine("---");
                Console.WriteLine($"Тип: {item.GetType()}");
                Console.WriteLine(item.name);
            }
        }

        public Bouquet()
        {
            NumberOfFlowers = 0;
            CostOfBouquet = 0;
        }
    }
}
