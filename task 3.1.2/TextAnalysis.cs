using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task_3._1._2
{
    class TextAnalysis
    {
        private Dictionary<string, int> _words;
        private string[] _array;
        private float _repeat = 0f;

        public TextAnalysis(string str)
        {
            Print("");
            Print("Text analysis in progress");
            _words = new Dictionary<string, int>();
            _array = str.ToLower().Split(PunctuationChar(str).ToArray(), StringSplitOptions.RemoveEmptyEntries);
            FillCollection();
            PrintCollection();
            PrintMaxRepeat();
            PrintResult();
        }

        private List<char> PunctuationChar(string str)
        {
            List<char> p = new List<char>() { ' ' };
            foreach (char item in str)
            {
                if (char.IsPunctuation(item))
                {
                    if (!p.Contains(item))
                    {
                        p.Add(item);
                    }
                }
            }

            return p;
        }

        private void Print(string str)
        {
            if (str != "")
            {
                Console.WriteLine(str);
            }

            for (int i = 0; i < 15; i++)
            {
                Console.Write('.');
            }

            Console.WriteLine();
        }

        private void FillCollection()
        {
            foreach (var item in _array)
            {
                if(_words.ContainsKey(item))
                {
                    _words[item]++;
                }
                else
                {
                    _words.Add(item, 1);
                }
            }
        }

        private void PrintCollection()
        {
            foreach (var item in _words)
            {
                Console.WriteLine($"Word \"{item.Key}\" found in the text {item.Value} time(s)");
                if (item.Value > 1)
                {
                    _repeat += item.Value;
                }
            }

            Print("");
        }

        private void PrintMaxRepeat()
        {
            var maxrepeat = _words.Where(s => s.Value.Equals(_words.Max(i => i.Value > 1 ? i.Value : 2))).Select(s => s.Key);
            if (maxrepeat.Count() > 0)
            {
                Console.WriteLine("Most repeated words: ");
                foreach (var item in maxrepeat)
                {
                    Console.WriteLine(item + ';');
                }

                Print("");
            }
        }

        private void PrintResult()
        { 
            if (_repeat / _array.Length * 100 > 50 )
            {
                Console.WriteLine("Ohh. Words in the text are repeated often.");
            }
            else
            {
                Console.WriteLine("Well done. Words in the text are rarely repeated.");
            }

            Print("");
        }
    }
}
