using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalTeam
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            //Read file and print first candidates list
            CandidatesRegister list1 = InOutClass.ReadCandidates(@"Kandidatai.csv");
            Console.WriteLine("List of 2021:");
            InOutClass.PrintPlayers(list1);
            Console.WriteLine();
            //Read file and print second candidates list
            CandidatesRegister list2 = InOutClass.ReadCandidates(@"Kandidatai2.csv");
            Console.WriteLine("List of 2022:");
            InOutClass.PrintPlayers(list2);
            Console.WriteLine();
            //Printing forward players who was in both camps
            CandidatesRegister bothYearFW = TaskClass.BothYearForward(list1, list2);
            Console.WriteLine("Forword players who are in both list:");
            InOutClass.PrintPlayers1(bothYearFW);
            Console.WriteLine();
            //Find and print tallest players
            int tallest = TaskClass.FindTalleatPLayers(list1, list2);
            CandidatesRegister list3 = new CandidatesRegister();
            TaskClass.MaxHeight(list3, list1, tallest);
            TaskClass.MaxHeight(list3, list2, tallest);
            Console.WriteLine("Tallest players:");
            InOutClass.PrintHightest(list3);
            // Make and print team names to CSV file
            List<string> TeamName = new List<string>();
            list1.TeamNames(TeamName);
            list2.TeamNames(TeamName);
            InOutClass.PrintTeamsToCSVFile("Klubai.csv", TeamName);
            Console.WriteLine("Programa darbą baigė!!");
        }
    }
}
