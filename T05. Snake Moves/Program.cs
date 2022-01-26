using System;
using System.Linq;

namespace T05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int row = input[0];
            int col = input[1];

            string[,] arr = new String[row, col];

            char[] word = Console.ReadLine().ToCharArray();
            int iterator = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = word[iterator].ToString();

                        Console.Write(arr[i,j]);

                        iterator++;
                        if (iterator == word.Length)
                        {
                            iterator = 0;
                        }
                    }

                    Console.WriteLine();
                }
                else
                {
                    string[] temp = new string[arr.GetLength(1)];

                    for (int j = arr.GetLength(1) - 1; j >= 0; j--)
                    {
                        temp[j] = word[iterator].ToString();

                        iterator++;
                        if (iterator == word.Length)
                        {
                            iterator = 0;
                        }
                    }

                    temp.Reverse();
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = temp[j];
                        Console.Write(arr[i,j]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
