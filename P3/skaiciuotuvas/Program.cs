using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skaiciuotuvas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a;
            double b;
            double rez;
            char simbolis;
            Console.Write("Įveskite a reikšmę: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Įveskite norimo veiksmo simbolį:('+' '-' '*' '/') ");
            simbolis = char.Parse(Console.ReadLine());
            Console.Write("Įveskite b reikšmę: ");
            b = double.Parse(Console.ReadLine());
            if (simbolis == '+')
            {
                rez = a + b;
                Console.WriteLine("Skaičių a = {0,6:f2} b = {1,8:f2} Veiksmo {2} rez={3,6:f2} ", a, b, simbolis, rez);
            }
            else if (simbolis == '-')
             { 
                rez = a - b;
                Console.WriteLine("Skaičių a = {0,6:f2} b = {1,8:f2} Veiksmo {2} rez={3,6:f2} ", a, b, simbolis, rez);
            }
            else if (simbolis == '*')
             {
                rez = a * b;
                Console.WriteLine("Skaičių a = {0,6:f2} b = {1,8:f2} Veiksmo {2} rez={3,6:f2} ", a, b, simbolis, rez);
            }
            else if (simbolis == '/')
             {
                if (b!=0)
                {
                    rez = a / b;
                    Console.WriteLine("Skaičių a = {0,6:f2} b = {1,8:f2} Veiksmo {2} rez={3,6:f2} ", a, b, simbolis, rez);
                }
                else
                    Console.WriteLine("Dalyba iš nulio negalina!!!");                
            }
            else
                Console.WriteLine("Toks veiksmas negalimas!!!");

        }
    }
}
