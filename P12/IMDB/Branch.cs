using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IMDB
{
    class Branch
    {
        public RecordContainer allRecords;
        public string nameSurname { get; set; }
        public int BirthYear { get; set; }
        public string City { get; set; }

        public Branch (RecordContainer records, string nameSurname, int BirthYear, string City)
        {
            this.allRecords = records;
            this.nameSurname = nameSurname;
            this.BirthYear = BirthYear;
            this.City = City;
           
        }
        public Branch ()
        {
            allRecords = new RecordContainer ();
        }
        public void Add (Branch[] branches)
        {
            foreach (Branch branch in branches)
            {
                Add(branch);
            }
        }
        public void AddSerial (Serial serial)
        {
            Serials.Add(serial);
        }
        public RecordContainer GetAllRecords()
        {
            RecordContainer allRecords = new RecordContainer(Program.MaxNumberOfRecords);
            for(int i = 0; i < Films.Count; i++)
            {
                allRecords.Add(Films.Get(i));
            }
            for (int j=0; j < Serials.Count; j++)
            {
                allRecords.Add(Serials.Get(j));
            }
            return allRecords;
        }
    }
}
