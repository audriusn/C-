using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
     class TaskClass
    {
        public static Branch GetBranch(Branch[] branches, ref int number, string nameSurname, int BirthYear, string City)
        {
            for(int i = 0; i< number; i++)
            {
                if (branches[i].nameSurname == nameSurname && branches[i].BirthYear == BirthYear && branches[i].City == City)
                {
                    return branches[i];
                }
            }
            branches[number++] = new Branch(nameSurname, BirthYear, City);
            return branches[number -1];
        }
    }
}
