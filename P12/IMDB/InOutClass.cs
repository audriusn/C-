using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace IMDB
{
    class InOutClass
    {
        public static  Branch[] ReadData (string[] INS)
        {
           Branch [] allBranch = Array.Empty<Branch> ();
           for(int i = 0; i < INS.Length; i++) 
            {
               Array.Resize(ref allBranch,allBranch.Length+1);
                allBranch[i] = InOutClass.ReadRecords(INS[i]);
            }
        }
        public static Branch ReadRecords(string IN)
        {
            RecordContainer record = new RecordContainer();
            string[] lines = File.ReadAllLines(IN, Encoding.UTF8);
            if (lines.Length <= 3)
            {
                return new Branch();
            }
            foreach (string line in lines.Skip(3))
            {
                string[] values = line.Split(',');
                if (values.Length != 8)
                    continue;
                    string type = values[0];
                    string Name = values[1];
                    string Genre = values[2];
                    string Studia = values[3];
                    string Actor1 = values[4];
                    string Actor2 = values[5];
                switch (values[0])
                {
                    case "Film":
                        int Year = int.Parse(values[6]);
                        string Director = values[7];
                        int Profit = int.Parse(values[8]);
                        record.Add( new Film(Name, Genre, Studia, Actor1, Actor2, Year, Director, Profit));                      
                        break;
                    case "Serial":
                        int StartYear = int.Parse(values[6]);
                        int Episodes = int.Parse(values[7]);
                        int EndYears = int.Parse(values[8]);
                        Mark StillPlaying;
                        Enum.TryParse(values[9], out StillPlaying);
                        record.Add(new Serial(Name, Genre, Studia, Actor1, Actor2, StartYear, Episodes, EndYears, StillPlaying));                      
                        break;
                        default:
                        break;
                }
            }
        }

        public static void PrintRecords(RecordContainer record, string header)
        {
            Console.Write("\n" + header);
            Console.WriteLine(new string('-', 150));
            if (record.Count == 0)
                Console.WriteLine("There are no records");
            else
            {
                for (int i = 0; i < record.Count; i++)
                {
                    Console.WriteLine(record.Get(i).ToString());
                }
            }
            Console.WriteLine(new string('-', 150));
        }
        public static void PrintRecordFromBranches( RecordContainer[] recordsFromBranch, string header)
        {
            for (int i = 0;i < recordsFromBranch.Length;i++)
            {
                PrintRecords(recordsFromBranch[i], i + 1 + "first persol list:");
            }
        }
    }
}
