using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;


namespace _6._3_Seimos_islaidos
{
    class Asmuo
    {
        private string vardas;
        private double pinigai;
        public Asmuo(string vardas, double pinigai)
        {
            this.vardas = vardas;
            this.pinigai = pinigai;
        }
        public string ImtiVarda() { return vardas; }
        public double ImtiPinigus() { return pinigai; }
    }
    class Matrica
    {
        const int CMaxEil = 100; // didžiausias galimas savaičių skaičius
        const int CMaxSt = 7;   // didžiausias galimas dienų skaičius
        private Asmuo[,] A;
        public int n { get; set; } // eilučiu skaicius (savaičių skaičius)
        public int m { get; set; } // stulpelių skaičius ( dienų skaičius)
        public Matrica()
        {
            n = 0;
            m = 0;
            A = new Asmuo[CMaxEil, CMaxSt];
        }
        public void Deti(int i, int j, Asmuo asmuo)
        {
            A[i, j] = asmuo;
        }
        public Asmuo ImtiReiksme(int i, int j)
        {
            return A[i, j];
        }
    }
    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\6.3_Seimos_islaidos\\bin\\Debug\\Duomenys.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\6.3_Seimos_islaidos\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        {

            Console.InputEncoding = Encoding.Unicode;

            Matrica seimosIslaidos = new Matrica();
            Skaityti(CFd, ref seimosIslaidos);
            if (File.Exists(CFr))
                File.Delete(CFr);
            Spausdinti(CFr, seimosIslaidos, "Pradiniai duoemnys");

            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                fr.WriteLine();
                fr.WriteLine();
                fr.WriteLine("Rezultatai");
                fr.WriteLine();
                fr.WriteLine("Viso išleista: {0,5:c2},", VisosIslaidos(seimosIslaidos));
            }
            KiekDienuNeleidoPinigu(CFr, seimosIslaidos);
            KiekIsleidoVyras(CFr, seimosIslaidos);
            KiekIsleidoŽmona(CFr, seimosIslaidos);
            IslaidosSavaitemis(CFr, ref seimosIslaidos, "Spausdinam lentele");

