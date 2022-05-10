using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//namespace Tekstas_P05
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//        }
//    }
//}

// 5.1. Eilutės simbolių analizė
// Užduotis. Raidės.
//namespace Tekstas_P05
//{
//    //------------------------------------------------------------
//    /** Klasė, skirta skaičiuoti raidžių dažniams.

//    @class RaidziuDazniai */
//    class RaidziuDazniai
//    {
//        private const int CMax = 256;
//        private int[] Rn; // raidžių pasikartojimai
//        public string eil { get; set; } // KAS CIA???

//        public RaidziuDazniai()
//        {
//            eil = "";
//            Rn = new int[CMax];
//            for (int i = 0; i < CMax; i++)
//                Rn[i] = 0; // ??? 
//        }
//        public int Imti(char sim)
//        {
//            return Rn[sim];
//        }
//        //------------------------------------------------------------
//        /** Skaičiuoja raidžių pasikartojimus */
//        //------------------------------------------------------------
//        public void kiek()
//        {
//            for (int i = 0; i < eil.Length; i++)
//            {
//                if (('a' <= eil[i] && eil[i] <= 'z') ||
//                ('A' <= eil[i] && eil[i] <= 'Z'))
//                    Rn[eil[i]]++;
//            }
//        }
//      //------------------------------------------------------------
//// Surikiuoja masyvą Mas(kiek) skaičių didėjimo tvarka 
//static void MinMax() // kuris kintamasis cia yra kiek ?
//{
//    int pag = 0; // pagalbinis kintamasis reikšmių sukeitimui 
//    int minInd; // mažiausios reikšmės elemento indeksas 
//    for (int i = 0; i < 26 - 1; i++)
//    {
//        minInd = i;
//        for (int j = i + 1; j < 26; j++)
//        {
//            if (Rn[j] < Rn[minInd]) minInd = j;
//        }
//        pag = Rn[i];
//        Rn[i] = Rn[minInd];
//        Rn[minInd] = pag;
//    }
//}
////-------------------------------------------------------------

// }
//------------------------------------------------------------

//    class Program
//    {
//        const string CFd = "D:\\2016 Ruduo\\Papildomi mokslai Informatikos kryptyje\\Programavimas\\P175B117 Objektinio programavimo pagrindai I\\Programos\\Laboratoriniai\\Tekstas_P05\\D1.txt";
//        const string CFr = "D:\\2016 Ruduo\\Papildomi mokslai Informatikos kryptyje\\Programavimas\\P175B117 Objektinio programavimo pagrindai I\\Programos\\Laboratoriniai\\Tekstas_P05\\R1.txt";

//        static void Main(string[] args)
//        {
//            //RaidziuDazniai eil = new RaidziuDazniai();
//            //Console.WriteLine("Įveskite eilutę iš mažųjų ir didžiųjų raidžių");
//            //string line = Console.ReadLine();
//            //eil.eil = line;
//            //eil.kiek();
//            //Spausdinti(CFr, eil);
//            //Console.WriteLine("Programa baigė darbą!");

//            RaidziuDazniai eil = new RaidziuDazniai();
//            Dazniai(CFd, eil);

//            Spausdinti(CFr, eil);

//            RaidziuDazniai[] Rn = new RaidziuDazniai[500];

//            Console.WriteLine(eil.minmax;)

//            Console.WriteLine("Programa baigė darbą!");
//        }
//        //------------------------------------------------------------
//        /** Spausdina į nurodytą failą raidžių dažnius dviem stulpeliais.
//            @param fv – failo vardas
//            @param eil – eilutės objektas */
//        //------------------------------------------------------------

//        static void Spausdinti(string fv, RaidziuDazniai eil)
//        {
//            using (var fr = File.CreateText(fv))
//            {
//                for (char sim = 'a'; sim <= 'z'; sim++)
//                    fr.WriteLine("{0, 3:c} {1, 4:d} |{2, 3:c} {3, 4:d}", sim, eil.Imti(sim), Char.ToUpper(sim), eil.Imti(Char.ToUpper(sim))); // ??? 
//            }
//        }
//        //------------------------------------------------------------
//        /** Įveda iš nurodyto failo ir skaičiuoja raidžių dažnius.
//            @param fv – failo vardas
//            @param eil – eilutės objektas */
//        //------------------------------------------------------------
//        static void Dazniai(string fv, RaidziuDazniai eil)
//        {
//            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
//            {
//                string line;
//                while ((line = reader.ReadLine()) != null)
//                {
//                    eil.eil = line;
//                    eil.kiek();
//                }
//            }
//        }
//        //------------------------------------------------------------
//       //

//    }
//}


