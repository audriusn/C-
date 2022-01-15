using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sumos_radimas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            int sum;
            Console.WriteLine("Iveskite sveikaja a reiksme");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite sveikaja b reiksme");
            b = int.Parse(Console.ReadLine());
            sum = a + b;
            Console.WriteLine("{0} + {1} = {2}",a ,b, sum);
        }
    }
}
