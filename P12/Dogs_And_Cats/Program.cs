using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs_And_Cats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            AnimalsContainer allAnimals = InOutUtils.ReadAnimals(@"Animals.csv");
            InOutUtils.PrintAnimals("Registro infromacija:", allAnimals);
            Console.WriteLine("Iš viso gyvūnų: {0}", allAnimals.Count);
            Console.WriteLine("Patinų: {0}", allAnimals.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", allAnimals.CountByGender(Gender.Female));
            Console.WriteLine("Agresyvių šunų yra: {0}", allAnimals.CountAggresiveDogs()); //count aggresive dogs
            Console.WriteLine();
            Animal oldest = allAnimals.FindOldestAnimal(allAnimals);
            Console.WriteLine("Seniausias gyvūnas:");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            Console.WriteLine();
            List<string> Breeds = allAnimals.FindBreeds(allAnimals);
            Console.WriteLine("Veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();
            List<Vaccination> VaccinationsDate = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            allAnimals.UpdateVaccinationsInfo(VaccinationsDate);
            Console.WriteLine("Šunys kuriems reikia vakcinacijos:");
            AnimalsContainer ToVaccinate = allAnimals.FilterByVaccinationExpired(allAnimals);
            InOutUtils.PrintAnimalsFiltered(ToVaccinate);
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            AnimalsContainer FilteredByBreed = allAnimals.FilterByBreed(selectedBreed);
            InOutUtils.PrintAnimalsFiltered(FilteredByBreed);
            Console.WriteLine();
            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);
            InOutUtils.PrintAnimals("Reikia skiepyti (" + selectedBreed + ")", ToVaccinate.Intersect(FilteredByBreed));
            allAnimals.Sort(new AnimalsComparatorByName());          
            InOutUtils.PrintAnimals("Rikiavimas pagal vardą ir ID :", allAnimals);
            allAnimals.Sort(new AnimalsComparatorByBirthDate());
            InOutUtils.PrintAnimals("Rikiavimas pagal gimimo datą ir ID :", allAnimals);
        }
    }
}