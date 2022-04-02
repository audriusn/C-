using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery_Shop
{
     class JewelContainer
    {
        private Jewel[] jewels;
        public int Count { get; private set; }
        public JewelContainer(int capacity = 20)
        {
            this.jewels = new Jewel [capacity];
        }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PhoneNR { get; set; }
        public void Add(Jewel jewel)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.jewels[this.Count++] = jewel;
        }
        private int Capacity;
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Jewel[] temp = new Jewel[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.jewels[i];
                }
                this.Capacity = minimumCapacity;
                this.jewels = temp;
            }
        }
        public Jewel Get(int index)
        {
            return this.jewels[index];
        }
        public bool Contains(Jewel jewel)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.jewels[i].Equals(jewel))
                {
                    return true;
                }
            }
            return false;
        }
        public void Put(int index, Jewel jewel)
        {
            this.jewels[index] = jewel;
        }
        public void Insert(int index, Jewel jewel)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count + 1; i > index; i--)
            {
                this.jewels[i] = this.jewels[i - 1];
            }
            this.jewels[index] = jewel;
            Count++;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.jewels[i] = this.jewels[i + 1];
            }
            Count--;
        }
        public void Remove(Jewel jewel)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.jewels[i].Name == jewel.Name)
                {
                    RemoveAt(i);
                    return;
                }
            }
        }
        public void Sort()
        {
            bool flag = true;
            while(flag)
            {
                flag = false;
                for(int i = 0; i <this.Count-1;i++)
                {
                    Jewel a = this.jewels[i];
                    Jewel b = this.jewels[i + 1];
                    if(a.CompareManufacture(b) > 0 || (a.CompareManufacture(b) == 0 && a.ComparePrice(b) < 0))
                    {
                        this.jewels[i] = b;
                        this.jewels[i + 1] = a;
                        flag = true;
                    }
                }
            }        
        }
        public JewelContainer(JewelContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public JewelContainer Intersect(JewelContainer other)
        {
            JewelContainer result = new JewelContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Jewel current = this.jewels[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public int FindMaxPrice()
        {
            int maxPrice = int.MinValue;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Price > maxPrice)
                    maxPrice = this.Get(i).Price;
            }
            return maxPrice;
        }
    }
}
