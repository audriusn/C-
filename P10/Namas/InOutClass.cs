using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace Namas
{
    static class InOutClass
    {

        public static FlatRegister ReadFlats(string filename)
        {
            FlatRegister Flats = new FlatRegister();
            string[] Lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(',');
                int Number = int.Parse(Values[0]);
                double Area = double.Parse(Values[1]);
                int Rooms = int.Parse(Values[2]);
                int Price = int.Parse(Values[3]);
                int MobPhone = int.Parse(Values[4]);
                Flats flat = new Flats(Number, Area, Rooms, Price, MobPhone);
                if (!Flats.Contains(flat))
                {
                    Flats.Add(flat);
                }
            }
            return Flats;
        }

        public static void PrintFlats(FlatRegister register)
        {
            Console.WriteLine(new string('-', 66));
            Console.WriteLine("| {0,6} | {1,6}    | {2,6} | {3,12} | {4,8}|{5}|", "Number", "Area", "Rooms", "Price", "Phone Number","Floor");
            Console.WriteLine(new string('-', 66));
            for (int i = 0; i < register.FlatsCount(); i++)
            {
                Console.WriteLine("| {0,6} | {1,6} m2 | {2,6} | {3,12:c} | {4,8}   |  {5}  |", register.GetFlat(i).Number, register.GetFlat(i).Area, register.GetFlat(i).Rooms, register.GetFlat(i).Price, register.GetFlat(i).MobPhone, register.GetFlat(i).Floor);
            }
            Console.WriteLine(new string('-', 66));
        }

        public static void PrintFiltered(FlatRegister register)
        {
            if (register.FlatsCount() != 0)
            {
                 Console.WriteLine(new string('-', 66));
                Console.WriteLine("| {0,6} | {1,6}    | {2,6} | {3,12} | {4,8}|{5}|", "Number", "Area", "Rooms", "Price", "Phone Number", "Floor");
                Console.WriteLine(new string('-', 66));
                for (int i = 0; i < register.FlatsCount(); i++)
                {
                    Console.WriteLine("| {0,6} | {1,6} m2 | {2,6} | {3,12:c} | {4,8}   |  {5}  |", register.GetFlat(i).Number, register.GetFlat(i).Area, register.GetFlat(i).Rooms, register.GetFlat(i).Price, register.GetFlat(i).MobPhone, register.GetFlat(i).Floor);
                }
                Console.WriteLine(new string('-', 66));
            }
            else
                Console.WriteLine("Atsiprašome, bet pagal Jūsų nurodytus kriterijus būtų pasiūlyti negalime.");
        }
           


    }
}
