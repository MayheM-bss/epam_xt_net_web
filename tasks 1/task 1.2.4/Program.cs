using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите предложения");
            string input = Console.ReadLine();
            char[] chars = { '.', '?', '!' };
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i > 2 && chars.Contains(input[i - 2]))
                {
                    if (char.IsWhiteSpace(input[i - 1]))
                    {
                        result.Append(char.ToUpper(input[i]));
                    }
                    else if (chars.Contains(input[i - 1]))
                    {
                        result.Append(input[i]);
                    }
                }
                else if (i == 0)
                {
                    result.Append(char.ToUpper(input[i]));
                }
                else
                {
                    result.Append(input[i]);
                }
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
