namespace IB.Arrays.Bucketing
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class WaveArray
    {
        public static void Test()
        {
            Wave(new List<int>() {1, 2, 3, 4}).Should().BeEquivalentTo(new List<int>() { 2, 1, 4, 3 });
        }

        /*
         *  1 2 3 4
         *  2 1 3 4
         *  2 1 4 3
         */

        public static List<int> Wave(List<int> A)
        {
            A.Sort();

            for (int i = 1; i < A.Count; i++)
            {
                bool isWaveTop = i % 2 == 0;
                int current = A[i];
                int previous = A[i - 1];

                if ((isWaveTop && current < previous) ||
                    (!isWaveTop && current > previous))
                {
                    Swap(A, i, i - 1);
                }
            }

            return A;
        }

        private static void Swap(List<int> A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }
    }

    /*
     * Given an array of integers, sort the array into a wave like array and return it,
In other words, arrange the elements into a sequence such that a1 >= a2 <= a3 >= a4 <= a5.....

Example

Given [1, 2, 3, 4]

One possible answer : [2, 1, 4, 3]
Another possible answer : [4, 1, 3, 2]
 NOTE : If there are multiple answers possible, return the one thats lexicographically smallest.
So, in example case, you will return [2, 1, 4, 3] 
     */
}