            // spausdina savaitės dienų išlaidas

            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                fr.WriteLine("Antradinių bendros išlaidos {0,5:c2}", IslaidosSavaitesDienaX(seimosIslaidos, 2));
                fr.WriteLine();
                fr.WriteLine("Šeštadienių bendros išlaidos {0,5:c2},", IslaidosSavaitesDienaX(seimosIslaidos, 6));
                fr.WriteLine();
            }
            //Spausdina savaite ir diena kada buvo išleista daugiausiai
            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                int savaite, diena;
                Asmuo a;
                DienaMaxIslaidos(seimosIslaidos, out savaite, out diena);
                fr.Write("Daugiausia išleista {0} savaitę {1} dieną. ", savaite, diena);
                a = seimosIslaidos.ImtiReiksme(savaite - 1, diena - 1);
                fr.WriteLine("Pinigus išleido {0}: {1,5:c2}", a.ImtiVarda(), a.ImtiPinigus());
                fr.WriteLine();
            }

            SavMinIslaidos(CFr, seimosIslaidos);


            IslaidosDienomis(CFr, ref seimosIslaidos, "");

            Console.WriteLine("Pradiniai duomenys išpausdinti faile: {0}", CFr);
            Console.WriteLine("Programa darbą baigė!!");
        }
        /// <summary>
        /// Failo duomenis surašo į konteinerį
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="seimosIslaidos"></param>
        static void Skaityti(string fd, ref Matrica seimosIslaidos)
        {
            int nn, mm;
            double pinigai;
            string line, vardas;
            Asmuo asmuo;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                seimosIslaidos.n = nn;
                seimosIslaidos.m = mm;
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    for (int j = 0; j < mm; j++)
                    {
                        vardas = parts[2 * j];
                        pinigai = double.Parse(parts[2 * j + 1]);
                        asmuo = new Asmuo(vardas, pinigai);
                        seimosIslaidos.Deti(i, j, asmuo);
                    }
                }
            }
        }
        static void Spausdinti(string fv, Matrica seimosIslaidos, string antraštė)
        {
            Asmuo asmuo;
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine();
                fr.WriteLine("Savaičių kiekis {0}", seimosIslaidos.n);
                fr.WriteLine("Dienų kiekis {0}", seimosIslaidos.m);
                fr.WriteLine();
                for (int j = 0; j < seimosIslaidos.m; j++)
                    fr.Write(" {0,1}-dienis    |", j + 1);
                fr.WriteLine();
                for (int i = 0; i < seimosIslaidos.n; i++)
                {
                    for (int j = 0; j < seimosIslaidos.m; j++)
                    {
                        asmuo = seimosIslaidos.ImtiReiksme(i, j);
                        fr.Write("{0} {1,6:f2}|  ", asmuo.ImtiVarda(), asmuo.ImtiPinigus());
                    }
                }
            }
        }
        /// <summary>
        /// Suskaičiuoja visas išlaidas
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        static decimal VisosIslaidos(Matrica A)
        {
            Asmuo asmuo;
            double suma = 0;
            for (int i = 0; i < A.n; i++)
                for (int j = 0; j < A.m; j++)
                {
                    asmuo = A.ImtiReiksme(i, j);
                    suma = suma + asmuo.ImtiPinigus();
                }
            return (decimal)suma;
        }
        //--------------6.3 savarankiškos---------------
        /// <summary>
        /// Randa kiek dienų nebuvo išleista pinigų
        /// </summary>
        /// <param name="Cfr"></param>
        /// <param name="A"></param>
        static void KiekDienuNeleidoPinigu(string Cfr, Matrica A)
        {

            using (var fr = File.AppendText(CFr))
            {
                Asmuo asmuo;
                int kiek = 0;
                for (int i = 0; i < A.n; i++)
                    for (int j = 0; j < A.m; j++)
                    {
                        asmuo = A.ImtiReiksme(i, j);
                        if (asmuo.ImtiPinigus() == 0.0)

                            kiek = kiek + 1;
                    }
                fr.WriteLine();
                fr.WriteLine("Šeima pinigų neleido {0} dienas.", kiek);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Randa ir spausdina kiek iš viso išleido vyras
        /// </summary>
        /// <param name="Cfr"></param>
        /// <param name="A"></param>
        static void KiekIsleidoVyras(string Cfr, Matrica A)
        {

            using (var fr = File.AppendText(CFr))
            {
                Asmuo asmuo;
                double suma = 0;
                for (int i = 0; i < A.n; i++)
                    for (int j = 0; j < A.m; j++)
                    {
                        asmuo = A.ImtiReiksme(i, j);
                        if (asmuo.ImtiVarda() == "vyras")

                            suma = suma + asmuo.ImtiPinigus();
                    }
                fr.WriteLine();
                fr.WriteLine("Vyras išleido {0}.", suma);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Randa ir spausdina kiek iš viso išleido žmona
        /// </summary>
        /// <param name="Cfr"></param>
        /// <param name="A"></param>
        static void KiekIsleidoŽmona(string Cfr, Matrica A)
        {
            using (var fr = File.AppendText(CFr))
            {
                Asmuo asmuo;
                double suma = 0;
                for (int i = 0; i < A.n; i++)
                    for (int j = 0; j < A.m; j++)
                    {
                        asmuo = A.ImtiReiksme(i, j);
                        if (asmuo.ImtiVarda() == "žmona")

                            suma = suma + asmuo.ImtiPinigus();
                    }
                fr.WriteLine();
                fr.WriteLine("Žmona išleido {0}.", suma);
                fr.WriteLine();
            }
        }
        //----------------6.4 ------------------------
        /// <summary>
        /// Spausdina lentele duomenis kiek išleista per savaitę
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="A"></param>
        /// <param name="antraštė"></param>
        static void IslaidosSavaitemis(string fv, ref Matrica A, string antraštė)
        {
            const string virsus =
                 "-------------------------\n"
                + " Savaitės Nr: Išlaidos:\n"
                + "------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("\n " + antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < A.n; i++)
                {
                    double suma = 0;
                    for (int j = 0; j < A.m; j++)
                    {
                        Asmuo x = A.ImtiReiksme(i, j);
                        suma = suma + x.ImtiPinigus();
                    }
                    fr.WriteLine(" {0,5}        {1,8:c2}.", i + 1, (decimal)suma);
                }
            }
        }
        /// <summary>
        /// Randa kuria savaites diena buvo išleista daugiausiai
        /// </summary>
        /// <param name="A"></param>
        /// <param name="nr"></param>
        /// <returns></returns>
        static decimal IslaidosSavaitesDienaX(Matrica A, int nr)
        {
            double suma = 0;
            for (int i = 0; i < A.n; i++)
            {
                Asmuo x = A.ImtiReiksme(i, nr - 1);
                suma = suma + x.ImtiPinigus();
            }
            return (decimal)suma;
        }
        /// <summary>
        /// suskaičiuoja kuria savaite ir kuria diena sav dieną buvo isleista did pinigu suma
        /// </summary>
        /// <param name="A"></param>
        /// <param name="eilNr"></param>
        /// <param name="stNr"></param>
        static void DienaMaxIslaidos(Matrica A, out int eilNr, out int stNr)
        {
            eilNr = -1;
            stNr = -1;
            double max = 0;
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                {
                    double x = A.ImtiReiksme(i, j).ImtiPinigus();
                    if (x > max)
                    {
                        max = x;
                        eilNr = i + 1;
                        stNr = j + 1;
                    }
                }
            }
        }
        //----------------6.4 savarankiškos ------------------------
        /// <summary>
        /// suskaičiuoja kuria sav buvo mažiausiai išlaidų
        /// </summary>
        /// <param name="Cfr"></param>
        /// <param name="A"></param>
        static void SavMinIslaidos(string Cfr, Matrica A)
        {

            using (var fr = File.AppendText(CFr))
            {
                int min = 0;
                double suma = 0;
                for (int j = 0; j < A.m; j++)
                    suma += A.ImtiReiksme(min, j).ImtiPinigus();
                for (int i = 0; i < A.n; i++)
                {
                    double suma1 = 0;
                    for (int j = 0; j < A.m; j++)
                    {
                        suma1 += A.ImtiReiksme(i, j).ImtiPinigus();
                    }
                    if (suma1 < suma)
                    {
                        suma = suma1;
                        min = i;
                    }
                }
                fr.WriteLine();
                fr.WriteLine("Mažiausia išlaidų buvo {0} savaite. {1,5:c2}", min + 1, suma);
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Spausdina išlaidas dienomis
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="A"></param>
        /// <param name="antraštė"></param>
        static void IslaidosDienomis(string fv, ref Matrica A, string antraštė)
        {
            const string virsus =
                 "-------------------------\n"
                + " Dienos Nr: Išlaidos:\n"
                + "------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("\n " + antraštė);
                fr.WriteLine(virsus);
                for (int j = 0; j < A.m; j++)
                {
                    double suma = 0;
                    for (int i = 0; i < A.n; i++)
                    {
                        Asmuo x = A.ImtiReiksme(i, j);
                        suma = suma + x.ImtiPinigus();
                    }
                    fr.WriteLine(" {0,5}        {1,8:c2}.", j + 1, (decimal)suma);
                }
            }
        }
    }
}

