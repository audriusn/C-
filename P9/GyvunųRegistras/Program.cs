using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GyvunųRegistras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            List<Dog> allDogs = InOutUtils.ReadDogs(@"Dogs.csv");
            Console.WriteLine("Registro informacija");
            InOutUtils.PrintDogs(allDogs);
            Console.WriteLine("Iš viso šunų: {0}", allDogs.Count);
            Console.WriteLine("Patinų: {0}",TaskUtils.CountByGender(allDogs,Gender.Male));
            Console.WriteLine("Patelių: {0}", TaskUtils.CountByGender(allDogs, Gender.Female));
            Console.WriteLine();
            Dog oldest = TaskUtils.FindOldestDog(allDogs);
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.CalculateAge());
            List<string> Breeds = TaskUtils.FindBreeds(allDogs);
            Console.WriteLine();
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();
            Console.WriteLine("Kokios veilės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            List<Dog> FilteredByBreed = TaskUtils.FilterByBreed(allDogs, selectedBreed);
            InOutUtils.PrintDogs(FilteredByBreed);
            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);
        }
    }
}
