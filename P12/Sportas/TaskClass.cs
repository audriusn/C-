using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportas
{
    class TaskClass
    {
        public static PlayerConatiner Filtered(PlayerConatiner players, TeamRegister Teams)
        {
            PlayerConatiner Filtered = new PlayerConatiner();

            for (int i = 0; i < players.Count; i++)
            {
                for (int j = 0; j < Teams.TeamCount(); j++)
                {
                    if (Teams.GetTeam(j).TeamName == players.Get(i).TeamName && Teams.GetTeam(j).PlayedGame == players.Get(i).GamePlay && players.Get(i).Score >= players.GetTotalPointScored(players, players.Get(i).TeamName))
                    {
                        Filtered.Add(players.Get(i));
                    }
                }
            }
            return Filtered;
        }
    }
}
