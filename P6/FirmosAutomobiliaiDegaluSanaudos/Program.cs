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

        public Auto(string pav, string degalai, double sanaudos)
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
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\FirmosAutomobiliaiDegaluSanaudos\\bin\\Debug\\Duomenys.txt";
        const string CFrez = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\FirmosAutomobiliaiDegaluSanaudos\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        {
            Auto[] A = new Auto[100];
            int na;


            if (File.Exists(CFrez))
                File.Delete(CFrez);

            Skaityti(CFd, A, out na);
            Spausdinti(CFrez, A, na);

            using (var fr =File.AppendText(CFrez))
            {
                fr.WriteLine("Vidutines degelu sanaudos: {0,7:f2} litro/100km", VidSanaudos(A, na));
            }
            using (var fr = File.AppendText(CFrez))
            {
                fr.WriteLine("Dyzeliniu automobiliu yra : {0}", KiekDyzeliu(A, na));
            }

            Console.WriteLine("Programa baige darba!");

        }
        static void Skaityti(string Fd, Auto[] A, out int kiek)
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
                  "|-----------------|------------|--------------------|\r\n"
                + "|                 |            |                    |\r\n"
                + "|   Pavadinimas   |  Degalai   | Sanaudos (1/100 km)|\r\n"
                + "|                 |            |                    |\r\n"
                + "|-----------------|------------|--------------------|";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Automobiliu kiekis {0}", nkiek);
                fr.WriteLine("Automobikiu sarasas:");
                fr.WriteLine(virsus);
                Auto tarp;
                for (int i = 0; i < nkiek; i++)
                {
                    tarp = A[i];
                    fr.WriteLine("| {0,-17} | {1,-9}  |   {2,8:f2}     |",
                        tarp.ImtiPav(), tarp.ImtiDegalus(), tarp.ImtiSanaudas());
                }
                fr.WriteLine("--------------------------------------------------------");
            }
        }
        static double VidSanaudos(Auto[] A, int kiek)
        {
            double sum = 0;
            for (int i = 0; i < kiek; i++)
            {
                sum= sum + A[i].ImtiSanaudas();
            }
            return sum / kiek;
        }
        static int KiekDyzeliu(Auto[] A,int kiek)
        {
            int k = 0;
            for (int i = 0; i < kiek; i++)
                if (A[i].ImtiDegalus() == " Dyzelinas")
                    k = k + 1;
            return k;
        }
    }
}
