using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2._2._1
{
    abstract class Obstacles : GameObject
    {
        public int Width { get; }
        public int Height { get; }

        public Obstacles(int x, int y, int width, int height)
            :base (x, y)
        {
            Width = width;
            Height = height;
        }
    }
}
