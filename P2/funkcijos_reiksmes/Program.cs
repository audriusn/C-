using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funkcijos_reiksmes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double fxy;
            int x;
            int y;
            Console.Write("Iveskite x reikšmę: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Iveskite y reikšmę: ");
            y = int.Parse(Console.ReadLine());
            if (Math.Pow(x ,3) - y != 0)
            {
                fxy = (Math.Pow(y,2) - (2*y*x) + Math.Pow(x, 2)) / (Math.Pow(x, 3) - y);
                Console.WriteLine("x = {0} y = {1} f(x,y) = {1,8:f3}", x, y, fxy);
            }
            else
                Console.WriteLine("f-ja neegzistuoja ");
        }
    }
}
