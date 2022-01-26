using System;
using System.Linq;

namespace T02._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            int rows = dimentions[0];
            int cols = dimentions[1];

            char[,] arr = new char[rows, cols];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = input[j];
                }
            }

            int matrixCount = 0;

            

            for (int i = 0; i < arr.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < arr.GetLength(1) - 1; j++)
                {
                    if (arr[i, j] == arr[i, j + 1] && arr[i, j] == arr[i + 1, j] && arr[i, j] == arr[i + 1, j + 1])
                    {
                        matrixCount++;
                    }
                }
            }

            Console.WriteLine(matrixCount);
        }
    }
}
