using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalTeam
{
     class CandidatesRegister
    {
        private List<Candidates> AllPlayers;
        public CandidatesRegister()
        {
            AllPlayers = new List<Candidates>();
        }
        public CandidatesRegister(List<Candidates> Players)
        {
            AllPlayers = new List<Candidates>();
            foreach (Candidates players in Players)
            {
                this.AllPlayers.Add(players);
            }
        }
        public void Add(Candidates players)
        {
            AllPlayers.Add(players);
        }
        public bool Contains(Candidates players)
        {
            return AllPlayers.Contains(players);
        }
        public int CandidatesCount()
        {
            return this.AllPlayers.Count;
        }
        public Candidates GetPlayers(int index)
        {
            return this.AllPlayers[index];
        }
        public int TallestPLayer()
        {
            int maxHeight = int.MinValue;
            foreach (Candidates players in this.AllPlayers)
            {
                if (players.Height > maxHeight)
                    maxHeight = players.Height;
            }
            return maxHeight;
        }

        public List<string> TeamNames(List<string> TeamName)
        {
            foreach (Candidates players in this.AllPlayers)
            {
                if (!TeamName.Contains(players.TeamName))

                    TeamName.Add(players.TeamName);
            }
            return TeamName;
        }
    }
}
