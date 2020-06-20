using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2._1._2
{
    class Rectangle : Shapes
    {
        protected int A, B;
        protected int Area
        {
            get
            {
                return A * B;
            }
        }

        protected int Perimeter
        {
            get
            {
                return (A + B) * 2;
            }
        }

        public Rectangle(int x, int y, string type, int a, int b)
            :base (x,y,type)
        {
            if(a<=0 || b<=0)
            {
                throw new ArgumentException("Длина или высота должна быть больше 0");
            }
            else
            {
                A = a;
                B = b;
            }
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("\tДлина = {0}", A);
            Console.WriteLine("\tВысота = {0}", B);
            Console.WriteLine("\tПлощадь = {0}", Area);
            Console.WriteLine("\tПериметр = {0}", Perimeter);
        }
    }
}
