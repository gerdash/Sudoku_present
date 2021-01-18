using FinalProjectSudoku;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace inspo_maze
{
    class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        public List<PlayerRegister> Players = new List<PlayerRegister>();

        public void Start()
        {
            Console.Title = "THE BEST SUDOKU EVER!";
            Console.SetWindowSize(90, 32);
            DisplayIntro();
            string[,] grid = LevelInput();
            MyWorld = new World(grid);

            var equal =
            grid.Rank == LevelParser.ParseFileToArray("Level1.txt").Rank &&
            Enumerable.Range(0, grid.Rank).All(dimension => grid.GetLength(dimension) == LevelParser.ParseFileToArray("Level1.txt").GetLength(dimension)) &&
            grid.Cast<string>().SequenceEqual(LevelParser.ParseFileToArray("Level1.txt").Cast<string>());
            if (equal)
            {
                MyWorld.GridSolution = LevelParser.ParseFileToArray("Level1Solution.txt");
                MyWorld.GridUnchanged = LevelParser.ParseFileToArray("Level1.txt");
            }

            var equal2 =
            grid.Rank == LevelParser.ParseFileToArray("Level2.txt").Rank &&
            Enumerable.Range(0, grid.Rank).All(dimension => grid.GetLength(dimension) == LevelParser.ParseFileToArray("Level2.txt").GetLength(dimension)) &&
            grid.Cast<string>().SequenceEqual(LevelParser.ParseFileToArray("Level2.txt").Cast<string>());
            if (equal2)
            {
                MyWorld.GridSolution = LevelParser.ParseFileToArray("Level2Solution.txt");
                MyWorld.GridUnchanged = LevelParser.ParseFileToArray("Level2.txt");
            }
            MyWorld.GeneralFrame = LevelParser.ParseFileToArray("Frame.txt");
            Console.SetWindowSize(MyWorld.GeneralFrame.GetLength(1), MyWorld.GeneralFrame.GetLength(0));
           
            var equal3 =
           grid.Rank == LevelParser.ParseFileToArray("Level3.txt").Rank &&
           Enumerable.Range(0, grid.Rank).All(dimension => grid.GetLength(dimension) == LevelParser.ParseFileToArray("Level3.txt").GetLength(dimension)) &&
           grid.Cast<string>().SequenceEqual(LevelParser.ParseFileToArray("Level3.txt").Cast<string>());
            if (equal3)
            {
                MyWorld.GridSolution = LevelParser.ParseFileToArray("Level3Solution.txt");
                MyWorld.GridUnchanged = LevelParser.ParseFileToArray("Level3.txt");
            }
            MyWorld.GeneralFrame = LevelParser.ParseFileToArray("Frame.txt");
            CurrentPlayer = new Player(5, 2);
            RunGameLoop(grid, MyWorld.GridSolution, MyWorld.Hints, MyWorld.GeneralFrame);
            Console.ReadKey(true);
        }
      
        public void choseLevel() 
        {
            Console.Clear();
            PrintSudokuHorizontal();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please choose one of below mentioned levels:");
            Console.WriteLine("Press '1' for EASY Sudoku");
            Console.WriteLine("Press '2' for MEDIUM Sudoku");
            Console.WriteLine("Press '3' for HARD Sudoku");
            Console.WriteLine();
            Console.WriteLine("To go back to menu press 'N'.");
        }
        public string[,] LevelInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine("You chose level easy! Press Enter!");
                    return LevelParser.ParseFileToArray("Level1.txt");

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.WriteLine("You chose level medium! Press Enter!");
                    return LevelParser.ParseFileToArray("Level2.txt");
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.WriteLine("You chose level easy! Press Enter!");
                    return LevelParser.ParseFileToArray("Level3.txt");
                case ConsoleKey.N:
                    InfoAboutGame();
                    return null;
            }
            Console.ResetColor();
            return null;
        }
        private void DisplayIntro()
        {
            for (int i = 0; i < 2; i++) //sudoku intro visualisation movement
            {
                PrintSudokuHorizontal();
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                PrintSudoku();
                System.Threading.Thread.Sleep(300);
                Console.Clear();
            }
            InfoAboutGame();
            Console.WriteLine();
        }
        private void DrawFrame(string[,] grid)
        {
            Console.Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw(grid);
        }
    
        private void HandlePlayerInput(string [,] grid, string[,] gridSolution, List<int> Hints)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            //int number = 3;
            //if (key == ConsoleKey.H)
            //{
            //    Hints.Add(number);
            //    number--;
            //}
            //Console.WriteLine(number);
            switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (MyWorld.IsPositionEmpty(CurrentPlayer.X - 4, CurrentPlayer.Y))
                        {
                            CurrentPlayer.X -= 4;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (MyWorld.IsPositionEmpty(CurrentPlayer.X, CurrentPlayer.Y - 2))
                        {
                            CurrentPlayer.Y -= 2;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (MyWorld.IsPositionEmpty(CurrentPlayer.X + 4, CurrentPlayer.Y))
                        {
                            CurrentPlayer.X += 4;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (MyWorld.IsPositionEmpty(CurrentPlayer.X, CurrentPlayer.Y + 2))
                        {
                            CurrentPlayer.Y += 2;
                        }
                        break;
                    case ConsoleKey.Tab:
                        {
                            int x = CurrentPlayer.X;
                            int y = CurrentPlayer.Y;
                            string answer = gridSolution[CurrentPlayer.Y, CurrentPlayer.X];

                            if (grid[y, x] == "0")
                            {
                                Console.SetCursorPosition(x, y);
                                string input = Console.ReadLine();
                                if (input == answer)
                                {
                                Console.SetCursorPosition(65, 26);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Success!");
                                Console.ResetColor();
                                System.Threading.Thread.Sleep(400);
                                grid[y, x] = input;
                                }
                                else
                                {
                                Console.SetCursorPosition(63, 26);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Wrong number!");
                                Console.ResetColor();
                                System.Threading.Thread.Sleep(400);
                                }
                            }  
                        }
                        break;
                    case ConsoleKey.H:
                    Hints.Add(1);
                    if (grid[CurrentPlayer.Y, CurrentPlayer.X] == "0")
                    {
                        if (Hints.Count > 3)
                        {
                            Console.SetCursorPosition(63, 26);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Out of hints!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.SetCursorPosition(62, 26);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("There's a hint!");
                            grid[CurrentPlayer.Y, CurrentPlayer.X] = gridSolution[CurrentPlayer.Y, CurrentPlayer.X];
                            Console.ResetColor();
                            System.Threading.Thread.Sleep(400);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(60, 26);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Can't give a hint!");
                        Hints.Remove(1);
                        Console.ResetColor();
                        System.Threading.Thread.Sleep(400);
                    }
                        break;
                case ConsoleKey.Escape:
                    InfoAboutGame();
                    break;
              
                    default:
                        break;
            }
        }
        
        private void RunGameLoop(string[,] grid, string[,] gridSolution, List<int> Hints, string[,] generalGrid)
        {
          var timer = new TimeOfTheGame();
            Console.Clear();
            timer.Start();
            while (ContainsZero(grid))
            {
                //Draw everything
                DrawFrame(grid);
                //Check player input
                HandlePlayerInput(grid, gridSolution, Hints);
            }
            Console.Clear();
            //Console.SetCursorPosition(0, 0);
            TimeSpan playerTime = timer.Stop();
            //Console.WriteLine("What is your name?");
            //string inputName = Console.ReadLine();
            //var equal =
            //gridSolution.Rank == LevelParser.ParseFileToArray("Level1Solution.txt").Rank &&
            //Enumerable.Range(0, grid.Rank).All(dimension => grid.GetLength(dimension) == LevelParser.ParseFileToArray("Level1Solution.txt").GetLength(dimension)) &&
            //grid.Cast<string>().SequenceEqual(LevelParser.ParseFileToArray("Level1Solution.txt").Cast<string>());
            //if (equal)
            //{
            //    PlayerRegister thisPlayer = new PlayerRegister(inputName, playerTime, 1);
            //    Players.Add(thisPlayer);
            //    Console.WriteLine($"Your name is {thisPlayer.Name} you are the {Players.Count}. to finish this sudoku!");
            //}
            //var equal2 =
            //gridSolution.Rank == LevelParser.ParseFileToArray("Level2Solution.txt").Rank &&
            //Enumerable.Range(0, grid.Rank).All(dimension => grid.GetLength(dimension) == LevelParser.ParseFileToArray("Level2Solution.txt").GetLength(dimension)) &&
            //grid.Cast<string>().SequenceEqual(LevelParser.ParseFileToArray("Level2Solution.txt").Cast<string>());
            //if (equal2)
            //{
            //    PlayerRegister thisPlayer = new PlayerRegister(inputName, playerTime, 2);
            //    Players.Add(thisPlayer);
            //    Console.WriteLine($"Your name is {thisPlayer.Name} you are the {Players.Count}. to finish this sudoku!");
            //}
            //var equal3 =
            //gridSolution.Rank == LevelParser.ParseFileToArray("Level3Solution.txt").Rank &&
            //Enumerable.Range(0, grid.Rank).All(dimension => grid.GetLength(dimension) == LevelParser.ParseFileToArray("Level3Solution.txt").GetLength(dimension)) &&
            //grid.Cast<string>().SequenceEqual(LevelParser.ParseFileToArray("Level3Solution.txt").Cast<string>());
            //if (equal3)
            //{ 
            //    PlayerRegister thisPlayer = new PlayerRegister(inputName, playerTime, 3);
            //    Players.Add(thisPlayer);
            //    Console.WriteLine($"Your name is {thisPlayer.Name} you are the {Players.Count}. to finish this sudoku!");
            //}

            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 4; i++)
            {//sudoku intro visualisation movement
                YouWonvisualisation();
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                PrintSudokuHorizontal();
                System.Threading.Thread.Sleep(300);
                Console.Clear();
            }
            BackToMenu();
        }

        public bool ContainsZero(string[,] grid)
        {
            int counter = 0;
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if (grid[y, x] == "0")
                    {
                        counter++; 
                    }
                }
            }

            if (counter > 0)
            {
                return true;
            }
            else
            {
               
                return false;
            }


        }
        public void PrintSudoku()
        {
            Console.ForegroundColor = ConsoleColor.Magenta; //HERE STARTS NAME SUDOKU VERTICALY
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("OOOOO          O   O");
            Console.SetCursorPosition(1, 6);
            Console.WriteLine("OOOOOOO        OO   OO");
            Console.SetCursorPosition(1, 7);
            Console.WriteLine("OOO  OO        OO   OO");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("OOO           OO   OO");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine("OOO          OO   OO");
            Console.SetCursorPosition(4, 10);
            Console.WriteLine("OOO         OO   OO");
            Console.SetCursorPosition(1, 11);
            Console.WriteLine("OO  OOO        OO   OO");
            Console.SetCursorPosition(1, 12);
            Console.WriteLine("OOOOOOO         OO OO");
            Console.SetCursorPosition(2, 13);
            Console.WriteLine("OOOOO           OOO");
            Console.SetCursorPosition(16, 14);
            Console.WriteLine("O     OOOOO");
            Console.SetCursorPosition(16, 15);
            Console.WriteLine("OO   OOO OOO");
            Console.SetCursorPosition(16, 16);
            Console.WriteLine("OO   OO   OO");
            Console.SetCursorPosition(16, 17);
            Console.WriteLine("OO   OO   OO");
            Console.SetCursorPosition(12, 18);
            Console.WriteLine("OOOOOO   OO   OO");
            Console.SetCursorPosition(11, 19);
            Console.WriteLine("OOO OOO   OO   OO");
            Console.SetCursorPosition(11, 20);
            Console.WriteLine("OO   OO   OO   OO");
            Console.SetCursorPosition(11, 21);
            Console.WriteLine("OOO OOO   OOO OOO");
            Console.SetCursorPosition(12, 22);
            Console.WriteLine("OOOOO     OOOOO");
            Console.SetCursorPosition(22, 23);
            Console.WriteLine("O   OO    O   O");
            Console.SetCursorPosition(21, 24);
            Console.WriteLine("OO  OO    OO   OO");
            Console.SetCursorPosition(21, 25);
            Console.WriteLine("OO OO     OO   OO");
            Console.SetCursorPosition(21, 26);
            Console.WriteLine("OOOO      OO   OO");
            Console.SetCursorPosition(21, 27);
            Console.WriteLine("OOOO      OO   OO");
            Console.SetCursorPosition(21, 28);
            Console.WriteLine("OO OO     OO   OO");
            Console.SetCursorPosition(21, 29);
            Console.WriteLine("OO  OO    OO   OO");
            Console.SetCursorPosition(21, 30);
            Console.WriteLine("OO   OO    OO OO");
            Console.SetCursorPosition(22, 31);
            Console.WriteLine("O   O      OOO");
            //HERE STARTS THE SMALL SUDOKU SQUARE CODE
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(40, 10);
            Console.WriteLine(" ______________");
            Console.SetCursorPosition(40, 11);
            Console.WriteLine("| 2  |    |  1 |");
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("|    |  4 |    |");
            Console.SetCursorPosition(40, 13);
            Console.WriteLine("|____|____|____|");
            Console.SetCursorPosition(40, 14);
            Console.WriteLine("|    |    |  9 |");
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("|    |  6 |    |");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("|____|____|____|");
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("| 8  |    |  7 |");
            Console.SetCursorPosition(40, 18);
            Console.WriteLine("|    |    |    |");
            Console.SetCursorPosition(40, 19);
            Console.WriteLine("|____|____|____|");
            Console.ResetColor();

        } //visuazlization for game intro
        static void PrintSudokuHorizontal()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("OOOOO    O   O        O    OOOOO    O   OO   O   O");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("OOOOOOO  OO   OO       OO  OOO OOO  OO  OO   OO   OO");
            Console.SetCursorPosition(1, 4);
            Console.WriteLine("OOO  OO  OO   OO       OO  OO   OO  OO OO    OO   OO");
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("OOO     OO   OO       OO  OO   OO  OOOO     OO   OO");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("OOO    OO   OO   OOOOOO  OO   OO  OOOO     OO   OO");
            Console.SetCursorPosition(4, 7);
            Console.WriteLine("OOO   OO   OO  OOO OOO  OO   OO  OO OO    OO   OO");
            Console.SetCursorPosition(1, 8);
            Console.WriteLine("OO  OOO  OO   OO  OO   OO  OO   OO  OO  OO   OO   OO");
            Console.SetCursorPosition(1, 9);
            Console.WriteLine("OOOOOOO   OO OO   OOO OOO  OOO OOO  OO   OO   OO OO");
            Console.SetCursorPosition(2, 10);
            Console.WriteLine("OOOOO     OOO     OOOOO    OOOOO    O   OO    OOO");

        } //visuazlization for game intro

        public void InfoAboutGame()
        {
            
            Console.Clear(); //after each movement clear screen and then show again
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("GAME  'SUDOKU'");
            Console.SetCursorPosition(5, 4);
            Console.WriteLine("What is Sudoku?");
            Console.SetCursorPosition(8, 6);
            Console.WriteLine("A sudoku puzzle is a grid of 9 X 9 cells");
            Console.SetCursorPosition(8, 8);
            Console.WriteLine("It has 9 subgrids of 3 X 3 cells");
            Console.SetCursorPosition(8, 10);
            Console.WriteLine("You should enter a digit in each cell so:");
            Console.SetCursorPosition(11, 12);
            Console.WriteLine(" * Each row contains each digit exactly once");
            Console.SetCursorPosition(11, 13);
            Console.WriteLine(" * Each column contains each digit exactly once");
            Console.SetCursorPosition(11, 14);
            Console.WriteLine(" * Each subgrid contains each digit exactly once");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press:");
            Console.WriteLine("1 - start new game");
            Console.WriteLine();
            Console.WriteLine("2 - info about");
            Console.WriteLine();
            Console.WriteLine("3 - exit game");
            Console.WriteLine();
            string chosedmenuitem = Console.ReadLine();

            switch (chosedmenuitem)
            {
                case "1":
                    choseLevel();
                    break;
                case "2":
                    Console.Clear();
                    PrintSudokuHorizontal();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Game was created by Gerda & Sandra");
                    Console.WriteLine();
                    Console.WriteLine("Final work for 'She Goes Tech' training.");
                    Console.WriteLine();
                    Console.WriteLine("2021, Riga");
                    Console.WriteLine();
                    BackToMenu();
                    break;
                case "3":
                    exit();
                    break;
            }

        }
        
        public void exit()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nooooooo.....don`t go away!");
            Console.WriteLine("We hope you changed your mind.");
            Console.WriteLine("Press 'Y' to exit or 'N' to go back to menu and enjoy game!");
            string exityesno = Console.ReadLine();

            switch (exityesno)
            {
                case "y":
                    Environment.Exit(0);
                    break;
                case "Y":
                    Environment.Exit(0);
                    break;
                case "n":
                    InfoAboutGame();
                    break;
                case "N":
                    InfoAboutGame();
                    break;
            }
            System.Threading.Thread.Sleep(1000000);
        }
        public void BackToMenu()
        {
            Console.WriteLine("Press 'N' to go back to menu and enjoy the game!");
            string backtomenu = Console.ReadLine();
            switch (backtomenu)
            {
                case "N":
                    InfoAboutGame();
                    break;
                case "n":
                    InfoAboutGame();
                    break;
            }
        }
        public void YouWonvisualisation()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(2, 1);
            Console.WriteLine("O   O    OOOOO    O   O       O   O    OOOOO    O OOO");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("OO   OO  OOO OOO  OO   OO     OO O OO  OOO OOO  OOOOOOO");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("OO   OO  OO   OO  OO   OO     OO O OO  OO   OO  OO  OOO");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("OO OOO  OO   OO  OO   OO     OO O OO  OO   OO  OO   OO");
            Console.SetCursorPosition(3, 5);
            Console.WriteLine("OOOOO  OO   OO  OO   OO     OO O OO  OO   OO  OO   OO");
            Console.SetCursorPosition(1, 6);
            Console.WriteLine("O    OO  OO   OO  OO   OO     OO O OO  OO   OO  OO   OO");
            Console.SetCursorPosition(1, 7);
            Console.WriteLine("OOO OOO  OOO OOO  OOO OOO     OOOOOOO  OOO OOO  OO   OO");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("OOOOO    OOOOO    OOOOO       OO OO    OOOOO    O   O");
        }
        
    }
}
