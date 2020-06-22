using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2._2._1
{
    static class Visualization
    {
        private static readonly int _width = 80;
        private static readonly int _height = 25;
        public static void DrawField()
        {
            DrawHorizontal(_width, 0);
            DrawHorizontal(_width, _height);
            DrawVertical(0, _height);
            DrawVertical(_width, _height);
        }

        public static void Draw(GameObject obj)
        {
            Console.SetCursorPosition(obj.PosX, obj.PosY);
            switch (obj)
            {
                case Hero _:
                    Console.Write('H');
                    break;
                case Wolf _:
                    Console.Write('W');
                    break;
                case Bear _:
                    Console.Write('B');
                    break;
                case Coin _:
                    Console.Write('@');
                    break;
                case Heart _:
                    Console.Write('*');
                    break;
            }
        }

        private static void DrawHorizontal(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write('#');
            }
        }

        private static void DrawVertical(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write('#');
            }
        }

    }
}
