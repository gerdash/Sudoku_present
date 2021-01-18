using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSudoku
{
    public class TimeOfTheGame
    {
        public DateTime _start;
        public DateTime _stop;
        public bool _isRunning;

        public TimeOfTheGame()
        {
            _start = new DateTime();
            _stop = new DateTime();
            _isRunning = false;
        }
        public void Start()
        {
            //handling exceptions with throw?? 

            _start = DateTime.Now;
            _isRunning = true; //while !gameFinished this timer is on
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"The time is: {_start.Hour} : {_start.Minute} : {_start.Second}");
            Console.WriteLine("Your game starts now!!!");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);
        }
        public TimeSpan Stop()
        {
            _stop = DateTime.Now;
            _isRunning = false;
            TimeSpan duration = _stop - _start;
            Duration(duration);
            return duration;
        }
        public void Duration(TimeSpan duration)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"You finished this puzzle in {duration.Minutes} min {duration.Seconds} sec");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
