using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            User.ChangeUser();
            bool flag = true;
            while(flag)
            {
                switch(User.ActionSelection())
                {
                    case 1:
                        User.AddShape();
                        break;
                    case 2:
                        User.PrintListShapes();
                        break;
                    case 3:
                        User.CleanShapes();
                        break;
                    case 4:
                        User.EndProgram();
                        break;
                    case 5:
                        User.ChangeUser();
                        break;
                }
            }    
        }
    }

    static class User
    {
       private static string _name;
       private static List<Shapes> _shapes = new List<Shapes> { };

        public static void ChangeUser()
        {
            Console.WriteLine("Введите имя пользователя");
            _name = Console.ReadLine();
            _shapes.Clear();
        }

        public static void AddShape()
        {
            Console.WriteLine("Выберите тип фигуры");
            Console.WriteLine("1. Линия\n2. Прямоугольник\n3. Квадрат\n4. Круг\n5. Кольцо\n6. Треугольник \n7. Назад");
            int.TryParse(Console.ReadLine(), out int c);
            switch(c)
            {
                case 1:
                    _shapes.Add(CreateLine());
                    break;
                case 2:
                   _shapes.Add(CreateRectangle());
                    break;
                case 3:
                    _shapes.Add(CreateSquare());
                    break;
                case 4:
                    _shapes.Add(CreateCircle());
                    break;
                case 5:
                    _shapes.Add(CreateRing());
                    break;
                case 6:
                    _shapes.Add(CreateTriangle());
                    break;
                case 7:
                    break;
            }
        }

        public static void PrintListShapes()
        {
            if (!(_shapes.Count == 0))
            {
                foreach (var i in _shapes)
                {
                    switch (i)
                    {
                        case Line line:
                            line.Print();
                            break;
                        case Square sq:
                            sq.Print();
                            break;
                        case Ring r:
                            r.Print();
                            break;
                        case Rectangle rect:
                            rect.Print();
                            break;
                        case Circle c:
                            c.Print();
                            break;
                        case Triangle t:
                            t.Print();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Холст пуст");
            }
        }

        public static void EndProgram()
        {
            Environment.Exit(0);
        }

        public static void CleanShapes()
        {
            _shapes.Clear();
            Console.WriteLine("Холст очищен");
        }

        public static int ActionSelection()
        {
            Console.WriteLine($"{_name}, выберите действие");
            Console.WriteLine("\t1. Добавить фигуру \n\t2. Вывести фигуры \n\t3. Очистить холст \n\t4. Выход \n\t5. Сменить пользователя");
            int.TryParse(Console.ReadLine(), out int i);
            return i;
        }

        public static void CheckPos(out int x, out int y)
        {
            Console.Write("x = ");
            if (!int.TryParse(Console.ReadLine(), out x))
            {
                throw new Exception("Координата x может быть только целым числом");
            }
            Console.Write("y = ");
            if (!int.TryParse(Console.ReadLine(), out y))
            {
                throw new Exception("Координата y может быть только целым числом");
            }
        }

        public static Line CreateLine()
        {
            Console.WriteLine("Введите точку начала линии");
            CheckPos(out int x, out int y);
            Console.WriteLine("Введите длину линии");
            if (!int.TryParse(Console.ReadLine(), out int length))
            {
                throw new Exception("Длина может быть только целым числом");
            }
            Console.WriteLine("Фигура \"Линия\" создана");
            return new Line(x, y, "Линия", length);
        }

        public static Rectangle CreateRectangle()
        {
            Console.WriteLine("Введите координаты нижней левой точки прямоугольника");
            CheckPos(out int x, out int y);
            Console.WriteLine("Введите длину прямоугольника");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                throw new Exception("Длина может быть только целым числом");
            }
            Console.WriteLine("Введите высоту прямоугольника");
            if (!int.TryParse(Console.ReadLine(), out int b))
            {
                throw new Exception("Высота может быть только целым числом");
            }
            Console.WriteLine("Фигура \"Прямоугольник\" создана");
            return new Rectangle(x, y, "Прямоугольник", a, b);
        }

        public static Square CreateSquare()
        {
            Console.WriteLine("Введите координаты нижней левой точки квадрата");
            CheckPos(out int x, out int y);
            Console.WriteLine("Введите сторону квадрата");
            if(!int.TryParse(Console.ReadLine(), out int a))
            {
                throw new Exception("Сторона может быть только целым числом");
            }
            Console.WriteLine("Фигура \"Квадрат\" создана");
            return new Square(x, y, "Квадрат", a);
        }

        public static Circle CreateCircle()
        {
            Console.WriteLine("Введите координаты центра");
            CheckPos(out int x, out int y);
            Console.WriteLine("Введите радиус");
            if(!int.TryParse(Console.ReadLine(), out int r))
            {
                throw new Exception("Радиус может быть только целым числом");
            }
            Console.WriteLine("Фигура \"Круг\" создана");
            return new Circle(x, y, "Круг", r);
        }

        public static Ring CreateRing()
        {
            Console.WriteLine("Введите координаты центра");
            CheckPos(out int x, out int y);
            Console.WriteLine("Введите радиус");
            if (!int.TryParse(Console.ReadLine(), out int r))
            {
                throw new Exception("Радиус может быть только целым числом");
            }
            Console.WriteLine("Введите внутренний радиус");
            if (!int.TryParse(Console.ReadLine(), out int ir))
            {
                throw new Exception("Внутренний радиус может быть только целым числом");
            }
            else if (ir >= r)
            {
                throw new Exception("Внутренний радиус не может быть равным или больше внешнего");
            }
            Console.WriteLine("Фигура \"Кольцо\" создана");
            return new Ring(x, y, "Кольцо", r, ir);
        }

        public static Triangle CreateTriangle()
        {
            Console.WriteLine("Введите координаты нижней левой точки треугольника");
            CheckPos(out int x, out int y);
            Console.WriteLine("Введите длину первой стороны");
            if(!int.TryParse(Console.ReadLine(), out int a))
            {
                throw new Exception("Стороны треугольника могут быть только целыми числами");
            }
            Console.WriteLine("Введите длину второй стороны");
            if(!int.TryParse(Console.ReadLine(), out int b))
            {
                throw new Exception("Стороны треугольника могут быть только целыми числами");
            }
            Console.WriteLine("Введите длину третьей стороны");
            if(!int.TryParse(Console.ReadLine(), out int c))
            {
                throw new Exception("Стороны треугольника могут быть только целыми числами");
            }
            Console.WriteLine("Фигура \"Треугольник\" создана");
            return new Triangle(x, y, "Треугольник", a, b, c);
        }
    }
}
