using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4._1_Sodas
{
    class Obelis
    {
        private int kiek,
            priaug;
        private int koef1, koef2;
        /// <summary>
        /// Pradiniai obels duomenys
        /// </summary>
        public Obelis()
        {
            kiek = 0;
            priaug = 16;
            koef1 = 1;
            koef2 = 2;
        }
        /// <summary>
        /// Obels duomenys
        /// </summary>
        /// <param name="kiek"> pirmaisiais metais uzderejusiu obuoliu kiekis</param>
        /// <param name="priaug"> obuoliu prieaugis kiekvienais metais</param>
        /// <param name="koef1"> desnio koeficentas a</param>
        /// <param name="koef2">desnio koeficentas b</param>
        public Obelis(int kiek, int priaug, int koef1, int koef2)
        {
            this.kiek = kiek;
            this.priaug = priaug;
            this.koef1 = koef1;
            this.koef2 = koef2;
        }

        /// <summary>
        /// Spausdinimo metodas
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, 5:d} {1, 6:d} {2, 5:d} {3, 7:d}", koef1, koef2, kiek, priaug);
            return eilute;
        }
        /// <summary>
        /// grazina uzderejusiu obuoliu kieki
        /// </summary>
        /// <param name="a"> 1-asis desnio koeficiantas</param>
        /// <param name="b"> 2-asis desnio koeficiantas</param>
        /// <param name="z"> dėsnio parametras </param>
        /// <returns></returns>
        public int Dėsnis(int a, int b, double z)
        {
            if (Math.Sin(a * z) > 0.1)
            {
                double t = Math.Pow(Math.Sin(a * z) - 0.1, 0.5);
                int y = (int)Math.Floor(a - b * t + z * t * t);
                return y;
            }
            else
                return 0;
        }
        /// <summary>
        /// Apskaičiuoja ir ekrane lenetle spausdina kiekvienais metais iki nurodytu metu obels  užrerėjusiu oboulių kiekį
        /// </summary>
        /// <param name="metai"> metų kiekis</param>
        public void Obuoliai(int metai)
        {
            int z = kiek;
            int y;
            Console.WriteLine(" -----------------------");
            Console.WriteLine(" Metai  Obuolių kiekis ");
            Console.WriteLine(" -----------------------");
            for (int i = 0; i < metai; i++)
            {
                y = Dėsnis(koef1, koef2, z);
                if (y > 0)
                    Console.WriteLine("{0,5:d}  {1,8:d}", i + 1, y);
                else
                    Console.WriteLine("{0,5:d}  nėra obuolių", i + 1);
                z = z + priaug;
            }
            Console.WriteLine(" -----------------------\r\n");
        }

        public int VisoObuolių(int metai)
        {
            int z = kiek;
            int y;
            int suma=0;
            for (int i = 0; i < metai; i++)
            {
                y = Dėsnis(koef1, koef2, z);
                suma = suma + y;
                z = z + priaug;
            }
            return suma;
        }


    }
    class Sodas
    {
        const int Cmaxi = 100;
        private Obelis[] Obelys;
        private int n;
        public Sodas()
        {
            n = 0;
            Obelys = new Obelis[Cmaxi];
        }
        /// <summary>
        /// grazina nurodyto indekso obels objekta
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Obelis Imti(int i) { return Obelys[i]; }
        /// <summary>
        /// Grazina obelu kieki
        /// </summary>
        /// <returns></returns>
        public int Imti() { return n; }
        /// <summary>
        /// Padeda i obelu objektu masyva nauja obeli ir masyvo dydi padidina viebetu
        /// </summary>
        /// <param name="ob"></param>
        public void Dėti(Obelis ob) { Obelys[n++] = ob; }
    }
    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\Sodas\\bin\\Debug\\U1.txt";
        static void Main(string[] args)
        {
            Sodas sodas = new Sodas();
            Skaityti(ref sodas, CFd);
            Spausdinti(sodas);

            int metai;
            Console.Write("Įveskite metų reikšmę: ");
            metai = int.Parse(Console.ReadLine());
            Skaičiuoti(sodas, metai);
       

            Sodas sodasN = new Sodas();
            int kiek;
            Console.Write("Sunokintu obouliu kiekis: ");
            kiek = int.Parse(Console.ReadLine());
            Formuoti(sodas, metai, ref sodasN, kiek);
            Spausdinti(sodasN);

            Console.WriteLine("Programa baigė darbą!");
        }
        /// <summary>
        /// Failo duomenis surašo į konteinerį
        /// </summary>
        /// <param name="sodas"> obelu konteineris</param>
        /// <param name="fv"> duomenu failo vardas</param>
        static void Skaityti(ref Sodas sodas, string fv)
        {
            int koef1, koef2, kiek, priaug, n;
            string line;
            using (StreamReader reader = new StreamReader(fv))
            {
                n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(';');
                    koef1 = int.Parse(parts[0]);
                    koef2 = int.Parse(parts[1]);
                    kiek = int.Parse(parts[2]);
                    priaug = int.Parse(parts[3]);
                    Obelis ob = new Obelis(kiek, priaug, koef1, koef2);
                    sodas.Dėti(ob);
                }
            }
        }
        /// <summary>
        /// Spausdina konteinerio duomenis ekrane lentele
        /// </summary>
        /// <param name="sodas"> obelu koteineris</param>
        static void Spausdinti(Sodas sodas)
        {
            string virsus = " Informacija apie obelis \r\n"
            + " --------------------------------- \r\n"
            + " Nr. koef1  koef2   kiek   prieaug \r\n"
            + " --------------------------------- ";
            Console.WriteLine(virsus);
            for (int i = 0; i < sodas.Imti(); i++)
                Console.WriteLine("{0,4:d} {1}", i + 1, sodas.Imti(i).ToString());
            Console.WriteLine(" -------------------------------- \n\n");
        }
        /// <summary>
        /// derliu ekrane lentele
        /// </summary>
        /// <param name="sodas"> obelu konteineris</param>
        /// <param name="metai"> metu kiekis</param>
        static void Skaičiuoti(Sodas sodas, int metai)
        {
            Console.WriteLine(" Informacija apie derlių");
            for (int i = 0; i < sodas.Imti(); i++)
            {
                Console.WriteLine("{0,3:d} obelis", i + 1);
                sodas.Imti(i).Obuoliai(metai);
            }
        }

        /// <summary>
        /// iš pirmojo konteinerio atrenka į antraji konteineri obelis, kurios per nurodyta metu kieki 
        /// sunokino daugiau negu nurodytas kiekis obuoliu
        /// </summary>
        /// <param name="sodas"> pirmasis obelu konteineris</param>
        /// <param name="metai"> metu kiekis</param>
        /// <param name="sodasN"> antradis obelu konteineris</param>
        /// <param name="kiek"> obuoliu kiekis</param>
        static void Formuoti(Sodas sodas, int metai, ref Sodas sodasN, int kiek)
        {
            for (int i = 0; i < sodas.Imti(); i++)
            {
                if (sodas.Imti(i).VisoObuolių(metai) > kiek)
                    sodasN.Dėti(sodas.Imti(i));
            }
            
        }
       


    }


}

