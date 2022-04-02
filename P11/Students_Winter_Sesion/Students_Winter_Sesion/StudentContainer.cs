using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Winter_Sesion
{
    class StudentContainer
    {
        private Student[] students;
        public int Count { get; private set; }
        public StudentContainer(int capacity = 25)
        {
            this.students = new Student[capacity];
        }
        public string Faculty { get; set; }
        public void Add(Student student)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.students[this.Count++] = student;
        }
        private int Capacity;
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Student[] temp = new Student[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.students[i];
                }
                this.Capacity = minimumCapacity;
                this.students = temp;
            }
        }
        public Student Get(int index)
        {
            return this.students[index];
        }
        public bool Contains(Student student)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.students[i].Equals(student))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(int index, Student student)
        {
            this.students[index] = student;
        }
        public void Insert(int index, Student student)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count + 1; i > index; i--)
            {
                this.students[i] = this.students[i - 1];
            }
            this.students[index] = student;
            Count++;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.students[i] = this.students[i + 1];
            }
            Count--;
        }
        public void Remove(Student student)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.students[i].Surname == student.Surname)
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
                Student student = this.students[i];
                int im = i;
                for (int j = i + 1; j < this.Count; j++)
                    if (this.students[j] <= student)
                    {
                        student = this.students[j];
                        im = j;
                    }
                this.students[im] = this.students[i];
                this.students[i] = student;
            }
        }
        public StudentContainer(StudentContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public StudentContainer Intersect(StudentContainer other)
        {
            StudentContainer result = new StudentContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Student current = this.students[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
  
        public double GrupėsVidurkis(StudentContainer students, string group)
        {
            double suma = 0;
            int kiek = 0;
            for (int i = 0; i < students.Count; i++)
            {
                if (this.students[i].GroupName == group)
                { 
                suma += this.students[i].GradesAvegare();
                kiek++;
                }
            }
            return suma / kiek;
        }
    }
}
