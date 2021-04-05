using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Resources;


namespace A04_Snake
{
    struct mrSnakePosition
    {
        public int row;
        public int col;
       

        public mrSnakePosition(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    class Snake_Body_Movements
    {
 
        public static void Main(string[] args)
        {
            int right = 0;
            int left = 1;
            int down = 2;
            int up = 3;
            var timer = new Stopwatch();
            bool gameLive = true;


            MainBoard game = new(20, 60);
            game.startGame();
            int snakeSpeed = MainBoard.gameSpeed;
            timer.Start();

            Console.CursorVisible = false;


            mrSnakePosition[] mrSnakeDirection = new mrSnakePosition[]
            {
                //right
                new mrSnakePosition(0,1),
                //left
                new mrSnakePosition(0,-1),
                //down
                new mrSnakePosition(1,0),
                //right
                new mrSnakePosition(-1, 0)
            };

            //starting direction
            int startDirection = right;

            List<mrSnakePosition> inhibit = new List<mrSnakePosition>()
            {
                
                new mrSnakePosition(11, 15),
                new mrSnakePosition(6, 22),
                new mrSnakePosition(18, 17),
                new mrSnakePosition(5, 45),
                new mrSnakePosition(14, 31),
                new mrSnakePosition(17, 51)
            };
            foreach (mrSnakePosition inhibiting in inhibit)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(inhibiting.col, inhibiting.row);
                Console.Write("||");
            }
            Queue<mrSnakePosition> mrSnakeParts = new Queue<mrSnakePosition>();
            
            for (int i = 0; i <= 10; i++)
            {
                mrSnakeParts.Enqueue(new mrSnakePosition(0+10, i+25));
            }
                foreach(mrSnakePosition snakePos in mrSnakeParts)
            {
                Console.SetCursorPosition(snakePos.col, snakePos.row);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("  ");
           
            }

            while (gameLive)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo arrowInputs = Console.ReadKey();
                    if(arrowInputs.Key == ConsoleKey.UpArrow)
                    {
                        if (startDirection != down) startDirection = up;
                    }
                    if (arrowInputs.Key == ConsoleKey.DownArrow)
                    {
                        if (startDirection != up) startDirection = down;
                    }
                    if (arrowInputs.Key == ConsoleKey.LeftArrow)
                    {
                        if (startDirection != right) startDirection = left;
                    }
                    if (arrowInputs.Key == ConsoleKey.RightArrow)
                    {
                        if (startDirection != left) startDirection = right;
                    }
                }
                TimeSpan gameTime = timer.Elapsed;
                mrSnakePosition mrSnakeHead = mrSnakeParts.Last();
                mrSnakePosition movingNewDirection = mrSnakeDirection[startDirection];
                mrSnakePosition newMrSnakeHead = new(mrSnakeHead.row + movingNewDirection.row, mrSnakeHead.col + movingNewDirection.col);
                if ((newMrSnakeHead.col < 6) || (newMrSnakeHead.col > 63))
                {
                    Console.Beep();
                    gameLive = false;
                    gameOver(gameTime);
                    timer.Stop();
                    return;
                }
                if ((newMrSnakeHead.row < 3) || (newMrSnakeHead.row > 19))
                {
                    Console.Beep();
                    gameLive = false;
                    gameOver(gameTime);
                    timer.Stop();
                    return;
                }

                if(mrSnakeParts.Contains(newMrSnakeHead)) 
                {
                    Console.Beep();
                    gameOver(gameTime);
                    timer.Stop();
                    return;
                }
                if (inhibit.Contains(newMrSnakeHead))
                {
                    Console.Beep();
                    gameOver(gameTime);
                    timer.Stop();
                    return;
                }

                mrSnakeParts.Enqueue(newMrSnakeHead);
                Console.SetCursorPosition(newMrSnakeHead.col, newMrSnakeHead.row);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(" ");

                mrSnakePosition lastPartOfMrSnake = mrSnakeParts.Dequeue();
                Console.SetCursorPosition(lastPartOfMrSnake.col, lastPartOfMrSnake.row);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ");

                Thread.Sleep(snakeSpeed);
              
                Console.SetCursorPosition(newMrSnakeHead.col, newMrSnakeHead.row);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" ");

                Thread.Sleep(snakeSpeed + 5);
               
            }

        }
        public static void gameOver(TimeSpan gameTime)
        {
            Console.SetCursorPosition(20, 1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Game Over! ");
            Console.Write("Time Alive: " + gameTime.ToString(@"m\:ss\.fff"));
            Console.SetCursorPosition(0, 20);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            return;
        }
    }   
}




