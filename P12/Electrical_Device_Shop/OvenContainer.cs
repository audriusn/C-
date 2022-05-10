using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electrical_Device_Shop
{
    internal class OvenContainer
    {
        private Oven[] ovens;
        public int Count { get; private set; }
        public OvenContainer(int capacity = 50)
        {
            this.ovens = new Oven[capacity];
        }

        public void Add(Oven oven)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.ovens[this.Count++] = oven;
        }
        private int Capacity;
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Oven[] temp = new Oven[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.ovens[i];
                }
                this.Capacity = minimumCapacity;
                this.ovens = temp;
            }
        }
        public Oven Get(int index)
        {
            return this.ovens[index];
        }

        public bool Contains(Oven oven)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.ovens[i].Equals(oven))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(int index, Oven oven)
        {
            this.ovens[index] = oven;
        }
        public void Insert(int index, Oven oven)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count + 1; i > index; i--)
            {
                this.ovens[i] = this.ovens[i - 1];
            }
            this.ovens[index] = oven;

            Count++;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.ovens[i] = this.ovens[i + 1];
            }
            Count--;
        }
        public void Remove(Oven oven)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.ovens[i].Model == oven.Model)
                {
                    RemoveAt(i);
                    return;
                }
            }
        }
        public void Sort(DeviceComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Oven a = this.ovens[i];
                    Oven b = this.ovens[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.ovens[i] = b;
                        this.ovens[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public void Sort()
        {
            Sort(new DeviceComparator());
        }
        public OvenContainer(OvenContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public OvenContainer Intersect(OvenContainer other)
        {
            OvenContainer result = new OvenContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Oven current = this.ovens[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public OvenContainer LowestPriceAPliusEnergyClassOven (OvenContainer oven)
        {
            OvenContainer filtered = new OvenContainer();

            for (int i = 0; i < this.Count; i++)
            {
                double minPrice =this.Get(0).Price;
                if (minPrice > this.Get(i).Price && this.Get(i).EnergyClass == "A+")
                {
                    filtered.Add(this.Get(i));
                }
            }
            return filtered;
        }
    }
}
