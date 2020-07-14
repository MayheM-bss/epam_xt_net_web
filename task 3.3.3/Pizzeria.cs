using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task_3._3._3
{
    class Pizzeria
    {
        public void MakeOrder(Order obj)
        {
            Console.WriteLine($"Order №{obj.Number} was received");
            Console.WriteLine($"Making order №{obj.Number}");
            foreach (var item in obj.Pizzas)
            {
                Console.WriteLine($"Making \"{item}\" pizza");
            }
            Console.WriteLine($"Order №{obj.Number} is ready");
            Console.WriteLine(new string ('_',25));
            obj.OnCreateOrder -= MakeOrder;
            obj.InitReadyOrder();
        }
    }
}
