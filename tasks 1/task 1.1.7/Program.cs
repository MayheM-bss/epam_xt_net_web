using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._7
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] array = new int[15];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(50);
            }
            Console.WriteLine("Массив до сортировки:");
            PrintArray(array);
            Console.WriteLine("Максимальное значение в массиве: {0}", Max(array));
            Console.WriteLine("Минимальное значение в массиве: {0}", Min(array));
            Console.WriteLine("Массив после сортировки:");
            Sort(array);
            PrintArray(array);
            Console.ReadLine();
        }
        static int[] Sort (int[] array)
        {
            int min, temp;
            for (int i = 0; i < array.Length; i++)
            {
                min = i;
                for (int j = i+1; j < array.Length; j++)
                {
                    if(array[j] < array[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    temp = array[i];
                    array[i] = array[min];
                    array[min] = temp;
                }
            }
            return array;
        }
        static int Max (int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
        static int Min (int[] array)
        {
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }
        static void PrintArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
