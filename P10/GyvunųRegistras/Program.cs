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

            DogsRegister register = InOutUtils.ReadDogs(@"Dogs.csv");
            Console.WriteLine("Registro informacija:");
            InOutUtils.PrintDogs(register);
            Console.WriteLine("Iš viso šunų: {0}", register.DogsCount());
            Console.WriteLine("Patinų: {0}", register.CountByGender( Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));
            Console.WriteLine();
            List<Vaccination> VaccinationsDate = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            register.UpdateVaccinationsInfo(VaccinationsDate); 
 
            Dog oldest = register.FindOldestDog();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            Console.WriteLine();
            List<string> Breeds = register.FindBreeds();
            Console.WriteLine("Veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();
            Console.WriteLine("Šunys kuriems reikia vakcinacijos:");
            List<Dog> ToVaccinate = register.FilterByVaccinationExpired();
            InOutUtils.PrintDogsFiltered(ToVaccinate);

            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed =Console.ReadLine();
            List<Dog> FilteredByBreed = register.FilterByBreed(selectedBreed);
            InOutUtils.PrintDogsFiltered(FilteredByBreed);
            Console.WriteLine();
            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);



            //Console.WriteLine();
            //Console.WriteLine("Šunų veislės:");
            //InOutUtils.PrintBreeds(Breeds);
            //Console.WriteLine();
            //Console.WriteLine("Kokios veilės šunis atrinkti?");
            //string selectedBreed = Console.ReadLine();
            //List<Dog> FilteredByBreed = TaskUtils.FilterByBreed(allDogs, selectedBreed);
            //InOutUtils.PrintDogs(FilteredByBreed);
            //string fileName = selectedBreed + ".csv";
            //InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);
        }
    }
}
