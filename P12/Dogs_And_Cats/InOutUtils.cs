using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace Dogs_And_Cats
{
    static class InOutUtils
    {
        public static AnimalsContainer ReadAnimals(string filename)
        {
            AnimalsContainer animals = new AnimalsContainer();
            string[] Lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(',');
                string type = Values[0];
                int id = int.Parse(Values[1]);
                string name = Values[2];
                string breed = Values[3];
                DateTime birthDate = DateTime.Parse(Values[4]);

                Gender gender;
                Enum.TryParse(Values[5], out gender);
                switch(type)
                {
                    case "DOG":
                        bool aggresive = bool.Parse(Values[6]);
                        Dog dog = new Dog (id, name, breed, birthDate, gender, aggresive);
                        animals.Add(dog);
                        break;
                    case "CAT":
                        Cat cat = new Cat (id, name, breed, birthDate, gender);
                        animals.Add(cat);
                        break;
                    case "GuineaPig":
                        GuineaPig guineaPig = new GuineaPig(id, name, breed, birthDate, gender);
                        animals.Add(guineaPig);
                        break;
                    default:
                        break; //unknown type
                }
            }
            return animals;
        }

        public static List<Vaccination> ReadVaccinations(string filename)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();
            string[] Lines = File.ReadAllLines(filename);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(',');
                int id = int.Parse(Values[0]);
                DateTime vaccinationDate = DateTime.Parse(Values[1]);
                Vaccination v = new Vaccination(id, vaccinationDate);
                Vaccinations.Add(v);
            }
            return Vaccinations;
        }

        public static void PrintAnimals(string label, AnimalsContainer animals)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,-70} |", label);
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,15} | {2,-15} | {3,-12} | {4,-8}|", "Reg.Nr", "Vardas", "Veisė", "Gimimo metai", "Lytis");
            Console.WriteLine(new string('-', 74));
            for (int i = 0; i < animals.Count; i++)
            {
                Animal animal = animals.Get(i);
                Console.WriteLine("| {0,8} | {1,15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8}|", animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender);
            }
            Console.WriteLine(new string('-', 74));
        }

        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }
        public static void PrintDogsToCSVFile(string fileName, AnimalsContainer dogs)
        {
            string[] lines = new string[dogs.Count + 1];
            lines[0] = String.Format("{0},{1},{2},{3},{4}", "Reg.Nr.", "Vardas", "Veislė", "Gimino data", "Lytis");
            for (int i = 0; i < dogs.Count; i++)
            {
                lines[i + 1] = String.Format("{0},{1},{2},{3},{4}", dogs.Get(i).ID, dogs.Get(i).Name, dogs.Get(i).Breed, dogs.Get(i).BirthDate, dogs.Get(i).Gender);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
        public static void PrintAnimalsFiltered(AnimalsContainer animals)
        {
            if (animals.Count != 0)
            {
                Console.WriteLine(new string('-', 95));
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} | {5,-12:yyyy-MM-dd} |", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis", "Vakcinavimo data");
                Console.WriteLine(new string('-', 95));
                for (int i = 0; i < animals.Count; i++)
                {
                    Animal animal = animals.Get(i);
                    Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} | {5,-12:yyyy-MM-dd} |", animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender, animal.LastVaccinationDate);
                    Console.WriteLine(new string('-', 95));
                }
            }
            else
                Console.WriteLine("Visų šunų skiepai galioja");

        }
    }
}
