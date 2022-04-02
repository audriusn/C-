using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace Students_Winter_Sesion
{
    static class InOutClass
    {
        public static StudentContainer ReadStudents(string filename)
        {
            StudentContainer Students = new StudentContainer();
            using (StreamReader reader = new StreamReader(filename))
            { 
            string[] Lines = File.ReadAllLines(filename, Encoding.UTF8);
                string line;
                line = reader.ReadLine();
                string Faculty = line;
                Students.Faculty = Faculty;
                while(null != (line = reader.ReadLine()))
            {
                ArrayList Grades = new ArrayList();
                string[] Values = line.Split(';');
                string Surname = Values[0];
                string Name = Values[1];
                string GroupName = Values[2];
                int GradeCount = int.Parse(Values[3]);
                string[] lines2 = Values[4].Trim().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                    foreach (string eil in lines2)
                    {
                        int grade = int.Parse(eil);
                        Grades.Add(grade);
                    }
                   Student student = new Student(Surname, Name, GroupName, GradeCount, Grades);
                if (!Students.Contains(student))
                {
                     Students.Add(student);
                }
             } 
          }
            return Students;
        }
        public static void PrintStudents(StudentContainer students)
        {
            if (students.Count != 0)
            { 
                Console.WriteLine(new string('-', 70));
            Console.WriteLine("| {0,-66} |", students.Faculty);
            Console.WriteLine(new string('-', 70));
            Console.WriteLine("| {0,-12} | {1,-10} | {2,-8} | {3,10} | {4,-14}|", "Surname", "Name", "Group", "Grade Count", "Grades");
            Console.WriteLine(new string('-', 70));
                for (int i = 0; i < students.Count; i++)
                {
                    Student student = students.Get(i);
                    Console.Write("| {0,-12} | {1,-10} | {2,-8} | {3,10}  |", student.Surname, student.Name, student.GroupName, student.GradeCount);
                    foreach (int grade in student.Grades)
                    {
                        Console.Write("{0,3:d}", grade);
                    }
                    Console.WriteLine("|");              
            }
            Console.WriteLine(new string('-', 70));
            }
            else
                Console.WriteLine("Sorry, there are no data in file!!!");
        }
        public static void PrintStudentsGradeAverage(StudentContainer students)
        {
            Console.WriteLine(new string('-', 87));
            Console.WriteLine("| {0,-84} |", students.Faculty);
            Console.WriteLine(new string('-', 87));
            Console.WriteLine("| {0,-12} | {1,-10} | {2,-8} | {3,10} | {4,-14}| {5,-15} |", "Surname", "Name", "Group", "Grade Count", "Grades", "Grades Average");
            Console.WriteLine(new string('-', 87));
            for (int i = 0; i < students.Count; i++)
            {
                Student student = students.Get(i);
                Console.Write("| {0,-12} | {1,-10} | {2,-8} | {3,10}  |", student.Surname, student.Name, student.GroupName, student.GradeCount);
                foreach (int grade in student.Grades)
                {
                    Console.Write("{0,3:d}", grade);
                }
                Console.WriteLine("|{0,17:f2}|",student.GradesAvegare());
                
            }
            Console.WriteLine(new string('-', 87));
        }
       
        }
    }

