using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Сhoose an action");
                Console.WriteLine("1. Analyze text");
                Console.WriteLine("2. Quit");
                int.TryParse(Console.ReadLine(), out int choose);
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Enter text for analysis");
                        new TextAnalysis(Console.ReadLine());
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                }
            }

        }
    }
}
