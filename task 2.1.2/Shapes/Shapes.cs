using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2._1._2
{
    abstract class Shapes
    {
        protected string Type { get; private set; }
        protected int x, y;
        
        protected Shapes(int x, int y, string type)
        {
            this.x = x;
            this.y = y;
            Type = type;
        }

        public virtual void Print()
        {
            Console.WriteLine("Тип фигуры: {0}", Type);
        }
    }
}
