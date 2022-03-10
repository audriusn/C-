using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            List<Film> allFilms = InOutClass.ReadFilm(@"IMDB.csv");
            Console.WriteLine("Film list:");
            InOutClass.PrintFilms(allFilms);
            List<Film> MaxProfit = TaskClass.FindMax(allFilms, 2019);
            InOutClass.PrintMaxProfit(MaxProfit);

            List<string> Directors =TaskClass.FindDirectors(allFilms);
            Console.WriteLine();
       
            List<int> Dir = TaskClass.CountDirectors(allFilms);
            Console.WriteLine();
            
            int a = TaskClass.dirMax(Dir);
            List<string> maxDir = TaskClass.FindMaxCountDirector(Directors, Dir, a);
            Console.WriteLine();
            Console.WriteLine("Film director who made max movies:");
            InOutClass.PrintDirectors(maxDir);
            List<Film> Ncage = TaskClass.NCageFimls(allFilms);
            InOutClass.PrintMuseumsToCSVFile("cage.csv", Ncage);

        }
    }
}
