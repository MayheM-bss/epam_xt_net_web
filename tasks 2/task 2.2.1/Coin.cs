using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2._2._1
{
    class Coin : Bonuses
    {
        public int Points { get; }
        public Coin(int x, int y)
            :base(x, y)
        {
            Points = 5;
        }
    }
}
