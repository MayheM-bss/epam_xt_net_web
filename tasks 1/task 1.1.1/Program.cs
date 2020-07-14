using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._1
{
    class Program
    {
        static void Main()
        {
            int a, b;
            do
            {
                Console.Write("A = ");
            }
            while (!int.TryParse(Console.ReadLine(), out a));
            do
            {
                Console.Write("B = ");
            }
            while (!int.TryParse(Console.ReadLine(), out b));
            if (a <= 0 || b <=0)
            {
                Console.WriteLine("Ошибка");
            }
            else 
            {
                Console.WriteLine("Площадь треугольника = {0}", a * b);
            }
            Console.ReadLine();
        }
    }
}
