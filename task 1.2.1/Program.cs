using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int wordsChars = 0;
            int result;
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
            foreach(string word in words)
            {
                wordsChars += word.Length;
            }
            // Среднее количество символов в предложении округляется
            result = wordsChars / words.Length;
            Console.WriteLine("Средняя длина слова: {0}",result);
            Console.ReadLine();
        }
    }
}
