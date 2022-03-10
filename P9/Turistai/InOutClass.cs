using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Turistai
{
    static class InOutClass
    {
        public static List<Narys> ReadMembers(string fileName)
        {
            List<Narys> Nariai = new List<Narys>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(',');
                string name = Values[0];
                string surname = Values[1];
                double money = double.Parse(Values[2]);
                Narys narys = new Narys(name, surname,money);
                Nariai.Add(narys);
            }
            return Nariai;
        }
        public static void PrintMembers(List<Narys> Nariai)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("| {0,8} | {1,15} | {2,-15} |", "Vardas", "Pavardė", "Pinigai");
            Console.WriteLine(new string('-', 50));
            foreach (Narys narys in Nariai)
            {
                Console.WriteLine("| {0,8} | {1,15} | {2,-15} |", narys.name, narys.surname,narys.money);
            }
            Console.WriteLine(new string('-', 50));
        }
       
    }
}
