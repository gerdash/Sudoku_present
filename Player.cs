using System;
using System.Collections.Generic;
using System.Text;

namespace inspo_maze
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMarker;
        private ConsoleColor PlayerColor;
        private ConsoleColor PlayerBackgroundColor;
        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = "X";
            PlayerColor = ConsoleColor.Red;
            PlayerBackgroundColor = ConsoleColor.Yellow;
        }

        public void Draw(string[,] grid)
        {
            Console.ForegroundColor = PlayerColor;
            Console.BackgroundColor = PlayerBackgroundColor;
            Console.SetCursorPosition(X, Y);
            if (grid[Y, X] == "0")
            {
                Console.CursorVisible = false;
                Console.Write(PlayerMarker);
            }
            else
            {
                Console.CursorVisible = true;
            }
            Console.ResetColor();
        }
    }
}
