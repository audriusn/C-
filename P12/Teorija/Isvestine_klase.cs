using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teorija
{
    public class Isvestine_klase :Bazine_klase
    {
        public int skaiciusIsvest { get; private set; }

        public Isvestine_klase() : base()
        {
            Console.WriteLine("Dirba išvestinės klasės konstruktorius.");
            Console.WriteLine(" Jis kreipiasi į baz.klasės konstruktorių base().");
        }
     
        public void Spausdinti1()
        {
            Console.WriteLine("Dirba išvestinės klasė metodas Spausdinti1().");
        }

        public Isvestine_klase(string eil, int skaicius) : base(eil)
        {
            skaiciusIsvest = skaicius;
            Console.WriteLine("Dirba išvestinės klasės konstruktorius.");
            Console.WriteLine(" Jis kreipiasi į bazinės klasės konstuktorių.");
        }
        public new void Spausdinti() // su new paslepiam bazinės klasės metodą Spausdinti()
        {
            Console.WriteLine("Dirba išvestinės klasės metodas Spausdinti():");
            Console.WriteLine("{0}",eiluteBaz);
            Console.WriteLine(" Jis kreipiasi į baz.klasės metodą Spausdinti().");
            base.Spausdinti();
            Console.WriteLine("{0}", skaiciusIsvest);

        }



    }
}
