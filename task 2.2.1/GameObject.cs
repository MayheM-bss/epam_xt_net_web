using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2._2._1
{
    abstract class GameObject
    {
        public int PosX { get; protected set; }
        public int PosY { get; protected set; }
        public GameObject(int x, int y)
        {
            PosX = x;
            PosY = y;
        }


    }
}
