using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball_Team
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            PlayerContainer allPlayers = new PlayerContainer();
            StaffContainer allStaff = new StaffContainer();
            // Read files
            MemberContainer members2020 = InOutClass.ReadPlayers(@"Kandidatai2020.csv", allPlayers, allStaff);
            MemberContainer members2021 = InOutClass.ReadPlayers(@"Kandidatai2021.csv", allPlayers, allStaff);
            MemberContainer members2022 = InOutClass.ReadPlayers(@"Kandidatai2022.csv", allPlayers, allStaff);
            //Make a container of all years members
            MemberContainer allCampsMember = MemberContainer.AllYearMember(members2020, members2021, members2022);
            Console.WriteLine("Members who was invited in all camps:");
            InOutClass.PrintPlayers(allCampsMember);
            Console.WriteLine("");
            // Make a contaiber of forward players in all camps
            PlayerContainer allCampsForward = PlayerContainer.AllYearForward(allPlayers, members2020, members2021);
            PlayerContainer allCampsForward1 = PlayerContainer.AllYearForward(allCampsForward, members2021, members2022);
            Console.WriteLine("Forward players who was invited in all camps:");
            InOutClass.PrintAllYearsForward(allCampsForward1);
            Console.WriteLine("");
            // Make a coach list
            StaffContainer allCoach = allStaff.FindCoach();
            Console.WriteLine("Coaches:");
            InOutClass.PrintCoach(allCoach);
            Console.WriteLine("");
            // All list sorted by birthday
            Console.WriteLine("2020 member list sorted by birthdate");
            members2020.Sort(new MembersComparatorByBirthDate());
            InOutClass.PrintPlayers(members2020);
            Console.WriteLine("");
            Console.WriteLine("2021 member list sorted by birthdate");
            members2021.Sort(new MembersComparatorByBirthDate());
            InOutClass.PrintPlayers(members2021);
            Console.WriteLine("");
            Console.WriteLine("2022 member list sorted by birthdate");
            members2022.Sort(new MembersComparatorByBirthDate());
            InOutClass.PrintPlayers(members2022);
            Console.WriteLine("");
            //Make all invited players container and print to CSV file
            PlayerContainer invitedPlayers = allPlayers.MarkAsInvited();
            InOutClass.PrintCandidatesToCSVFile("Rinktinė.csv", invitedPlayers);
            //Print staff list to CSV file
            InOutClass.PrintStaffToCSVFile("Personalas.csv", allStaff);
            Console.WriteLine("It's all done!!");
        }
    }
}
