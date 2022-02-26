using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace AuksščiausiaLyga
{
    class Komanda
    {
        private string pavadinimas, miestas, Tpav, Tvard;
        private int ivartis, pergales;

        public Komanda()
        {
            pavadinimas = "";
            miestas = "";
            Tpav = "";
            Tvard = "";
            ivartis = 0;
            pergales = 0;
        }
        public void Dėti(string pavadinimas, string miestas, string Tpav, string Tvard)
        {
            this.pavadinimas = pavadinimas;
            this.miestas = miestas;
            this.Tpav = Tpav;
            this.Tvard = Tvard;
        }
        public void DėtiTaskus(int ivart) { ivartis = ivart; }
        public void DėtiPergales(int perg) { pergales = perg; }
        public string ImtiPavadinima() { return pavadinimas; }
        public string ImtiMiesta() { return miestas; }
        public string ImtiTpav() { return Tpav; }
        public string ImtiTvard() { return Tvard; }
        public int ImtiTaskus() { return ivartis; }
        public int ImtiPergales() { return pergales; }

        public static bool operator <=(Komanda pirmas, Komanda antras)
        {
            return pirmas.ivartis > antras.ivartis || pirmas.ivartis == antras.ivartis && pirmas.pergales < antras.pergales;
        }
        public static bool operator >=(Komanda pirmas, Komanda antras)
        {
            return pirmas.ivartis < antras.ivartis || pirmas.ivartis == antras.ivartis && pirmas.pergales > antras.pergales;
        }
    }
    class Turnyras
    {
        const int CMaxMk = 1000;
        const int CMaxDn = 30;
        private Komanda[] Komandos;
        public int n { get; set; }
        private int[,] Ivarčiai;
        public int m { get; set; }
        public Turnyras()
        {
            n = 0;
            Komandos = new Komanda[CMaxMk];

            m = 0;
            Ivarčiai = new int[CMaxMk, CMaxDn];
        }
        public Komanda Imti(int nr) { return Komandos[nr]; }
        public void Dėti(Komanda ob) { Komandos[n++] = ob; }
        public void DėtiIvarčiai(int i, int j, int r) { Ivarčiai[i, j] = r; }
        public int ImtiIvarčiai(int i, int j) { return Ivarčiai[i, j]; }
        public void PakeistiKomanda(int nr, Komanda kom) { Komandos[nr] = kom; }
        /// <summary>
        /// Papildo komandos lentele duomeninis
        /// </summary>
        public void PapilDytiKomanduDuomenis()
        {
            int suma;
            int taskai;
            int pergalės;
            Komanda kom;
            for (int i = 0; i < n; i++)
            {
                suma = 0;
                taskai = 0;
                pergalės = 0;
                for (int j = 0; j < m; j++)
                {
                    if (Ivarčiai[i, j]>=0 && Ivarčiai[i, j] == Ivarčiai[j, i])
                    {
                        taskai = 1;
                        suma = suma + taskai;
                    }
                    if (Ivarčiai[i, j] >= 0 && Ivarčiai[i, j] > Ivarčiai[j, i])
                    {
                        taskai = 3;
                        suma = suma + taskai;
                        pergalės++;
                    }
                }
                kom = Imti(i);
                kom.DėtiTaskus(suma);
                kom.DėtiPergales(pergalės);
                PakeistiKomanda(i, kom);
            }
        }
        /// <summary>
        /// Rikiavimo metodas
        /// </summary>
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Komanda kom = Komandos[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (Komandos[j] <= kom)
                    {
                        kom = Komandos[j];
                        im = j;
                    }
                Komandos[im] = Komandos[i];
                Komandos[i] = kom;
            }
        }
    }
    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\AuksščiausiaLyga\\bin\\Debug\\Duomenys.txt";
        const string CFd1 = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\AuksščiausiaLyga\\bin\\Debug\\Duomenys2.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\AuksščiausiaLyga\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        {
            Turnyras turn = new Turnyras();

        // nuskaitom pradinius failus
            SkaitytiKom(CFd, ref turn);
            SkaitytiIvartcius(CFd1, ref turn);
            if (File.Exists(CFr))
                File.Delete(CFr);
        //isspausdinam pradinius failus
            SpausdintiKom(CFr,  turn, "Pradiniai  duomenys");
            SpausdintiIvartcius(CFr, turn, " Įmušti  įvarčiai:");

         // spausdinam papildytus failus
            turn.PapilDytiKomanduDuomenis();
            SpausdintiKom(CFr, turn, "Papildyta");

         //surikiuota
            turn.Rikiuoti();
            SpausdintiKom(CFr, turn, "Rikiuota");

        // Spausdina mažiausia pralaimėjimu turinčią komandą.
            SpausdintiMIn(CFr, turn);
            Console.WriteLine("Programa baige darbą!");
        }
        /// <summary>
        /// Nuskaito komandų failą
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="turn"></param>

        static void SkaitytiKom(string fd, ref Turnyras turn)
        {
            string pavadinimas, miestas, Tpav, Tvard;
            int nn;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    pavadinimas = parts[0];
                    miestas = parts[1];
                    Tpav = parts[2];
                    Tvard = parts[3];
                    Komanda kom;
                    kom = new Komanda();
                    kom.Dėti(pavadinimas, miestas, Tpav, Tvard);
                    turn.Dėti(kom);
                }
            }
        }
        /// <summary>
        /// NUskaito įvarčių failą
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="turn"></param>
        static void SkaitytiIvartcius(string fd, ref Turnyras turn)
        {
            int ivartis, nn, mm;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                turn.m = mm;
                for (int i = 0; i < turn.n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    for (int j = 0; j < turn.m; j++)
                    {
                        ivartis = int.Parse(parts[j]);
                        turn.DėtiIvarčiai(i, j, ivartis);
                    }
                }
            }
        }
        /// <summary>
        /// Spausdina komandos duomenis
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="turn"></param>
        /// <param name="antraštė"></param>
        static void SpausdintiKom(string fv, Turnyras turn, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-',85);
                fr.WriteLine(antraštė);
                fr.WriteLine();

                fr.WriteLine(bruksnys);
                fr.WriteLine("Nr:     Pavadinimas:   Miestas:       Treneris:               Taškai:   Pergalės: ");
                fr.WriteLine(bruksnys);
                for (int i = 0; i < turn.n; i++)
                    fr.WriteLine("{0,-7} {1,-14} {2,-14} {3,-11} {4,-14} {5,-10} {6}", i + 1, turn.Imti(i).ImtiPavadinima(), turn.Imti(i).ImtiMiesta(), turn.Imti(i).ImtiTpav(), turn.Imti(i).ImtiTvard(), turn.Imti(i).ImtiTaskus(), turn.Imti(i).ImtiPergales());
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Spausdina įvarčius lenetelę
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="turn"></param>
        /// <param name="koment"></param>
        static void SpausdintiIvartcius(string fv, Turnyras turn, string koment)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("{0}", koment);
                fr.WriteLine();
                for (int i = 0; i < turn.n; i++)
                {
                    fr.Write("{0,-10} ", turn.Imti(i).ImtiPavadinima());
                    for (int j = 0; j < turn.m; j++)
                        fr.Write("{0,5:d}", turn.ImtiIvarčiai(i, j));
                    fr.WriteLine();
                }
            }
        }
        /// <summary>
        /// Suranda ir išpsausdina daugiausiai pergalių turinčią komandą
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="turn"></param>
        /// <param name="antraštė"></param>
        static void SpausdintiMIn(string fv, Turnyras turn)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 50);
             
                fr.WriteLine(bruksnys);
                int max = 0;
                string minpav="";
                for (int i = 0; i < turn.n; i++)
                {
                    max = turn.Imti(0).ImtiPergales();
                    minpav = turn.Imti(0).ImtiPavadinima();
                    if (turn.Imti(i).ImtiPergales() > max)
                    {
                        max = turn.Imti(i).ImtiPergales();
                        minpav = turn.Imti(i).ImtiPavadinima();
                    }
                }
                fr.WriteLine("Mažiausiai pralaimėjimų turi komanda {0,-7}", minpav);           
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }

    }
}