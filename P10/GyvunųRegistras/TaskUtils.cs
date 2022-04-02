using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyvunųRegistras
{
    static class TaskUtils
    {
      
        public static Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0]; //mean least value
            for (int i = 1; i < Dogs.Count; i++)
            {
                if (DateTime.Compare(Dogs[i].BirthDate, oldest.BirthDate) < 0)
                {
                    oldest = Dogs[i];
                }
            }
            return oldest;
        }
        public static List<string> FindBreeds(List<Dog> Dogs)
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in Dogs)
            {
                string breed = dog.Breed;
                if (Breeds.Contains(breed)) //uses List Method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }
       
    }
}
