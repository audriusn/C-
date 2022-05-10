using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    class Film : Record
    {
        public int Year { get; set; }
        public string Director { get; set; }
        public int Profit { get; set; }
        public Film(string Name, string Genre, string Studia, string Actor1, string Actor2, int Year, string Director, int Profit) : base(Name, Genre, Studia, Actor1, Actor2)
        {
            this.Year = Year;
            this.Director = Director;
            this.Profit = Profit;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-8} {1, 12} {2, 17} {3, 15} {4, 15} {5,10} {6,10} {7,10} ",
                Name, Genre, Studia, Actor1, Actor2, Year, Director, Profit);
            return eilute;
        }
    }
}
