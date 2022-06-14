using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyStack
{
    public class Stack<T> : IEnumerable<T>
    {
        public T[] Elements { get; set; }
        public int Count { get; set; }
        public Stack()
        {
            Elements = new T[100];
            Count = 0;
        }

        public void Push(params T[] elements)
        {
            foreach (var item in elements)
            { 
                Elements[Count] = item;
                Count++;
            }
        }

        public T Pop()
        {
            
            T lastEl = Elements[Count - 1];
            Elements[Count - 1] = default;
            Count--;
            return lastEl;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = Count-1; i >= 0; i--)
            {
                yield return Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
