using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportas
{
    public abstract class Player
    {
        public string TeamName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int GamePlay { get; set; }
        public int Score { get; set; }
        public int Age
        {
            get
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

        public Player(string TeamName, string Name, string Surname, DateTime birthDate, int GamePlay, int Score)
        {
            this.TeamName = TeamName;
            this.Name = Name;
            this.Surname = Surname;
            this.BirthDate = birthDate;
            this.GamePlay = GamePlay;
            this.Score = Score;
        }
        public override bool Equals(object other)
        {
            {
                return this.TeamName == ((Player)other).TeamName;
            }
        }
        public override int GetHashCode()
        {
            return this.TeamName.GetHashCode();
        }
        //public int CompareTo(Player other)
        //{
        //    int result = this.Name.CompareTo(other.Name);
        //    if (result == 0)
        //    {
        //        return this.Surname.CompareTo(other.Surname);
        //    }
        //    return result;
        //}
    }
}
