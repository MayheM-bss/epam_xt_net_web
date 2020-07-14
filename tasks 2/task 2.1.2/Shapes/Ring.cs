using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace task_2._1._2
{
    class Ring : Circle
    {
        protected int InnerRadius;
        protected int InnerDiameter
        {
            get
            {
                return InnerRadius * 2;
            }
        }
        
        protected override double Area
        {
            get
            {
                return Math.Round(Math.PI * (Math.Pow(Radius, 2) - Math.Pow(InnerRadius, 2)), 3);
            }
        }

        protected double InnerLenghtRing
        {
            get
            {
                return Math.Round(2 * Math.PI * InnerRadius, 3);
            }
        }

        public Ring (int x, int y, string type, int r, int ir)
            : base (x, y, type, r)
        {
            if(ir <= 0)
            {
                throw new ArgumentException("Внутренний радиус должен быть больше 0");
            }
            else
            {
                InnerRadius = ir;
            }
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("\tРадиус внутренней окружности = {0}", InnerRadius);
            Console.WriteLine("\tДиаметр внутренней окружности = {0}", InnerDiameter);
            Console.WriteLine("\tДлина внутренней окружности = {0}", InnerLenghtRing);
            Console.WriteLine("\tСумма длин внешней и внтуренней окружностей = {0}", LengthCircle+InnerLenghtRing);
        }
    }
}
