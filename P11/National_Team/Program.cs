using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Team
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            //Read file and print first candidates list
            CandidatesContainer cont1 = InOutClass.ReadCandidates(@"Kandidatai.csv");
            InOutClass.PrintPlayers(cont1);
            Console.WriteLine();
            //Read file and print second candidates list
            CandidatesContainer cont2 = InOutClass.ReadCandidates(@"Kandidatai2.csv");
            InOutClass.PrintPlayers(cont2);
            Console.WriteLine();
            //Find and print tallest players
            int tallest = TaskClass.FindTalleatPLayers(cont1, cont2);
            CandidatesContainer list3 = new CandidatesContainer();
            TaskClass.MaxHeight(list3, cont1, tallest);
            TaskClass.MaxHeight(list3, cont2, tallest);
            InOutClass.PrintHightest(list3);
            //Printing forward players who was in both camps
            CandidatesContainer bothYearFW = TaskClass.BothYearForward(cont1, cont2);
            Console.WriteLine("Forward players who are in both list:");
            bothYearFW.Sort();
            InOutClass.PrintPlayers1(bothYearFW);
            Console.WriteLine();
            CandidatesContainer NationalTeam = TaskClass.NationalTeam(cont1);
            CandidatesContainer NationalTeam2 = TaskClass.NationalTeam(cont2);
            CandidatesContainer FinalCandidates = TaskClass.BothYearsCandidates(NationalTeam, NationalTeam2);
            InOutClass.PrintCandidatesToCSVFile("Rinktinė.csv",FinalCandidates);
            List<string> TeamName = cont1.TeamNames(cont1);     
            InOutClass.PrintTeamsToCSVFile("Klubai.csv", TeamName);
            Console.WriteLine("It's all done!!");



        }
    }
}
