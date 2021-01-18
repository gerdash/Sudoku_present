using System;

namespace inspo_maze
{
    class Program
    {
        static void Main(string[] args)
        {

            Game myGame = new Game();
            Console.Title = "THE BEST SUDOKU EVER!";
            Console.SetWindowSize(90, 32);
            DisplayIntro(myGame);
            myGame.Start();

        }
        public static void ChoseLevel(Game myGame)
        {
            Console.CursorVisible = false;
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
            myGame.Start();

        }
        public static void DisplayIntro(Game myGame)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < 2; i++) //sudoku intro visualisation movement
            {
                PrintSudokuHorizontal();
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                PrintSudoku();
                System.Threading.Thread.Sleep(300);
                Console.Clear();
            }
            InfoAboutGame(myGame);
            Console.WriteLine();
        }
        public static void PrintSudoku()
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

        }
        public static void PrintSudokuHorizontal()
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

        public static void InfoAboutGame(Game myGame)
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
                    ChoseLevel(myGame);
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
                    BackToMenu(myGame);
                    break;
                case "3":
                    exit(myGame);
                    break;
            }
        }
        public static void exit(Game myGame)
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
                    DisplayIntro(myGame);
                    myGame.Start();
                    break;
                case "N":
                    DisplayIntro(myGame);
                    myGame.Start();
                    break;
            }
            System.Threading.Thread.Sleep(1000000);
        }
        public static void BackToMenu(Game myGame)
        {
            Console.WriteLine("Press 'N' to go back to menu and enjoy the game!");
            string backtomenu = Console.ReadLine();
            switch (backtomenu)
            {
                case "N":
                    InfoAboutGame(myGame);
                    myGame.Start();
                    break;
                case "n":
                    InfoAboutGame(myGame);
                    myGame.Start();
                    break;
            }
        }
    }
}
        
