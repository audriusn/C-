using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace TuristuInformacijosCentras
{
    static class InOutClass
    {
        /// <summary>
        /// Reading file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Museum> ReadMuseum(string fileName)
        {
            List<Museum> Museums = new List<Museum>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(',');
                string pavadinimas = Values[0];
                string miestas = Values[1];
                string tipas = Values[2];
                int pirmadienis = int.Parse(Values[3]);
                int antradienis = int.Parse(Values[4]);
                int treciadienis = int.Parse(Values[5]);
                int ketvirtadienis = int.Parse(Values[6]);
                int penktadienis = int.Parse(Values[7]);
                int sestadienis = int.Parse(Values[8]);
                int sekmadienis = int.Parse(Values[9]);
                double kaina = double.Parse(Values[10]);

                Guide Guide;
                Enum.TryParse(Values[11], out Guide);  //tries to convert values to enum
                Museum museum = new Museum(pavadinimas, miestas, tipas, pirmadienis, antradienis, treciadienis,ketvirtadienis, penktadienis, sestadienis, sekmadienis,kaina,Guide);
                Museums.Add(museum);
            }
            return Museums;

        }
        /// <summary>
        /// Printing all museums
        /// </summary>
        /// <param name="Museums"></param>
        public static void PrintMuseums(List<Museum> Museums)
        {
            Console.WriteLine(new string('-', 100));
            Console.WriteLine(" {0,-23}  {1,-11}  {2,-10} {3,2} {4,2} {5,2} {6,2} {7,2} {8,3} {9,3} {10,6} {11,-20}", "Pavadinimas", "Miestas", "Tipas", "I", "II", "III", "IV", "V", "VI", "VII","Kaina","Gidas");
            Console.WriteLine(new string('-', 100));
            foreach (Museum museum in Museums)
            {
                if (museum != null)
                {
                    Console.WriteLine(" {0,-23} {1,-11}  {2,-10}  {3,2} {4,2} {5,2} {6,2} {7,3} {8,3} {9,3} {10,6} {11,-20}", museum.pavadinimas, museum.miestas, museum.tipas, museum.pirmadienis, museum.antradienis,
                        museum.treciadienis, museum.ketvirtadienis, museum.penktadienis, museum.sestadienis, museum.sekmadienis, museum.kaina, museum.Guide);
                }
                else
                    Console.WriteLine("Atsiprašome, bet pagal Jūsų pasirinktus kriterijus nieko neradome");
            }

            Console.WriteLine(new string('-',100));
        }
        /// <summary>
        /// Printing all museums type witch working on wednesday in Vilnius
        /// </summary>
        /// <param name="tipas"></param>
        /// <param name="Museums"></param>
        public static void PrintTypesVLNOnWensdaye(List<string> tipas, List<Museum> Museums)
        {
                int a = TaskClass.TypesVLNOnWensday(Museums, 1, "Vilnius").Count;
                if (a > 0)
                {
                Console.WriteLine("Trečiadieniais Vilniuje galima aplankyti šių tipų muziejus:");
                    foreach (string VLNtipai in tipas)
                    {
                        Console.WriteLine(VLNtipai);
                    }
                }
                else Console.WriteLine("Atsiprašome, bet muziejų dirbančių Vilniuje trečiadieniais nėra");
            }
        /// <summary>
        /// Printing filtered values to console
        /// </summary>
        /// <param name="Museums"></param>
        public static void PrintFilteredMuseums(List<Museum> Museums)
        {
            if (Museums.Count > 0)
            {
                Console.WriteLine(new string('-', 100));
                Console.WriteLine(" {0,-23}  {1,-11}  {2,-10} {3,2} {4,2} {5,2} {6,2} {7,2} {8,3} {9,3} {10,6} {11,-20}", "Pavadinimas", "Miestas", "Tipas", "I", "II", "III", "IV", "V", "VI", "VII", "Kaina", "Gidas");
                Console.WriteLine(new string('-', 100));
                foreach (Museum museum in Museums)
                {
                    Console.WriteLine(" {0,-23} {1,-11}  {2,-10}  {3,2} {4,2} {5,2} {6,2} {7,3} {8,3} {9,3} {10,6} {11,-20}", museum.pavadinimas, museum.miestas, museum.tipas, museum.pirmadienis, museum.antradienis,
                        museum.treciadienis, museum.ketvirtadienis, museum.penktadienis, museum.sestadienis, museum.sekmadienis, museum.kaina, museum.Guide);
                }
            }
            else
                Console.WriteLine("Atsiprašome, bet pagal Jūsų pasirinktus kriterijus nieko neradome");
            Console.WriteLine(new string('-', 100));
        }
        /// <summary>
        /// Printing values to CSV file.
        /// </summary>
        /// <param name="fileName">File Name</param>
        /// <param name="Museums">List</param>
        public static void PrintMuseumsToCSVFile(string fileName, List<Museum> Museums)
        {
            string[] lines = new string[Museums.Count + 1];
            lines[0] = String.Format(" {0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}", "Pavadinimas", "Miestas", "Tipas", "I", "II", "III", "IV", "V", "VI", "VII", "Kaina", "Gidas");
            for (int i = 0; i < Museums.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}", Museums[i].pavadinimas, Museums[i].miestas, Museums[i].tipas, Museums[i].pirmadienis, Museums[i].antradienis,
                        Museums[i].treciadienis, Museums[i].ketvirtadienis, Museums[i].penktadienis, Museums[i].sestadienis, Museums[i].sekmadienis, Museums[i].kaina, Museums[i].Guide);
            }
            File.WriteAllLines(fileName, lines);
        }
    }
}
    

