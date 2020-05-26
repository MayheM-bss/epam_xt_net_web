using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1._1._6
{
    class Program
    {
        [Flags]
        enum Format
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }
        static void Main(string[] args)
        { 
            Format f = Format.None;
            while (true)
            {
                Console.WriteLine("Параметры надписи: {0}", f);
                Console.WriteLine("Введите: \n\t1: bold \n\t2: italic \n\t3: underline");
                int.TryParse(Console.ReadLine(), out int n);
                switch(n)
                {
                    case 1:
                        f = f ^ Format.Bold;
                        break;
                    case 2:
                        f = f ^ Format.Italic;
                        break;
                    case 3:
                        f = f ^ Format.Underline;
                        break;
                }
            }   
        }
    }
}
