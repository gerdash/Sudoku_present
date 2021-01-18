using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace inspo_maze
{
    class World
    {
        public string[,] Grid { get; set; }
        public string[,] GridUnchanged { get; set; }
        public string[,] GridSolution { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string[,] GeneralFrame { get; set; }
        public List<int> Hints = new List<int>();

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Columns = Grid.GetLength(1);
        }

        public void Draw()
        {
            int counter = 0;
            int counter1 = 0;
            int counter2 = 0;
            int counter3 = 0;
            int counter4 = 0;
            int counter5 = 0;
            int counter6 = 0;
            int counter7 = 0;
            int counter8 = 0;
          
            
            Console.SetWindowSize(GeneralFrame.GetLength(1), GeneralFrame.GetLength(0));

            for (int y = 0; y < GeneralFrame.GetLength(0); y++)
            {
                for (int x = 0; x < GeneralFrame.GetLength(1); x++)
                { 
                   string element = GeneralFrame[y, x];
                    if (element == "3" && x != 13)
                    {
                        
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (3 - Hints.Count <= 0)
                        {
                            Console.Write("Out of Hints");
                        }
                        else
                        {
                            Console.Write(3 - Hints.Count);
                        }
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"{element}");
                        Console.ResetColor();
                    }
                }
            }

            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    #region Number Count Checks
                    if (Grid[y, x] == "1")
                    {
                        counter++;
                        if (counter == 9)
                        {
                            Console.SetCursorPosition(3, 25);
                            Console.WriteLine(" ");
                        }
                    }
                    if (Grid[y, x] == "2")
                    {
                        counter1++;
                        if (counter1 == 9)
                        {
                            Console.SetCursorPosition(8, 25);
                            Console.WriteLine(" ");
                        }
                    }
                    if (Grid[y, x] == "3")
                    {
                        counter2++;
                        if (counter2 == 9)
                        {
                            Console.SetCursorPosition(13, 25);
                            Console.WriteLine(" ");
                        }
                    }
                    if (Grid[y, x] == "4")
                    {
                        counter3++;
                        if (counter3 == 9)
                        {
                            Console.SetCursorPosition(18, 25);
                            Console.WriteLine(" ");
                        }
                    }
                    if (Grid[y, x] == "5")
                    {
                        counter4++;
                        if (counter4 == 9)
                        {
                            Console.SetCursorPosition(23, 25);
                            Console.WriteLine(" ");
                        }
                    }
                    if (Grid[y, x] == "6")
                    {
                        counter5++;
                        if (counter5 == 9)
                        {
                            Console.SetCursorPosition(28, 25);
                            Console.WriteLine(" ");
                        }
                    }
                    if (Grid[y, x] == "7")
                    {
                        counter6++;
                        if (counter6 == 9)
                        {
                            Console.SetCursorPosition(33, 25);
                            Console.WriteLine(" ");
                        }
                    }
                    if (Grid[y, x] == "8")
                    {
                        counter7++;
                        if (counter7 == 9)
                        {
                            Console.SetCursorPosition(38, 25);
                            Console.WriteLine(" ");
                        }
                    }
                    if (Grid[y, x] == "9")
                    {
                        counter8++;
                        if (counter8 == 9)
                        {
                            Console.SetCursorPosition(43, 25);
                            Console.WriteLine(" ");
                        }
                    }
                    #endregion

                    string initialElement = GridUnchanged[y, x];
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x, y);
    
                    if (element != initialElement) //need to color userinputs differently
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{element}");
                        Console.ResetColor();
                    }
                    else if (element != "0")
                    {
                        if ((y ==3 || y == 5 || y == 9 || y == 11 || y == 15 || y == 17) && (x > 3 && x < 39) && x != 15 && x != 27)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.Write($"{element}");
                            Console.ResetColor();
                        }
                        else if (((y == 1 || y == 7 || y == 13 || y == 19) && (x > 1 && x < 41)) || ((y > 1 && y < 19) && (x == 15 || x == 27 || x == 2 || x == 3 || x == 39 || x == 40)))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.Write($"{element}");
                            Console.ResetColor();
                        }
                        else 
                        { 
                         Console.ForegroundColor = ConsoleColor.Cyan;
                         Console.BackgroundColor = ConsoleColor.Magenta;
                         Console.Write($"{element}");
                         Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write($" ");
                        Console.ResetColor();
                    }
                   
                }
            }
        }

        public bool IsPositionEmpty(int x, int y)
        {
            if (x < 4 || y < 1 || x >= Columns-2 || y >= Rows-2) //establishing that the cursor positions exist, if not the person cannot go there/put the input there
            {
                //set the cursor before where we want the error message
                Console.SetCursorPosition(62, 26);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Out of bounds!");
                Console.ResetColor();
                System.Threading.Thread.Sleep(400);
                return false;
            }
            return true;
        }
    }
}
