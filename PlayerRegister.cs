using System;

namespace FinalProjectSudoku
{
    public class PlayerRegister
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; } 
        public int LevelPlayed { get; set; }

        public PlayerRegister(string name, TimeSpan timeElapsed, int levelPlayed)
        {
            Name = name;
            Duration = timeElapsed;
            LevelPlayed = levelPlayed;
        }
        
    }
}