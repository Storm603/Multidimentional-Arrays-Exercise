using System;
using System.Linq;

namespace T01._diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            int[,] matrix = new int[dimentions, dimentions];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int primary = 0;
            int secondary = 0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                secondary += matrix[dimentions - 1, j];
                primary += matrix[j, j];
                dimentions--;
            }


            Console.WriteLine(Math.Abs(primary - secondary));
        }
    }
}
