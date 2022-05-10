using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    internal class RecordContainer
    {
        private Record [] records;
        public int Count { get; private set; }
        public RecordContainer(int capacity = 16)
        {
            this.records = new Record [capacity];
        }
        public string Hname { get; set; }
        public int birthYear { get; set; }
        public string city { get; set; }

        public void Add(Record record)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.records[this.Count++] = record;
        }
        private int Capacity;
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Record[] temp = new Record[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.records[i];
                }
                this.Capacity = minimumCapacity;
                this.records = temp;
            }
        }
        public Record Get(int index)
        {
            return this.records[index];
        }

        public bool Contains(Record record)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.records[i].Equals(record))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(int index, Record record)
        {
            this.records[index] = record;
        }
        public void Insert(int index, Record record)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count + 1; i > index; i--)
            {
                this.records[i] = this.records[i - 1];
            }
            this.records[index] = record;

            Count++;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.records[i] = this.records[i + 1];
            }
            Count--;
        }
        public void Remove(Record record)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.records[i].Name == record.Name)
                {
                    RemoveAt(i);
                    return;
                }
            }
        }
        public void Sort(RecordComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Record a = this.records[i];
                    Record b = this.records[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.records[i] = b;
                        this.records[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public void Sort()
        {
            Sort(new RecordComparator());
        }
        public RecordContainer(RecordContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public RecordContainer Intersect(RecordContainer other)
        {
            RecordContainer result = new RecordContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Record current = this.records[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
    }
}
