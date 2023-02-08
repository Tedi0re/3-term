using System;
using System.Collections.Generic;
using System.Text;

namespace AiSD_Lab_8.Backpack
{
    class Item
    {
        public readonly string Name;
        public readonly uint Size;
        public readonly uint Cost;

        public Item(string name = "",uint size = 0, uint cost = 0)
        {
            Name = name;
            Size = size;
            Cost = cost;
        }
    }

    class Backpack
    {
        public readonly uint Size;
        public List<Item> Items;

        public Backpack(uint size, List<Item> items)
        {
            Size = size;
            Items = MaxItems(items);
        }

        public List<Item> MaxItems(List<Item> items)
        {
            List<Item>[,] backpacks = new List<Item>[items.Count + 1, Size + 1];

            //проходим по вещам
            for (int i = 0; i <= items.Count; i++)
            {
                //проходим по рюкзакам
                for (int j = 0; j <= Size; j++)
                {
                    if (i == 0 || j == 0) backpacks[i, j] = new List<Item>() { new Item()};//если элемент-пустышка
                    else
                    {
                        backpacks[i, j] = new List<Item>() { new Item() };
                        if (items[i - 1].Size > j)//если предмет больше размера рюкзака
                        {
                            backpacks[i, j] = backpacks[i - 1, j];
                        }
                        else
                        {
                            //
                            var prev = backpacks[i - 1, j].SumCost();
                            var prevMax = backpacks[i - 1, j - items[i - 1].Size].SumCost() + items[i - 1].Cost;

                            var max = Math.Max(prev, prevMax);
                            if(max == prev)
                            {
                                backpacks[i, j] = backpacks[i - 1, j];
                            }
                            else
                            {
                                backpacks[i, j] = new List<Item>(backpacks[i - 1, j - items[i - 1].Size]);
                                backpacks[i, j].Add(items[i - 1]);
                            }
                        }
                    }
                }
            }
            for (int i = 0;  i <= items.Count; i++)
            {
                for (int j = 0; j <= Size; j++)
                {
                    Console.Write(backpacks[i,j].SumCost() + "\t");
                }
                Console.WriteLine();
            }
            return backpacks[items.Count, Size];
        }

        public void Print()
        {
            Console.WriteLine($"Вместимость рюкзака: {Size}");
            Console.WriteLine("Предметы:");
            uint CostSum = 0;
            uint SizeSum = 0;
            foreach (Item item in Items)
            {
                if (item.Name == "") continue;
                Console.WriteLine($"{item.Name}\nРазмер {item.Size}\nСтоимость {item.Cost}");
                Console.WriteLine("-------------------------------------");
                CostSum += item.Cost;
                SizeSum += item.Size;
            }
            Console.WriteLine($"Всего занято в рюкзаке: {SizeSum}");
            Console.WriteLine($"Сумма стоимости предметов: {CostSum}");
        }
    }
}
