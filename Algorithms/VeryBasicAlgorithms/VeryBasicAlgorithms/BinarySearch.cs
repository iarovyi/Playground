using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VeryBasicAlgorithms
{
    class BinarySearch
    {
        public static int FindIndex(int[] items, int value)
        {
            int low = 0;
            int high = items.Length - 1;
            
            while (low < high)
            {
                int middle = ((high - low) / 2) + low;
                int itemInTheMiddle = items[middle];

                if (itemInTheMiddle > value)      { high = middle; }
                else if (itemInTheMiddle < value) { low = middle; }
                else                              { return middle;}
            }

            return -1;
        }

        public static void Main()
        {
            var items = Enumerable.Range(1, 20).ToArray();
            int index = FindIndex(items, 5);

            Console.WriteLine(index == 4 ? "Found index with binary search" : "Incorrect");
        }
    }
}
