using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teorija
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Isvestine_klase objIšvKlasės = new Isvestine_klase();
            //objIšvKlasės.Spausdinti();
            //objIšvKlasės.Spausdinti1();

            //Isvestine_klase objIšvKlasės = new Isvestine_klase("DUOMENYS");
            //objIšvKlasės.Spausdinti();
            //Console.WriteLine("Dirba klasės Program metodas Main().");
            //Console.WriteLine("Jis parodo bazinės klasės savybės reikšmę: {0}.", objIšvKlasės.eiluteBaz);

            //Isvestine_klase objIšvKlasės = new Isvestine_klase("DUOMENYS",99999);
            //objIšvKlasės.Spausdinti();
            //Isvestine_klase objIšvKlasės1 = new Isvestine_klase();
            //objIšvKlasės1.Spausdinti();


            //Apskritimas apskritimasA = new Apskritimas(10);
            //Console.WriteLine("Apskritimo A duomenys: {0}", apskritimasA.ToString());
            //Console.WriteLine("Apskritimo A ribojamas plotas: {0, 10:f3}",
            //apskritimasA.Plotas());
            //Apskritimas apskritimasB = new Apskritimas();
            //Console.WriteLine("Apskritimo B duomenys: {0}", apskritimasB.ToString());
            //Console.WriteLine("Apskritimo B ribojamas plotas: {0, 10:f3}",
            //apskritimasB.Plotas());
            //Cilindras cilindrasA = new Cilindras();
            //Console.WriteLine("Cilindro A duomenys: {0}", cilindrasA.ToString());
            //Console.WriteLine("Cilindro A tūris ={0, 10:f3}", cilindrasA.Turis());
            //Cilindras cilindrasB = new Cilindras(10, 50);
            //Console.WriteLine("Cilindro B duomenys: {0}", cilindrasB.ToString());
            //Console.WriteLine("Cilindro B tūris ={0, 10:f3}", cilindrasB.Turis());


            Mama mama = new Mama("Aldona", "Adams",50);
            Asmuo sunus1 = mama.Naujagimis("Jonas",12);
            Asmuo dukra1 = mama.Naujagimis("Rasa",15);
            Asmuo sunus2 = mama.Naujagimis("Titas",19);
            Console.WriteLine("Mama:\n{0}", mama.ToString());

            Console.WriteLine();
            Console.WriteLine("Vaikai:");
            foreach (Asmuo vaikas in mama)
                Console.WriteLine(vaikas.Vardas);


        }
    }
}
