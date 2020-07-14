using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3._3._2
{
    static class StringExtensions
    {
        public static void ExtensionsMethod(this string str)
        {
            str = str.ToLower();
            if (str.All(i => i >= 'а' && i <= 'я' || i == 'ё'))
            {
                Console.WriteLine("Russian");
            }
            else if (str.All(i => i >= 'a' && i <= 'z'))
            {
                Console.WriteLine("English");
            }
            else if (str.All(i => i >= '0' && i <= '9'))
            {
                Console.WriteLine("Number");
            }
            else
            {
                Console.WriteLine("Mixed");
            }
        }
    }
}
