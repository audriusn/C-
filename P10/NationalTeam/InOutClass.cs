using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace NationalTeam
{
    static class InOutClass
    {
        public static CandidatesRegister ReadCandidates(string filename)
        {
            CandidatesRegister Players = new CandidatesRegister();
            StreamReader read = new StreamReader(filename);
            int bYear = int.Parse(read.ReadLine());
            DateTime CampStart = DateTime.Parse(read.ReadLine());
            DateTime CampEnd = DateTime.Parse(read.ReadLine());
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

        public static void PrintPlayers(CandidatesRegister cand)
        {
            if (cand.CandidatesCount() != 0)
            {
                Console.WriteLine(new string('-', 120));
            Console.WriteLine(" {0,-10} {1,-10}  {2,-12} {3,-8} {4,-18} {5,-18} {6,-15} {7}", "Name", "Surname", "BirthDate", "Height", "Position", "TeamName", "Candidate", "Captain");
            Console.WriteLine(new string('-', 120));
            for (int i = 0; i < cand.CandidatesCount(); i++)
            {
                Console.WriteLine(" {0,-10} {1,-10}  {2,-12:yyyy-MM-dd} {3,-8} {4,-18} {5,-18} {6,-15} {7} ", cand.GetPlayers(i).Name, cand.GetPlayers(i).Surname, cand.GetPlayers(i).BirthDate, cand.GetPlayers(i).Height, cand.GetPlayers(i).Position,
                      cand.GetPlayers(i).TeamName, cand.GetPlayers(i).Candidate, cand.GetPlayers(i).Captain);
            }
            Console.WriteLine(new string('-', 120));
            }
            else
                Console.WriteLine("Sorry, there are no data in file!!!");
        }
        public static void PrintPlayers1(CandidatesRegister cand)
        {
            if (cand.CandidatesCount() != 0)
            {
                Console.WriteLine(new string('-', 120));
                Console.WriteLine(" {0,-10} {1,-10}  {2,-12} ", "Name", "Surname", "Height");
                Console.WriteLine(new string('-', 120));
                for (int i = 0; i < cand.CandidatesCount(); i++)
                {
                    Console.WriteLine(" {0,-10} {1,-10}  {2,-12}", cand.GetPlayers(i).Name, cand.GetPlayers(i).Surname, cand.GetPlayers(i).Height);
                }
                Console.WriteLine(new string('-', 120));
            }
            else
                Console.WriteLine("Sorry, there are no players who a in both year list's ant playing forward.");
        }
        public static void PrintHightest(CandidatesRegister cand)
        {
            if (cand.CandidatesCount() != 0)
            {
                Console.WriteLine(new string('-', 120));
                Console.WriteLine(" {0,-10} {1,-10}  {2,-12} ", "Name", "Surname", "Old");
                Console.WriteLine(new string('-', 120));
                for (int i = 0; i < cand.CandidatesCount(); i++)
                {
                    Console.WriteLine(" {0,-10} {1,-10}  {2,-12}", cand.GetPlayers(i).Name, cand.GetPlayers(i).Surname, cand.GetPlayers(i).CalculateAge());
                }
                Console.WriteLine(new string('-', 120));
            }
            else
                Console.WriteLine("Sorry, there are no players who a in both year list's ant playing forward.");
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
