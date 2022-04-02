using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Winter_Sesion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            StudentContainer AllStudents = InOutClass.ReadStudents(@"Group.csv");
            InOutClass.PrintStudents( AllStudents);
            InOutClass.PrintStudentsGradeAverage(AllStudents);
            double vid1 = AllStudents.GrupėsVidurkis(AllStudents, "IF-1/8");
            Console.WriteLine("Grupės IF-1/8 vidurkis: {0}", vid1);
            double vid2 = AllStudents.GrupėsVidurkis(AllStudents, "IF-1/9");
            Console.WriteLine("Grupės IF-1/9 vidurkis: {0}", vid2);
            AllStudents.Sort();
            InOutClass.PrintStudentsGradeAverage(AllStudents);
           

        }
    }
}
