using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodai
{
    internal class Program
    {
        //    static void Main(string[] args)
        //    {
        //        char simbolis;
        //        Console.Write("Įveskite  spausdinamą  simbolį: ");
        //        simbolis = (char)Console.Read();
        //        Console.Clear();
        //        Spausdinti(simbolis);
        //    }
        //    static void Spausdinti(char ch)
        //    { 
        //        for (int i =1; i<51; i++)
        //            if (i % 5 == 0)
        //                Console.WriteLine(ch);
        //        else 
        //                Console.Write(ch);
        //        Console.WriteLine("");
        //    }
       // ---------------------------------------------------
        //static void Main(string[] args)
        //{
        //    int a;
        //    int b;
        //    Console.Write("Įveskite sveikąją a reikšmę: ");
        //    a = int.Parse(Console.ReadLine());
        //    Console.Write("Įveskite sveikąją b reikšmę: ");
        //    b = int.Parse(Console.ReadLine());
        //    Console.WriteLine("{0,3:d} + {1,3:d} = {2,4:d}", a, b, Suma(a, b));
        //}
        //static int Suma(int sk1, int sk2)
        //{
        //    int suma = sk1 + sk2;
        //    return suma;
        //}

        //------------------------------------------------------
        static void Main(string[] args)
        {
            int z;
            Console.Write("Įveskite z reikšmę: ");
            z = int.Parse(Console.ReadLine());
            if (z - 1 >= 0)
                Console.WriteLine("z = {0,3:d} f(x) = {1,8:f3}", z, Reiksme(z, 1, 0.5));
            else
                Console.WriteLine("z = {0} f-ja neegzistuoja", z);
        }
        static double Reiksme (int sk1, int sk2, double laipsnis)
        {
            return Math.Pow(sk1-sk2, laipsnis);
        }




    }
}
