using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Basketball_Team
{
    static class InOutClass
    {
        public static MemberContainer ReadPlayers(string filename, PlayerContainer Players, StaffContainer Staff)
        {
            MemberContainer Members = new MemberContainer();
            StreamReader read = new StreamReader(filename);
            int bYear = int.Parse(read.ReadLine());
            Members.bYear = bYear;
            DateTime CampStart = DateTime.Parse(read.ReadLine());
            Members.CampStart = CampStart;
            DateTime CampEnd = DateTime.Parse(read.ReadLine());
            Members.CampEnd = CampEnd;
            string lines;
              while ((lines =read.ReadLine()) !=null)
            {
                string[] Values = lines.Split(';');
                string type = Values[0];
                string Name = Values[1];
                string Surname = Values[2];
                DateTime birthDate = DateTime.Parse(Values[3]);
                switch (type)
                {
                    case "Player":
                        int Height = int.Parse(Values[4]);
                        string Position = Values[5];
                        string TeamName = Values[6];
                        Mark Candidate;
                        Enum.TryParse(Values[7], out Candidate);
                        Mark Captain;
                        Enum.TryParse(Values[8], out Captain);
                        Player player = new Player(Name, Surname, birthDate, Height, Position, TeamName, Candidate, Captain);
                        if(!Members.Contains(player))
                        {
                            Members.Add(player);
                        }
                        if (!Players.Contains(player))
                         {
                            Players.Add(player);
                        }                      
                        break;
                    case "Staff":
                        string jobTitle = Values[4];
                        Staff staf = new Staff(Name, Surname, birthDate, jobTitle);
                        if (!Members.Contains(staf))
                        {
                            Members.Add(staf);
                        }
                        if (!Staff.Contains(staf))
                        {
                            Staff.Add(staf);
                        }
                        break;
                    default:
                        break; //unknown type
                }
            }
            return Members;
        }
        public static void PrintPlayers(MemberContainer member)
        {
            if (member.Count != 0)
            {
                Console.WriteLine(new string('-', 36));
                Console.WriteLine(" {0,-10} {1,-10}  {2,-12}", "Name", "Surname", "BirthDate");
                Console.WriteLine(new string('-', 36));
                for (int i = 0; i < member.Count; i++)
                {
                    Member candidate = member.Get(i);
                    Console.WriteLine(" {0,-10} {1,-10}  {2,-12:yyyy-MM-dd}", candidate.Name, candidate.Surname, candidate.BirthDate);
                }
                Console.WriteLine(new string('-', 36));
            }
            else
                Console.WriteLine("Sorry, there are no members who was invited to camp 3 years in a row.");
        }
        public static void PrintAllYearsForward(PlayerContainer cand)
        {
            if (cand.Count != 0)
            {
                Console.WriteLine(new string('-', 36));
                Console.WriteLine(" {0,-10} {1,-10}  {2,-12} ", "Name", "Surname", "Height");
                Console.WriteLine(new string('-', 36));
                for (int i = 0; i < cand.Count; i++)
                {
                    Player candidate = cand.Get(i);
                    Console.WriteLine(" {0,-10} {1,-10}  {2,-12}", candidate.Name, candidate.Surname, candidate.Height);
                }
                Console.WriteLine(new string('-', 36));
            }
            else
                Console.WriteLine("Sorry, there are no players who a in all year list's ant playing forward.");
        }
        public static void PrintCoach(StaffContainer staff)
        {
            if (staff.Count != 0)
            {
                Console.WriteLine(new string('-', 36));
                Console.WriteLine(" {0,-10} {1,-10}  {2,-12} ", "Name", "Surname", "Height");
                Console.WriteLine(new string('-', 36));
                for (int i = 0; i < staff.Count; i++)
                {
                    Staff staf = staff.Get(i);
                    Console.WriteLine(" {0,-10} {1,-10}  {2,-12:yyyy-MM-dd}", staf.Name, staf.Surname, staf.BirthDate);
                }
                Console.WriteLine(new string('-', 36));
            }
            else
                Console.WriteLine("Sorry, there are no coaches");
        }
        public static void PrintCandidatesToCSVFile(string fileName, PlayerContainer cand)
        {
            if (cand.Count > 0)
            {
                string[] lines = new string[cand.Count + 1];
                lines[0] = String.Format(" {0,-10}, {1,-10},  {2,-12}, {3,-8}, {4,-18}, {5,-18}, {6,-15}, {7}", "Name", "Surname", "BirthDate", "Height", "Position", "TeamName", "Candidate", "Captain");
                for (int i = 0; i < cand.Count; i++)
                {
                    Player candidate = cand.Get(i);
                    lines[i + 1] = String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7} ", candidate.Name, candidate.Surname, candidate.BirthDate, candidate.Height, candidate.Position,
                          candidate.TeamName, candidate.Candidate, candidate.Captain);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
                Console.WriteLine("Information about players was printed in {0}.", fileName);
            }
            else
                Console.WriteLine("The list of national team candidates is empty.");
        }
        public static void PrintStaffToCSVFile(string fileName, StaffContainer cand)
        {
            if (cand.Count > 0)
            {
                string[] lines = new string[cand.Count + 1];
                lines[0] = String.Format(" {0,-10}, {1,-10},  {2,-12}, {3,-8}", "Name", "Surname", "BirthDate", "Job Title");
                for (int i = 0; i < cand.Count; i++)
                {
                    Staff candidate = cand.Get(i);
                    lines[i + 1] = String.Format("{0}, {1}, {2}, {3}", candidate.Name, candidate.Surname, candidate.BirthDate, candidate.jobTitle);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
                Console.WriteLine("Information about Staff was printed in {0}.", fileName);
            }
            else
                Console.WriteLine("The list of staff is empty.");
        }
    }
}
