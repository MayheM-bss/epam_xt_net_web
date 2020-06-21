using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task_2._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero player = new Hero(15, 3);
            List<Enemies> EnemiesList = new List<Enemies> { new Wolf(75, 5), new Bear(45, 10) };
            List<Bonuses> BonusList = new List<Bonuses> { new Coin(24, 7), new Heart(20, 4), new Coin(10, 2), new Coin(15, 8), new Heart(21, 8) };
            Console.CursorVisible = false;
            while (player.Health > 0 && BonusList.Count !=0)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 26);
                Console.WriteLine("Points {0}, HP {1}", player.Score, player.Health);
                Visualization.DrawField();
                Visualization.DrawHero(player.PosX, player.PosY);
                foreach(Enemies enemy in EnemiesList)
                {
                    Visualization.DrawEnemy(enemy);
                }

                foreach(Bonuses bonus in BonusList)
                {
                    Visualization.DrawBonus(bonus);
                }

                player.Move();
                for(int i = 0; i < BonusList.ToArray().Length; i++)
                {
                    if(player.PosX == BonusList[i].PosX && player.PosY == BonusList[i].PosY)
                    {
                        player.PickBonus(BonusList[i]);
                        BonusList.Remove(BonusList[i]);
                    }
                }

                foreach(Enemies enemy in EnemiesList)
                {
                    enemy.Move(player);
                    enemy.Hit(player);
                }
            }

            Console.Clear();
            if (player.Health <= 0)
            {
                Console.WriteLine("Вы проиграли");
            }
            else
            {
                Console.WriteLine("Вы выиграли");
            }

            Console.ReadLine();
        }
    }
}
