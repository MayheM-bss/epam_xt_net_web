using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = IntMoreThan1("Введите N");
            int step = IntMoreThan1("Введите, какой по счету человек будет вычеркнут каждый раунд");

            if(step > length)
            {
                Console.WriteLine("Невозможно вычеркнуть человека с номером больше, чем общее количество человек");
                Console.ReadLine();
                Environment.Exit(0);
            }

            List<int> people = CreateList(length);
            LastRemaining(people, step);
            Console.ReadLine();
        }

        static int IntMoreThan1 (string str)
        {
            int i;

            do
            {
                Console.WriteLine(str);
                int.TryParse(Console.ReadLine(), out i);
            }

            while (i < 1);

            return i;
        }

        static List<int> CreateList(int length)
        {
            List<int> list = new List<int>();

            for (int i = 1; i <= length; i++)
            {
                list.Add(i);
            }

            return list;
        }

        static void LastRemaining (List<int> list, int step)
        {
            int round = 1;
            int index = 0;
            while(step - 1 < list.Count && list.Count != 1)
            {
                index = (index + step - 1) % list.Count;
                list.RemoveAt(index);
                Console.WriteLine($"Раунд {round}. Вычеркнут человек. Людей осталось: {list.Count}");
                round++;
            }

            Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");
        }
    }
}
