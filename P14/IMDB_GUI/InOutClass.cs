using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IMDB_GUI
{
    internal class InOutClass
    {
        public static List<Film> ReadFilm(string fileName)
        {
            List<Film> Films = new List<Film>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {

                string[] Values = line.Split(',');
                string Name = Values[0];
                int Year = int.Parse(Values[1]);
                string Type = Values[2];
                string Company = Values[3];
                string Director = Values[4];
                string Actor1 = Values[5];
                string Actor2 = Values[6];
                int Profit = int.Parse(Values[7]);

                Film film = new Film(Name, Year, Type, Company, Director, Actor1, Actor2, Profit);
                Films.Add(film);
            }
            return Films;
        }

        public static void PrintFilms(List<Film> Films)
        {
            Console.WriteLine(new string('-', 150));
            Console.WriteLine(" {0,-22} {1,-6}  {2,-10} {3,-35} {4,-18} {5,-15} {6,-15} {7:c}", "Name", "Year", "Type", "Company", "Director", "Actor", "Actor", "Profit");
            Console.WriteLine(new string('-', 150));
            foreach (Film film in Films)
            {
                Console.WriteLine(" {0,-22} {1,-6}  {2,-10} {3,-35} {4,-18} {5,-15} {6,-15} {7:c} ", film.Name, film.Year, film.Type, film.Company, film.Director,
                    film.Actor1, film.Actor2, film.Profit);
            }
            Console.WriteLine(new string('-', 150));
        }
        /// <summary>
        /// Print max profit
        /// </summary>
        /// <param name="Films"></param>
        public static void PrintMaxProfit(List<Film> Films)
        {
            if (Films.Count > 0)
            {
                Console.WriteLine("The most lucrative film of 2019:");
                Console.WriteLine(new string('-', 80));
                Console.WriteLine(" {0,-22} {1,-20} {2:c}", "Name", "Director", "Profit");
                Console.WriteLine(new string('-', 80));
                foreach (Film film in Films)
                {
                    Console.WriteLine(" {0,-22} {1,-20} {2:c} ", film.Name, film.Director, film.Profit);
                }
                Console.WriteLine(new string('-', 80));
            }
            else
                Console.WriteLine("Sorry, there are no films who was made in 2019!!!");
        }
        /// <summary>
        /// Print directors list
        /// </summary>
        /// <param name="Directors"></param>

        public static void PrintDirectors(List<string> Directors)
        {
            foreach (string director in Directors)
            {
                Console.WriteLine(director);
            }
        }
        /// <summary>
        /// Priting  films with Nicolas Cage to CSV file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Museums"></param>
        public static void PrintMuseumsToCSVFile(string fileName, List<Film> Films)
        {
            if (Films.Count > 0)
            {
                string[] lines = new string[Films.Count + 1];
                lines[0] = String.Format(" {0},{1},{2}", "Name", "Year", "Company");
                for (int i = 0; i < Films.Count; i++)
                {
                    lines[i + 1] = String.Format("{0},{1},{2}", Films[i].Name, Films[i].Year, Films[i].Company);

                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
                Console.WriteLine("Sorry, there are no movies with Nicolas Cage");

        }
    }
}
