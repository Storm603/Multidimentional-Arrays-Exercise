using System;
using System.Linq;

namespace T04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] split = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int row = int.Parse(split[0]);
            int col = int.Parse(split[1]);

            string[,] arr = new String[row, col];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                string[] splitted = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = splitted[j];
                }
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                string[] splitted = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (splitted[0] != "swap" || splitted.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int row1 = int.Parse(splitted[1]);
                    int col1 = int.Parse(splitted[2]);
                    int row2 = int.Parse(splitted[3]);
                    int col2 = int.Parse(splitted[4]);

                    if (row1 >= arr.GetLength(0) || row2 >= arr.GetLength(0) || col1 >= arr.GetLength(1) || col2 >= arr.GetLength(1))
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string tempValue = String.Empty;

                        tempValue = arr[row1, col1];
                        arr[row1, col1] = arr[row2, col2];
                        arr[row2, col2] = tempValue;

                        for (int i = 0; i < arr.GetLength(0); i++)
                        {
                            for (int j = 0; j < arr.GetLength(1); j++)
                            {
                                Console.Write(arr[i,j] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                }


                input = Console.ReadLine();
            }
        }
    }
}
