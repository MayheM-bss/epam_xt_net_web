using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int.TryParse(Console.ReadLine(), out int N);
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    string result = new String('*', j);
                    Console.WriteLine(result.PadLeft(N)  + "*" + result);
                }
            }
            Console.ReadLine();
        }
    }
}
