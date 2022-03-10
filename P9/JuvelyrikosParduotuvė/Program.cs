using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuvelyrikosParduotuvė
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            List<Ziedas> VisiZiedai = InOutClass.ReadZiedus(@"ziedai.csv");
            Console.WriteLine("Rings list:");
            InOutClass.PrintZiedus(VisiZiedai);
            List<Ziedas> Maxweight = TaskClass.LowPriceWithFreezer(VisiZiedai);
            Console.WriteLine("The Heaviest rings:");
            InOutClass.PrintTopWeight(Maxweight);
            List<Ziedas> TopPraba = TaskClass.HightPrabaRing(VisiZiedai);
            Console.WriteLine();
            Console.WriteLine("Top praba rings are: {0}", TopPraba.Count);
            InOutClass.PrintZiedus2(TopPraba);
            Console.WriteLine();
            Console.WriteLine("Information about metals was printed in Metalai.csv file");
            List<string> Metals = TaskClass.FindMetal(VisiZiedai);
            InOutClass.PrintMetalsToCSVFile("Metalai.csv", Metals);

        }
    }
}
