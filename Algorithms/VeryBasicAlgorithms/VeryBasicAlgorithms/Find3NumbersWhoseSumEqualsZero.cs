using System;
using System.Collections.Generic;
using System.Text;

namespace VeryBasicAlgorithms
{
    /// <summary>
    /// 3-Sum Problem
    /// Sorting based algorithm N^2logN
    /// 1) Sort the N (distinct) numbers
    /// 2) For each pair of numbers a[i] and a[j] binary search for - (a[i]+ a[j])
    /// </summary>
    class Find3NumbersWhoseSumEqualsZero
    {
        private static int[] Find3NumbersWithSumOfZero(int[] items)
        {
            Array.Sort(items);//-40 -20 -10 0 5 10 30 40

            for (int i = 0; i < items.Length; i++)
            {
                for (int j = 0; j < items.Length; j++)
                {
                    int possibleThirdNumber = -(items[i] + items[j]);
                    int foudIndex = Array.BinarySearch(items, possibleThirdNumber);
                    if (foudIndex > 0)
                    {
                        return new int[]{items[i],items[j], items[foudIndex] };
                    }
                }
            }
            

            return null;
        }

        public static void Main()
        {
            int[] items = new int[]{30,-40,-20,-10,40,0,10,5};
            int[] numbers = Find3NumbersWithSumOfZero(items);

            Console.WriteLine(numbers != null ? $"Found three numbers: {numbers[0]}+{numbers[1]}+{numbers[2]}=0" : "Ïncorrect");
        }
    }
}
