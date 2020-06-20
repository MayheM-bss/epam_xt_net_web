using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2._2._1
{
    class Hero : GameObject
    {
        public int Health { get; set; }
        public int Score { get; private set; }

        public Hero(int x, int y)
            :base (x,y)
        {
            Health = 10;
            Score = 0;
        }

        public void Move()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    PosY--;
                    break;
                case ConsoleKey.DownArrow:
                    PosY++;
                    break;
                case ConsoleKey.LeftArrow:
                    PosX--;
                    break;
                case ConsoleKey.RightArrow:
                    PosX++;
                    break;
            }
        }

        public void PickBonus(Bonuses bonus)
        {
            switch(bonus)
            {
                case Coin c:
                    Score += c.Points;
                    break;
                case Heart h:
                    Health += h.Hp;
                    break;
            }
        }



    }
}
