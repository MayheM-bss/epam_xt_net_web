using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._9
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int[] array = new int[15];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-50, 50);
            }
            foreach (int item in array)
            {
                Console.Write(item + " ");
                if (item > 0)
                {
                    result += item;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Сумма неотрицательных элементов = {0}", result);
            Console.ReadLine();
        }
    }
}
