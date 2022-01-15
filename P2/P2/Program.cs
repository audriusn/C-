using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 10;
            Console.WriteLine("Skaičiai nuo a iki b ir jų kubai:");
            for (int i = a; i < 15; i++)
                Console.WriteLine(" {0,3:d} {1,5:d}", i, i * i * i);
        }

        }
    }

