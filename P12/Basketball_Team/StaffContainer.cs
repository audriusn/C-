using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball_Team
{
    internal class StaffContainer
    {
        private Staff[] staffs;
        public int Count { get; private set; }
        public StaffContainer(int capacity = 16)
        {
            this.staffs = new Staff[capacity];
        }
        public int bYear { get; set; }
        public DateTime CampStart { get; set; }
        public DateTime CampEnd { get; set; }

        public void Add(Staff staff)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.staffs[this.Count++] = staff;
        }
        private int Capacity;
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Staff[] temp = new Staff[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.staffs[i];
                }
                this.Capacity = minimumCapacity;
                this.staffs = temp;
            }
        }
        public Staff Get(int index)
        {
            return this.staffs[index];
        }
        public bool Contains(Staff staff)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.staffs[i].Equals(staff))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(int index, Staff staff)
        {
            this.staffs[index] = staff;
        }
        public void Insert(int index, Staff staff)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count + 1; i > index; i--)
            {
                this.staffs[i] = this.staffs[i - 1];
            }
            this.staffs[index] = staff;

            Count++;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.staffs[i] = this.staffs[i + 1];
            }
            Count--;
        }
        public void Remove(Staff staff)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.staffs[i].Name == staff.Name)
                {
                    RemoveAt(i);
                    return;
                }
            }
        }
        public void Sort(MembersComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Staff a = this.staffs[i];
                    Staff b = this.staffs[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.staffs[i] = b;
                        this.staffs[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public void Sort()
        {
            Sort(new MembersComparator());
        }
        public StaffContainer (StaffContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public StaffContainer Intersect(StaffContainer other)
        {
            StaffContainer result = new StaffContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Staff current = this.staffs[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public StaffContainer FindCoach()
        {
            StaffContainer coach = new StaffContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (!coach.Contains(this.Get(i)) && this.Get(i).jobTitle == "Treneris")
                {
                    coach.Add(this.Get(i));
                }
            }
            return coach;
        }
       
    }
}
