using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace Dogs.Lab3
{
    static class InOutUtils
    {
        public static DogsContainer ReadDogs(string filename)
        {
            DogsContainer Dogs = new DogsContainer();
            string[] Lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(',');
                int id = int.Parse(Values[0]);
                string name = Values[1];
                string breed = Values[2];
                DateTime birthDate = DateTime.Parse(Values[3]);

                Gender gender;
                Enum.TryParse(Values[4], out gender);
                Dog dog = new Dog(id, name, breed, birthDate, gender);
                if (!Dogs.Contains(dog))
                {
                    Dogs.Add(dog);
                }
            }
            return Dogs;
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

        public static void PrintDogs(string label, DogsContainer dogs)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,-70} |", label);
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,15} | {2,-15} | {3,-12} | {4,-8}|", "Reg.Nr", "Vardas", "Veisė", "Gimimo metai", "Lytis");
            Console.WriteLine(new string('-', 74));
            for (int i = 0; i < dogs.Count; i++)
            {
                Dog dog = dogs.Get(i);
                Console.WriteLine("| {0,8} | {1,15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8}|", dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
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
        public static void PrintDogsToCSVFile(string fileName, DogsContainer dogs)
        {
            string[] lines = new string[dogs.Count + 1];
            lines[0] = String.Format("{0},{1},{2},{3},{4}", "Reg.Nr.", "Vardas", "Veislė", "Gimino data", "Lytis");
            for (int i = 0; i < dogs.Count; i++)
            {
                lines[i + 1] = String.Format("{0},{1},{2},{3},{4}", dogs.Get(i).ID, dogs.Get(i).Name, dogs.Get(i).Breed, dogs.Get(i).BirthDate, dogs.Get(i).Gender);
            }
            File.WriteAllLines(fileName, lines);
        }
        public static void PrintDogsFiltered(DogsContainer dogs)
        {
            if (dogs.Count != 0)
            {
                Console.WriteLine(new string('-', 95));
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} | {5,-12:yyyy-MM-dd} |", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis", "Vakcinavimo data");
                Console.WriteLine(new string('-', 95));
                for (int i = 0; i < dogs.Count; i++)
                {
                    Dog dog = dogs.Get(i);
                    Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} | {5,-12:yyyy-MM-dd} |", dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender, dog.LastVaccinationDate);
                    Console.WriteLine(new string('-', 95));
                }
            }
            else
                Console.WriteLine("Visų šunų skiepai galioja");

        }

    }
}

