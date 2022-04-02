using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace National_Team
{
    static class InOutClass
    {
        public static CandidatesContainer ReadCandidates(string filename)
        {
            CandidatesContainer Players = new CandidatesContainer();
            StreamReader read = new StreamReader(filename);
            int bYear = int.Parse(read.ReadLine());
            Players.bYear = bYear;
            DateTime CampStart = DateTime.Parse(read.ReadLine());
            Players.CampStart = CampStart;
            DateTime CampEnd = DateTime.Parse(read.ReadLine());
            Players.CampEnd = CampEnd;
            string lines;
            while ((lines = read.ReadLine()) != null)
            {
                string[] Values = lines.Split(';');
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
                Candidates candidates = new Candidates(Name, Surname, BirthDate, Height, Position, TeamName, Candidate, Captain);

                if (!Players.Contains(candidates))
                {
                    Players.Add(candidates);
                }
            }
            return Players;
        }

        public static void PrintPlayers(CandidatesContainer cand)
        {
            if (cand.Count != 0)
            {
                Console.WriteLine("{0} years camp candidates list. Camp start: {1,10:yyyy-MM-dd}. End: {2,10:yyyy-MM-dd}", cand.bYear, cand.CampStart, cand.CampEnd);
                Console.WriteLine(new string('-', 120));
                Console.WriteLine(" {0,-10} {1,-10}  {2,-12} {3,-8} {4,-18} {5,-18} {6,-15} {7}", "Name", "Surname", "BirthDate", "Height", "Position", "TeamName", "Candidate", "Captain");
                Console.WriteLine(new string('-', 120));
                for (int i = 0; i < cand.Count; i++)
                {
                    Candidates candidate = cand.Get(i);
                    Console.WriteLine(" {0,-10} {1,-10}  {2,-12:yyyy-MM-dd} {3,-8} {4,-18} {5,-18} {6,-15} {7} ", candidate.Name, candidate.Surname, candidate.BirthDate, candidate.Height, candidate.Position,
                          candidate.TeamName, candidate.Candidate, candidate.Captain);
                }
                Console.WriteLine(new string('-', 120));
            }
            else
                Console.WriteLine("Sorry, there are no data in file!!!");
        }
        public static void PrintPlayers1(CandidatesContainer cand)
        {
            if (cand.Count != 0)
            {
                Console.WriteLine(new string('-', 120));
                Console.WriteLine(" {0,-10} {1,-10}  {2,-12} ", "Name", "Surname", "Height");
                Console.WriteLine(new string('-', 120));
                for (int i = 0; i < cand.Count; i++)
                {
                    Candidates candidate = cand.Get(i);
                    Console.WriteLine(" {0,-10} {1,-10}  {2,-12}", candidate.Name, candidate.Surname, candidate.Height);
                }
                Console.WriteLine(new string('-', 120));
            }
            else
                Console.WriteLine("Sorry, there are no players who a in both year list's ant playing forward.");
        }
        public static void PrintHightest(CandidatesContainer cand)
        {
            if (cand.Count != 0)
            {
                Console.WriteLine("Tallest players:");
                Console.WriteLine(new string('-', 120));
                Console.WriteLine(" {0,-10} {1,-10}  {2,-12} {3,-8} {4,-18} {5,-18} {6,-15} {7}", "Name", "Surname", "BirthDate", "Height", "Position", "TeamName", "Candidate", "Captain");
                Console.WriteLine(new string('-', 120));
                for (int i = 0; i < cand.Count; i++)
                {
                    Candidates candidate = cand.Get(i);
                    Console.WriteLine(" {0,-10} {1,-10}  {2,-12:yyyy-MM-dd} {3,-8} {4,-18} {5,-18} {6,-15} {7} ", candidate.Name, candidate.Surname, candidate.BirthDate, candidate.Height, candidate.Position,
                          candidate.TeamName, candidate.Candidate, candidate.Captain);
                }
                Console.WriteLine(new string('-', 120));
            }
            else
                Console.WriteLine("Sorry,something wrong. We can't find players height.");
        }
        public static void Print(CandidatesContainer cand)
        {
            if (cand.Count != 0)
            {
                Console.WriteLine(new string('-', 120));
                Console.WriteLine(" {0,-10} {1,-10}  {2,-12} {3,-8} {4,-18} {5,-18} {6,-15} {7}", "Name", "Surname", "BirthDate", "Height", "Position", "TeamName", "Candidate", "Captain");
                Console.WriteLine(new string('-', 120));
                for (int i = 0; i < cand.Count; i++)
                {
                    Candidates candidate = cand.Get(i);
                    Console.WriteLine(" {0,-10} {1,-10}  {2,-12:yyyy-MM-dd} {3,-8} {4,-18} {5,-18} {6,-15} {7} ", candidate.Name, candidate.Surname, candidate.BirthDate, candidate.Height, candidate.Position,
                          candidate.TeamName, candidate.Candidate, candidate.Captain);
                }
                Console.WriteLine(new string('-', 120));
            }
            else
                Console.WriteLine("Sorry,something wrong. There a no players in a list.");
        }
        public static void PrintCandidatesToCSVFile(string fileName, CandidatesContainer cand)
        {
            if (cand.Count > 0)
            {
                string[] lines = new string[cand.Count + 1];
                lines[0] = String.Format(" {0,-10}, {1,-10},  {2,-12}, {3,-8}, {4,-18}, {5,-18}, {6,-15}, {7}", "Name", "Surname", "BirthDate", "Height", "Position", "TeamName", "Candidate", "Captain");
                for (int i = 0; i < cand.Count; i++)
                {
                    Candidates candidate = cand.Get(i);
                    lines[i + 1] = String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7} ", candidate.Name, candidate.Surname, candidate.BirthDate, candidate.Height, candidate.Position,
                          candidate.TeamName, candidate.Candidate, candidate.Captain);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
                Console.WriteLine("The list of national team candidates is empty.");
        }
        public static void PrintTeamsToCSVFile(string fileName, List<string> Teams)
        {
            if (Teams.Count() > 0)
            {

                string[] lines = new string[Teams.Count() + 1];
                lines[0] = String.Format(" {0}", "TeamNames:");
                for (int i = 0; i < Teams.Count(); i++)
                {
                    lines[i + 1] = String.Format(" {0} ", Teams[i]);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
                Console.WriteLine("The list of team names is empty.");
        }
    }
 }
