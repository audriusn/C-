using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace PrekybosTinklas
{
    class Kasininkas
    {
        private string vardas, pavarde;
        private int gimimoMetai, kasosNr;
        private double apyvarta;

        public Kasininkas()
        {
            vardas = "";
            pavarde = "";
            gimimoMetai = 0;
            kasosNr = 0;        
        }
        public void Dėti(string vardas, string pavarde, int gimimoMetai, int kasosNr)
        {
            this.vardas = vardas;
            this.pavarde = pavarde;
            this.gimimoMetai = gimimoMetai;
            this.kasosNr = kasosNr;
        }
        public string ImtiVarda() { return vardas; } // grąžina varda
        public string ImtiPavarde() { return pavarde; } // grąžina pavarde
        public int ImtiGimimoMetai() { return gimimoMetai; } // grąžina gimimo metus
        public int ImtiKasosNr() { return kasosNr; } // grazina kasos numeri
        public double ImtiaApyvarta() { return apyvarta; } // grazina apyvartą
        public void DėtiApyvartą(double apyv) { apyvarta = apyv; }
    }
    class PrekybosTinklas
    {
        const int CMaxMk = 1000;
        const int CMaxDn = 30;
        private Kasininkas[] Kasininkai;
        public int n { get; set; }
        private double[,] Pinigai;
        public int m { get; set; }
        public PrekybosTinklas()
        {
            n = 0;
            Kasininkai = new Kasininkas[CMaxMk];

            m = 0;
            Pinigai = new double[CMaxMk, CMaxDn];
        }
        public Kasininkas Imti(int nr) { return Kasininkai[nr]; }
        public void Dėti(Kasininkas ob) { Kasininkai[n++] = ob; }
        public void DėtiPinigus(int i, int j, double r) { Pinigai[i, j] = r; }
        public double ImtiPinigus(int i, int j) { return Pinigai[i, j]; }
        public void PakeistKasininka(int nr, Kasininkas mst) { Kasininkai[nr] = mst; }
        /// <summary>
        /// Papildo kasininkus apyvartomis
        /// </summary>
        public void PapilDytiKasininką()
        {
            double suma;
            Kasininkas leid;
            for (int j = 0; j < n; j++)
            {
                suma = 0;
                for (int i = 0; i < m; i++)
                    suma = suma + Pinigai[i, j];
                leid = Imti(j);
                leid.DėtiApyvartą(suma);
                PakeistKasininka(j, leid);
            }
        }
    }
        internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\PrekybosTinklas\\bin\\Debug\\Duomenys.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\PrekybosTinklas\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        {
            PrekybosTinklas prekT = new PrekybosTinklas();

            SkaitytiKasininkus(CFd, ref prekT);
            SkaitytiPinigus(CFd, ref prekT);
            if (File.Exists(CFr))
                File.Delete(CFr);

            SpausdintiKasininkus(CFr, prekT,"Pradiniai duomenys");
            SpausdintiPinigus(CFr, prekT,"Surinkti pinigai");
            prekT.PapilDytiKasininką();
            SpausdintiKasininkus(CFr, prekT, "Pradiniai duomenys");
            SpausdintiAtlyginimus(CFr, prekT,"Kasininkų atlyginimai");
            SpausdintiJauniausioAtl(CFr, prekT, "Jauniausio atlyginimas");
            SpausdintiVyriausioAtl(CFr, prekT, "Vyriausio atlyginimas");
            SpausdintiDidDienosVidurki(CFr, prekT, "Geriausios dienos vidurkis");
        }
        /// <summary>
        /// Nuskaito pirmą dalį failo.(Kasininkus)
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="prekT"></param>
        static void SkaitytiKasininkus(string fd, ref PrekybosTinklas prekT)
        {
            string vardas, pavarde;
            int nn, mm, gimimoMetai, kasosNR;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    vardas = parts[0];
                    pavarde = parts[1];
                    gimimoMetai = int.Parse(parts[2]);
                    kasosNR = int.Parse(parts[3]);
                    Kasininkas kasn;
                    kasn = new Kasininkas();
                    kasn.Dėti(vardas, pavarde, gimimoMetai, kasosNR);
                    prekT.Dėti(kasn);
                }
            }
        }
        /// <summary>
        /// Nuskaito pinigų matricą
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="prekT"></param>
        static void SkaitytiPinigus(string fd, ref PrekybosTinklas prekT)
        {
            int nn, mm;
            double pinigai;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                prekT.n = nn;
                prekT.m = mm;
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                }
                for (int z = 0; z < prekT.m; z++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    for (int j = 0; j < prekT.n; j++)
                    {
                        pinigai = double.Parse(parts[j]);
                        prekT.DėtiPinigus(z, j, pinigai);
                    }
                }
            }
        }
        /// <summary>
        /// Spausdina kasininkus su apyvartomis
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="prekT"></param>
        /// <param name="antraštė"></param>
        static void SpausdintiKasininkus(string fv, PrekybosTinklas prekT, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 70);
                fr.WriteLine(antraštė);
                fr.WriteLine();
                fr.WriteLine(bruksnys);
                fr.WriteLine(" Vardas:    Pavardė:  Gimimo metai:   Kasos NR: Apyvarta: ");
                fr.WriteLine(bruksnys);
                for (int i = 0; i < prekT.n; i++)
                    fr.WriteLine(" {0,-10} {1,-14} {2,-13} {3,-7} {4}", prekT.Imti(i).ImtiVarda(), prekT.Imti(i).ImtiPavarde(), prekT.Imti(i).ImtiGimimoMetai(), prekT.Imti(i).ImtiKasosNr(), prekT.Imti(i).ImtiaApyvarta());
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Spausdina apyvartas dienomis
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="prekT"></param>
        /// <param name="antraštė"></param>
        static void SpausdintiPinigus(string fv, PrekybosTinklas prekT, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 70);
                fr.WriteLine(antraštė);
                fr.WriteLine();
                fr.WriteLine(bruksnys);
                fr.WriteLine("Vardas, Pavardė:      I:      II:      III:      IV:      V:      VI:  ");
                fr.WriteLine(bruksnys);
                for (int i = 0; i < prekT.n; i++)
                {
                    fr.Write("{0,-7}{1,-13}", prekT.Imti(i).ImtiVarda(), prekT.Imti(i).ImtiPavarde());
                    for (int j = 0; j < prekT.m; j++)
                        fr.Write("{0,-9}", prekT.ImtiPinigus(j, i));
                    fr.WriteLine();
                }
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Spausdina visus atyginimus
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="prekT"></param>
        /// <param name="antraštė"></param>
        static void SpausdintiAtlyginimus(string fv, PrekybosTinklas prekT, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 70);
                fr.WriteLine(antraštė);
                fr.WriteLine();
                fr.WriteLine(bruksnys);
                fr.WriteLine("Vardas, Pavardė:    Atlyginimas:  ");
                fr.WriteLine(bruksnys);
                for (int i = 0; i < prekT.n; i++)
                {
                    double alga = prekT.Imti(i).ImtiaApyvarta() * 0.01;
                    fr.Write("{0,-7}{1,-13} {2,2:f}", prekT.Imti(i).ImtiVarda(), prekT.Imti(i).ImtiPavarde(), alga);
                    fr.WriteLine();
                }
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Randa ir išspausdina jauniausio kasininko atlyginima
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="prekT"></param>
        /// <param name="antraštė"></param>
        static void SpausdintiJauniausioAtl(string fv, PrekybosTinklas prekT, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 60);
                fr.WriteLine(bruksnys);
                double max = 0;
                double alga = 0;
                string maxpav = "";
                for (int i = 0; i < prekT.n; i++)
                {
                    if (max < prekT.Imti(i).ImtiGimimoMetai())
                    {
                        max = prekT.Imti(i).ImtiGimimoMetai();
                        maxpav = prekT.Imti(i).ImtiVarda();
                        alga = prekT.Imti(i).ImtiaApyvarta() * 0.01;
                    }
                }
                fr.WriteLine("Jauniausias kasininkas: {0}, gimęs {1} uždirbo: {2,2:f} ", maxpav,max,alga);
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Randa ir išspausdina vyriausio kasininko atlyginima
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="prekT"></param>
        /// <param name="antraštė"></param>
        static void SpausdintiVyriausioAtl(string fv, PrekybosTinklas prekT, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 60);
                fr.WriteLine(bruksnys);
                double alga = 0;
                string maxpav = "";
                int min = prekT.Imti(0).ImtiGimimoMetai();
                for (int i = 0; i < prekT.n; i++)
                {
                    if (prekT.Imti(i).ImtiGimimoMetai() < min  )
                    {
                        min = prekT.Imti(i).ImtiGimimoMetai();
                        maxpav = prekT.Imti(i).ImtiVarda();
                        alga = prekT.Imti(i).ImtiaApyvarta() * 0.01;
                    }
                }
                fr.WriteLine("Vyriausias kasininkas: {0}, gimęs {1} uždirbo: {2,2:f} ", maxpav, min, alga);
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Randa ir spausdina didžiausia dienos pardavimų vidurkį
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="prekT"></param>
        /// <param name="antraštė"></param>
        static void SpausdintiDidDienosVidurki(string fv, PrekybosTinklas prekT, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                double suma = 0;
                int diena = 0;
                for (int i = 0; i < prekT.n; i++)
                {
                    double vid = 0;
                    for (int j = 0; j < prekT.m; j++)
                    {
                        vid += prekT.ImtiPinigus(i, j);
                    }
                    vid = vid / prekT.n;
                    if (suma < vid)
                    {
                        suma = vid;
                        diena = i;
                    }
                }
                fr.WriteLine(" Vidutiniškai didžiausi pardavimai {0} dieną: {1}", diena + 1, suma);

            }
        }
    }
}
