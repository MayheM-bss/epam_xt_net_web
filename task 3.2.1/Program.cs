using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> a = new DynamicArray<int>();
            List<int> b = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            a.AddRange(b);
            a.Remove(6);
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine(a.Length);
            Console.ReadLine();
        }
    }
}
