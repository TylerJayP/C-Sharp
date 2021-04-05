using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace A04_Snake
{
    class MainBoard
    {
        public int widthOfBoard { get; set; }
        public int heightOfBoard { get; set; }
        public static int gameSpeed { get; set; }
        

        public MainBoard (int heightOfBoard, int widthOfBoard)
        {
            this.widthOfBoard = widthOfBoard;
            this.heightOfBoard = heightOfBoard;
        }

        public void startGame()
        {
            Console.SetCursorPosition(50, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome To SNAKE!");
            Console.SetCursorPosition(40, 6);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Controls: UP/DOWN/LEFT/RIGHT Arrow Keys");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(20, 7);
            Console.WriteLine("Directions: Avoid biting yourself, hitting the walls, and hitting the obstacles");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(25, 8);
            Console.WriteLine("Press <ENTER> Once You Understand The Game Rules And How To Play Snake!");
            Console.ReadLine();
            Console.Clear();
            secondScreen();
        }
        public void secondScreen()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(40, 5);
            Console.WriteLine("Choose the difficulty of the game!");
            Console.SetCursorPosition(52, 6);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1: Easy");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(52, 7);
            Console.WriteLine("2: Normal");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(52, 8);
            Console.WriteLine("3: Hard");
            Console.SetCursorPosition(45, 9);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Your Difficulty Choice: ");
            int userDifficulty = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (userDifficulty == 1)
            {
                gameSpeed = 50;
                Console.SetCursorPosition(28, 0);
                Console.WriteLine("Snake : EASY");
                drawGameBorder();
               
            }
            if (userDifficulty == 2)
            {
                gameSpeed = 30;
                Console.SetCursorPosition(28, 0);
                Console.WriteLine("Snake : NORMAL");
                drawGameBorder();
            }
            if (userDifficulty == 3)
            {
                gameSpeed = 5;
                Console.SetCursorPosition(28, 0);
                Console.WriteLine("Snake : HARD");
                drawGameBorder();
            }
            
        }
        public void drawGameBorder()
        {         
            Console.SetCursorPosition(5, 2);
            for (int i = 0; i < heightOfBoard; i++)
            {                              
                for (int h = 0; h < widthOfBoard; h++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                }
                Console.WriteLine("");
                Console.SetCursorPosition(5, i+2);               
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    } 
}







