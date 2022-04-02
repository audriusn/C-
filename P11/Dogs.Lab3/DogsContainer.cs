using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs.Lab3
{
    class DogsContainer
    {
        private Dog[] dogs;
        public int Count { get; private set; }
        public DogsContainer(int capacity = 16)
        {
            this.dogs = new Dog[capacity];
        }
 
        public void Add(Dog dog)
        {
            if( this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.dogs[this.Count++] = dog;
        }
        private int Capacity;
        private void EnsureCapacity(int minimumCapacity)
        {
            if(minimumCapacity > this.Capacity)
            {
                Dog[] temp = new Dog[minimumCapacity];
                for(int i=0; i <this.Count; i++)
                {
                    temp[i] = this.dogs[i];
                }
                this.Capacity = minimumCapacity;
                this.dogs = temp;
            }
        }      
        public Dog Get(int index)
        {
            return this.dogs[index];
        }
        public bool Contains(Dog dog)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if(this.dogs[i].Equals(dog))
                {
                    return true;
                }
            }
            return false;
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        private Dog FindDogByID(int ID)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].ID == ID)
                {
                    return this.dogs[i];
                }
            }
            return null;
        }
        public Dog FindOldestDog(DogsContainer dogs)
        {
            return FinfOldestDog1(dogs);
        }
        private static Dog FinfOldestDog1(DogsContainer dogs)
        {
            if(dogs.Count <=0)
            {
                return null;
            }
            Dog oldest = dogs.Get(0);
            for (int i = 0; i < dogs.Count;i++)
            {
                if (DateTime.Compare(oldest.BirthDate, dogs.Get(i).BirthDate) > 0)
                {
                    oldest = dogs.Get(i);
                }
            }
            return oldest;
        }
     
        public DogsContainer FilterByBreed(string breed)
        {
            DogsContainer Filtered = new DogsContainer();
            for (int i = 1; i < this.Count; i++)
            {
                if (this.dogs[i].Breed.Equals(breed)) //uses string method Equals()
                {
                    Filtered.Add(this.dogs[i]);
                }
            }
            return Filtered;
        }
        public List<string> FindBreeds(DogsContainer Dogs)
        {
            List<string> Breeds = new List<string>();
            for (int i = 0; i < Dogs.Count; i++)
            {
                string breed = this.dogs[i].Breed;
                if (!Breeds.Contains(breed))
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vacc in Vaccinations)
            {
                Dog dog = this.FindDogByID(vacc.DogID);
                if (dog != null)                            
                {
                    if (vacc.Date > dog.LastVaccinationDate)
                    {
                        dog.LastVaccinationDate = vacc.Date;
                    }
                }
            }
        }
        public DogsContainer FilterByVaccinationExpired(DogsContainer Dogs)   
        {
            DogsContainer Filtered = new DogsContainer();
            for (int i = 0; i < Dogs.Count; i++)
            {
                if (this.dogs[i].RequiresVaccination)
                    Filtered.Add(this.dogs[i]);
            }
            return Filtered;
        }
        public void Put(int index, Dog dog)
        {
            this.dogs[index] = dog;
        }
        public void Insert(int index, Dog dog)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count + 1; i > index; i--)
            {
                this.dogs[i] = this.dogs[i - 1];
            }
            this.dogs[index] = dog;
            Count++;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.dogs[i] = this.dogs[i + 1];
            }
            Count--;
        }
        public void Remove(Dog dog)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.dogs[i].ID == dog.ID)
                {
                    RemoveAt(i);
                    return;
                }
            }
        }
         public void Sort()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                Dog dog = this.dogs[i];
                int im = i;
                for (int j = i + 1; j < this.Count; j++)
                    if (this.dogs[j] <= dog)
                    {
                        dog = this.dogs[j];
                        im = j;
                    }
                this.dogs[im] = this.dogs[i];
                this.dogs[i] = dog;
            }
        }
        public DogsContainer(DogsContainer container): this()
        {
            for (int i = 0;i < container.Count ;i++)
            {
                this.Add(container.Get(i));
            }
        }
        public DogsContainer Intersect(DogsContainer other)
        {
            DogsContainer result = new DogsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Dog current  =this.dogs[i];
                if(other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }

    }
        
 }

