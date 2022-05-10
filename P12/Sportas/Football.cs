using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportas
{
    internal class Football : Player
    {
        public int YellowCards { get; set; }
     
        public Football(string TeamName, string Name, string Surname, DateTime birthDate, int GamePlay, int Score, int YellowCards) : base(TeamName, Name, Surname, birthDate, GamePlay, Score)
        {
            this.YellowCards = YellowCards;
            
        }
    }
}
