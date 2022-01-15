using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salygos_sakinys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Step 2-3
            
            int a;
            int b;
            char simbolis;
            Console.WriteLine("Įveskite bendrą spausdinamų simbolių skaičių: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite vienos eilutės simbolių skaičių: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite norimą simbolį: ");
            simbolis = (char)Console.Read();
            for (int i = 0; i <= a; i++)
            {
                Console.Write(simbolis);
                if (i % b == 0)
                    Console.WriteLine("");
            }
            Console.WriteLine("");
        }
    }
}
