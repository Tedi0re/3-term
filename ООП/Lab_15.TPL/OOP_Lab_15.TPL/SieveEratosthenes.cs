using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OOP_Lab_15.TPL
{
    class SieveEratosthenes
    {
        readonly int MaxNumber;
        private List<int> PrimeNumbers;

        public SieveEratosthenes(int maxNumber)
        {
            if(maxNumber > 1)
            {
                MaxNumber = maxNumber;
                PrimeNumbers = new List<int>();
            }
            else
            {
                throw new Exception("Неправильно задан параметр");
            }
        }

        public void GetPrimeNumber(ref CancellationToken token)
        {
            int[] AllNumbers = new int[MaxNumber - 1];
            for (int i = 2; i <= MaxNumber; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана");
                    return;
                }
                AllNumbers[i - 2] = i;
            }
            while(Convert.ToBoolean(AllNumbers.Length))
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана");
                    return;
                }
                int j = AllNumbers[0];
                PrimeNumbers.Add(AllNumbers[0]);
                for (int i = 0; i < AllNumbers.Length; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }
                    if (AllNumbers[i] % j == 0)
                    {
                        List<int> lst = new List<int>(AllNumbers);
                        lst.RemoveAt(i);
                        AllNumbers = lst.ToArray();
                        i--;
                    }
                }
                Thread.Sleep(300);
            }
            Console.Write($"Все простые числа до числа {MaxNumber}: ");
            foreach (int Number in PrimeNumbers)
            {
                Console.Write(Number + " ");
            }
            Console.WriteLine();
            
        }

    }
}