////5.2. Teksto eilučių šalinimas
////Užduotis. Ilgiausia teksto eilutė.
////Tekstiniame faile duotas tekstas.Tekstą sudaro viena ir daugiau eilučių.Parašykite programą, kuri pašalintų iš teksto ilgiausią eilutę.
//namespace Tekstas_P05
//{
//    
//    
//    class Program
//    {
//        const string CFd = "D:\\2016 Ruduo\\Papildomi mokslai Informatikos kryptyje\\Programavimas\\P175B117 Objektinio programavimo pagrindai I\\Programos\\Laboratoriniai\\Tekstas_P05\\D2.txt";
//        const string CFd2 = "D:\\2016 Ruduo\\Papildomi mokslai Informatikos kryptyje\\Programavimas\\P175B117 Objektinio programavimo pagrindai I\\Programos\\Laboratoriniai\\Tekstas_P05\\D3.txt";
//        const string CFr = "D:\\2016 Ruduo\\Papildomi mokslai Informatikos kryptyje\\Programavimas\\P175B117 Objektinio programavimo pagrindai I\\Programos\\Laboratoriniai\\Tekstas_P05\\R2.txt";
//        const string CFr1 = "D:\\2016 Ruduo\\Papildomi mokslai Informatikos kryptyje\\Programavimas\\P175B117 Objektinio programavimo pagrindai I\\Programos\\Laboratoriniai\\Tekstas_P05\\R3.txt";
//        const string CFr2 = "D:\\2016 Ruduo\\Papildomi mokslai Informatikos kryptyje\\Programavimas\\P175B117 Objektinio programavimo pagrindai I\\Programos\\Laboratoriniai\\Tekstas_P05\\R4.txt";

//        static void Main(string[] args)
//        {
//            //int nr;
//            //Skaityti(CFd, out nr);
//            //Console.WriteLine("Ilgiausios eilutės nr. {0, 4:d}", nr + 1);
//            //Console.WriteLine("Programa baigė darbą!");
//            RaidziuDazniai Rd = new RaidziuDazniai();

//            //-------------------------------------------------------------------
//            string[] lines = File.ReadAllLines(CFd, Encoding.GetEncoding(1257));
//            int nreil = 0;
//            using (var fr = File.CreateText(CFr1))
//            {
//                foreach (string line in lines)
//                {
//                    if (line.Length >= 0)
//                    {
//                        nreil++;
//                    }
//                }
//            }

//            //  Console.WriteLine("{0}", nreil);

//            int failoeilnr = nreil; // Viso failo eiluciu skaicius
//                                    //-----------------------------------------------------------------


//            ////  int ilgis = 0;
//            //  int nreil1 = failoeilnr; // zinome kiek isviso faile yra eiluciu
//            //  using (var fr = File.CreateText(CFr1))
//            //  {
//            //      using (StreamReader reader = new StreamReader(CFd, Encoding.GetEncoding(1257)))
//            //      {
//            //          string[] lines1 = File.ReadAllLines(CFd, Encoding.GetEncoding(1257));
//            //          string line;
//            //          int maxilgis = 0;
//            //          for (int i = 0; i < failoeilnr && ((line = reader.ReadLine()) != null); i++)
//            //          {
//            //              if (line.Length != maxilgis)
//            //                  maxilgis = i;

//            //              Console.WriteLine("{0}", maxilgis);
//            //          }


//            //      }
//            //  }



//            //// eilutėje 
//            //static int SkirtSkaitmenuSkaicius(string e)
//            //{
//            //    char[] balses = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
//            //    intkiek = 0;
//            //    for (inti = 0; i < balses.Length; i++)
//            //        if (e.IndexOf(balses[i]) >= 0) kiek++; returnkiek; }



//            int nr;

//            //Skaityti(Rd, CFd, out nr);
//            //Spausdinti(CFd, CFr, nr);
//            //Console.WriteLine("Ilgiausios eilutės nr. {0, 4:d}", nr + 1);

//            int sk =   Skaityti22(Rd, CFd, out nr);

//            SkaitoRaso(CFd, CFr1, sk, nreil);

//            SkaitoRaso2(CFd2, CFr2, nreil); // trina tuscias

//            Console.WriteLine("{0}", sk);

//            Console.WriteLine("Programa baigė darbą!");
//        }
//        //------------------------------------------------------------
//        /** Suranda ilgiausios eilutės numerį.
//            @param fv - duomenų failo vardas
//            @param nr - ilgiausios eilutės numeris */
//        //------------------------------------------------------------
//        static void Skaityti(RaidziuDazniai Rd, string fv, out int nr)
//        {
//            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
//            int ilgis = 0;
//            nr = 0;
//            int nreil = 0;

//            foreach (string line in lines)
//            {
//                if (line.Length > ilgis)
//                {
//                    ilgis = line.Length;
//                    nr = nreil;

//                }
//                nreil++;

//            }
//        }
//        //------------------------------------------------------------
//        static int Skaityti22(RaidziuDazniai Rd, string fv, out int nr)
//        {
//            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
//            int ilgis = 0;
//            nr = 0;
//            int nreil = 0;

//            foreach (string line in lines)
//            {
//                if (line.Length > ilgis)
//                {
//                    ilgis = line.Length;
//                    nr = nreil;

//                }
//                nreil++;

