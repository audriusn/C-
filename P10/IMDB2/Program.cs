using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            //Read file and print first movie list
            FilmRegister list1 = InOutClass.ReadFilms(@"IMDB.csv");
            Console.WriteLine("Movies:");
            InOutClass.PrintFilms(list1);
            //Read file and print second movie list
            FilmRegister list2 = InOutClass.ReadFilms(@"IMDB2.csv");
            Console.WriteLine("Movies:");
            InOutClass.PrintFilms(list2);
            // Print movies both seen
            FilmRegister SeenBoth = TaskClass.SeenBoth(list1, list2);
            Console.WriteLine("Seen Both:");
            InOutClass.PrintFilmsSeenBoth(SeenBoth);
            InOutClass.PrintFilmsToCSVFile("MatėAbu.csv", SeenBoth);
            // Print movie wicth earn most money
            double maxProfit = TaskClass.FindMaxProfit(list1, list2);
            FilmRegister list3 = new FilmRegister();
            TaskClass.MaxProfit(list3, list1, maxProfit);
            TaskClass.MaxProfit(list3, list2, maxProfit);
            Console.WriteLine("Film who earned most money:");
            InOutClass.PrintFilms(list3);
            ///Print genres to file
            List<string> Genre = new List<string>();
             list1.filmTypes(Genre);
             list2.filmTypes(Genre);
            InOutClass.PrintGenreToCSVFile("Žanrai.csv", Genre);
            Console.WriteLine("Programa darbą baigė!!");







        }
    }
}
