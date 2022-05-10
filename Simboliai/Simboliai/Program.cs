using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// P1 PILNAS
////------------------------------------------------------------
//// Mažosios raidės
////------------------------------------------------------------
namespace Simboliai
  {
    class Program
   {
        static void Main(string[] args)
        {




            string SetenceString = " a a: ai au io io: iu iu: iuo o o: u u: ui uo a: ai au io: iu: iui iuo o: u: ui uo";
            Console.WriteLine(SetenceString);
            var result = string.Join(" ", SetenceString.Split(' ').Distinct());
            Console.WriteLine(result);


            //for (char ch = 'a'; ch <= 'z'; ch++)
            // Console.Write("{0} ", ch);
            //Console.WriteLine("");
        }
    }
}
////------------------------------------------------------------
////------------------------------------------------------------
//// Mažosios raidės ir jų kodai
////------------------------------------------------------------
//namespace mazosios_raides
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            for (char ch = 'a'; ch <= 'z'; ch++)
//                Console.WriteLine("{0} - {1}", ch, (int)ch);
//        }
//    }
//}
////------------------------------------------------------------
////------------------------------------------------------------
//// Nurodyto intervalo raidės ir jų kodai
////------------------------------------------------------------
//namespace raidziu_intervalas
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            char pr, pb;
//            Console.Write("Įveskite raidę raidžių intervalo pradžiai: ");
//            pr = Console.ReadLine()[0];
//            Console.Write("Įveskite raidę raidžių intervalo pabaigai: ");
//            pb = Console.ReadLine()[0];
//            for (char ch = pr; ch <= pb; ch++)
//                Console.WriteLine("{0} - {1}", ch, (int)ch);
//        }
//    }
//}
////------------------------------------------------------------
////------------------------------------------------------------
//// Duomenų tipas string
////------------------------------------------------------------
//namespace simboliai_string
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string vardas;
//            Console.Write("Koks jūsų vardas: ");
//            vardas = Console.ReadLine();
//            Console.WriteLine(" Sveika(s), {0}! ", vardas);
//        }
//    }
//}
////------------------------------------------------------------
//------------------------------------------------------------
//// Savaitės dienos
////------------------------------------------------------------
//namespace simboliai_dienos
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string diena;
//            Console.Write("Kokia šiandien savaitės diena (iverkite mažosiomis raidėmis)? ");
//            diena = Console.ReadLine();
//            if (diena == "pirmadienis")
//                Console.WriteLine("Pirmadienis - sudėtingiausia savaitės diena.");
//            else
//            if (diena == "antradienis")
//                Console.WriteLine("Antradienis – aktyvių veiksmų, Marso diena.");
//            else
//            if (diena == "trečiadienis")
//                Console.WriteLine("Trečiadienis – sandoriams sudaryti " +
//                "tinkamiausia diena.");
//            else
//            if (diena == "ketvirtadienis")
//                Console.WriteLine("Ketvirtadienį reikėtų imtis" +
//                "visuomeninių darbų.");
//            else
//            if (diena == "penktadienis")
//                Console.WriteLine("Penktadienį lengvai gimsta šedevrai," +
//                "susitinka mylimieji.");
//            else
//            if (diena == "šeštadienis")
//                Console.WriteLine("Šeštadienis - savo problemų " +
//                "sprendimo diena.");
//            else
//            if (diena == "sekmadienis")
//                Console.WriteLine("Sekmadienį reikėtų pradėti " +
//                "naujus darbus.");
//            else
//                Console.WriteLine("Tokios savaitės dienos " +
//                "pas mus nebūna.");
//        }
//    }
//}
////------------------------------------------------------------
////------------------------------------------------------------
//// Savaitės dienos su switch operatoriumi
////------------------------------------------------------------
//namespace simboliai_su_switch
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string diena;
//            Console.Write("Kokia šiandien savaitės diena? ");
//            diena = Console.ReadLine().ToLower();
//            switch (diena)
//            {
//                case "pirmadienis":
//                    Console.WriteLine("Pirmadienis - sudėtingiausia savaitės diena.");
//                    break;
//                case "antradienis":
//                    Console.WriteLine("Antradienis – aktyvių veiksmų, Marso diena.");
//                    break;
//                case "trečiadienis":
//                    Console.WriteLine("Trečiadienis – sandoriams sudaryti " +
//                    "tinkamiausia diena.");
//                    break;
//                case "ketvirtadienis":
//                    Console.WriteLine("Ketvirtadienį reikėtų imtis visuomeninių darbų.");
//                    break;
//                case "penktadienis":
//                    Console.WriteLine("Penktadienį lengvai gimsta šedevrai, " +
//                    "susitinka mylimieji.");
//                    break;
//                case "šeštadienis":
//                    Console.WriteLine("Šeštadienis - savo problemų sprendimo diena.");
//                    break;
//                case "sekmadienis":
//                    Console.WriteLine("Sekmadienį reikėtų pradėti naujus darbus, " +
//                    "kurti planus.");
//                    break;
//                default:
//                    Console.WriteLine("Tokios savaitės dienos pas mus nebūna.");
//                    break;
//            }
//        }
//    }
//}
////------------------------------------------------------------
//------------------------------------------------------------
//// Visas žodžio raides verčia didžiosiomis metodAS
////----------------------------------------------------
//static void Toupper1(string str1, out string str)
//{
//    int y;
//    str = str1;
//    int n = str.Length;
//    for (int pos = 0; pos < n; pos++)
//        if (str[pos] >= 'a' && str[pos] <= 'z')
//        {
//            y = (int)str[pos] + (int)'A' - (int)'a';
//            char z = (char)y;
//            string z1 = z.ToString();
//            str = str.Remove(pos, 1);
//            str = str.Insert(pos, z1);
//        }
//}
////------------------------------------------------------------