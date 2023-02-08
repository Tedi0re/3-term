using System;

namespace AiSD_Lab_9.GeneticAlgorithm
{
    class Program
    {
        const int SizeMap = 5;
        const int CountChild = 3;
        const string Genes = "ABCDE";

        int[,] Map = new int[SizeMap, SizeMap]
                { { int.MaxValue, 25, 40, 31, 27},
                { 5, int.MaxValue, 17, 30, 25},
                { 19, 15, int.MaxValue, 6, 1},
                { 9, 50, 24, int.MaxValue, 6 },
                { 22, 8, 7, 10, int.MaxValue } };

        class individ
        {
            string G;
            int fitness;
        }

    }
}
