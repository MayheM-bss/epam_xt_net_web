using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass = { 4,4,4,4,4, 8,8,8,8 };
            double[] mass1 = { 3.2, 3.2, 3.2, 3.2, 3.2, 2.5, 2.5, 2.5, 2.5 };
            mass.ExtensionRepeat();
            Console.WriteLine(mass.ExtensionAverage());
            Console.WriteLine(mass.ExtensionSum());
            Console.WriteLine(new string ('-',25));
            mass.ExtensionMethod(i => i * 2); 
            foreach (var item in mass)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string ('-', 25));
            mass1.ExtensionRepeat();
            Console.WriteLine(mass1.ExtensionAverage());
            Console.WriteLine(mass1.ExtensionSum());
            Console.WriteLine(new string ('-', 25));
            mass1.ExtensionMethod(i => i * i);
            foreach (var item in mass1)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
  
}
