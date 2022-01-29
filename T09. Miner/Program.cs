using System;
using System.Data;
using System.Linq;

namespace T09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            char[,] matrix = new Char[dimentions, dimentions];
            string[] inputs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int coalCount = 0;
            int[] startPosition = new int[2];
            //int[] endPosition = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (input[j] == 'c')
                    {
                        coalCount++;
                    }
                    else if (input[j] == 's')
                    {
                        startPosition[0] = i;
                        startPosition[1] = j;
                    }
                    //else if (input[j] == 'e')
                    //{
                    //    endPosition[0] = i;
                    //    endPosition[1] = j;
                    //}
                    matrix[i, j] = input[j];
                }
            }

            int[] currIndex = startPosition;

            for (int i = 0; i < inputs.Length; i++)
            {
                int row = currIndex[0];
                int col = currIndex[1];

                string movement = inputs[i];

                switch (movement)
                {
                    case "up":
                        if (IsInRange(matrix, row - 1, col))
                        {
                            currIndex[0] = row - 1;
                            currIndex[1] = col;

                            coalCount = CoalSubtraction(coalCount, matrix, currIndex[0], currIndex[1]);

                            matrix = MovementPlusCoalOrEndGame(matrix, currIndex[0], currIndex[1]);

                            //if (matrix[currIndex[0] + 1, currIndex[1]] != 's')
                            //{
                            //    matrix[currIndex[0] + 1, currIndex[1]] = '*';
                            //}
                            
                        }
                        break;

                    case "down":
                        if (IsInRange(matrix, row + 1, col))
                        {
                            currIndex[0] = row + 1;
                            currIndex[1] = col;

                            coalCount = CoalSubtraction(coalCount, matrix, currIndex[0], currIndex[1]);

                            matrix = MovementPlusCoalOrEndGame(matrix, currIndex[0], currIndex[1]);

                            
                            //if (matrix[currIndex[0] - 1, currIndex[1]] != 's')
                            //{
                            //    matrix[currIndex[0] - 1, currIndex[1]] = '*';
                            //}
                        }
                        break;

                    case "left":
                        if (IsInRange(matrix, row, col - 1))
                        {
                            currIndex[0] = row;
                            currIndex[1] = col - 1;

                            coalCount = CoalSubtraction(coalCount, matrix, currIndex[0], currIndex[1]);

                            matrix = MovementPlusCoalOrEndGame(matrix, currIndex[0], currIndex[1]);

                            
                            //if (matrix[currIndex[0], currIndex[1] + 1] != 's')
                            //{
                            //    matrix[currIndex[0], currIndex[1] + 1] = '*';
                            //}
                        }
                        break;

                    case "right":
                        if (IsInRange(matrix, row, col + 1))
                        {
                            currIndex[0] = row;
                            currIndex[1] = col + 1;

                            coalCount = CoalSubtraction(coalCount, matrix, currIndex[0], currIndex[1]);

                            matrix = MovementPlusCoalOrEndGame(matrix, currIndex[0], currIndex[1]);

                            
                            //if (matrix[currIndex[0], currIndex[1] - 1] != 's')
                            //{
                            //    matrix[currIndex[0], currIndex[1] - 1] = '*';
                            //}
                        }
                        break;

                    default: continue;
                }
            }

            Console.WriteLine($"{coalCount} coals left. ({currIndex[0]}, {currIndex[1]})");
        }

        private static int CoalSubtraction(int coalCount, char[,] matrix, int row, int col)
        {
            if (matrix[row, col] == 'c')
            {
                coalCount--;
                if (coalCount == 0)
                {
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    Environment.Exit(0);
                }
            }
            return coalCount;
        }

        private static char[,] MovementPlusCoalOrEndGame(char[,] matrix, int row, int col)
        {

            if (matrix[row, col] == 'e')
            {
                Console.WriteLine($"Game over! ({row}, {col})");
                Environment.Exit(0);
            }
            else if (matrix[row, col] == 'c')
            {
                matrix[row, col] = '*';
            }

            return matrix;
        }

        public static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }
    }
}
