using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._10
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int[,] array = new int[4, 4];
            Random rand = new Random();
            int rows = array.GetUpperBound(0) + 1;
            int colums = array.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    array[i, j] = rand.Next(50);
                }
            }
            Console.WriteLine("Массив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    Console.Write(array[i, j] + " ");
                    if((i+j) % 2 == 0)
                    {
                        result += array[i, j];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Сумма элементов стоящих на четной позиции: {0}", result);
            Console.ReadLine();
        }
    }
}
