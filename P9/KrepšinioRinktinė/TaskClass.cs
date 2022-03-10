using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrepšinioRinktinė
{
    static class TaskClass
    {
    /// <summary>
    ///  Finf oldest players from list
    /// </summary>
    /// <param name="Players"></param>
    /// <returns></returns>
        public static Kandidatai FindOldestPlayer(List<Kandidatai> Players)
        {
            Kandidatai oldest = Players[0]; //mean least value
            for (int i = 1; i < Players.Count; i++)
            {
                if (DateTime.Compare(Players[i].BirthDate, oldest.BirthDate) < 0)
                {
                    oldest = Players[i];
                }
            }
            return oldest;
        }
        /// <summary>
        /// Make oldest players list if there are more than one
        /// </summary>
        /// <param name="Players"></param>
        /// <returns></returns>
        public static List<Kandidatai> MakeOldestList(List<Kandidatai> Players)
        {
            List<Kandidatai> OldPlayers = new List<Kandidatai>();
            int oldest = FindOldestPlayer(Players).CalculateAge();
            foreach (Kandidatai players in Players)
            {
                if (players.CalculateAge().Equals(oldest) && oldest == FindOldestPlayer(Players).CalculateAge())
                {
                    OldPlayers.Add(players);
                }
            }
            return OldPlayers;
        }
        /// <summary>
        /// Make a list of players with position = "Puolėjas"
        /// </summary>
        /// <param name="Players"></param>
        /// <returns></returns>

        public static List<Kandidatai> FindPuolėjai(List<Kandidatai> Players)
        {
            List<Kandidatai> Puolėjai = new List<Kandidatai>();
            
            foreach (Kandidatai players in Players)
            {
                if (players.Position =="Puolėjas")
                {
                    Puolėjai.Add(players);
                }
            }
            return Puolėjai;
        }
        /// <summary>
        /// Maka a list of players with mark candidate = TRUE
        /// </summary>
        /// <param name="Players"></param>
        /// <param name="Candidate"></param>
        /// <returns></returns>
        public static List<Kandidatai> CandidateToCsv(List<Kandidatai> Players, Mark Candidate)
        {
            List<Kandidatai> NatTeamCandidate = new List<Kandidatai>();
            foreach (Kandidatai players in Players)
            {
                if (players.Candidate.Equals(Candidate))
                    NatTeamCandidate.Add(players);
            }
            return NatTeamCandidate;
        }

    }
}
