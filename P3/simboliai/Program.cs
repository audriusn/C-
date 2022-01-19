using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simboliai
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //char pr, pb;
            //Console.Write("Įveskite raidę raidžių intervalo pradžiai: ");
            //pr = Console.ReadLine()[0];
            //Console.Write("Įveskite raidę raidžių intervalo pabaigai: ");
            //pb = (char)Console.Read();
            //for (char ch = pr; ch <= pb; ch++)
            //    Console.WriteLine("{0} - {1}", ch, (int)ch);

            string vardas;
            Console.Write("Koks jūsų vardas: ");
            vardas = Console.ReadLine();
            Console.WriteLine(" Sveika(s), {0}! ", vardas);


        }
    }
}
