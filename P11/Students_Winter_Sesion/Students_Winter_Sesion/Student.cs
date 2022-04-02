using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Students_Winter_Sesion
{
   
        class Student
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string GroupName { get; set; }
            public int GradeCount { get; set; }
            public ArrayList Grades{ get; set; }

            public Student(string Surname, string Name, string GroupName, int GradeCount, ArrayList Grades)
            {
                this.Surname = Surname;
                this.Name = Name;
                this.GroupName = GroupName;
                this.GradeCount = GradeCount;
                this.Grades = Grades;
            }
        public override bool Equals(object other)
        {
            return this.Surname == ((Student)other).Surname;
        }
        public override int GetHashCode()
        {
            return this.Surname.GetHashCode();
        }
        public double GradesAvegare()
        {
            double sum = 0;
            foreach (int grade in Grades)
            {
                sum += grade;
            }
            return sum / GradeCount;

        }
        public static bool operator <=(Student pirmas, Student antras)
        {
            return pirmas.GradesAvegare() > antras.GradesAvegare() || pirmas.GradesAvegare() == antras.GradesAvegare() && pirmas.GroupName != antras.GroupName;
        }

        public static bool operator >=(Student pirmas, Student antras)
        {
            return pirmas.GradesAvegare() < antras.GradesAvegare() || pirmas.GradesAvegare() == antras.GradesAvegare() && pirmas.GroupName != antras.GroupName;
        }
    }
}
