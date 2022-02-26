using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Pastas
{
    class Leidinys
    {
        private string pavadinimas, bankoPav, sasNr;
        private int kaina, proc, uzkiekis;

        public Leidinys()
        {
            pavadinimas = "";
            kaina = 0;
            bankoPav = "";
            sasNr = "";
            uzkiekis = 0;
            proc = 0;
        }
        public void Dėti(string pavadinimas, int kaina, string bankoPav, string sasNr,  int proc )
        {
            this.pavadinimas = pavadinimas;
            this.bankoPav = bankoPav;
            this.sasNr = sasNr;
            this.kaina = kaina;
            this.proc = proc;
        }
     
        public string ImtiPavadinima() { return pavadinimas; } // grąžina pavadinimą
        public string ImtiBankoPav() { return bankoPav; } // grąžina banko pavadinimą
        public string ImtiSasNr() { return sasNr; } // grąžina Saskaitos Nr
        public int ImtiKaina() { return kaina; } // grąžina kaina
        public int ImtiProc() { return proc; } // grąžina procentus
        public int ImtiUzkieki() { return uzkiekis; } // grąžina užsakytą kiekį
        public void DėtiLeidinius(int uzkiek) { uzkiekis = uzkiek; }

    }
    class Prenumerata
    {
        const int CMaxMk = 1000;
        const int CMaxDn = 30;
        private Leidinys[] Leidiniai;
        public int n { get; set; }
        private int[,] Užsakymai;
        public int m { get; set; }
        public Prenumerata()
        {
            n = 0;
            Leidiniai = new Leidinys[CMaxMk];

            m = 0;
            Užsakymai = new int[CMaxMk, CMaxDn];
        }
        public Leidinys Imti(int nr) { return Leidiniai[nr]; }
        public void Dėti(Leidinys ob) { Leidiniai[n++] = ob; }
        public void DėtiIUžsakymus(int i, int j, int r) { Užsakymai[i, j] = r; }
        public int ImtiUžsakymus(int i, int j) { return Užsakymai[i, j]; }
        public void PakeistiLeidinį(int nr, Leidinys leid) { Leidiniai[nr] = leid; }
        /// <summary>
        ///  Randa užsakymų sumą ir papildo 
        /// </summary>
        public void PapilDytiPasta()
        {
            int suma;
            Leidinys leid;
            for (int j = 0; j < n; j++)
            {
                suma = 0;
                for (int i = 0; i < m; i++)
                    suma = suma + Užsakymai[i, j];
                leid = Imti(j);
                leid.DėtiLeidinius(suma);
                PakeistiLeidinį(j, leid);
            }
        }
    }
        internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\Pastas\\bin\\Debug\\Duomenys.txt";
        const string CFd1 = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\Pastas\\bin\\Debug\\Duomenys2.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\Pastas\\bin\\Debug\\Rezultatai.txt";

        static void Main(string[] args)
        {
            Prenumerata prenum = new Prenumerata();
        
            SkaitytiLeid(CFd, ref prenum);
            SkaitytiUsakymus(CFd1, ref prenum);

            if (File.Exists(CFr))
                File.Delete(CFr);

            SpausdintiLeid(CFr, prenum, "Pirminiai duomenys");

            prenum.PapilDytiPasta();
            SpausdintiLeid(CFr, prenum, "Papildyta");

            SpausdintiMax(CFr, prenum);
            SpausdintiIšmokejimus(CFr, prenum, "Banko išmokėjimai");

            KiekDienuNeuzsakyta(CFr, prenum);

            Console.WriteLine("Programa baige darbą!");
        }
        /// <summary>
        /// Nuskaito pirmą failą
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="prenum"></param>
        static void SkaitytiLeid(string fd, ref Prenumerata prenum)
        {
            string pavadinimas, bankoPav, sasNr;
            int nn, kaina, proc;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pavadinimas = parts[0];
                    kaina = int.Parse(parts[1]);
                    bankoPav = parts[2];
                    sasNr = parts[3];
                    proc = int.Parse(parts[4]);
                    Leidinys leid;
                    leid = new Leidinys();
                    leid.Dėti(pavadinimas, kaina, bankoPav, sasNr, proc);
                    prenum.Dėti(leid);
                }
            }
        }
        /// <summary>
        /// Nuskaito antrą failą.
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="prenum"></param>
        static void SkaitytiUsakymus(string fd, ref Prenumerata prenum)
        {
            int nn, mm, uzkiekis;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                prenum.n = nn;
                prenum.m = mm;
                for (int i = 0; i < mm; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    for (int j = 0; j < nn; j++)
                    {
                        uzkiekis = int.Parse(parts[j]);
                        prenum.DėtiIUžsakymus(i, j, uzkiekis);
                    }
                }
            }
        }
        /// <summary>
        /// Spausdina  leidinius
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="prenum"></param>
        /// <param name="antraštė"></param>
        static void SpausdintiLeid(string fv, Prenumerata prenum, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 50);
                fr.WriteLine(antraštė);
                fr.WriteLine();

                fr.WriteLine(bruksnys);
                fr.WriteLine("Nr:   Pavadinimas:      Užsakytas kiekis: ");
                fr.WriteLine(bruksnys);
                for (int i = 0; i < prenum.n; i++)
                    fr.WriteLine("{0,-5} {1,-25} {2}", i + 1, prenum.Imti(i).ImtiPavadinima(), prenum.Imti(i).ImtiUzkieki());
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Spausdina max užsakymų turintį leidinį
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="prenum"></param>
        static void SpausdintiMax(string fv, Prenumerata prenum)
        {
            using (var fr = File.AppendText(fv))
            {
               
                string bruksnys = new string('-', 50);
                fr.WriteLine(bruksnys);
                int max = 0;
                string maxpav = "";
                for (int i = 0; i < prenum.n; i++)
                {

                    if ( max < prenum.Imti(i).ImtiUzkieki())
                    {
                        max = prenum.Imti(i).ImtiUzkieki();
                        maxpav = prenum.Imti(i).ImtiPavadinima();
                    }
                }
                fr.WriteLine("Leidinys lyderis yra: {0,-7}", maxpav);
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Suskaičiuoja ir spausdina bankų išmokėjimus.
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="prenum"></param>
        /// <param name="antraštė"></param>
        static void SpausdintiIšmokejimus(string fv, Prenumerata prenum, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 50);
                fr.WriteLine(antraštė);
                fr.WriteLine();

                fr.WriteLine(bruksnys);
                fr.WriteLine("Nr:   Bankas:      Leidinys:               Išmoka: ");
                fr.WriteLine(bruksnys);
                decimal sum = 0;
                for (int i = 0; i < prenum.n; i++)
                {
                    sum = (prenum.Imti(i).ImtiUzkieki() * prenum.Imti(i).ImtiKaina()) -( prenum.Imti(i).ImtiUzkieki() * prenum.Imti(i).ImtiKaina() * (decimal)(prenum.Imti(i).ImtiProc() * 0.01));
                    fr.WriteLine("{0,-5} {1,-13} {2,-23} {3,4}", i + 1, prenum.Imti(i).ImtiBankoPav(), prenum.Imti(i).ImtiPavadinima(), sum);
                }
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Randa ar yra daugiau nej 1 dieną be leidinio užsakymo
        /// </summary>
        /// <param name="Cfr"></param>
        /// <param name="prenum"></param>
        static void KiekDienuNeuzsakyta(string Cfr, Prenumerata prenum)
        {
            using (var fr = File.AppendText(CFr))
            {
                for (int j = 0; j < prenum.n; j++)
                {
                    int suma = 0;
                    for (int i = 0; i < prenum.m; i++)
                    {
                        if (prenum.ImtiUžsakymus(i, j) == 0)
                            suma++;
                    }
                    if (suma > 1)
                    {
                        fr.WriteLine("Leidinys {0} buvo neužsakytas {1} dienas.", prenum.Imti(j).ImtiPavadinima(), suma);
                    }                
                }
                fr.WriteLine();
            }
        }
    }
}
