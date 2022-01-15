using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciklas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skaičiai nuo 1 iki 10 ir jų kvadratai:");
            for (int i = 1; i < 10; i++)
                Console.WriteLine(" {0,3:d} {1,5:d}", i, i * i);

            // Antras žingsnis
            Console.WriteLine("Skaičiai nuo 5 iki 15 ir jų kvadratai:");
            for (int i = 5; i < 15; i++)
                Console.WriteLine(" {0,3:d} {1,5:d}", i, i * i);
            // Trečias žingsnis
            Console.WriteLine("Skaičiai nuo 5 iki 15 ir jų kubai:");
            for (int i = 5; i < 15; i++)
                Console.WriteLine(" {0,3:d} {1,5:d}", i, i * i * i);
            //4-5 žingnis
            int a = 3;
            int b = 10;
            int c = 0;
            Console.WriteLine("Skaičiai nuo a iki b ir jų kubai:");
            for (int i = a; i < b; i++)
            {
                c++;
                Console.WriteLine(" {0,3:d} {1,5:d} {2,5:d} {3},  ", i, i * i * i, "Buvo skaičiuota = ", c);   
            }
            //6 žingnis
            int x;
            int y;
            int k = 0;
            Console.WriteLine("Įveskite pirmą skaičių:");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite antrą skaičių:");
            y = int.Parse(Console.ReadLine());
            for (int i=x; i<=y; i++)
            {
                k ++;
                Console.WriteLine("{0,3:d} {1,5:d} {2,5:d} {3}", i, i * i, i * i * i, "Buvo skaičiuota:", k);
            }
            
        }
    }
}
