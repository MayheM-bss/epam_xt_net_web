using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2._1._2
{
    class Triangle : Shapes
    {
        private int A, B, C;
        private int Perimeter
        {
            get
            {
                return A + B + C;
            }
        }

        private double HalfPerimeter
        {
            get
            {
                return (double)Perimeter / 2;
            }
        }

        private double Area
        {
            get
            {
                if (HalfPerimeter * (HalfPerimeter - A) * (HalfPerimeter - B) * (HalfPerimeter - C) < 0)
                {
                    throw new Exception("Нельзя извлечь квадратный корень из отрицательного числа");
                }
                else
                {
                    return Math.Round(Math.Sqrt(HalfPerimeter * (HalfPerimeter - A) * (HalfPerimeter - B) * (HalfPerimeter - C)), 3);
                }
            }
        }

        public Triangle(int x, int y, string type, int a, int b, int c)
            :base (x, y, type)
        {
            if(a <= 0 || b <= 0 | c <= 0)
            {
                throw new ArgumentException("Стороны треугольника должны быть больше 0");
            }
            else
            {
                A = a;
                B = b;
                C = c;
            }
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("\tСтороны треугольника: {0}, {1}, {2}", A, B, C);
            Console.WriteLine("\tПлощадь = {0}", Area);
            Console.WriteLine("\tПериметр = {0}", Perimeter);
        }
    }
}
