using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int.TryParse(Console.ReadLine(), out int N);
            for (int i = 0; i < N; i++)
            {
                string result = new String('*', i);
                Console.WriteLine(result.PadLeft(N-1) + '*' + result);
            }
            Console.ReadLine();
        }
    }
}
