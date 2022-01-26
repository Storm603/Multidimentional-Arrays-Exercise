using System;
using System.Linq;

namespace T03._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] arr = new int[rows, cols];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] loadRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = loadRow[j];
                }
            }

            int[,] bestMatrix = new int[3, 3];
            int bestSum = 0;

            for (int row = 0; row < arr.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < arr.GetLength(1) - 2; col++)
                {
                    // iterating triple matrix
                    int currSum = 0;
                    int[,] currMatrix = new int[3, 3];

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            currMatrix[i, j] = arr[row + i, col + j];
                            currSum += arr[row + i, col + j];
                        }
                    }

                    if (currSum > bestSum)
                    {
                        bestSum = currSum;
                        bestMatrix = currMatrix;
                    }
                }
            }

            Console.WriteLine($"Sum = {bestSum}");

            for (int i = 0; i < bestMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < bestMatrix.GetLength(1); j++)
                {
                    Console.Write(bestMatrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
