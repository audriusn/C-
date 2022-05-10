using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball_Team
{
    public abstract class Member 
    {
           
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime BirthDate { get; set; }
           

            public Member( string Name, string Surname, DateTime BirthDate)
            {
                this.Name = Name;
                this.Surname = Surname;
                this.BirthDate = BirthDate;          
            }
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
             public override bool Equals(object other)
            {
                {
                    return this.Name == ((Member)other).Name;
                }
            }
            public override int GetHashCode()
            {
                return this.Name.GetHashCode();
            }
        public int CompareTo(Member other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                return this.Surname.CompareTo(other.Surname);
            }
            return result;
        }
    }
}
