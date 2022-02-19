using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace _6._1_Prekybos_bazė
{
    class Matrica
    {
        const int CMaxEil = 10; // didžiausis galimas eil skaičius
        const int CMaxSt = 100; // didžiausias galinas stulpeliu skaičius
        private int[,] A;        // duomenų matrica
        public int n { get; set; } // eilučiu skaicius (kasų skaičius)
        public int m { get; set; } // stulpelių skaičius ( dienų skaičius)

        /// <summary>
        /// Pradinių matricos duomenų nustatymas
        /// </summary>
        public Matrica()
        {
            n = 0;
            m = 0;
            A = new int[CMaxEil, CMaxSt];
        }
        /// <summary>
        /// Priskiria klasės matricos kintamajam reikšmę
        /// </summary>
        /// <param name="i"> eilutės (kasos) indeksas</param>
        /// <param name="j"> stulpelio (dienos) indeksas</param>
        /// <param name="pirk"> pirkėjų skaičius</param>
        public void Deti(int i, int j, int pirk)
        {
            A[i, j] = pirk;
        }
        /// <summary>
        /// Grąžina pirkėjų kiekį
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int ImtiReiksme(int i, int j)
        {
            return A[i, j];
        }

    }
    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\6.1_Prekybos_bazė\\bin\\Debug\\Duomenys.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P8\\6.1_Prekybos_bazė\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        {
            Matrica prekybosBaze = new Matrica();
            Skaityti(CFd, ref prekybosBaze);
            if (File.Exists(CFr))
                File.Delete(CFr);
            Spausdinti(CFr, prekybosBaze, "Pradiniai duomeys");
            Spausdinti2(CFr, prekybosBaze, "Duomenys lentelėje");

            VidAptarnavo(CFr, prekybosBaze);

            KiekDienuNedirbo(CFr, prekybosBaze);

            Console.WriteLine("Programa baigė darbą!");
        }
        /// <summary>
        /// Failo duoemnis surašo į kontenerį
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="prekybosBaze"></param>
        static void Skaityti(string fd, ref Matrica prekybosBaze)
        {
            int nn, mm, skaic;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                prekybosBaze.n = nn;
                prekybosBaze.m = mm;
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    for (int j = 0; j < mm; j++)
                    {
                        skaic = int.Parse(parts[j]);
                        prekybosBaze.Deti(i, j, skaic);
                    }
                }
            }
        }
        /// <summary>
        /// Spausdina konteinerio duomenis faile
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="prekybosBaze"></param>
        /// <param name="antraštė"></param>
        static void Spausdinti(string fv, Matrica prekybosBaze, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine();
                fr.WriteLine("Kasų kiekis {0}", prekybosBaze.n);
                fr.WriteLine("Darbo dienų kiekis {0}", prekybosBaze.m);
                fr.WriteLine("Aptarnautų klientų keikiai");
                for (int i = 0; i < prekybosBaze.n; i++)
                {
                    for (int j = 0; j < prekybosBaze.m; j++)
                        fr.Write("{0,4:d}", prekybosBaze.ImtiReiksme(i, j));
                    fr.WriteLine();
                }
                fr.WriteLine();
                fr.WriteLine("Rezultatai");
                fr.WriteLine();
                fr.WriteLine("Viso aptarnauta: {0} klientų", VisoAptarnauta(prekybosBaze));

            }
        }
        static int VisoAptarnauta(Matrica A)
        {
            int suma = 0;
            for (int i = 0; i < A.n; i++)
                for (int j = 0; j < A.m; j++)
                    suma = suma + A.ImtiReiksme(i, j);
            return suma;
        }
        /// <summary>
        /// Spausdina duomenis lentelę
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="prekybosBaze"></param>
        /// <param name="antraštė"></param>
        static void Spausdinti2(string fv, Matrica prekybosBaze, string antraštė)
        {
            const string virsus =
                 "-------------------------------------------------\n"
                + " Kasos nr: Pirm Antr Trec Ketvir Penkt Sest Sekm\n"
                + "-------------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("\n " + antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < prekybosBaze.n; i++)
                {
                    fr.Write("{0, 6}", i + 1);
                    for (int j = 0; j < prekybosBaze.m; j++)
                    {
                        fr.Write("{0,6:d}", prekybosBaze.ImtiReiksme(i, j));
                    }
                    fr.WriteLine();
                }
                fr.WriteLine();
                fr.WriteLine("---------------------------------------------------");
            }
        }
        /// <summary>
        /// Randa, suskaičiuoja ir išveda  vidutinį aptarnauotų klientų skaičių
        /// </summary>
        /// <param name="Cfr"></param>
        /// <param name="A"></param>
        static void VidAptarnavo(string Cfr, Matrica A)
        {
            double vid = 0;
            using (var fr = File.AppendText(CFr))
            {
                for (int i = 0; i < A.n; i++)
                {
                    int suma = 0;
                    
                    for (int j = 0; j < A.m; j++)
                    {
                        suma = suma + A.ImtiReiksme(i, j);
                         vid =  suma / A.m;
                    }
                    fr.WriteLine("Kasa nr. {0} Vidutiniškai aptarnavo {1} klientų.", i + 1, vid);
                }
                fr.WriteLine();
            }
        }
       /// <summary>
       /// Randa suskaičiuoja ir išveda kiek dienų nedirbo kasa
       /// </summary>
       /// <param name="Cfr"></param>
       /// <param name="A"></param>
        static void KiekDienuNedirbo(string Cfr, Matrica A)
        {
            using (var fr = File.AppendText(CFr))
            {
                for (int i = 0; i < A.n; i++)
                {
                    int suma = 0;
                    for (int j = 0; j < A.m; j++)
                        if (A.ImtiReiksme(i, j) == 0)
                        {
                            suma = suma + 1;
                            fr.WriteLine("Kasa nr. {0} nedirbo {1} dienas.", i + 1, suma);
                        }
                }
                fr.WriteLine();
            }
        }
    }
}