//            }
//            return ilgis ;
//        }
//       
//        //  ------------------------------------------------------------
//        /** Spausdina tekstą į failą be ilgiausios eilutęs.
//            @param fv - duomenų failo vardas
//            @param fvr - rezultatų failo vardas
//            @param nr - ilgiausios eilutės numeris */
//        //  -----------------------------------------------------------
//        static void Spausdinti(string fv, string fvr, int nr)
//        {
//            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
//            int nreil = 0;
//            using (var fr = File.CreateText(fvr))
//            {
//                foreach (string line in lines)
//                {
//                    if (nr != nreil)
//                    {
//                        fr.WriteLine(line);
//                    }
//                    nreil++;
//                }
//            }
//        }

//        //------------------------------------------------------------
//        // pašalinimas visu ilgiausiu eiluciu 
//        static void SkaitoRaso(string fv, string fvr, int maxilgis, int nrvisu)
//        {
//           using (var frr = File.CreateText(fvr))
//            {
//              //  using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
//                {
//                   // for (int i = 0; i < nrvisu; i++)
//                    {
//                        string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
//                        // reader.ReadLine();

//                        //  string line;

//                        foreach (string line in lines)
//                        {
//                            if (line.Length < maxilgis)
//                            {
//                                frr.WriteLine(line);
//                            }
//                        }

//                        //  while ((line = reader.ReadLine()) != null)
//                        //    frr.WriteLine(line);
//                    }
//                }
//            }
//        }
//        //--------------------------------------------------------
//        // pašalinimas tusciu eiluciu 
//        static void SkaitoRaso2(string fv, string fvr, int nrvisu)
//        {
//            int ilgis = 0;
//            using (var frr = File.CreateText(fvr))
//            {
//                //  using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
//                {
//                    // for (int i = 0; i < nrvisu; i++)
//                    {
//                        string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
//                        // reader.ReadLine();

//                        //  string line;

//                        foreach (string line in lines)
//                        {
//                            if (line.Length > ilgis)
//                            {
//                                frr.WriteLine(line);
//                            }
//                        }

//                        //  while ((line = reader.ReadLine()) != null)
//                        //    frr.WriteLine(line);
//                    }
//                }
//            }
//        }
//        //--------------------------------------------------------

//    }
//}

//    //5.3. Teksto eilučių dalių šalinimas
// Užduotis. C++ vienos eilutės komentavimas //.
// Tekstiniame faile duotas C++ programos tekstas.Pašalinkite iš teksto komentarus, kurie žymimi //.

//namespace Tekstas_P05
//{
//    //------------------------------------------------------------
//    /** Klasė, skirta skaičiuoti raidžių dažniams
//    @class RaidziuDazniai */

//    class RaidziuDazniai
//    {
//        private const int CMax = 256;
//        private int[] Rn; // raidžių pasikartojimai
//        public string eil { get; set; } // KAS CIA???

//        public RaidziuDazniai()
//        {
//            eil = "";
//            Rn = new int[CMax];
//            for (int i = 0; i < CMax; i++)
//                Rn[i] = 0; // ??? 
//        }
//        public int Imti(char sim)
//        {
//            return Rn[sim];
//        }
//        //------------------------------------------------------------
//        /** Skaičiuoja raidžių pasikartojimus */
//        //------------------------------------------------------------
//        public void kiek()
//        {
//            for (int i = 0; i < eil.Length; i++)
//            {
//                if (('a' <= eil[i] && eil[i] <= 'z') ||
//                ('A' <= eil[i] && eil[i] <= 'Z'))
//                    Rn[eil[i]]++;
//            }
//        }
//        //------------------------------------------------------------
//        class Program
//        {
//            const string CFd = "D:\\2016 Ruduo\\Papildomi mokslai Informatikos kryptyje\\Programavimas\\P175B117 Objektinio programavimo pagrindai I\\Programos\\Laboratoriniai\\Tekstas_P05\\D5.txt";
//            const string CFr = "D:\\2016 Ruduo\\Papildomi mokslai Informatikos kryptyje\\Programavimas\\P175B117 Objektinio programavimo pagrindai I\\Programos\\Laboratoriniai\\Tekstas_P05\\R5.txt";
//            const string CFa = "D:\\2016 Ruduo\\Papildomi mokslai Informatikos kryptyje\\Programavimas\\P175B117 Objektinio programavimo pagrindai I\\Programos\\Laboratoriniai\\Tekstas_P05\\A.txt";


//            static void Main(string[] args)
//            {
//                Apdoroti(CFd, CFr, CFa);

//                Console.WriteLine("Programa baigė darbą!");
//            }
//        }
//        //------------------------------------------------------------
//        /** Skaito, analizuoja ir rašo į skirtingus failus.
//            @param fv - duomenų failo vardas
//            @param fvr - rezultatų failo vardas
//            @param fa - analizės failo vardas */
//        //------------------------------------------------------------
//        static void Apdoroti(string fv, string fvr, string fa)
//        {
//            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
//            using (var fr = File.CreateText(fvr))
//            {
//                using (var far = File.CreateText(fa))
//                {
//                    foreach (string line in lines)
//                    {
//                        if (line.Length > 0)
//                        {
//                            string nauja = line;
//                            if (BeKomentaru(line, out nauja))
//                                far.WriteLine(line);
//                            if (nauja.Length > 0)
//                                fr.WriteLine(nauja);
//                        }
//                        else
//                            fr.WriteLine(line);
//                    }
//                }
//            }
//        }
//        //-----------------------------------------------------------
//        //------------------------------------------------------------
//        /** Pašalina iš eilutės komentarus ir grąžina požymį, ar šalino.
//            @param line - eilutė su komentarais
//            @param nauja - eilutė be komentarų */
//        //-----------------------------------------------------------
//        static bool BeKomentaru(string line, out string nauja)
//        {
//            nauja = line;


