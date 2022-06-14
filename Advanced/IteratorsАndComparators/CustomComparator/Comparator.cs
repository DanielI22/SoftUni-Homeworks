using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CustomComparator
{
    public class Comparator : IComparer<int>
    {
        public int Compare([AllowNull] int x, [AllowNull] int y)
        {
            if(x%2 == 0 && y%2 != 0)
            {
                return -1;
            }
            else if(x%2 != 0 && y%2 == 0)
            {
                return 1;
            }
            else
            {
                return x.CompareTo(y);
            }
        }
    }
}
