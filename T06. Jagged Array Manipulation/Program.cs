using System;
using System.Linq;

namespace T06._Jagged_Array_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine());

            double[][] arr = new Double[rows][];

            for (int i = 0; i < rows; i++)
            {
                arr[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double
                    .Parse).ToArray();
            }


            for (int i = 0; i < arr.GetLength(0) - 1; i++)
            {
                bool isEven = arr[i].GetLength(0) == arr[i + 1].GetLength(0);



                if (isEven == true)
                {
                    for (int j = 0; j < arr[i].GetLength(0); j++)
                    {
                        arr[i][j] *= 2;
                    }

                    for (int j = 0; j < arr[i + 1].GetLength(0); j++)
                    {
                        arr[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < arr[i].GetLength(0); j++)
                    {
                        arr[i][j] /= 2;
                    }

                    for (int j = 0; j < arr[i + 1].GetLength(0); j++)
                    {
                        arr[i + 1][j] /= 2;
                    }
                }

            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] splitted = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = splitted[0];
                int row = int.Parse(splitted[1]);
                int col = int.Parse(splitted[2]);
                double val = double.Parse(splitted[3]);

                if (row >= 0 && row < arr.GetLength(0) && col >= 0 && col < arr[row].GetLength(0))
                {
                    if (action == "Add")
                    {
                        arr[row][col] += val;
                    }
                    else if (action == "Subtract")
                    {
                        arr[row][col] -= val;
                    }
                }
                
                input = Console.ReadLine();
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr[i].GetLength(0); j++)
                {
                    Console.Write(arr[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
