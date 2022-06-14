using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIteratorExercise
{
    public class ListyIterator <T> : IEnumerable<T>
    {
        public List<T> list { get; set; }
        public int currentIndex { get; set; }

        public ListyIterator(params T[] elements)
        {
            this.list = elements.ToList();
            currentIndex = 0;
        }


        public bool Move()
        {
            
            if(currentIndex < list.Count-1)
            {
                currentIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return currentIndex < list.Count - 1;
        }

        public void Print()
        {
            if(list.Count == 0)
            {
                throw new Exception("Invalid Operation!");
            }
            Console.WriteLine(list[currentIndex]);
        }

        public void PrintAll()
        {
            if (list.Count == 0)
            {
                throw new Exception("Invalid Operation!");
            }
            foreach (T item in this)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                yield return this.list[currentIndex];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return this.GetEnumerator();
        }
    }
}
