using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString a = "hello";
            MyString b = "hello";
            MyString c = "HeLLo WoRlD";
            Console.WriteLine(MyString.Concat(a,b));
            Console.WriteLine(a.Concat(b));
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(b.Replace("he", "lo"));
            Console.WriteLine(b.Contains('p'));
            Console.WriteLine(a.Slice(1,4));
            Console.WriteLine(c.SwapCase());
            Console.WriteLine(c.Remove(5));
            Console.ReadLine();
        }
    }
}
