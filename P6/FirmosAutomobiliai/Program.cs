using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FirmosAutomobiliai
{
    class Auto
    {
        private string pav;
        private string degalai;
        private double sanaudos;

        public Auto (string pav, string degalai, double sanaudos)
        { 
            this.pav = pav;
            this.degalai = degalai;
            this.sanaudos = sanaudos;
        }
        public string ImtiPav() { return pav; }
        public string ImtiDegalus() { return degalai; }
        public double ImtiSanaudas() { return sanaudos; }
    }
    internal class Program
    {
        const int Cn = 100;
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\FirmosAutomobiliai\\bin\\Debug\\Duomenys.txt";
        const string CFrez = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\FirmosAutomobiliai\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        {
            Auto[] A = new Auto[100];
            int na;


            if (File.Exists(CFrez))
                File.Delete(CFrez);

            Skaityti(CFd, A, out na);
            Spausdinti(CFrez, A, na);
            Console.WriteLine("Programa baige darba!");

        }
        static void Skaityti (string Fd, Auto[] A, out int kiek)
        {
            using (StreamReader reader = new StreamReader(Fd))
            {
                string pav, degalai;
                double sanaudos;
                string line;
                line = reader.ReadLine();
                string[] parts;
                kiek = int.Parse(line);
                for (int i = 0; i < kiek; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pav = parts[0];
                    degalai = parts[1];
                    sanaudos = double.Parse(parts[2]);
                    A[i] = new Auto(pav, degalai, sanaudos);
                }
              }
        }
        static void Spausdinti(string fv, Auto[] A, int nkiek)
        {
            const string virsus =
                  "|----------|-----------------|------------|--------------------|\r\n"
                + "|          |                 |            |                    |\r\n"
                + "|  Eil,Nr  |   Pavadinimas   |  Degalai   | Sanaudos (1/100 km)|\r\n"
                + "|          |                 |            |                    |\r\n"
                + "|----------|-----------------|------------|--------------------|";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Automobiliu kiekis {0}", nkiek);
                fr.WriteLine("Automobikiu sarasas:");
                fr.WriteLine(virsus);
                Auto tarp;
                for (int i = 0; i < nkiek; i++)
                {
                    tarp = A[i];
                    fr.WriteLine("| {0,-10}| {1,-27} | {2,-9}  |   {3,8:f2}     |",i+1,
                        tarp.ImtiPav(), tarp.ImtiDegalus(), tarp.ImtiSanaudas());
                }
                fr.WriteLine("--------------------------------------------------------");
            }
        }
    }
}
