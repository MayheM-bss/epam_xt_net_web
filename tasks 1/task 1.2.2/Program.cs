using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение");
            string input1 = Console.ReadLine();
            Console.WriteLine("Введите еще одно предложение");
            string input2 = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            char[] input1chars = input1.ToCharArray();
            foreach(char item in input1chars)
            {
                if(input2.Contains(item))
                {
                    result.Append(item);
                    result.Append(item);
                }
                else
                {
                    result.Append(item);
                }
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
