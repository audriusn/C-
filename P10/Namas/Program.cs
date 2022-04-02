using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            FlatRegister register = InOutClass.ReadFlats(@"Flats.csv");
            Console.WriteLine("Flats information:");
            InOutClass.PrintFlats(register);
            Console.WriteLine("Įveskite jus dominantį aukštų intervalą:");
            Console.WriteLine("Nuo:");
            int minFloor = int.Parse(Console.ReadLine());
            Console.WriteLine("Iki:");
            int maxFloor = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite jus dominančių kambarių skaičių:");
            int rooms = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite maksimalią kainą kurią jūs galite mokėti:");
            int price = int.Parse(Console.ReadLine());
            FlatRegister filtered = FlatRegister.FilteredFlats(minFloor, maxFloor, rooms, price, register);
            InOutClass.PrintFiltered(filtered);
        }
    }
}
