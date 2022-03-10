using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turistai
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            List<Narys> allmembers = InOutClass.ReadMembers(@"turistai.csv");
            Console.WriteLine("Turistų grupė:");
            InOutClass.PrintMembers(allmembers);
            Console.WriteLine("Iš viso bendroms išlaidoms grupė turi: {0,4:f2}", TaskClass.MoneyForCosts(allmembers));
            Narys generous = TaskClass.FindGeerousTurist(allmembers);
            List<Narys> narys1 = TaskClass.FindMaxDonators(allmembers);
            InOutClass.PrintMembers(narys1);
        }
    }
}
