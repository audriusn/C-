using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savaites__dienos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string diena;
            Console.Write("Kokia šiandien savaitės diena (Įveskite mažosiomis raidėmis)? ");
            diena = Console.ReadLine().ToLower();
            if (diena == "pirmadienis")
                Console.WriteLine("Pirmadienis - sudėtingiausia savaitės diena.");
            else
            if (diena == "antradienis")
                Console.WriteLine("Antradienis – aktyvių veiksmų, Marso diena.");
            else
            if (diena == "trečiadienis")
                Console.WriteLine("Trečiadienis – sandoriams sudaryti " +
                "tinkamiausia diena.");
            else
            if (diena == "ketvirtadienis")
                Console.WriteLine("Ketvirtadienį reikėtų imtis" +
                "visuomeninių darbų.");
            else
            if (diena == "penktadienis")
                Console.WriteLine("Penktadienį lengvai gimsta šedevrai," +
                "susitinka mylimieji.");
            else
            if (diena == "šeštadienis")
                Console.WriteLine("Šeštadienis - savo problemų " +
                "sprendimo diena.");
            else
            if (diena == "sekmadienis")
                Console.WriteLine("Sekmadienį reikėtų pradėti " +
                "naujus darbus.");
            else
                Console.WriteLine("Tokios savaitės dienos " +
                "pas mus nebūna.");

        }
    }
}
