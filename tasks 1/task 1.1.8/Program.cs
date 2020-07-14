using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] array = new int[2, 3, 4];
            Random rand = new Random(); 
            for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    for (int k = 0; k < array.GetUpperBound(2) + 1; k++)
                    {
                        array[i, j, k] = rand.Next(-50, 50);
                    }

                }
            }
            Console.WriteLine("Исходный массив:");
            ArrayPrint(array);
            for (int i = 0; i <array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j <array.GetUpperBound(1) + 1; j++)
                {
                    for (int k = 0; k <array.GetUpperBound(2) + 1; k++)
                    {
                        if (array[i,j,k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }
            Console.WriteLine("Массив с 0 вместо положительных чисел:");
            ArrayPrint(array);
            Console.ReadLine();
        }
        static void ArrayPrint(int[,,] array)
        {
            for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    for (int k = 0; k < array.GetUpperBound(2) + 1; k++)
                    {
                        Console.Write(array[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
