using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs.Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            DogsContainer allDogs = InOutUtils.ReadDogs(@"Dogs.csv");
            allDogs.Sort();
            InOutUtils.PrintDogs("Registro infromacija:", allDogs);
            Console.WriteLine("Iš viso šunų: {0}", allDogs.Count);
            Console.WriteLine("Patinų: {0}", allDogs.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", allDogs.CountByGender(Gender.Female));
            Console.WriteLine();
            Dog oldest = allDogs.FindOldestDog(allDogs);
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            Console.WriteLine();
            List<string> Breeds = allDogs.FindBreeds(allDogs);
            Console.WriteLine("Veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();
            List<Vaccination> VaccinationsDate = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            allDogs.UpdateVaccinationsInfo(VaccinationsDate);
            Console.WriteLine("Šunys kuriems reikia vakcinacijos:");
            DogsContainer ToVaccinate = allDogs.FilterByVaccinationExpired(allDogs);
            InOutUtils.PrintDogsFiltered(ToVaccinate);
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            DogsContainer FilteredByBreed = allDogs.FilterByBreed(selectedBreed);
            InOutUtils.PrintDogsFiltered(FilteredByBreed);
            Console.WriteLine();
            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);
            InOutUtils.PrintDogs("Reikia skiepyti (" + selectedBreed + ")", ToVaccinate.Intersect(FilteredByBreed));


        }
    }
}