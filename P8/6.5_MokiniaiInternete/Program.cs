using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;


namespace _6._5_MokiniaiInternete
{
    class Mokinys
    {
        private string pav, vard;
        private int klas, laikas;
        private double vid;
        public Mokinys()
        {
            pav = "";
            vard = "";
            klas = 0;
            laikas = 0;
            vid = 0.0;
        }
        public void Dėti(string pav, string vard, int klas, double vid)
        {
            this.pav = pav;
            this.vard = vard;
            this.klas = klas;
            this.vid = vid;
        }
        public void DėtiLaiką(int laik) { laikas = laik; }
        public string ImtiPav() { return pav; }
        public string ImtiVard() { return vard; }
        public int ImtiKlas() { return klas; }
        public double ImtiVid() { return vid;}
        public double ImtiLaika() { return laikas;}

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-15} {1,-10}  {2,2:d}   {3,10:f2}", pav, vard, klas, laikas);
            return eilute;
        }
        public static bool operator <=(Mokinys pirmas, Mokinys antras)
        {
            return pirmas.klas < antras.klas || pirmas.klas == antras.klas && pirmas.laikas < antras.laikas;
        }
        public static bool operator >=(Mokinys pirmas, Mokinys antras)
        {
            return pirmas.klas > antras.klas || pirmas.klas == antras.klas && pirmas.laikas > antras.laikas;
        }

    }
    class Mokykla
    {
        const int CMaxMk = 1000; // max mokiniu
        const int CMaxDn = 30;   // max dienu
        private Mokinys[] Mokiniai;
        public int n { get;  set; }
        private int[,] WWW;
        public int m { get; set; }
        public Mokykla()
        {
            n = 0;
            Mokiniai = new Mokinys[CMaxMk];

            m=0;
            WWW = new int[CMaxMk,CMaxDn];
        }
        /// <summary>
        /// Grąžina nurodyto indekso mokinio objektą
        /// </summary>
        /// <param name="nr"></param>
        /// <returns></returns>
        public Mokinys Imti(int nr) { return Mokiniai[nr]; }
        /// <summary>
        /// Padeda į moknių objektų masyvą naują mokinį it masyvą padidina vienetu
        /// </summary>
        /// <param name="ob"></param>
        public void Dėti(Mokinys ob) { Mokiniai[n++] = ob; }
        /// <summary>
        /// Pakeičia mokinių objektų masyvo mokinį kurio numeris nr
        /// </summary>
        /// <param name="nr"></param>
        /// <param name="mok"></param>
        public void PakeistiMokinį(int nr, Mokinys mok) { Mokiniai[nr] = mok; }
        /// <summary>
        /// Pakiečia laikų matrivos elementą
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="r"></param>
        public void DėtiWWW(int i, int j, int r) { WWW[i,j] = r; }
        /// <summary>
        /// Grąžina laikų matricos elementą
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int ImtiWWW(int i, int j) { return WWW[i, j]; }
        /// <summary>
        /// sukeičia dvi eilutes vietomis dvimačiame masyve WWW(n,m)
        /// </summary>
        /// <param name="nr1"></param>
        /// <param name="nr2"></param>
        public void SukeistiEilutesWWW(int nr1, int nr2)
        {
            for(int j=0; j<m; j++)
            {
                int d = WWW[nr1, j];
                WWW[nr1, j] = WWW[nr2, j];
                WWW[nr2,j] = d;
            }
        }
        /// <summary>
        /// Objektų masyvo papildymas laikais, praleistais internete iš dvimačio masyvo
        /// </summary>
        public void PapilDytiMokiniųDuomenis()
        {
            int suma;
            Mokinys mok;
            for (int i = 0; i < n; i++)
            {
                suma = 0;
                for (int j = 0; j < m; j++)
                    suma = suma + WWW[i, j];
                mok = Imti(i);
                mok.DėtiLaiką(suma);
                PakeistiMokinį(i, mok);
            }
        }
        /// <summary>
        /// Surikiuoja objektų masyvą paal klases ir laikus
        /// </summary>
        public void RikiuotiMinMax()
        {
            Mokinys mok;
            for (int i = 0; i < n-1; i++)
            {
                int minnr = i;
                for(int j = i+1;j<n; j++)
                    if(Imti(j) <= Imti(minnr))
                        minnr = j;
                mok = Imti(i);
                PakeistiMokinį(i, Imti(minnr));
                PakeistiMokinį(minnr, mok);
                SukeistiEilutesWWW(i, minnr);
            }
        }

    }
    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\6.5_MokiniaiInternete\\bin\\Debug\\Duomenys.txt";
        const string CFd1 = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\6.5_MokiniaiInternete\\bin\\Debug\\Duomenys2.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\6.5_MokiniaiInternete\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        {

            Mokykla mokykl = new Mokykla();
            SkaitytiMok(CFd, ref mokykl);
            SkaitytiLaik(CFd1 , ref mokykl);

            using (var fr =File.CreateText(CFr))
            {
                fr.WriteLine("        Pradiniai duomenys");
                fr.WriteLine();
                fr.WriteLine("Mokinių kiekis {0}", mokykl.n);
                fr.WriteLine("Dienų kiekis {0}", mokykl.m);
                fr.WriteLine();
            }
            Spausdinti(CFr, mokykl, "   Mokyklos mokiniai (laikas =0)");
            SpausdintiLaik(CFr, mokykl, "Mokinių laikai, praleisti internete");

            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                fr.WriteLine("        Rezultatai");
                fr.WriteLine();
            }
            mokykl.PapilDytiMokiniųDuomenis();
            Spausdinti(CFr, mokykl, "   Mokyklos mokiniai (papildyta, laikai !=0)");

            mokykl.RikiuotiMinMax();
            Spausdinti(CFr, mokykl, "   Mokyklos mokiniai (surikiuoti)");
            SpausdintiLaik(CFr, mokykl, "Mokinių laikai, praleisti internete (po rikiavimo)");

            using (var fr = File.AppendText(CFr))
            {
                int klasė;
                Console.WriteLine("Užrašykite klasę (1-12;");
                klasė = int.Parse(Console.ReadLine());
                fr.WriteLine();
                if (VidlaikasKl(mokykl, klasė) != 0)
                    fr.WriteLine("{0} klasės mokiniai internete vidutiniškai pradeido: "
                        + " {1,6:f2} minučių", klasė, VidlaikasKl(mokykl, klasė));
                else
                    fr.WriteLine("{0} klasės mokinių sąrašę nėra", klasė);
            }


            Console.WriteLine("Pradiniai duoemnys išspausdinami faile: {0}", CFr);
            Console.WriteLine("Programa baige darbą!");
        }
        /// <summary>
        /// Failo duomenis į konteinerį
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="mokykl"></param>
        static void SkaitytiMok(string fd, ref Mokykla mokykl)
        {
            string pav, vard;
            int klas, nn;
            double vid;
            string line;
            using(StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn=int.Parse(line);
                for(int i=0; i<nn; i++)
                {
                    line=reader.ReadLine();
                    parts = line.Split(';');
                    pav= parts[0];
                    vard= parts[1];
                    klas= int.Parse(parts[2]);
                    vid= double.Parse(parts[3]);
                    Mokinys mok;
                    mok = new Mokinys();
                    mok.Dėti(pav,vard,klas,vid);
                    mokykl.Dėti(mok);
                }
            }
        }
        /// <summary>
        /// Įveda duomenis į dvimatį masyvą WWW(n,m)
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="mokykl"></param>
        static void SkaitytiLaik(string fd, ref Mokykla mokykl)
        {
            int laikas, nn, mm;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                mokykl.m = mm;
                for(int i=0; i<mokykl.n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    for(int j=0; j< mokykl.m; j++)
                    {
                        laikas = int.Parse(parts[j]);
                        mokykl.DėtiWWW(i,j,laikas);
                    }
                }
            }
        }
        /// <summary>
        /// Spausdina konteinerio duomenis faile
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="mokykl"></param>
        /// <param name="antraštė"></param>
        static void Spausdinti (string fv, Mokykla mokykl, string antraštė)
        {
            using(var fr= File.AppendText(fv))
            {
                string bruksnys = new string('-', 46);
                fr.WriteLine(antraštė);
                fr.WriteLine();

                fr.WriteLine(bruksnys);
                fr.WriteLine("Nr. Pavardė        Vardas      KLasė    Laikas");
                fr.WriteLine(bruksnys);
                for (int i=0; i< mokykl.n; i++)
                    fr.WriteLine("{0}. {1}", i+1, mokykl.Imti(i).ToString());
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Spausdina internete praleistų laikų matricos faile
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="mokykl"></param>
        /// <param name="koment"></param>
        static void SpausdintiLaik(String fv, Mokykla mokykl, string koment)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("{0} per {1} dienas", koment,mokykl.m);
                fr.WriteLine();
                for (int i = 0; i < mokykl.n; i++)
                {
                    fr.Write("{0,4:d}. ", i + 1);
                    for (int j = 0; j< mokykl.m; j++)
                        fr.Write("{0,5:d}", mokykl.ImtiWWW(i, j));
                    fr.WriteLine();
                }

            }
        }
        /// <summary>
        /// suskaičiuoja ir grąžina nurodytos klasės mokinių vidutinį laiką.
        /// </summary>
        /// <param name="mokykl"></param>
        /// <param name="klasė"></param>
        /// <returns></returns>
        static double VidlaikasKl(Mokykla mokykl, int klasė)
        {
            double suma = 0;
            int kiek = 0;
            for (int i = 0; i < mokykl.n; i++)
                if(mokykl.Imti(i).ImtiKlas() == klasė)
                {
                    kiek++;
                    suma = suma + mokykl.Imti(i).ImtiLaika();
                }
            if (kiek != 0)
                return suma / kiek;
            else
                return 0;
        }
       
    }
}
