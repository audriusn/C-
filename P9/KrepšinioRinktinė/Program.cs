using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrepšinioRinktinė
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            List<Kandidatai> AllPlayers = InOutClass.ReadKandidatai(@"Kandidatai.csv");
            Console.WriteLine("Player list:");
            InOutClass.PrintPlayers(AllPlayers);
            Kandidatai oldest = TaskClass.FindOldestPlayer(AllPlayers);
            List<Kandidatai> Oldest = TaskClass.MakeOldestList(AllPlayers);
            InOutClass.PrintOldestList(Oldest);
            List<Kandidatai> Puolėjai = TaskClass.FindPuolėjai(AllPlayers);
            InOutClass.PrintPuolėjai(Puolėjai);
            List<Kandidatai> NationalTeam = TaskClass.CandidateToCsv(AllPlayers,Mark.TRUE);
            InOutClass.PrintPlyersToCSVFile("Rinktinė.csv", NationalTeam);

        }
    }
}
