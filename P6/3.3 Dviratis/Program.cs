using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Dviratis
{
    class Dviratis
    {
        private int metai;
        private double kaina;
        private string pav;
        private int kiekis;


        public Dviratis(string pav, int kiekis, int metai, double kaina)
        {
            this.metai = metai;
            this.kaina = kaina;
            this.pav = pav;
            this.kiekis = kiekis;
        }
        public int ImtiMetus() { return metai; }
        public double ImtiKaina() { return kaina; }
        public string ImtiPavadinima() { return pav; }
        public int ImtiKieki() { return kiekis; }
        public void PapildytiKieki(int k) { kiekis = kiekis + k; }

    }
    internal class Program
    {
        const int Cn = 100;
        const string CFd1 = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\3.3 Dviratis\\bin\\Debug\\Nuoma1.txt";
        const string CFd2 = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\3.3 Dviratis\\bin\\Debug\\Nuoma2.txt";
        const string CFrez = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\3.3 Dviratis\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        {
            Dviratis[] D1 = new Dviratis[Cn];
            int n1;
            string pav1;
            int kiekis1;

            Dviratis[] D2 = new Dviratis[Cn];
            int n2;
            string pav2;
            int kiekis2;

            Skaityti(CFd1, D1, out n1, out pav1);
            Skaityti(CFd2, D2, out n2, out pav2);

            Console.WriteLine("Pirmas nuomos punktas: {0}", pav1);
            Console.WriteLine("Dviraciu kiekis {0}\n", n1);
            Console.WriteLine("Pavadinimas     Kiekis    Pagaminimo metai   Kaina");
            for (int i = 0; i < n1; i++)
                Console.WriteLine("{0,-12}     {1,4:d}         {2,3:d}         {3,7:f2}",
                    D1[i].ImtiPavadinima(), D1[i].ImtiKieki(), D1[i].ImtiMetus(), D1[i].ImtiKieki());
            Console.WriteLine();

            if (File.Exists(CFrez))
                File.Delete(CFrez);

            SpaudintiDuomenis(CFrez, D1, n1, pav1);
            SpaudintiDuomenis(CFrez, D2, n2, pav2);

            int ind1 = Seniausias(D1, n1);
            int ind2 = Seniausias(D2, n2);
            using (var fr = File.AppendText(CFrez))
             {
                if (D1[ind1].ImtiMetus() < D2[ind2].ImtiMetus())
                    fr.WriteLine("Seniausias dviratis yra nuomos punkte: {0}", pav1);
                 if (D1[ind1].ImtiMetus() == D2[ind2].ImtiMetus())
                    fr.WriteLine("Seniausias dviratis yra nuomos punkte: {0} ir {1}", pav1, pav2);
                 if (D1[ind1].ImtiMetus() > D2[ind2].ImtiMetus())
                    fr.WriteLine("Seniausias dviratis yra nuomos punkte: {0}", pav2);
            }

            Dviratis[] Dr = new Dviratis[Cn];
            int nr;
            nr = 0;
            Formuoti(D1, n1, Dr, ref nr);
            Formuoti(D2, n2, Dr, ref nr);
            SpaudintiDuomenis(CFrez, Dr, nr, "Modeliu sarasas");

            Console.WriteLine("Programa baigė darbą");
        }
        //Metodas nuskaitantis duomenu faila
        static void Skaityti(string Fd, Dviratis[] D, out int n, out string pav)
        {
            using (StreamReader reader = new StreamReader(Fd))
            {
                string eil; int kiekn; int metain; double kainan;
                string line;
                line = reader.ReadLine();
                string[] parts;
                pav = line;
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    eil = parts[0];
                    kiekn = int.Parse(parts[1]);
                    metain = int.Parse(parts[2]);
                    kainan = double.Parse(parts[3]);
                    D[i] = new Dviratis(eil, kiekn, metain, kainan);

                }
            }
      
        }
        // Spausdina duomenis i faila
        // fv  - rezultatu failo vardas
        // D  - objektu rinkinys dviraciu duomenims saugoti
        // nkiek - dviraciu skaicius
        // pav  - nuomos firmos pavadinimas
        static void SpaudintiDuomenis(string fv, Dviratis[] D, int nkiek, string pav)
        {
            const string virsus =
                 "|-----------------|------------|---------------|---------|\r\n"
               + "|   Pavadinimas   |   Kiekis   |   Pagaminimo  |  Kaina  |\r\n"
               + "|                 |            |      metai    |  (euru) |\r\n"
               + "|-----------------|------------|---------------|---------|";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Nuomos firma: {0}", pav);
                fr.WriteLine(virsus);
                Dviratis tarp;
                for (int i = 0; i < nkiek; i++)
                {
                    tarp = D[i];
                    fr.WriteLine("| {0,-10} | {1,8} |    {2,5:d}| {3,7:F2} |",
                        tarp.ImtiPavadinima(), tarp.ImtiKieki(), tarp.ImtiMetus(), tarp.ImtiKaina());
                }
                fr.WriteLine("--------------------------------------------------------------------");
            }

        }
        // Grazina dviracio, kurios metu skaicius yra maziausias, indeksa
        // D - objektu rinkinys
        // n - objektu skaicius rinkinyje
        static int Seniausias(Dviratis[] D, int n)
        {
            int k = 0;
            for (int i = 0; i < n; i++)
                if (D[i].ImtiMetus() < D[k].ImtiMetus())
                    k = i;
            return k;
        }
        // grazina surasto dciracio masyve indeksa arba -1, jeigu dviracio masyve nera
        // D - objektu rinkinys
        // n - objektu skaicius rinkinyje
        // pav - ieskomo modelio pavadinimas
        static int YraModelis(Dviratis[] D, int n, string pav, int metai)
        {
            for (int i =0; i < n; i++)
                if ((D[i].ImtiPavadinima() == pav && D[i].ImtiMetus() == metai)) return i;
            return -1;
        }
        //Objektu rinkini papildo duomenimis is kito objektu rinkinio
        // Jeigu objektu rinkinio D tokio pat modelio dviratis yra objektu rinkinyje Dr,
        // tuomet didinamas kiekis, kitaip - papildoma nauju objektu
        // n - objektu skaicius rinkinyje D
        // D - objektu rinkinys, is kurio pildo
        // nr - objektu skaicius rinkinyje Dr
        // Dr - objektu rinkinys, kuri pildo
        static void Formuoti (Dviratis []D, int n, Dviratis[] Dr, ref int nr)
        {
            int k;
            for (int i = 0; i < n; i++)
            {
                k = YraModelis(Dr, nr, D[i].ImtiPavadinima(), D[i].ImtiMetus());
                if (k >= 0)
                    Dr[k].PapildytiKieki(D[i].ImtiKieki()); //didinamas kiekis
                else
                {
                    Dr[nr]=D[i];
                    nr++;                                   // papildomas rinkinys
                }
            }
        }
    }
}
