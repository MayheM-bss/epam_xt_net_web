using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace task_2._1._2
{
    class Line : Shapes
    {
        private int Lenght;
        public Line (int x,int y, string type, int length)
            : base (x,y,type)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Длина линии должна быть больше 0");
            }
            else
            {
                Lenght = length;
            }
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("\tДлина: {0}", Lenght);
        }

    }
}
