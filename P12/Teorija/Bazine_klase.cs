using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teorija
{
    public class Bazine_klase : Object
    {
        public string eiluteBaz { get; set; }
        public Bazine_klase() // konstruktorius be parametrų
        {
            Console.WriteLine("Dirba bazinės klasės konstruktorius.");
        }
       
        public Bazine_klase(string eilute) // konstruktorius su parametrais
        {
            Console.WriteLine("Dirba bazinės klasės konstruktorius.");
            eiluteBaz = eilute;
        }
        public void Spausdinti()
        {
            Console.WriteLine("Dirba bazinės klasės metodas Spausdinti():");
            Console.WriteLine("{0}", eiluteBaz);
        }


    }
}
