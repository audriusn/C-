using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
     class Serial : Record
    {
        public int StartYear { get; set; }
        public int Episodes { get; set; }
        public int EndYears { get; set; }
        public Mark StillPlaying { get; set; }
        public Serial(string Name, string Genre, string Studia, string Actor1, string Actor2, int StartYear, int Episodes, int EndYears, Mark StillPlaying) : base(Name, Genre, Studia, Actor1, Actor2)
        {
            this.StartYear = StartYear;
            this.Episodes = Episodes;
            this.EndYears = EndYears;
            this.StillPlaying = StillPlaying;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-8} {1, 12} {2, 17} {3, 15} {4, 15} {5,10} {6,10} {7,10} {8}",
                Name, Genre, Studia, Actor1, Actor2, StartYear, Episodes, EndYears, StillPlaying);
            return eilute;
        }
    }
}
