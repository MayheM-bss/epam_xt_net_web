using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2._2._1
{
    class Heart : Bonuses
    {
        public int Hp { get; }
        public Heart (int x, int y)
            : base (x, y)
        {
            Hp = 3;
        }
    }
}
