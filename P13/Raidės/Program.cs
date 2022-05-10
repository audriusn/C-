using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Raidės
{
     class Program
    {

        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P13\\Raidės\\bin\\Debug\\Tekstas.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P13\\Raidės\\bin\\Debug\\rez.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            RaidziuDazniai eil = new RaidziuDazniai();
            Dazniai(CFd, eil);
         
            Spausdinti(CFr, eil);
            Console.WriteLine("Programa darbą baigė!");
        }

        static void Spausdinti (string fv, RaidziuDazniai eil)
        {
            using (var fr = File.CreateText(fv))
            {
                for (char sim = 'a'; sim <= 'z'; sim++)
                    fr.WriteLine("{0,3:c} {1,4:d} |{2, 3:c} {3,4:d}", sim, eil.Imti(sim), Char.ToUpper(sim), eil.Imti(Char.ToUpper(sim)));
            }
        }
        static void Dazniai (string fv, RaidziuDazniai eil)
        {
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                   while ((line = reader.ReadLine()) != null)
                {
                    eil.eil = line;
                    eil.kiek();
                }
            }
        }
    }
}
