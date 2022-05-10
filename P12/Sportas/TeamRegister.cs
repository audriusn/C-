using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportas
{
     class TeamRegister
    {
        private List<Teams> allTeams;
        public TeamRegister()
        {
            allTeams = new List<Teams>();
        }
        public TeamRegister(List<Teams> Teams)
        {
            allTeams = new List<Teams>();
            foreach (Teams team in Teams)
            {
                this.allTeams.Add(team);
            }
        }
   
        public void Add(Teams Teams)
        {
            allTeams.Add(Teams);
        }
        public bool Contains(Teams Teams)
        {
            return allTeams.Contains(Teams);
        }
        public int TeamCount()
        {
            return this.allTeams.Count;
        }
        public Teams GetTeam(int index)
        {
            return this.allTeams[index];
        }
        public TeamRegister FilterByCity(string city)
        {
            List<Teams> filtered = new List<Teams>();
            foreach (Teams team in allTeams)
            {
                if (team.City == city)
                {
                    filtered.Add(team);
                }
            }
            return new TeamRegister(filtered);
        }

    }
}
