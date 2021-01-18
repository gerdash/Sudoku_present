using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FinalProjectSudoku
{
    class Levels
    {
        //for now only 2 options for easy and medium levels.To check how ths will work. This is work in progress...
        public string PathToEasyEmpty1_1 = @"C:\Users\Sandra Aunina\source\repos\Sudoku_finalProject\easyleveltxtfiles\EasyEmpty1.txt";
        string PathToEasySolution1_1 = @"C:\Users\Sandra Aunina\source\repos\Sudoku_finalProject\easyleveltxtfiles\EasySolution1.txt";
        string PathToEasyEmpty1_2 = @"C:\Users\Sandra Aunina\source\repos\Sudoku_finalProject\easyleveltxtfiles\EasyEmpty2.txt";
        string PathToEasySolution1_2 = @"C:\Users\Sandra Aunina\source\repos\Sudoku_finalProject\easyleveltxtfiles\EasySolution2.txt";
        string PathToMediumEmpty2_1 = @"C:\Users\Sandra Aunina\source\repos\Sudoku_finalProject\mediumleveltxtfiles\mediumlevelempty1.txt";
        string PathToMediumSolution2_1 = @"C:\Users\Sandra Aunina\source\repos\Sudoku_finalProject\mediumleveltxtfiles\mediumlevelsolution1.txt";
        string PathToMediumEmpty2_2 = @"C:\Users\Sandra Aunina\source\repos\Sudoku_finalProject\mediumleveltxtfiles\mediumlevelempty2.txt";
        string PathToMediumSolution2_2 = @"C:\Users\Sandra Aunina\source\repos\Sudoku_finalProject\mediumleveltxtfiles\mediumlevelsolution2.txt";

        public void PrintFromFileGrid1_1_Empty()
        {
            //to read all lines from 1.level emty grid
            string[] EasylevelEmpty1_1text = File.ReadAllLines(PathToEasyEmpty1_1);
            //foreach (var item in EasylevelEmpty1_1text)
            //{
            //    Console.WriteLine(item);
            //}
            string[] EasylevelEmpty1_1split = EasylevelEmpty1_1text[0].Split(" "); //split each number with empty space, all lines.
            foreach (var item in EasylevelEmpty1_1split)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}
