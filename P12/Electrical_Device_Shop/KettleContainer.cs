using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electrical_Device_Shop
{
    internal class KettleContainer
    {
        private Kettle[] kettles;
        public int Count { get; private set; }
        public KettleContainer(int capacity = 50)
        {
            this.kettles = new Kettle[capacity];
        }

        public void Add(Kettle kettle)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.kettles[this.Count++] = kettle;
        }
        private int Capacity;
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Kettle[] temp = new Kettle[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.kettles[i];
                }
                this.Capacity = minimumCapacity;
                this.kettles = temp;
            }
        }
        public Kettle Get(int index)
        {
            return this.kettles[index];
        }

        public bool Contains(Kettle kettle)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.kettles[i].Equals(kettle))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(int index, Kettle kettle)
        {
            this.kettles[index] = kettle;
        }
        public void Insert(int index, Kettle kettle)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count + 1; i > index; i--)
            {
                this.kettles[i] = this.kettles[i - 1];
            }
            this.kettles[index] = kettle;

            Count++;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.kettles[i] = this.kettles[i + 1];
            }
            Count--;
        }
        public void Remove(Kettle kettle)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.kettles[i].Model == kettle.Model)
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
                    Kettle a = this.kettles[i];
                    Kettle b = this.kettles[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.kettles[i] = b;
                        this.kettles[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public void Sort()
        {
            Sort(new DeviceComparator());
        }
        public KettleContainer(KettleContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public KettleContainer Intersect(KettleContainer other)
        {
            KettleContainer result = new KettleContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Kettle current = this.kettles[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public List<string> KettleColor(KettleContainer kettle)
        {
            List<string> Color = new List<string>();
            for (int i = 0; i < this.Count; i++)
            {
                string color = kettle.Get(i).Color;
                if (!Color.Contains(color))
                {
                    Color.Add(color);
                }
            }
            return Color;
        }
        public KettleContainer LowestPriceAPliusEnergyClassKettle(KettleContainer kettle)
        {
            KettleContainer filtered = new KettleContainer();

            for (int i = 0; i < this.Count; i++)
            {
                double minPrice = this.Get(0).Price;
                if (minPrice >= this.Get(i).Price && this.Get(i).EnergyClass.Equals("A+"))
                {
                    filtered.Add(this.Get(i));
                }
            }
            return filtered;
        }
    }
}
