using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportas
{
     class Teams
    {
        public string TeamName { get; set; }
        public string City { get; set; }
        public string Coach { get; set; }
        public int PlayedGame { get; set; }
        public Teams(string TeamName, string City, string Coach, int PlayedGame)
        {
            this.TeamName = TeamName;
            this.City = City;
            this.Coach = Coach;
            this.PlayedGame = PlayedGame;
        }

        public override bool Equals(object other)
        {
            {
                return this.TeamName == ((Teams)other).TeamName;
            }
        }
        public override int GetHashCode()
        {
            return this.TeamName.GetHashCode();
        }
       

    }
}
