using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs_And_Cats
{
     class AnimalsContainer
    {
        private Animal[] animals;
        public int Count { get; private set; }
        public AnimalsContainer(int capacity = 16)
        {
            this.animals = new Animal[capacity];
        }

        public void Add(Animal dog)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.animals[this.Count++] = dog;
        }
        private int Capacity;
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Animal[] temp = new Animal[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.animals[i];
                }
                this.Capacity = minimumCapacity;
                this.animals = temp;
            }
        }
        public Animal Get(int index)
        {
            return this.animals[index];
        }
        public bool Contains(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i].Equals(animal))
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
                if (this.animals[i].Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        private Animal FindAnimalByID(int ID)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i].ID == ID)
                {
                    return this.animals[i];
                }
            }
            return null;
        }
        public Animal FindOldestAnimal(AnimalsContainer animals)
        {
            return FinfOldestAnimal1(animals);
        }
        private static Animal FinfOldestAnimal1(AnimalsContainer animals)
        {
            if (animals.Count <= 0)
            {
                return null;
            }
            Animal oldest = animals.Get(0);
            for (int i = 0; i < animals.Count; i++)
            {
                if (DateTime.Compare(oldest.BirthDate, animals.Get(i).BirthDate) > 0)
                {
                    oldest = animals.Get(i);
                }
            }
            return oldest;
        }

        public AnimalsContainer FilterByBreed(string breed)
        {
            AnimalsContainer Filtered = new AnimalsContainer();
            for (int i = 1; i < this.Count; i++)
            {
                if (this.animals[i].Breed.Equals(breed)) //uses string method Equals()
                {
                    Filtered.Add(this.animals[i]);
                }
            }
            return Filtered;
        }
        public List<string> FindBreeds(AnimalsContainer Dogs)
        {
            List<string> Breeds = new List<string>();
            for (int i = 0; i < Dogs.Count; i++)
            {
                string breed = this.animals[i].Breed;
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
                Animal animals = this.FindAnimalByID(vacc.AnimalID);
                if (animals != null)
                {
                    if (vacc.Date > animals.LastVaccinationDate)
                    {
                        animals.LastVaccinationDate = vacc.Date;
                    }
                }
            }
        }
        public AnimalsContainer FilterByVaccinationExpired(AnimalsContainer animals)
        {
            AnimalsContainer Filtered = new AnimalsContainer();
            for (int i = 0; i < animals.Count; i++)
            {
                if (this.animals[i].RequiresVaccination)
                    Filtered.Add(this.animals[i]);
            }
            return Filtered;
        }
        public void Put(int index, Animal animal)
        {
            this.animals[index] = animal;
        }
        public void Insert(int index, Animal animal)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count + 1; i > index; i--)
            {
                this.animals[i] = this.animals[i - 1];
            }
            this.animals[index] = animal;
            Count++;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.animals[i] = this.animals[i + 1];
            }
            Count--;
        }
        public void Remove(Animal animal)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.animals[i].ID == animal.ID)
                {
                    RemoveAt(i);
                    return;
                }
            }
        }
        public void Sort(AnimalsComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Animal a = this.animals[i];
                    Animal b = this.animals[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.animals[i] = b;
                        this.animals[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public void Sort()
        {
            Sort(new AnimalsComparator());
        }
        public AnimalsContainer(AnimalsContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public AnimalsContainer Intersect(AnimalsContainer other)
        {
            AnimalsContainer result = new AnimalsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Animal current = this.animals[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public int CountAggresiveDogs()
        {
            int count = 0;
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = this.Get(i);
                if (animal is Dog && (animal as Dog).Aggresive)
                {
                    count++;
                }
            }
            return count;
        }
      
    }
}