//            for (int i = 0; i < line.Length - 1; i++)
//                if ( line[i] == '/' || line[i+1] == '/') //(line[i] == '/' && line[i + 1] == '/') pakeiciam i ||
//                {
//                    nauja = line.Remove(i);
//                    return true;
//                }
//            return false;
//        }

//        //--------------------------------------------------------------

//    }
//}

//5.4. Žodžių išskyrimas eilutėje
//Užduotis. Žodžių išskyrimas ir analizė.
//Rasti, kiek tekste yra žodžių, kurių pirma ir paskutinė raidės vienodos.Žodžiai skiriami skyrikliais.

//namespace Tekstas_P05
//{
//    class Program
//    {
//        const string CFd = "..\\..\\D6.txt";
//        static void Main(string[] args)
//        {
//            char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
//            Console.WriteLine("Sutampančių žodžių {0, 3:d}", Apdoroti(CFd, skyrikliai));
//            Console.WriteLine("-------------------------------------------------------");
//            Console.WriteLine("Sutampančių žodžių {0, 3:d}", Apdoroti1(CFd, skyrikliai));
//            Console.WriteLine("-------------------------------------------------------");
//            Console.WriteLine("Polindromų skaicius {0, 3:d}", Apdoroti2(CFd, skyrikliai));
//            Console.WriteLine("Programa baigė darbą!");
//        }
//        //------------------------------------------------------------
//        /** Skaito failą ir analizuoja eilutes.
//            @param fv - duomenų failo vardas
//            @param skyrikliai - žodžių skyrikliai */
//        //------------------------------------------------------------
//        static int Apdoroti(string fv, char[] skyrikliai)
//        {
//            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
//            int sutampa = 0;
//            foreach (string line in lines)
//                if (line.Length > 0)
//                    sutampa += Zodziai(line, skyrikliai);
//            return sutampa;
//        }
//        //------------------------------------------------------------
//        /** Skaito failą ir analizuoja eilutes.
//            @param fv - duomenų failo vardas
//            @param skyrikliai - žodžių skyrikliai */
//        //------------------------------------------------------------
//        static int Apdoroti1(string fv, char[] skyrikliai)
//        {
//            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
//            int sutampa = 0;
//            foreach (string line in lines)
//                if (line.Length > 0)
//                    sutampa += Zodziai1(line, skyrikliai);
//            return sutampa;
//        }
//        //------------------------------------------------------------

//        /** Skaito failą ir analizuoja eilutes.
//            @param fv - duomenų failo vardas
//            @param skyrikliai - žodžių skyrikliai */
//        //------------------------------------------------------------
//        static int Apdoroti2(string fv, char[] skyrikliai)
//        {
//            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
//            int sutampa = 0;
//            foreach (string line in lines)
//                if (line.Length > 0)
//                    sutampa += Zodziai2(line, skyrikliai);
//            return sutampa;
//        }
//        //------------------------------------------------------------

//        /** Skaido eilutę į žodžius ir analizuoja žodžius.
//            @param eilute - duomenų eilutė
//            @param skyrikliai - žodžių skyrikliai */
//        //------------------------------------------------------------
//        static int Zodziai(string eilute, char[] skyrikliai)
//        {
//            string[] parts = eilute.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
//            int sutampa = 0;
//            foreach (string zodis in parts)
//                if (zodis[0] == zodis[zodis.Length - 1])
//                    sutampa++;
//            return sutampa;
//        }
//        //------------------------------------------------------------
//        //Papildykite metodą Zoddiai() atvejui, kai žodis prasideda ir pasibaigia skirtingo dydžio (kodo) raidėmis (pvz.: 'A' ir 'a'). Atsižvelkite tik į lotyniškos abėcėlės raides.
//        static int Zodziai1(string eilute, char[] skyrikliai)
//        {
//            string[] parts = eilute.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
//            int sutampa = 0;
//            foreach (string zodis in parts)
//                if (zodis.ToUpper()[0] == zodis[zodis.Length - 1])
//                    sutampa++;
//            return sutampa;
//        }
//        //------------------------------------------------------------
//        // Savarankiško darbo užduotis.
//        // Parašykite programą, kuri surastų kiek tekste yra žodžių palindromų, vienodai skaitomų iš abiejų pusių, pvz., „sūnūs“, „ėmė“, „iki“ ir pan.
//        static int Zodziai2(string eilute, char[] skyrikliai)
//        {
//            string[] parts = eilute.Split(skyrikliai,
//            StringSplitOptions.RemoveEmptyEntries);
//            int sutampa = 0, n = 0;
//            foreach (string zodis in parts)
//            {
//                for (int i = 0; i < zodis.Length / 2; i++)
//                {
//                    if (zodis[i] == zodis[zodis.Length - (i + 1)])
//                    {
//                        n++;
//                    }
//                    if (n == zodis.Length / 2) sutampa++;
//                }
//                n = 0;
//            }

