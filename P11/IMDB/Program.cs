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
            //Read file and print first movie list
            FilmContainer cont1 = InOutClass.ReadFilms(@"IMDB.csv");
            InOutClass.PrintFilms(cont1);
            Console.WriteLine();
            //Read file and print second movie list
            FilmContainer cont2 = InOutClass.ReadFilms(@"IMDB2.csv");
            InOutClass.PrintFilms(cont2);
            Console.WriteLine();
            //Finds favorite director from first file
            List<string> Directors = FilmContainer.FindDirectors(cont1);
            List<int> Dir = FilmContainer.CountDirectors(cont1);
            int a = TaskClass.dirMax(Dir);
            List<string> maxDir = TaskClass.FindMaxCountDirector(Directors, Dir, a);
            InOutClass.PrintDirectors(maxDir, cont1);
            Console.WriteLine();
            //Finds favorite director from second file
            List<string> Directors2 = FilmContainer.FindDirectors(cont2);
            List<int> Dir2 = FilmContainer.CountDirectors(cont2);
            int b = TaskClass.dirMax(Dir);
            List<string> maxDir2 = TaskClass.FindMaxCountDirector(Directors2, Dir2, b);
            InOutClass.PrintDirectors(maxDir2, cont2);
            Console.WriteLine();
            //Finds most money earned movie
            double maxProfit = FilmContainer.FindMaxProfit(cont1, cont2);
            FilmContainer cont3 = new FilmContainer();
            FilmContainer.MaxProfit(cont3, cont1, maxProfit);
            FilmContainer.MaxProfit(cont3, cont2, maxProfit);
            Console.WriteLine("Film who earned most money:");         
            InOutClass.PrintFilms1(cont3);
            //Print to file a recomended movie
            FilmContainer recomended1 = TaskClass.RecomendedFilms(cont1, cont2);
            FilmContainer recomended2 = TaskClass.RecomendedFilms(cont2, cont1);          
            recomended1.Sort();
            recomended2.Sort();
            string tofile1 = "Rekomendacija_" + cont1.Hname + ".csv";
            string tofile2 = "Rekomendacija_" + cont2.Hname + ".csv";
            InOutClass.PrintFilmsToCSVFile(tofile1, recomended1);
            InOutClass.PrintFilmsToCSVFile(tofile2, recomended2);
            //Print to file film genre
            List<string> Genres =  cont1.filmTypes(cont1);
            InOutClass.PrintGenreToCSVFile("Genres.csv", Genres);
            Console.WriteLine();
            Console.WriteLine("It's all done!!");

        }
    }
}
