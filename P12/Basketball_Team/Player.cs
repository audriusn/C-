using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball_Team
{
    class Player : Member
    {

        public int Height { get; set; }
        public string Position { get; set; }
        public string TeamName { get; set; }
        public Mark Candidate { get; set; }
        public Mark Captain { get; set; }
        public Player(string Name, string Surname, DateTime BirthDate, int Height, string Position, string TeamName, Mark Candidate, Mark Captai) : base(Name, Surname, BirthDate)
        {
            this.Height = Height;
            this.Position = Position;
            this.TeamName = TeamName;
            this.Candidate = Candidate;
            this.Captain = Captai;
        }
      
    }
}
