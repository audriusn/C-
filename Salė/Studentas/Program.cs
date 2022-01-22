using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentas
{
    class Pabaisa
    {
        private int ragai; 
        private int uodegos;
        private int amžius;

        public Pabaisa(int ragai, int uodegos, int amžius)
        {
           this.ragai = ragai;
           this.uodegos = uodegos;
           this.amžius = amžius;
        }

        public int ImtiRagus() { return ragai; }
        public int ImtiUodegas() { return uodegos; }
        public int ImtiAmžiu() { return amžius; }
    }
    class Studentas
    {
        private int ragai;
        private int uodegos;
        private string vardas;

        public Studentas(string vardas, int ragai, int uodegos)
        {
            this.vardas = vardas;
            this.ragai = ragai;
            this.uodegos = uodegos;
        }
        public void DėtiRagus(int ragai) { this.ragai = ragai; }
        public void DėtiUodegas(int uodegos) { this.uodegos = uodegos; }
        public string ImtiVarda() { return vardas; }
        public int ImtiRagus() { return ragai; }
        public int ImtiUodegas() { return uodegos; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Pabaisa p1, p2, p3;
            Console.WriteLine("Įveskite pirmos pabaisos ragų ir uodegų skaičių ir amžių: ");
            p1 = new Pabaisa(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine("Įveskite antros pabaisos ragų ir uodegų skaičių ir amžių: ");
            p2 = new Pabaisa(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine("Įveskite trečios pabaisos ragų ir uodegų skaičių ir amžių: ");
            p3 = new Pabaisa(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

            Console.WriteLine("Pabaisos bendrai turi {0} ragų", PabaisuRagai(p1.ImtiRagus(), p2.ImtiRagus(), p3.ImtiRagus()));
            Console.WriteLine("Pabaisos bendrai turi {0} uodegų", PabaisuUodegos(p1.ImtiUodegas(), p2.ImtiUodegas(),p3.ImtiUodegas()));

            Console.WriteLine();
            int mazUodega = p1.ImtiUodegas();
            string pabaisosNUmeris = "pirma";
            int raguSK = p1.ImtiRagus();
            if (mazUodega > p2.ImtiUodegas())
            {
                mazUodega = p2.ImtiUodegas();
                pabaisosNUmeris = "antra";
                raguSK = p2.ImtiRagus();

            }
            if (mazUodega > p3.ImtiUodegas())
            {
                mazUodega = p3.ImtiUodegas();
                pabaisosNUmeris = "trečia";
                raguSK = p3.ImtiRagus();

            }
            Console.WriteLine("Maiausiai uodeguota pabaisa yra {0}, kuri turi {1} ragus", pabaisosNUmeris, raguSK);

            int vyrPab = p1.ImtiAmžiu();
            int uodeguSK = p1.ImtiUodegas();
            pabaisosNUmeris = "pirma";
            if (vyrPab< p2.ImtiAmžiu())
            {
                vyrPab = p2.ImtiAmžiu();
                pabaisosNUmeris = "antra";
                uodeguSK = p2.ImtiUodegas();
                raguSK = p2.ImtiRagus();
            }
            if (vyrPab < p3.ImtiAmžiu())
            {
                vyrPab = p3.ImtiAmžiu();
                pabaisosNUmeris = "trečia";
                uodeguSK = p3.ImtiUodegas();
                raguSK = p3.ImtiRagus();
            }
            Console.WriteLine("Vyriausia pabaisa yra {0}, kuriai yra {1}, metų. Nukovęs ją studentas turės {2} trofėjinius ragus ir {3} trofėjines uodegas ", pabaisosNUmeris, vyrPab, raguSK, uodeguSK);

            //--- sukuriam du naujus studentus
            Studentas s1, s2;
            s1 = new Studentas("Jonas", 0, 0);
            s2 = new Studentas("Petras", 0, 0);
            Console.WriteLine();
            Console.WriteLine("Įveskite {0}  turimų trofėjų skaičius: Dabar ragu turi: {1}  Dabar uodegų turi: {2}",s1.ImtiVarda(), s1.ImtiRagus(), s1.ImtiUodegas());
            Console.WriteLine();
            Console.WriteLine("Įveskite {0}  turimą ragų skaičių:",s1.ImtiVarda());
            s1.DėtiRagus(int.Parse(Console.ReadLine()));
            Console.WriteLine("Įveskite {0}  turimą uodegų skaičių:", s1.ImtiVarda());
            s1.DėtiUodegas(int.Parse(Console.ReadLine()));
            Console.WriteLine();
            Console.WriteLine("Įveskite {0}  turimų trofėjų skaičius:Dabar ragu turi: {1}  Dabar uodegų turi: {2}", s2.ImtiVarda(), s2.ImtiRagus(), s2.ImtiUodegas());
            Console.WriteLine();
            Console.WriteLine("Įveskite {0}  turimą ragų skaičių:", s2.ImtiVarda());
            s2.DėtiRagus(int.Parse(Console.ReadLine()));
            Console.WriteLine("Įveskite {0}  turimą uodegų skaičių:",s2.ImtiVarda());
            s2.DėtiUodegas(int.Parse(Console.ReadLine()));

            //--vyriausios pabaisos medžioklė
             vyrPab = p1.ImtiAmžiu();
             uodeguSK = p1.ImtiUodegas();
            if (vyrPab < p2.ImtiAmžiu())
            {
                vyrPab = p2.ImtiAmžiu();
                uodeguSK = p2.ImtiUodegas();
                raguSK = p2.ImtiRagus();
            }
            if (vyrPab < p3.ImtiAmžiu())
            {
                vyrPab = p3.ImtiAmžiu();
                uodeguSK = p3.ImtiUodegas();
                raguSK = p3.ImtiRagus();
            }
            
            Console.WriteLine("{0} studentas sumedžiojęs vyriausia pabaisą turės {1} ragu ir {2} uodegų:",s1.ImtiVarda(),(s1.ImtiRagus()+ raguSK), (s1.ImtiUodegas()+ uodeguSK));
            //-- pridedam sumedžiotų trofėjų kiekis
            s1.DėtiRagus(s1.ImtiRagus() + raguSK);
            s1.DėtiUodegas(s1.ImtiUodegas() + uodeguSK);

            //--jauniausios pabaisos medžioklė
            vyrPab = p1.ImtiAmžiu();
            uodeguSK = p1.ImtiUodegas();
            raguSK = p1.ImtiRagus();
            if (vyrPab > p2.ImtiAmžiu())
            {
                vyrPab = p2.ImtiAmžiu();
                uodeguSK = p2.ImtiUodegas();
                raguSK = p2.ImtiRagus();
            }
            if (vyrPab > p3.ImtiAmžiu())
            {
                vyrPab = p3.ImtiAmžiu();
                uodeguSK = p3.ImtiUodegas();
                raguSK = p3.ImtiRagus();
            }     
            Console.WriteLine("{0} studentas sumedžiojęs jauniausia pabaisą turės {1} ragu ir {2} uodegų:", s2.ImtiVarda(),(s2.ImtiRagus() + raguSK), (s2.ImtiUodegas() + uodeguSK));

            //-- pridedam sumedžiotų trofėjų kiekis
            s2.DėtiRagus(s2.ImtiRagus() + raguSK);
            s2.DėtiUodegas(s2.ImtiUodegas() + uodeguSK);

            Console.WriteLine();
            Console.WriteLine("Daugiau ragų turi {0}", DaugiauRagu(s1.ImtiRagus(),s2.ImtiRagus(),s1.ImtiVarda(),s2.ImtiVarda()));
            Console.WriteLine("Daugiau uodegų turi {0}", DaugiauUodegų(s1.ImtiUodegas(), s2.ImtiUodegas(), s1.ImtiVarda(), s2.ImtiVarda()));
        }
        static int PabaisuRagai(int ragai1, int ragai2, int ragai3)
        {
            return ragai1 + ragai2 + ragai3;
        }
        static int PabaisuUodegos(int uodegos1, int uodegos2, int uodegos3)
        {
            return uodegos1+ uodegos2 +uodegos3;
        }

        static string DaugiauRagu(int ragu1, int ragu2, string vardas1, string vardas2)
        {
            if (ragu1 > ragu2)
                return vardas1;
            else
                return vardas2;
        }
        static string DaugiauUodegų(int uodegu1, int uodegu2, string vardas1, string vardas2)
        {
            if (uodegu1 > uodegu2)
                return vardas1;
            else
                return vardas2;
        }

    }
}
