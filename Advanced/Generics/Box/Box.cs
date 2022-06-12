using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace BoxString
{
    public class Box <T> : IComparable<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public List<T> Elements { get; set; } = new List<T>();

        public Box()
        {
        }

        public Box(T data)
        {
            this.Data = data;
        }

        public override string ToString()
        {
            return Data.GetType().ToString() + ": " + Data.ToString();
        }

         public void Swap<T>(List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

         public int Count<T>(List<T> list, T element) where T : IComparable
        {
            int count = 0;
            count = list.Where(el => el.CompareTo(element) > 0).Count();
            return count;
        }



        public int CompareTo(T other) => Data.CompareTo(other);
    }
}
