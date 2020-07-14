using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3._3._3
{
    class User
    {
        public string Name { get; }

        public int OrderNumber { get; private set; }

        public User(string name)
        {
            Name = name;
        }

        public User()
        {
            Name = "User";
        }

        public void CreateOrder(Pizzeria pizzeria, params Pizza[] pizzas)
        {
            Order order = new Order(pizzeria, pizzas);
            OrderNumber = order.Number;
            order.OnReadyOrder += TakeOrder;
            Console.WriteLine($"{Name} made an order");
            Console.WriteLine(new string('_',25));
            order.InitCreateOrder();
        }

        public void TakeOrder(Order obj)
        {
            obj.OnReadyOrder -= TakeOrder;
            Console.WriteLine($"{Name} took the order");
            Console.WriteLine(new string('_', 25));
        }
    }
}
