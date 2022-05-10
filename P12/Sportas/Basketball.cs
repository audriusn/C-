using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportas
{
    public class Basketball : Player 
    {
     
        public int Rebouds { get; set; }
        public int Assist { get; set; }
        public Basketball (string TeamName, string Name, string Surname, DateTime birthDate, int GamePlay, int Score, int Rebouds, int Assist) : base (TeamName, Name, Surname, birthDate, GamePlay, Score)
        {
            this.Rebouds = Rebouds;
            this.Assist = Assist;
        }
    }
}
