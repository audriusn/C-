using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace National_Team_GUI
{
    internal class InOutClass
    {
        /// <summary>
        /// Reading file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Kandidatai> ReadKandidatai(string fileName)
        {
            List<Kandidatai> players = new List<Kandidatai>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string Name = Values[0];
                string Surname = Values[1];
                DateTime BirthDate = DateTime.Parse(Values[2]);
                int Height = int.Parse(Values[3]);
                string Position = Values[4];
                string TeamName = Values[5];
                Mark Candidate;
                Enum.TryParse(Values[6], out Candidate);
                Mark Captain;
                Enum.TryParse(Values[7], out Captain);

                Kandidatai candidates = new Kandidatai(Name, Surname, BirthDate, Height, Position, TeamName, Candidate, Captain);
                players.Add(candidates);
            }
            return players;
        }
        /// <summary>
        /// Printing all list of players
        /// </summary>
        /// <param name="players"></param>
        public static void PrintPlayers(List<Kandidatai> players)
        {
            Console.WriteLine(new string('-', 120));
            Console.WriteLine(" {0,-10} {1,-10}  {2,-12} {3,-8} {4,-18} {5,-18} {6,-15} {7}", "Name", "Surname", "BirthDate", "Height", "Position", "TeamName", "Candidate", "Captain");
            Console.WriteLine(new string('-', 120));
            foreach (Kandidatai player in players)
            {
                Console.WriteLine(" {0,-10} {1,-10}  {2,-12:yyyy-MM-dd} {3,-8} {4,-18} {5,-18} {6,-15} {7} ", player.Name, player.Surname, player.BirthDate, player.Height, player.Position,
                    player.TeamName, player.Candidate, player.Captain);
            }
            Console.WriteLine(new string('-', 120));
        }
        /// <summary>
        /// Printing in console oldest player
        /// </summary>
        /// <param name="players"></param>
        public static void PrintOldestList(List<Kandidatai> players)
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine(" {0,-10} {1,-10} {2,-10} ", "Name:", "Surname:", "Old:");
            Console.WriteLine(new string('-', 30));
            foreach (Kandidatai player in players)
            {
                Console.WriteLine(" {0,-10} {1,-10} {2,-10}", player.Name, player.Surname, player.CalculateAge());
            }
            Console.WriteLine(new string('-', 30));
        }
        /// <summary>
        /// Printing in console list of players with position "Puolėjas"
        /// </summary>
        /// <param name="players"></param>
        public static void PrintPuolėjai(List<Kandidatai> players)
        {
            if (players.Count > 0)
            {
                Console.WriteLine(new string('-', 30));
                Console.WriteLine(" {0,-10} {1,-10} {2,-10} ", "Name:", "Surname:", "Height:");
                Console.WriteLine(new string('-', 30));
                foreach (Kandidatai player in players)
                {
                    Console.WriteLine(" {0,-10} {1,-10} {2,-10}", player.Name, player.Surname, player.Height);
                }
                Console.WriteLine(new string('-', 30));
            }
            else
                Console.WriteLine("Kandidatų sąraše puolėjų nėra");
        }
        /// <summary>
        /// Printing players to CSV file Candidate = TRUE
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Players"></param>
        public static void PrintPlyersToCSVFile(string fileName, List<Kandidatai> Players)
        {
            if (Players.Count > 0)
            {
                string[] lines = new string[Players.Count + 1];
                lines[0] = String.Format(" {0},{1},{2},{3},{4},{5},{6},{7}", "Name", "Surname", "BirthDate", "Height", "Position", "TeamName", "Candidate", "Captain"); ;
                for (int i = 0; i < Players.Count; i++)
                {
                    lines[i + 1] = String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", Players[i].Name, Players[i].Surname, Players[i].BirthDate, Players[i].Height, Players[i].Position,
                     Players[i].TeamName, Players[i].Candidate, Players[i].Captain);

                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
                Console.WriteLine("Sorry, there are no candidates fot national team");

        }
    }
}
