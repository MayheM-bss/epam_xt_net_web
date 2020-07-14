using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task_3._3._3
{
    public enum Pizza
    {
        Hawaiian,
        Capricciosa,
        Calzone,
        Neapolitan,
        Diabola,
        Sicilian,
        Margarita
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pizzeria pizzeria = new Pizzeria();
            User Sam = new User("Sam");
            Sam.CreateOrder(pizzeria, Pizza.Margarita);
            User Jack = new User("Jack");
            Jack.CreateOrder(pizzeria, Pizza.Sicilian, Pizza.Neapolitan, Pizza.Hawaiian);
            User Ethan = new User("Ethan");
            Ethan.CreateOrder(pizzeria, Pizza.Diabola);
        }
    }
}
    

