using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2._1._2
{
    class Circle : Shapes
    {
        protected int Radius;
        protected int Diameter
        {
            get
            {
                return Radius * 2;
            }
        }

        protected virtual double Area
        {
            get
            {
                return Math.Round(Math.PI * Math.Pow(Radius, 2), 5);
            }
        }

        protected double LengthCircle
        {
            get
            {
                return Math.Round(2 * Math.PI * Radius, 3);
            }
        }

        public Circle(int x, int y, string type, int r)
            : base (x,y,type)
        {
            if(r <= 0)
            {
                throw new ArgumentException("Радиус должен быть больше 0");
            }
            else
            {
                Radius = r;
            }
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("\tКоординаты центра: x = {0}, y = {1}", x, y);
            Console.WriteLine("\tРадиуc = {0}", Radius);
            Console.WriteLine("\tДиаметр = {0}", Diameter);
            Console.WriteLine("\tПлощадь = {0}", Area);
            Console.WriteLine("\tДлина окружности = {0}", LengthCircle);
        }
    }
}
