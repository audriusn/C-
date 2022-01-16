using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skaičiuotuvas_su_metodais
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a;
            double b;
            char simbolis;
   
            Console.Write("Įveskite a reikšmę: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Įveskite norimo veiksmo simbolį:('+' '-' '*' '/') ");
            simbolis = char.Parse(Console.ReadLine());
            Console.Write("Įveskite b reikšmę: ");
            b = double.Parse(Console.ReadLine());
            if (simbolis == '+')
            Console.WriteLine("Skaičių a = {0,2:f2} b = {1,2:f2} Veiksmo {2} rezultatas={3,6:f2}", a, b, simbolis, SUMA(a, b, simbolis));
            else if (simbolis == '-')
            Console.WriteLine("Skaičių a = {0,2:f2} b = {1,2:f2} Veiksmo {2} rezultatas={3,6:f2}", a, b, simbolis, ATIMTIS(a, b, simbolis));
            else if (simbolis == '*')
            Console.WriteLine("Skaičių a = {0,2:f2} b = {1,2:f2} Veiksmo {2} rezultatas={3,6:f2}", a, b, simbolis, DAUGYBA(a, b, simbolis));
            else if (simbolis == '/')
                if(b!=0)
                    Console.WriteLine("Skaičių a = {0,2:f2} b = {1,2:f2} Veiksmo {2} rezultatas={3,6:f2}", a, b, simbolis, DALYBA(a, b, simbolis));
                else
                    Console.WriteLine("Dalyba iš nulio negalina!!!");
            else
                Console.WriteLine("Toks veiksmas negalimas!!!");
        }

        static double SUMA(double sk1, double sk2, char simbolis)
        {
            double atsakymas = 0;
                atsakymas = sk1 + sk2;
                return atsakymas;
        }
        static double ATIMTIS(double sk1, double sk2, char simbolis)
        {
            double atsakymas = 0;
            atsakymas = sk1 - sk2;
            return atsakymas;
        }
         static double DAUGYBA(double sk1, double sk2, char simbolis)
        {
            double atsakymas = 0;
            atsakymas = sk1 * sk2;
            return atsakymas;
        }
        static double DALYBA(double sk1, double sk2, char simbolis)
        {
            double atsakymas = 0;
            atsakymas = sk1 / sk2;
            return atsakymas;
        }
    }
}

