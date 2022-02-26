using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace DarboBirza
{
    class Miestas
    {
        private string pavadinimas;
        private int gyvSK, jaunSK, jaunBedarb;

        public Miestas()
        {
            pavadinimas = "";
            gyvSK = 0;
            jaunSK = 0;
            jaunBedarb = 0;
        }
        public void Dėti(string pavadinimas, int gyvSK, int jaunSK)
        {
            this.pavadinimas = pavadinimas;
            this.gyvSK = gyvSK;
            this.jaunSK = jaunSK;
        }

        public string ImtiPavadinima() { return pavadinimas; } // grąžina pavadinimą
        public int ImtigyvSK() { return gyvSK; } // grąžina gyventoju  skaičių
        public int ImtiJaunSk() { return jaunSK; } // grąžina jaunimo skaičių
        public int ImtiBeDarb() { return jaunBedarb; }
        public void DėtiBedarbius(int bedarb) { jaunBedarb = bedarb; }
        /// <summary>
        /// Užkloti operatoriai rikiavimui
        /// </summary>
        /// <param name="pirmas"></param>
        /// <param name="antras"></param>
        /// <returns></returns>
        public static bool operator <=(Miestas pirmas, Miestas antras)
        {
            return pirmas.jaunSK > antras.jaunSK || pirmas.jaunSK == antras.jaunSK && pirmas.gyvSK < antras.gyvSK;
        }
        /// <summary>
        /// Užkloti operatoriai rikiavimui
        /// </summary>
        /// <param name="pirmas"></param>
        /// <param name="antras"></param>
        /// <returns></returns>
        public static bool operator >=(Miestas pirmas, Miestas antras)
        {
            return pirmas.jaunSK < antras.jaunSK || pirmas.jaunSK == antras.jaunSK && pirmas.gyvSK > antras.gyvSK;
        }

    }
    class DarboBirza
    {
        const int CMaxMk = 1000;
        const int CMaxDn = 30;
        private Miestas[] Miestai;
        public int n { get; set; }
        private int [,] birza;
        public int m { get; set; }
        public DarboBirza()
        {
            n = 0;
            Miestai = new Miestas[CMaxMk];

            m = 0;
            birza = new int[CMaxMk, CMaxDn];
        }
        public Miestas Imti(int nr) { return Miestai [nr]; }
        public void Dėti(Miestas ob) { Miestai[n++] = ob; }
        public void DėtiBedarbius(int i, int j, int r) { birza[i, j] = r; }
        public int ImtiBedarbius(int i, int j) { return birza[i, j]; }
        public void PakeistMiesta(int nr, Miestas mst) { Miestai[nr] = mst; }
        /// <summary>
        /// Suskaičiuoja  ir papildo mėn bedarbių sumą
        /// </summary>
        public void PapilDytiMiesta()
        {
            int suma;
            Miestas mst;
            for (int i = 0; i < m; i++)
            {
                suma = 0;
                for (int j = 0; j < n; j++)
                    suma = suma + birza[i, j];
                mst = Imti(i);
                mst.DėtiBedarbius(suma);
                PakeistMiesta(i, mst);
            }
        }
        /// <summary>
        /// Rikiavimo metodas
        /// </summary>
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Miestas mst = Miestai[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (Miestai[j] <= mst)
                    {
                        mst = Miestai[j];
                        im = j;
                    }
                Miestai[im] = Miestai[i];
                Miestai[i] = mst;
            }
        }
    }
    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\DarboBirza\\bin\\Debug\\Duomenys.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\DarboBirza\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        {
            DarboBirza dBirza = new DarboBirza();

            SkaitytiMiestus(CFd, ref dBirza);
            SkaitytiBedarbius(CFd, ref dBirza);

            if (File.Exists(CFr))
                File.Delete(CFr);

            SpausdintiMiestus(CFr, dBirza, "Pirminiai duomenys");
            SpausdintiBedarbius(CFr, dBirza, "Jaunimo nedarbas");

            dBirza.PapilDytiMiesta();
            SpausdintiMax(CFr, dBirza);

            SpausdintiProc(CFr, dBirza);
            dBirza.Rikiuoti();
            SpausdintiMiestus(CFr, dBirza, "Surikiuota");
            Console.WriteLine("Programa baige darbą!");
        }
        /// <summary>
        /// Nuskaito pirma dalį failo (miestus)
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="dBirza"></param>
        static void SkaitytiMiestus(string fd, ref DarboBirza dBirza)
        {
            string pavadinimas;
            int nn,mm, gyvSK, jaunSK;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm= int.Parse(line);
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pavadinimas = parts[0];
                    gyvSK = int.Parse(parts[1]);
                    jaunSK = int.Parse(parts[2]);
                    Miestas miest;
                    miest = new Miestas();
                    miest.Dėti(pavadinimas, gyvSK, jaunSK);
                    dBirza.Dėti(miest);
                }
            }
        }
        /// <summary>
        /// Nuskaito anrtą dalį failo (bedarbių skaičius)
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="dBirza"></param>
        static void SkaitytiBedarbius(string fd, ref DarboBirza dBirza)
        {
            int nn, mm, jaunBedarb;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                dBirza.n = nn;
                dBirza.m = mm;
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                }
                 for (int z = 0; z < dBirza.m; z++)
                  {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    for (int j = 0; j < dBirza.n; j++)
                    {
                        jaunBedarb = int.Parse(parts[j]);
                        dBirza.DėtiBedarbius(z, j, jaunBedarb);
                    }
                  }
            }
        }
        /// <summary>
        /// Spausdina miestus
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="dBirza"></param>
        /// <param name="antraštė"></param>
        static void SpausdintiMiestus(string fv, DarboBirza dBirza, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 70);
                fr.WriteLine(antraštė);
                fr.WriteLine();
                fr.WriteLine(bruksnys);
                fr.WriteLine(" Nr:     Miestas:   Gyventojų skaičius:    Jaunimo skaičius: ");
                fr.WriteLine("                                               (19-25 metų)   ");
                fr.WriteLine(bruksnys);
                for (int i = 0; i < dBirza.n; i++)
                    fr.WriteLine(" {0,-7} {1,-16} {2,-22} {3}",i+1, dBirza.Imti(i).ImtiPavadinima(), dBirza.Imti(i).ImtigyvSK(), dBirza.Imti(i).ImtiJaunSk()) ;
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Spausdina bedarbių skaičius
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="dBirza"></param>
        /// <param name="antraštė"></param>
        static void SpausdintiBedarbius(string fv, DarboBirza dBirza, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 70);
                fr.WriteLine(antraštė);
                fr.WriteLine();
                fr.WriteLine(bruksnys);
                fr.WriteLine(" Miestas:      I:    II:     III:    IV:      V:    ");
                fr.WriteLine(bruksnys);
                        for (int i = 0; i < dBirza.n; i++)
                        {
                            fr.Write("{0,-12} ", dBirza.Imti(i).ImtiPavadinima());
                            for (int j = 0; j < dBirza.m; j++)
                                fr.Write("{0,-8}", dBirza.ImtiBedarbius(j, i));
                            fr.WriteLine();
                        }
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Randa ir spausdina kurį mėn buvo daugiausia bedarbių
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="dBirza"></param>
        static void SpausdintiMax(string fv, DarboBirza dBirza)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 70);
                fr.WriteLine(bruksnys);
                int max = 0;
                int x = 0;
                for (int i = 0; i < dBirza.n; i++)
                {
                    if (max < dBirza.Imti(i).ImtiBeDarb())
                    {
                        max = dBirza.Imti(i).ImtiBeDarb();
                        x = i+1;
                    }
                }
                fr.WriteLine("Didžiausias nedarbas buvo: {0} mėnesį ir siekė {1} gyventojų ", x, max );
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }

        /// <summary>
        /// Randa ir spausdina kuri men r kuriam mieste buvo mažiausias santykitnis nedarbas
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="dBirza"></param>
        static void SpausdintiProc(string fv, DarboBirza dBirza)
        {
            double min = 100;
            int men = 0;
            string miest = "";
            for (int i = 0; i < dBirza.n; i++)
            {
                for (int j = 0; j < dBirza.m; j++)
                {
                    double gyv = dBirza.Imti(i).ImtigyvSK();
                    double nedlyg =( dBirza.ImtiBedarbius(j, i)  / gyv) * 100;
                    if (nedlyg < min)
                    {
                        min = nedlyg;
                        miest = dBirza.Imti(i).ImtiPavadinima();
                        men = j + 1;
                    }
                }
            }
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Mažiausias santykinis nedarbas yra miesta {0} buvo {1} mėn {2,4:f}%", miest, men, (double)min);
                fr.WriteLine();
                fr.WriteLine();
            }

        }
    }
}
