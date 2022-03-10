using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuitinėsTechnikosParduotuvė
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            List<Saldytuvas> VisiSaldytuvai = InOutClass.ReadSaldytuvas(@"saldytuvai.csv");
            Console.WriteLine("Refrigerator list:");
            InOutClass.PrintSaldytuvus(VisiSaldytuvai);
            List<string> Tipai = TaskClass.FindTypes(VisiSaldytuvai);
            Console.WriteLine("Refrigerator Types:");
            Console.WriteLine();
            InOutClass.PrintTypes(Tipai);
            List<Saldytuvas> LowPrice = TaskClass.LowPriceWithFreezer(VisiSaldytuvai, Mark.TAIP);
            Console.WriteLine();
            Console.WriteLine("Refrigerator filtered by lowest price, type = Pastatomas, freezer = Taip");
            InOutClass.PrintLowPriceWithFreezer(LowPrice);
            List<Saldytuvas> ToFile = TaskClass.RefrigetatorToCsv(VisiSaldytuvai);
            InOutClass.PrintRefigeratorToCSVFile("Baltieji.csv", ToFile);

        }
    }
}
