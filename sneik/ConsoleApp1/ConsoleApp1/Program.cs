using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Game
    {
        int _w;
        int _h;
        int _frute_X;
        int _frute_Y;
        int _snake_X;
        int _snake_Y;
        Random random = new Random();
        

        public Game(int w, int h)
        {
            _w = w;
            _h = h;
            _frute_X = random.Next(1, _w - 2);
            _frute_Y = random.Next(1, _h - 2);
            _snake_X = random.Next(1, _w - 2);
            _snake_Y = random.Next(1, _h - 2);
        }
       public void Snakeleft()
        {
           
            if (_snake_X > 1)
            {
                --_snake_X;
            }

        }
        public void Snakeright()
        {
           

            if (_snake_X < _w-2)
            {
                ++_snake_X;
            }

        }
        public void Snakedown()
        {
            
            if (_snake_Y < _h-1)
            {
                ++_snake_Y;
            }

        }
        public void Snakeup()
        {
            
            if (_snake_Y > 1)
            {
                --_snake_Y;
            }
        }
        public void DrawFruit()
        {
            Console.SetCursorPosition(_frute_X, _frute_Y);
            Console.Write("Q");
        }
        public void DrawSnake()
        {
            Console.SetCursorPosition(_snake_X, _snake_Y);
            Console.Write("R");
        }

        public void DrawFeild()
        {

            for (int i = 0; i < _w; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, _h);
                Console.Write("#");

            }
            for (int c = 1; c < _h; c++)
            {
                Console.SetCursorPosition(0, c);
                Console.Write("#");
                Console.SetCursorPosition(_w - 1, c);
                Console.Write("#");
            }

        }
    }
    class Program
    {



        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            string[] mass = n.Split(' ');
            int w = Int32.Parse(mass[0]);
            int h = Int32.Parse(mass[1]);
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            Game game = new Game(w, h);
            while (true)
            {
                Console.Clear();
                game.DrawFeild();
                game.DrawFruit();
                game.DrawSnake();
                Console.SetCursorPosition(0, h + 1);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.WriteLine("змея вверх");
                        game.Snakeup();
                        break;
                    case ConsoleKey.DownArrow:
                        Console.WriteLine("змея вниз");
                        game.Snakedown();
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.WriteLine("змея влево");
                        game.Snakeleft();
                        break;
                    case ConsoleKey.RightArrow:
                        Console.WriteLine("змея вправо");
                        game.Snakeright();
                        break;
                }
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey();

                }
                System.Threading.Thread.Sleep(200);
            }

        }
    }
}