//            return sutampa;
//        }

//        //------------------------------------------------------------

//    }
//}
////----------------------------------------------------------------------
////5.5. Eilučių redagavimas
////Užduotis. Žodžių išskyrimas ir eilutės redagavimas.
////Tekste visus vardus(pvz., Arvydas) papildyti nurodyta pavarde(pvz., SABONIS). Žodžiai skiriami skyrikliais.

//namespace Tekstas_P05
//{
//    class Program
//    {
//        const string CFd = "..\\..\\D7.txt";
//        const string CFr = "..\\..\\R7.txt";

//        static void Main(string[] args)
//        {
//            string skyr = " .,!?:;()\t'";
//            string zodis = "Arvydas";
//            string pavarde = " Sabonis";
//            Apdoroti22(CFd, CFr, skyr, zodis);
//            Console.WriteLine("Programa baigė darbą!");

//            //string skyr = " .,!?:;()\t'";
//            //string vardas = "Arvydas";
//            //string pavarde = "Sabonis";
//            //Console.WriteLine("Įveskite eilutę");
//            //string fv;
//            //fv = Console.ReadLine();
//            //Apdoroti(fv, skyr, vardas, pavarde);
//            //Console.WriteLine();
//            //Apdoroti1(fv, skyr, vardas, pavarde);
//            //Console.WriteLine("Programa baigė darbą!");

//        }
//        //--------------------------------------------------------------
//        // metodas darbui su viena eilute:
//        //------------------------------------------------------------
//         /** Analizuoja vieną eilutę.
//             @param fd – analizuojama eilutė
//             @param skyrikliai - žodžių skyrikliai
//             @param vardas - žodis, kurio ieškome
//             @param pavarde - žodis, kuriuo papildome */
//        //------------------------------------------------------------
//        static void Apdoroti(string fd, string skyrikliai, string vardas, string pavarde)
//        {
//            string line = fd;
//            StringBuilder nauja = new StringBuilder();
//            Zodziai(line, skyrikliai, vardas, pavarde, nauja);
//            Console.WriteLine(nauja);
//        }
//        //------------------------------------------------------------
//        static void Apdoroti1(string fd, string skyrikliai, string vardas, string pavarde)
//        {
//            string line = fd;
//            StringBuilder nauja = new StringBuilder();
//            Zodziai1(line, skyrikliai, vardas, pavarde, nauja);
//            Console.WriteLine(nauja);
//        }
//        //------------------------------------------------------------
//        // metodas darbui su vienos eilutės žodžiais:
//        //------------------------------------------------------------
//        /** Ieško eilutėje žodžių ir konstruoja naują eilutę.
//            @param line - duomenų eilutė
//            @param skyrikliai - žodžių skyrikliai
//            @param vardas - žodis, kurio ieškome
//            @param pavarde - žodis, kuriuo papildome
//            @param nauja - rezultatų eilutė */
//        //------------------------------------------------------------
//        static void Zodziai(string line, string skyrikliai, string vardas, string pavarde, StringBuilder nauja)
//        {
//            string papild = " " + line + " "; // kaip veikia sita papildoma eilute???
//            int prad = 1;
//            int ind = papild.IndexOf(vardas);
//            while (ind != -1)
//            {
//                if (skyrikliai.IndexOf(papild[ind - 1]) != -1 && skyrikliai.IndexOf(papild[ind + vardas.Length]) != -1)
//                {
//                    nauja.Append(papild.Substring(prad, ind + vardas.Length - prad));
//                    nauja.Append(pavarde);
//                    prad = ind + vardas.Length;
//                }
//                ind = papild.IndexOf(vardas, ind + 1);
//            }
//            nauja.Append(line.Substring(prad - 1));
//        }

