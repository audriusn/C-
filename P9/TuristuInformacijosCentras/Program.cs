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
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            List<Museum> allMuseums = InOutClass.ReadMuseum(@"muziejai.csv");
            Console.WriteLine("Lietuvos muziejai");
            InOutClass.PrintMuseums(allMuseums);
            TaskClass.PrintCountByGuide(allMuseums);
            TaskClass.CountVLNOnWensday(allMuseums, 1, "Vilmius");
            List<string> VLNtipai = TaskClass.TypesVLNOnWensday(allMuseums, 1,"Vilnius");
            Console.WriteLine();
            InOutClass.PrintTypesVLNOnWensdaye(VLNtipai, allMuseums);
            Console.WriteLine("Kokio miesto muziejus atrinkti, kurie dirba ne mažiau nei 3 dienas per savaitę?");
            string selectedCity = Console.ReadLine();
            List<Museum> FilterByCity = TaskClass.FilterByCity(allMuseums, selectedCity);
            InOutClass.PrintFilteredMuseums(FilterByCity);
            string fileName = selectedCity + ".csv";
            InOutClass.PrintMuseumsToCSVFile(fileName, FilterByCity);        
        }
    }
}
