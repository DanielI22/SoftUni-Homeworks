using System;
using System.Collections.Generic;
using System.Text;

namespace TupleExample
{
    public class MyTuple<T,V>
    {
        public T Item1 { get; set; }
        public V Item2 { get; set; }

        public MyTuple(T item1, V item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public override string ToString()
        {
            return Item1 + " -> " + Item2;
        }
    }
}
