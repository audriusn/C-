﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyvunųRegistras
{
     class DogsRegister
     {
        private List<Dog> AllDogs;
        public DogsRegister()
        {
            AllDogs = new List<Dog>();
        }
        public DogsRegister (List<Dog> Dogs)
        {
            AllDogs = new List<Dog>();
            foreach (Dog dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }
        public void Add (Dog dog)
        {
            AllDogs.Add(dog);
        }
        /// <summary>
        /// Suskaičiuoja šunų kiekį
        /// </summary>
        /// <returns></returns>
        public int DogsCount()
        {
            return this.AllDogs.Count;
        }

        /// <summary>
        /// SUskaičiuoja šunis pagal veislę
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach(Dog dog in this.AllDogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Paima masyvo elementą pagal indeksą
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Dog GetDog(int index)       // pirma savarankiška užduotis
        {
            return this.AllDogs[index];
        }
        /// <summary>
        /// Surenka šunų veisles į vieną sąrašą
        /// </summary>
        /// <param name="breed"></param>
        /// <returns></returns>
        public List<Dog> FilterByBreed(string breed)
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Breed.Equals(breed)) //uses string method Equals()
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }
       /// <summary>
       /// Grąžina seniausią šunį
       /// </summary>
       /// <returns></returns>
        public Dog FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="breed"></param>
        /// <returns></returns>
        public Dog FindOldestDog(string breed)
        {
            List<Dog> Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }
      /// <summary>
      /// Randa seniausią šunį
      /// </summary>
      /// <param name="Dogs"></param>
      /// <returns></returns>
        private Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0];
            for (int i = 1; i < Dogs.Count; i++)
            {
               if(DateTime.Compare(oldest.BirthDate, Dogs[i].BirthDate) > 0 )
                {
                    oldest = Dogs[i];
                }
            }
            return oldest;
        }
        /// <summary>
        /// padaro veislių list'ą
        /// </summary>
        /// <returns></returns>
        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in this.AllDogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed))
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }
        /// <summary>
        /// ieško šuns ID pagal ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private Dog FindDogByID(int ID)
        {
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.ID == ID)
                {
                    return dog;
                }
            }
            return null;
        }
        /// <summary>
        /// Papildo Dog tipo objektus paskutinio skiepijimo data
        /// </summary>
        /// <param name="Vaccinations"></param>
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vacc in Vaccinations)
            {
                Dog dog = this.FindDogByID(vacc.DogID);
                if (dog != null)                            // 3 savarankiška užduotis
                { 
                    if (vacc.Date > dog.LastVaccinationDate)
                    {
                        dog.LastVaccinationDate = vacc.Date;
                    }
                 }
            }
        }
        /// <summary>
        /// Padaro neskiepytų šunų sąrašą
        /// </summary>
        /// <returns></returns>
        public List<Dog> FilterByVaccinationExpired()   // 2 savarankiška užduotis
        {
            List <Dog> Filtered = new List<Dog>();
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.RequiresVaccination)           
                    Filtered.Add(dog); 
            }
            return Filtered;
        }
            public bool Contains(Dog dog)
             {
                 return AllDogs.Contains(dog);
             }
    }
}