//        //------------------------------------------------------------
//        /** Skaito failą ir analizuoja eilutes.
//           @param fd - duomenų failo vardas
//           @param fr - rezultatų failo vardas
//           @param skyrikliai - žodžių skyrikliai
//           @param vardas - žodis, kurio ieškome
//           @param pavarde - žodis, kuriuo papildome */
//        //------------------------------------------------------------
//        static void Apdoroti(string fd, string fr, string skyrikliai, string vardas, string pavarde)
//        {
//            string[] lines = File.ReadAllLines(fd, Encoding.GetEncoding(1257));
//            using (var far = File.CreateText(fr))
//            {
//                foreach (string line in lines)
//                {
//                    StringBuilder nauja = new StringBuilder();
//                    Zodziai(line, skyrikliai, vardas, pavarde, nauja);
//                    far.WriteLine(nauja);
//                }
//            }
//        }
//        //---------------------------------------------------------------------------
//        static void Apdoroti22(string fd, string fr, string skyrikliai, string zodis)
//        {
//            string[] lines = File.ReadAllLines(fd, Encoding.GetEncoding(1257));
//            using (var far = File.CreateText(fr))
//            {
//                foreach (string line in lines)
//                {
//                    StringBuilder nauja = new StringBuilder();
//                    Zodziai2(line, skyrikliai, zodis, nauja);
//                    far.WriteLine(nauja);
//                }
//            }
//        }
//        //------------------------------------------------------------
//        //Papildykite metodą Zodziai() taip, kad papildomas žodis būtų įrašomas, paliekant tarp žodžių tarpelį (eilutės pavarde pradžioje esantį tarpelį prieš tai išmeskite).
//        static void Zodziai1(string line, string skyrikliai, string vardas, string pavarde, StringBuilder nauja)
//        {
//            string papild = " " + line + " "; // kaip veikia sita papildoma eilute???
//            int prad = 1;
//            string papild1 = " " + pavarde;
//            int ind = papild.IndexOf(vardas);
//            while (ind != -1)
//            {
//                if (skyrikliai.IndexOf(papild[ind - 1]) != -1 && skyrikliai.IndexOf(papild[ind + vardas.Length]) != -1)
//                {
//                    nauja.Append(papild.Substring(prad, ind + vardas.Length - prad));
//                    nauja.Append(papild1);
//                    prad = ind + vardas.Length;
//                }
//                ind = papild.IndexOf(vardas, ind + 1);
//            }
//            nauja.Append(line.Substring(prad - 1));
//        }
//        //--------------------------------------------------------------
//        //  Parašykite programą, kuri pašalintų iš teksto nurodytus žodžius kartu su už jų esančiais skyrikliais.
//        //Papildykite metodą Zodziai() taip, kad papildomas žodis būtų įrašomas, paliekant tarp žodžių tarpelį (eilutės pavarde pradžioje esantį tarpelį prieš tai išmeskite).
//        // Eil.Remove(pr, kiek) –šalina iš eilutės simbolius.pr –pradinis adresas; kiek –kiekis;
//        static void Zodziai2(string line, string skyrikliai, string zodis, StringBuilder nauja)
//        {
//            string papild = " " + line + " ";
//            int ind = papild.IndexOf(zodis);
//            int prad = 1;
//            while (ind !=-1)
//            {
//                nauja.Remove(ind + zodis.Length, 100);

//                ind = papild.IndexOf(zodis, ind + 1);
//                prad = ind + zodis.Length;
//            }

//            nauja.Append(line.Substring(prad - 1));

//        }




//    }
//}

//// 5.6. Analizės failo sukūrimas
////Užduotis. Analizės failo, kuriame bus atspindėti tarpiniai veiksmai, sukūrimas.
////Tekstiniame faile duotas tekstas.Žodžiai iš eilutės į eilutę nekeliami.Skyrikliai žinomi. Pašalinti iš kiekvienos eilutės ilgiausio žodžio (vieno) visas balses.

//namespace Tekstas_P05
//{
//    //------------------------------------------------------------
//    class Program
//    {
//        const string CFd = "..\\..\\D8.txt";
//        const string CFr = "..\\..\\R8.txt";
//        const string CFa = "..\\..\\A8.txt";

//        static void Main(string[] args)
//        {
//            const string balses = "AEIYOUaeiyouĄąĘęĖėĮįŲųŪū";
//            char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
//            Apdoroti(CFd, CFr, CFa, skyrikliai, balses);
//            Console.WriteLine("Programa baigė darbą!");
//        }

//    //------------------------------------------------------------
//    //--------------------------------------------------------
//    // metodas ilgiausio žodžio paieškai eilutėje:
//    //--------------------------------------------------------
//    /** Ieško ilgiausio žodžio eilutėje ir grąžina rezultatą per vardą.
//       @param eilute - duomenų eilutė
//       @param skyrikliai - žodžių skyrikliai */
//    //------------------------------------------------------------
//    static string Ilgiausias(string eilute, char[] skyrikliai)
//        {
//            string[] parts = eilute.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
//            string ilgiaus = "";
//            foreach (string zodis in parts)
//                if (zodis.Length > ilgiaus.Length)
//                    ilgiaus = zodis;
//            return ilgiaus;
//        }
//        //------------------------------------------------------------
//        //metodas, kuris iš duoto žodžio pašalintų nurodytus simbolius:
//        //------------------------------------------------------------
//        /** Iš žodžio pašalima balses ir grąžina rezultatą per vardą.
//            @param eilute - žodis su balsėmis
//            @param balsės - abėcėlės balsės */
//        //-----------------------------------------------------------
//        static StringBuilder BeBalsiu(string eilute, string balses)
//        {
//            StringBuilder nauja = new StringBuilder();
//            for (int i = 0; i < eilute.Length; i++)
//                if (balses.IndexOf(eilute[i]) == -1)
//                    nauja.Append(eilute[i]);
//            return nauja;
//        }
//        //------------------------------------------------------------
//        //------------------------------------------------------------
//        /** Skaito failą, analizuoja eilutes, kuria rezultatų ir analizės failus.
//@param fd - duomenų failo vardas
//@param fr - rezultatų failo vardas
//@param fa - analizės failo vardas
//@param skyrikliai - žodžių skyrikliai
//@param balses - abėcėlės balsės */
//        //------------------------------------------------------------
//        static void Apdoroti(string fd, string fr, string fa, char[] skyrikliai,string balses)
//        {
//            string[] lines = File.ReadAllLines(fd);
//            string eilute = new string('-', 38); // eilutes liniju brezimui 
//            using (var far = File.CreateText(fr))
//            {
//                using (var faa = File.CreateText(fa))
//                {
//                    faa.WriteLine(eilute);
//                    faa.WriteLine("| Ilgiausias žodis | Pradžia | Ilgis |");
//                    faa.WriteLine(eilute);
//                    foreach (string line in lines)
//                        if (line.Length > 0)
//                        {
//                            string ilgiaus = Ilgiausias(line, skyrikliai);
//                            string ilgiausBe = BeBalsiu(ilgiaus, balses).ToString();
//                            faa.WriteLine("| {0,-16} | {1, 7:d} | {2, 5:d} |",
//                            ilgiaus, line.IndexOf(ilgiaus), ilgiaus.Length);
//                            string nauja = line.Replace(ilgiaus, ilgiausBe);
//                            // trumpiausio taip pakeisti negalima,
//                            // gali būti kito žodžio dalimi, sprendimas 5.5 poskyryje
//                            far.WriteLine(nauja);
//                        }
//                        else
//                            far.WriteLine(line);
//                    faa.WriteLine(eilute);
//                }
//            }
//        }
//        //------------------------------------------------------------


