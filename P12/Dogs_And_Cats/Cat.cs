using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs_And_Cats
{
    public class Cat : Animal
    {
        private const int VaccinationDurationMoths = 6;
        public Cat (int id, string name, string breed, DateTime birtDate,Gender gender) : base(id, name,breed, birtDate, gender)
        {

        }
        public override bool RequiresVaccination
        {
            get
            {
                if (this.LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddMonths(VaccinationDurationMoths).CompareTo(DateTime.Now) < 0;
            }
        }
    }
}
