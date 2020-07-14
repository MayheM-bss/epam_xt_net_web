using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            Console.WriteLine("Введите предложение");
            string input = Console.ReadLine();
            List<char> punctuationChars = new List<char>() { ' ' };
            foreach (char item in input)
            {
                if (char.IsPunctuation(item))
                {
                    if (!punctuationChars.Contains(item))
                    {
                        punctuationChars.Add(item);
                    }
                }
            }
            string[] words = input.Split(punctuationChars.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                foreach (char item in word)
                {
                    if (char.IsLower(item))
                    {
                        result++;
                    }
                    break;
                }
            }
            Console.WriteLine("Слов, которые начинаются с маленькой буквы: {0}", result);
            Console.ReadLine();
        }
    }
}
