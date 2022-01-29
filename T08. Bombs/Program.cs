using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace T08._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {

            int dimentions = int.Parse(Console.ReadLine());

            int[,] matrix = new int[dimentions, dimentions];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            Queue<int[]> queue = new Queue<int[]>();

            string[] bombs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombs.Length; i++)
            {
                int[] split = bombs[i].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                queue.Enqueue(new int[]{split[0], split[1]});
            }

            foreach (int[] location in queue)
            {
                int row = location[0];
                int col = location[1];

                int numToSubtract = matrix[row, col];

                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        if (!InRange(matrix, i, j))
                        {
                            continue;
                        }

                        if (matrix[i, j] > 0)
                        {
                            matrix[i, j] -= numToSubtract;
                        }
                    }
                }
            }

            int aliveCells = 0;
            int aliveCellsSum = 0;

            foreach (int num in matrix)
            {
                if (num > 0)
                {
                    aliveCells++;
                    aliveCellsSum += num;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveCellsSum}");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }

                Console.WriteLine();
            }
        }

        public static bool InRange(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && 
                   col >= 0 && col < matrix.GetLength(1);
        }
    }
}