//    }
//}

//U5-1. Ilgiausias žodis
//Tekstiniame faile pateikiamas tekstas.
//Žodžiai iš eilutės į kitą eilutę nekeliami. 
//Žodžiai eilutėse skiriami bent vienu tarpu. 
//Tarpai gali būti eilutės pradžioje bei gale, gali būti tuščios eilutės. 
//Pašalinti kiekvienos eilutės ilgiausią žodį.
//Jei yra keli ilgiausi žodžiai, tuomet reikia pašalinti juos visus.

//namespace Tekstas_P05
//{
//    class Program
//    {
//        const string CFd = "..\\..\\D9.txt";
//        const string CFr = "..\\..\\R9.txt";
//        const string CFa = "..\\..\\A9.txt";

//        static void Main(string[] args)
//        {

//            string eilute = " labas mano i namas ir laba, kabo, labas, labas";
//            char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
//            //   Apdoroti1(CFd, CFr, CFa, skyrikliai);
//            //  Console.WriteLine("{0}", Ilgiausiaskiek(eilute, skyrikliai));
//            //  Zodziai(eilute, skyrikliai); // trina tumpesni nei 5 ilgio

//            string zodis = "mano";
//         //   if (zodis.Length < 5)
//            {
//                eilute.Remove(zodis.IndexOf(zodis), zodis.Length);

//               // Console.WriteLine("{0}",b);
//            }
//            Console.WriteLine("Programa baigė darbą!");
//        }
//        //---------------------------------------------------
//        //static void Zodziai(string eilute, char[] skyrikliai) // skaido zodziais
//        //{
//        //    string[] parts = eilute.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
//        // //   string naujesne = "";
//        //    foreach (string zodis in parts) 
//        //    {
//        //      //  string nauja7 = "";

//        //        if (parts.Length < 5) //eilute.Length > 0 &&
//        //        {
//        //            for (int i = 0; i < 9; i++)
//        //            {
//        //                string nauja = eilute.Remove(eilute.IndexOf(zodis), zodis.Length);

//        //                // nauja = nauja1;
//        //                 Console.WriteLine("{0}", nauja);
//        //            }

//        //        }
//               //nauja1 = eilute ;
//        //    }
//        //   // Console.WriteLine("{0}", naujesne);
//        //    //    Console.WriteLine("{0}", eilute);
//        //}
//        //--------------------------------------------------------
//        // metodas ilgiausio žodžio paieškai eilutėje:
//        //--------------------------------------------------------
//        /** Ieško ilgiausio žodžio eilutėje ir grąžina rezultatą per vardą.
//           @param eilute - duomenų eilutė
//           @param skyrikliai - žodžių skyrikliai */
//        //------------------------------------------------------------
//        static string Ilgiausias(string eilute, char[] skyrikliai)
//        {
//            string[] parts = eilute.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
//            string ilgiaus = "";

//            foreach (string zodis in parts)
//                if (zodis.Length > ilgiaus.Length)
//                    ilgiaus = zodis;

//            return ilgiaus;
//        }

//        //---------------------------------------------------------------------
//        //static string Skaitoeilute(string eilute, char[] skyrikliai, string fv)
//        //{

//        //    // string ilgiaus = Ilgiausias(eilute, skyrikliai);

//        //    using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
//        //    {
//        //        while (((eilute = reader.ReadLine()) != null))
//        //        {
//        //            if (eilute.Length > 0)
//        //                Zodziai(eilute, skyrikliai);

//        //        }


//                //if (zodis.Length >= ilgiaus.Length)
//                //    ilgiaus = ilgiaus + parts.IndexOf(zodis);


//                //  return ilgiaus;
//        //    }
//        //}

//        //---------------------------------------------------------------------
//        static void Apdoroti1(string fd, string fr, string fa, char[] skyrikliai)
//        {
//            string[] lines = File.ReadAllLines(fd);
//            string eilute = new string('-', 38); // eilutes liniju brezimui 

