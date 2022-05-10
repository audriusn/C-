using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Char metodai//

            //Console.Write("Įveskite simbolį: ");
            //char sim = Convert.ToChar(Console.ReadLine());
            //Console.WriteLine();
            //Console.WriteLine("Ar skaičius?: {0}", Char.IsDigit(sim));
            //Console.WriteLine("Ar raidė?: {0}", Char.IsLetter(sim));
            //Console.WriteLine("Raidė ar skaičius?: {0}", Char.IsLetterOrDigit(sim));
            //Console.WriteLine("Ar mažoji raidė?: {0}", Char.IsLower(sim));
            //Console.WriteLine("Ar didžioji raidė?: {0}", Char.IsUpper(sim));
            //Console.WriteLine("Į mažają: {0}", Char.ToLower(sim));
            //Console.WriteLine("Į didžiają: {0}", Char.ToUpper(sim));
            //Console.WriteLine("Ar skyriklis? : {0}", Char.IsPunctuation(sim));
            //Console.WriteLine("Ar simbolis?: {0}", Char.IsSymbol(sim));

            // string konstruktoriai  //

            //char[] simboliai = { 'V', 'y', 'k', 's', 't', 'a', ' ', 'p', 'a', 's', 'k', 'a', 'i', 't', 'a' };
            //string eil = "Sveiki!";
            //string eil1 = eil;
            //string eil2 = new string(simboliai);
            //string eil3 = new string(simboliai, 7, 8);
            //string eil4 = new string('-', 15);
            //Console.WriteLine(eil);
            //Console.WriteLine(eil1);
            //Console.WriteLine(eil2);
            //Console.WriteLine(eil3);
            //Console.WriteLine(eil4);

            //string metodai//

            //char[] simboliai1 = { 'p', 'a', 's', 'k', 'a', 'i', 't', 'a' };
            //string eil5;
            //eil5 = "" + simboliai1[0];
            //Console.WriteLine(eil5);
            //eil5 = "" + '5';
            //Console.WriteLine(eil5);
            //eil5 = eil + " " + eil1 + " " + eil2;
            ///*eil5 = '5';*/ //Klaida
            //char simb6 = eil5[0];

            //pvz1
            //string eil1 = "Vyksta paskaita";
            //char[] simboliai = new char[20];
            //char[] simboliai1 = new char[20];
            //Console.WriteLine("Eilutės eil1 ilgis: {0}", +eil1.Length);
            //Console.WriteLine("Eilutė: {0}", eil1);
            //Console.WriteLine("Simbolių masyvas: ");
            ////kopijuojant eilutę į simbolių masyva
            //eil1.CopyTo(7, simboliai, 0, 8);
            //for (int i = 0; i < simboliai.Length; ++i)
            //    Console.Write(simboliai[i]);
            //Console.WriteLine();

            ////pvz2
            //simboliai1 = eil1.ToCharArray(0, 6);
            //Console.Write("Simbolių masyvas1: ");
            //for (int j = 0; j < simboliai1.Length; ++j)
            //    Console.Write(simboliai1[j]);
            //Console.WriteLine();

            ///pvz3

            //string eil1 = "Pirmadienis";
            //string eil2 = "Antradienis";
            //string eil3 = "Trečiadienis";
            //string eil4 = "trečiadienis";
            //Console.WriteLine("eil1 = " + "\"" + eil1 + "\"\n" +
            //                  "eil2 = " + "\"" + eil2 + "\"\n" +
            //                  "eil3 = " + "\"" + eil3 + "\"\n" +
            //                  "eil4 = " + "\"" + eil4 + "\"\n");
            //if (eil1.Equals("Pirmadienis")) Console.WriteLine("eil1 lygi \"Pirmadienis\"");
            //else Console.WriteLine("eil1 nelygi \"Pirmadienis\"");
            //if (eil1 == ("Pirmadienis")) Console.WriteLine("eil1 lygi \"Pirmadienis\"");
            //else Console.WriteLine("eil1 nelygi \"Pirmadienis\"");
            //if (string.Equals(eil3, eil4)) Console.WriteLine("eil3 ir eil4 lygios");
            //else Console.WriteLine("eil3 ir eil4 nelygios");

            //pvz4

            //Console.WriteLine("\neil1.CompareTo(eil2) yra " +
            //    eil1.CompareTo(eil2) + "\n" +
            //    "eil2.CompareTo(eil1) yra " +
            //     eil2.CompareTo(eil1) + "\n" +
            //     "eil1.CompareTo(eil1) yra " +
            //     eil1.CompareTo(eil1) + "\n" +
            //     "eil3.CompareTo(eil4) yra " +
            //     eil3.CompareTo(eil4) + "\n" +
            //     "eil4.CompareTo(eil3) yra " +
            //     eil4.CompareTo(eil3) + "\n");


            //pvz5

            //string[] eilutės = { "pirmas", "antras", "ketvirtas", "pirmadienis" };
            //for (int i = 0; i < eilutės.Length; ++i)
            //    if (eilutės[i].StartsWith("pir"))
            //        Console.WriteLine("\"" + eilutės[i] + "\"" + " prasideda su \"pir\"");
            //Console.WriteLine();
            //for (int i = 0; i < eilutės.Length; ++i)
            //    if (eilutės[i].EndsWith("is"))
            //        Console.WriteLine("\"" + eilutės[i] + "\"" + " pasibaigia su \"is\"");

            // pvz6

            //string raidės = "aąbcdeęė kkk fcdc bghiį 123 jklmną  kloiiii";
            //char[] paieška = { 'ą', 'd', 'k', 's', '1' };
            //Console.WriteLine("Pirmoji 'ą' yra pozicijoje " + raidės.IndexOf(paieška[0]));
            //Console.WriteLine("Pirmoji 'ą' pradedant nuo 5 yra  " + raidės.IndexOf('ą', 5));
            //Console.WriteLine("Pirmoji 'k' pradedant nuo 20 ir 7 pozicijoje yra  " + raidės.IndexOf('ą', 20, 7));
            //Console.WriteLine();
            //Console.WriteLine("paskutinė 'm' yra pozicijoje " + raidės.LastIndexOf('m'));
            //Console.WriteLine("paskutinė 'm' iki 21 pozicijos yra " + raidės.LastIndexOf('m', 21));
            //Console.WriteLine("paskutinė 'k' baigiant 15 ir 7 pozicijose yra  " + raidės.LastIndexOf('k', 15, 7));

            //pvz7

            //string raidės = "aąbcdeęė kkk fcdc bghiį 123 jklmną abccccc kloiiii";

            //Console.WriteLine("Pirmoji \"abc\" yra pozicijoje " + raidės.IndexOf("abc"));
            //Console.WriteLine("Pirmoji \"abc\"  pradedant nuo 7, yra pozicijoje " + raidės.IndexOf("abc", 7));
            //Console.WriteLine("Pirmoji \"ab\"  pradedant nuo 5 ir 20 pozicijoje " + raidės.IndexOf("ab", 2, 10));
            //Console.WriteLine();
            //Console.WriteLine("Paskutinė \"abc\" yra pozicijoje " + raidės.LastIndexOf("abc"));
            //Console.WriteLine("Paskutinė \"abc\"  iki  21 pozicijos yra: " + raidės.LastIndexOf("abc", 21));
            //Console.WriteLine("Paskutinė \"ab\"  baigiant 11 ir 5 pozicijoje yra  " + raidės.LastIndexOf("ab", 11, 5));

            //pvz8
            //string raidės = "aąabcdeęė kkk fcdc bghiį 123 jklmną abccccc kloiiii";
            //char[] paieška = { 'ą', 'd', '1' };
            //Console.WriteLine("Pirmoji  iš 'ą', 'd', '1' yra pozicijoje " + raidės.IndexOfAny(paieška));
            //Console.WriteLine("Pirmoji  iš 'ą', 'd', '1', pradedant nuo 7 yra  " + raidės.IndexOfAny(paieška, 7));
            //Console.WriteLine("Pirmoji  iš 'ą', 'd', '1', pradedant nuo 11 ir 10 pozicijų yra  " + raidės.IndexOfAny(paieška, 12, 10));
            //Console.WriteLine();
            //Console.WriteLine("Paskutinė  iš 'ą', 'd', '1' yra pozicijoje " + raidės.LastIndexOfAny(paieška));
            //Console.WriteLine("Paskutinė  iš 'ą', 'd', '1', baigiant  8 yra  " + raidės.LastIndexOfAny(paieška, 7));
            //Console.WriteLine("Paskutinė  iš 'ą', 'd', '1', baigiant 20 ir 8 pozicijų yra  " + raidės.LastIndexOfAny(paieška, 20, 8));
            //Console.WriteLine();

            //pvz 9

            //string tekstas = "aąbcdeęė fcdc bghiį jklmną";
            //Console.WriteLine("Eilutės dalis nuo 10 pozicijos \""
            //    + tekstas.Substring(10) + "\"");
            //Console.WriteLine("Eilutės dalis nuo 0 pozicijos 7 simboliai \""
            //    + tekstas.Substring(0,7) + "\"");

            //pvz10

            //string eil1 = "Vyksta paskaita";
            //string eil2 = "Metų pabaiga";
            //string eil3 = " ,.,Artėja sesija:;    ";
            //char[] simboliai = { ' ', ',', '.', ';', ':' };
            //Console.WriteLine("eil1 = " + "\"" + eil1 + "\"\n" +
            //                  "eil2 = " + "\"" + eil2 + "\"\n" +
            //                  "eil3 = " + "\"" + eil3 + "\"");
            //Console.WriteLine("\nPakeisti 'ė' su 'Ė' eil3" + eil3.Replace('ė', 'Ė') + "\"");
            //Console.WriteLine("\neil2.ToUpper() = \"" + eil2.ToUpper() + "\"\nneil3.ToLower() = \"" + eil3.ToLower() +"\"");

            //pvz 11

            //string eil3 = " ,.,Artėja sesija:;    ";
            //char[] simboliai = { ' ', ',', '.', ';', ':' };
            //Console.WriteLine("\neil3 po Trim = \"" + eil3.Trim() + "\"");
            //Console.WriteLine("\neil3 po Trim = \"" + eil3.Trim(simboliai) + "\"");

            //pvz 12

            //string eil1 = "Vyksta paskaita.";
            //string[] skyrikliai = new string[] { ".", ",", ";", " " };
            //string[] rezultatai;
            //rezultatai = eil1.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine("Elementų kiekis rezultatų masyve: {0}", rezultatai.Length);
            //foreach(string s in rezultatai)
            //    Console.WriteLine(s);
            //Console.WriteLine();
            //char [] char_mas = {'.',',',' ',';',':'};
            //rezultatai = eil1.Split(char_mas, StringSplitOptions.RemoveEmptyEntries);
            //foreach (string s in rezultatai)
            //    Console.WriteLine(s);

            //pvz 13

            //string eil1 = "Vyksta paskaita.";
            //string eil2, eil3;
            //eil2 = eil1.Remove(7);
            //Console.WriteLine(eil2);
            //eil2 = eil1.Remove(0, 7);
            //Console.WriteLine(eil2);
            //eil3 = eil1.Insert(7, "objektinio programavimo ");
            //Console.WriteLine(eil3);
            //-------------------------------------------------------------------------------------------------------------------------------------------

            //Eilučių metodų pvz1 StringBuilder

            //StringBuilder eil3 = new StringBuilder("Vyksta paskaita");
            //Console.WriteLine("eil3 = " + "\"" + eil3+ "\"\n" + "Ilgis = " + eil3.Length + "\nTalpa = " + eil3.Capacity);
            //eil3.EnsureCapacity(50);
            //Console.WriteLine("\nNauja talpa = " + eil3.Capacity);
            //eil3.Length = 7;
            //Console.WriteLine("Naujas ilgis = "+ eil3.Length);
            //for (int i=0; i< eil3.Length; ++i)
            //    Console.Write(eil3[i]);
            //Console.WriteLine();

            //Eilučių metodų pvz2

            //string strReiksme = "Paskaita";
            //char[] chrMasyvas = { 'R', 'y', 't', 'a', 's' };
            //bool booReiksme = true;
            //char chrReiksme = '!';
            //int intReiksme = 101;
            //double douReiksme = 3.14;
            //StringBuilder eil4  = new StringBuilder();
            //eil4.Append(strReiksme); eil4.Append(" ");
            //eil4.Append(chrMasyvas); eil4.Append(" ");
            //eil4.Append(booReiksme); eil4.Append(" ");
            //eil4.Append(chrReiksme); eil4.Append(" ");
            //eil4.Append(intReiksme); eil4.Append(" ");
            //eil4.Append(douReiksme);
            //Console.WriteLine("eil4 = " + "\"" + eil4.ToString() +"\"\n");

            //Eilučių metodų pvz3

            //StringBuilder eil5 = new StringBuilder();
            //string eil1 = "Šie {0} yra {1}. \n";
            //object [] objMas =new object[2];
            //objMas[0] = "metai";
            //objMas[1] = 2015;
            //eil5.AppendFormat(eil1, objMas);
            //string eil2 = "Skaičius {0:d3}. \n" +
            //    "Išlygintas į dešinę su {0,5} tarpais. \n" +
            //    "Išlygintas į kairę su {0,-5} tarpais.";
            //eil5.AppendFormat(eil2 , 6);
            //Console.WriteLine(eil5.ToString());

            //Eilučių metodų pvz4

            //string strReiksme = "Paskaita";
            //char [] chrMasyvas = { 'R', 'y', 't', 'a', 's' };
            //bool booReiksme = true;
            //char chrReiksme = '!';
            //int intReiksme = 101;
            //double douReiksme = 3.14;
            //StringBuilder eil6 = new StringBuilder();
            //eil6.Insert(0, strReiksme); eil6.Insert(0, " ");
            //eil6.Insert(0, chrMasyvas); eil6.Insert(0, " ");
            //eil6.Insert(0, booReiksme); eil6.Insert(0, " ");
            //eil6.Insert(0, chrReiksme); eil6.Insert(0, " ");
            //eil6.Insert(0, intReiksme); eil6.Insert(0, " ");
            //eil6.Insert(0, douReiksme); eil6.Insert(0, " ");
            //Console.WriteLine("Eilutė po įterpimų \n" + eil6);
            //eil6.Remove(11, 1);
            //eil6.Remove(4, 4);
            //Console.WriteLine("Eilutė po pašalinimo \n" + eil6);

            //Eilučių metodų pvz5

            StringBuilder eil7 = new StringBuilder("Geras rytas");
            StringBuilder eil8 = new StringBuilder("Good morning");
            Console.WriteLine("Eilutės prieš pakeitimus\n" + eil7 + "\n" + eil8);
            eil7.Replace("Geras", "Labas");
            eil8.Replace('o', 'O', 0, 5);
            Console.WriteLine(("\n Eilutės po pakeitimų\n" + eil7 + "\n" + eil8));
        }
    }
}
