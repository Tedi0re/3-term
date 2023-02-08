using System;
using System.Collections.Generic;
using System.Text;

namespace AiSD_Lab_8.Backpack
{
    static class Extentions
    {
        public static uint SumSize(this List<Item> items)
        {
            uint sum = 0;
            foreach (var item in items)
            {
                sum += item.Size;
            }
            return sum;
        }

        public static uint SumCost(this List<Item> items)
        {
            uint sum = 0;
            foreach (var item in items)
            {
                sum += item.Cost;
            }
            return sum;
        }
    }
}
