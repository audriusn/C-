using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalTeam
{
     class Candidates
    {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime BirthDate { get; set; }
            public int Height { get; set; }
            public string Position { get; set; }
            public string TeamName { get; set; }
            public Mark Candidate { get; set; }
            public Mark Captain { get; set; }

            public Candidates(string Name, string Surname, DateTime BirthDate, int Height, string Position, string TeamName, Mark Candidate, Mark Captain)
            {
                this.Name = Name;
                this.Surname = Surname;
                this.BirthDate = BirthDate;
                this.Height = Height;
                this.Position = Position;
                this.TeamName = TeamName;
                this.Candidate = Candidate;
                this.Captain = Captain;

            }
        public int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - this.BirthDate.Year;
            if (this.BirthDate.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
