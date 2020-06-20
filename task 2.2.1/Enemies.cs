using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace task_2._2._1
{
    abstract class Enemies : GameObject
    {
        protected int Damage;

        public Enemies (int x, int y, int dam)
            : base (x, y)
        {
            Damage = dam;
        }

        public void Move(Hero h)
        {
            if(h.PosX >= PosX && h.PosX != PosX)
            {
                PosX++;
            }
            else 
            {
                PosX--;
            }

            if (h.PosY >= PosY && h.PosY != PosY)
            {
                PosY++;
            }
            else
            {
                PosY--;
            }

            if(h.PosX == PosX && h.PosY == PosY)
            {
                Hit(h);
            }
        }

        private void Hit(Hero h)
        {
            h.Health -= Damage;
        }
    }
}
