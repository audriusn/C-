using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball_Team
{
    internal class MemberContainer
    {
        private Member[] members;
        public int Count { get; private set; }
        public MemberContainer(int capacity = 16)
        {
            this.members = new Member[capacity];
        }
        public int bYear { get; set; }
        public DateTime CampStart { get; set; }
        public DateTime CampEnd { get; set; }

        public void Add(Member member)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.members[this.Count++] = member;
        }
        private int Capacity;
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Member[] temp = new Member[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.members[i];
                }
                this.Capacity = minimumCapacity;
                this.members = temp;
            }
        }
        public Member Get(int index)
        {
            return this.members[index];
        }
       
        public bool Contains(Member member)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.members[i].Equals(member))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(int index, Member member)
        {
            this.members[index] = member;
        }
        public void Insert(int index, Member member)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count + 1; i > index; i--)
            {
                this.members[i] = this.members[i - 1];
            }
            this.members[index] = member;

            Count++;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.members[i] = this.members[i + 1];
            }
            Count--;
        }
        public void Remove(Member member)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.members[i].Name == member.Name)
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
                    Member a = this.members[i];
                    Member b = this.members[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.members[i] = b;
                        this.members[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public void Sort()
        {
            Sort(new MembersComparator());
        }
        public MemberContainer(MemberContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public MemberContainer Intersect(MemberContainer other)
        {
            MemberContainer result = new MemberContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Member current = this.members[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public static MemberContainer AllYearMember(MemberContainer cont1, MemberContainer cont2, MemberContainer cont3)
        {
            MemberContainer AllYearMember = new MemberContainer();

            for (int i = 0; i < cont1.Count; i++)
            {
                for (int j = 0; j < cont2.Count; j++)
                {
                    for (int k = 0; k < cont3.Count; k++)
                    {
                        if (cont1.Get(i).Name == cont2.Get(j).Name && cont2.Get(j).Name == cont3.Get(k).Name && cont1.Get(i).Surname == cont2.Get(j).Surname && cont2.Get(j).Surname == cont3.Get(k).Surname 
                            && cont1.Get(i).BirthDate == cont2.Get(j).BirthDate && cont2.Get(j).BirthDate == cont3.Get(k).BirthDate)
                        {
                            AllYearMember.Add(cont1.Get(i));
                        }
                    }
                }
            }
            return AllYearMember;
        }
       
    }
}
