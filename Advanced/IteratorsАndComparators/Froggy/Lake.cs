using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        public int[] StoneNumbers { get; set; }

        public Lake(int[] stoneNumbers)
        {
            StoneNumbers = stoneNumbers;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < StoneNumbers.Length; i++)
            {
                if(i % 2 == 0)
                {
                    yield return StoneNumbers[i];
                }
                
            }

            for (int i = StoneNumbers.Length -1 ; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return StoneNumbers[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
