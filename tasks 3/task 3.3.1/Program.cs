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
            mass.ExtensionRepeat();
            Console.WriteLine(mass.ExtensionAverage());
            Console.WriteLine(mass.ExtensionSum());
            Console.WriteLine(new string ('-',25));
            mass.ExtensionMethod(i => i * 2); 
            foreach (var item in mass)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
  
}
