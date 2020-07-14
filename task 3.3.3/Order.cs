using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3._3._3
{
    class Order
    {
        public int Number { get; private set; }
        public Pizza[] Pizzas { get; private set; }

        private static int _totalOrders = 0;

        public Order (Pizzeria pizzeria, params Pizza[] pizzas)
        {
            Pizzas = pizzas;
            _totalOrders++;
            Number = _totalOrders;
            OnCreateOrder += pizzeria.MakeOrder;
        }

        public event Action<Order> OnCreateOrder = delegate { };

        public event Action<Order> OnReadyOrder = delegate { };

        public void InitCreateOrder()
        {
            OnCreateOrder(this);
        }

        public void InitReadyOrder()
        {
            OnReadyOrder(this);
        }

    }
}
