using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace Sportas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            PlayerConatiner allPlayers = InOutClass.ReadPlayers(@"Players.csv");
            InOutClass.PrintPlayers("All players:", allPlayers);
            TeamRegister allTeams = InOutClass.ReadTeams(@"teams.csv");
            InOutClass.PrintTeams(allTeams);
            Console.WriteLine("Kokio miesto žaidėjus atrinkti?");
            string City = Console.ReadLine();
            TeamRegister filtered = allTeams.FilterByCity(City);
            InOutClass.PrintTeams(filtered);
           
            PlayerConatiner FilteredBYTask = TaskClass.Filtered(allPlayers, filtered);
            InOutClass.PrintPlayers1("Filtered:", FilteredBYTask);

            Console.WriteLine("It's all done!");
        }
    }
}
