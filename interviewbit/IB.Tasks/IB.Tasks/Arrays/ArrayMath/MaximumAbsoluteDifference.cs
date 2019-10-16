namespace IB.Arrays.ArrayMath
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class MaximumAbsoluteDifference
    {
        public static void Test()
        {
            GetMaxSumOfPositionAndValueDifference(new List<int>() { 1, 3, -1 }).Should().Be(5);
        }

        /*
         * A=[1, 3, -1]

f(1, 1) = f(2, 2) = f(3, 3) = 0
f(1, 2) = f(2, 1) = |1 - 3| + |1 - 2| = 3
f(1, 3) = f(3, 1) = |1 - (-1)| + |1 - 3| = 4
f(2, 3) = f(3, 2) = |3 - (-1)| + |2 - 3| = 5

So, we return 5.
         */
        private static int f(List<int> A, int i, int j)
        {
            return Math.Abs(j - i) + Math.Abs(A[j] - A[i]);
        }

        /*
         * A[i]+i - (A[j]+j)
           A[i]-i - (A[j]-j)
         */
        public static int GetMaxSumOfPositionAndValueDifference(List<int> A)
        {
            int maxAddition = 0;     //A[i]+i
            int minAddition = 0;     //A[i]+i
            int maxSubsctuction = 0; //A[i]-i
            int minSubsctuction = 0; //A[i]-i
            for (int i = 0; i < A.Count; i++)
            {
                int addition = A[i] + i;
                int substcution = A[i] - i;

                maxAddition = Math.Max(maxAddition, addition);
                minAddition = Math.Min(minAddition, addition);

                maxSubsctuction = Math.Max(maxSubsctuction, substcution);
                minSubsctuction = Math.Min(minSubsctuction, substcution);
            }

            return Math.Max(maxAddition - minAddition, maxSubsctuction - minSubsctuction);
            /*int maxDif = 0;
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < A.Count; j++)
                {
                    int iAndJDiff = f(A, i, j);
                    if (iAndJDiff > maxDif)
                    {
                        maxDif = iAndJDiff;
                    }
                }
            }
            return maxDif;*/
        }
    }



    /*
     *You are given an array of N integers, A1, A2 ,…, AN. Return maximum value of f(i, j) for all 1 ≤ i, j ≤ N.
f(i, j) is defined as |A[i] - A[j]| + |i - j|, where |x| denotes absolute value of x.

For example,

A=[1, 3, -1]

f(1, 1) = f(2, 2) = f(3, 3) = 0
f(1, 2) = f(2, 1) = |1 - 3| + |1 - 2| = 3
f(1, 3) = f(3, 1) = |1 - (-1)| + |1 - 3| = 4
f(2, 3) = f(3, 2) = |3 - (-1)| + |2 - 3| = 5

So, we return 5.




    Hint:

    f(i, j) = |A[i] - A[j]| + |i - j| can be written in 4 ways (Since we are looking at max value, we don’t even care if the value becomes negative as long as we are also covering the max value in some way).

(A[i] + i) - (A[j] + j)
-(A[i] - i) + (A[j] - j) 
(A[i] - i) - (A[j] - j) 
(-A[i] - i) + (A[j] + j) = -(A[i] + i) + (A[j] + j)
Note that case 1 and 4 are equivalent and so are case 2 and 3.

We can construct two arrays with values: A[i] + i and A[i] - i. Then, for above 2 cases, we find the maximum value possible. For that, we just have to store minimum and maximum values of expressions A[i] + i and A[i] - i for all i.
     *
     */

    class Solution
    {
        public int maxArr(List<int> A)
        {

            int ans = 0;
            int n = A.Count;

            int max1 = Int32.MinValue;
            int max2 = Int32.MinValue;

            int min1 = Int32.MaxValue;
            int min2 = Int32.MaxValue;

            for (int i = 0; i < n; i++)
            {
                max1 = Math.Max(max1, A[i] + i);
                max2 = Math.Max(max2, A[i] - i);
                min1 = Math.Min(min1, A[i] + i);
                min2 = Math.Min(min2, A[i] - i);
            }
            ans = Math.Max(ans, max2 - min2);
            ans = Math.Max(ans, max1 - min1);
            return ans;
        }
    }
}