//            using (var far = File.CreateText(fr))
//            {
//                foreach (string line in lines)
//                {
//                    if (line.Length > 0)
//                    {

//                        string ilgiaus = Ilgiausias(line, skyrikliai); // zodis
//                        string nauja = line.Remove(line.IndexOf(ilgiaus), ilgiaus.Length);
//                        far.WriteLine(nauja);
//                    }
//                    else
//                        far.WriteLine(line);
//                }
//            }


//        }
//        //-------------------------------------------------------------------------
//        //static void Apdoroti2(string eilute, String zodis)
//        //{

//        //    if (zodis.Length < 3)
//        //    {
//        //      string b = eilute.Remove(eilute.IndexOf(zodis), zodis.Length);
//        //      Console.WriteLine( b);
//        //    }

//        //}
//            //----------------------------------------------------------------        




//        }
//    }

//static void Apdoroti(string fd, string fr, string fa, char[] skyrikliai)
//{
//    string[] lines = File.ReadAllLines(fd);
//    string eilute = new string('-', 38); // eilutes liniju brezimui 

//    using (var far = File.CreateText(fr))
//    {
//        using (var faa = File.CreateText(fa))
//        {
//            faa.WriteLine(eilute);
//            faa.WriteLine("| Ilgiausias žodis | Pradžia | Ilgis |");
//            faa.WriteLine(eilute);


//            foreach (string line in lines)
//            {
//                if (line.Length > 0)
//                {
//                    string ilgiaus = Ilgiausias(line, skyrikliai);
//                    int maxilgis = ilgiaus.Length;
//                    string nauja = line.Remove(line.IndexOf(ilgiaus), ilgiaus.Length);
//                    string[] parts = nauja.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
//                    char[] simbgr = new
//                            for (int i = 0; i < nauja.Length; i++)
//                    {
//                        // string[] parts = line.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
//                        //  faa.WriteLine("| {0,-16} | {1, 7:d} | {2, 5:d} |", ilgiaus, line.IndexOf(ilgiaus), ilgiaus.Length);
//                        // foreach (string zodis in parts)              

//                        if (.Length == maxilgis)
//                        {

//                            // faa.WriteLine("| {0,-16} | {1, 7:d} | {2, 5:d} |", ilgiaus, line.IndexOf(ilgiaus), ilgiaus.Length);
//                            string nauja1 = nauja.Remove(nauja.IndexOf(zodis), zodis.Length); // gali reikt taisyt
//                            far.WriteLine(nauja1);
//                        }                                                                // trumpiausio taip pakeisti negalima,   
//                                                                                         // gali būti kito žodžio dalimi, sprendimas 5.5 poskyryje                 
//                        else
//                            far.WriteLine(nauja);
//                    }
//                }

//                else
//                    far.WriteLine(line);
//            }
//            faa.WriteLine(eilute);

//        }
//    }
//}
////------------------------------------------------------------
namespace Tekstas_P05
{
    class Program
    {
        const string CFd = "..\\..\\Duom.txt";
        const string CFr = "..\\..\\Rez.txt";
        const string CFr2 = "..\\..\\Rezz.txt";
        const string CFr3 = "..\\..\\Rez2.txt";
        static void Main(string[] args)
        {
            Apdoroti(CFd, CFr);
            Apdoroti(CFr2, CFr3);
            Console.WriteLine("Programa baigė darbą!");
        }
        //------------------------------------------------------------
        /** Skaito, analizuoja ir rašo į skirtingus failus.
            @param fv - duomenų failo vardas
            @param fvr - rezultatų failo vardas
            @param fa - analizės failo vardas */
        //------------------------------------------------------------
        static void Apdoroti(string fv, string fvr)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            using (var fr = File.CreateText(fvr))
            {

                foreach (string line in lines)
                {
                    if (line.Length > 0)
                    {
                        char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
                        string[] parts = line.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string zodis in parts)
                        {
                            if (zodis == "text")
                            {
                                fr.WriteLine(line);
                            }


                        }
                    }

                }
            }
        }
        //--------------------------------------------------------------------
        static void Apdoroti2(string fv, string fvr)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            using (var fr = File.CreateText(fvr))
            {
                foreach (string line in lines)
                {
                    if (line.Length > 0)
                    {

                        fr.WriteLine(line);
                    }


                }


            }

        }
    }
}
        //-----------------------------------------------------------
        //------------------------------------------------------------
        /** Pašalina iš eilutės komentarus ir grąžina požymį, ar šalino.
            @param line - eilutė su komentarais
            @param nauja - eilutė be komentarų */
        //-----------------------------------------------------------
        //static bool BeKomentaru(string line, out string nauja)
        //{
        //    nauja = line;


        //    for (int i = 0; i < line.Length - 1; i++)
        //        if (line[i] == '/' || line[i + 1] == '/') //(line[i] == '/' && line[i + 1] == '/') pakeiciam i ||
        //        {
        //            nauja = line.Remove(i);
        //            return true;
        //        }
        //    return false;
        //}

        //--------------------------------------------------------------


