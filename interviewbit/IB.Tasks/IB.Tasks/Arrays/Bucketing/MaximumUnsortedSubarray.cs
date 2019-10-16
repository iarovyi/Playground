using System.Linq;

namespace IB.Arrays.Bucketing
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    public static class MaximumUnsortedSubarray
    {
        public static void Test()
        {
            GetMaxUnsortedSubArray(new List<int>() { 1, 2, 3, 5, 6, 13, 15/**/, 16, 17, 13, 13, 15/**/, 17, 17, 17, 17, 17, 19, 19 })
                .Should().BeEquivalentTo(new List<int>() { 6,11 });
            GetMaxUnsortedSubArray(new List<int>() { 4, 15, 4, 4, 15, 18, 20 }).Should().BeEquivalentTo(new List<int>() { 1, 3 });
            GetMaxUnsortedSubArray(new List<int>() { 1, 3, 2, 4, 5 }).Should().BeEquivalentTo(new List<int>() {1, 2});
            GetMaxUnsortedSubArray(new List<int>() { 1, 2, 3, 4, 5 }).Should().BeEquivalentTo(new List<int>() { -1 });
        }


        /*
         *
         *  1 2 3 5 6 7 8 9 4 10 11 12
         *  1 2 3 10 4 5 6 7 8 9 11 12
         *  1 2 3 4 5 10X 6 7 8  2X 9 11 12
         *
         *    Assume that Al, …, Ar is the minimum-unsorted-subarray which is to be sorted.
then min(Al, …, Ar) >= max(A0, …, Al-1)
and max(Al, …, Ar) <= min(Ar+1, …, AN-1)

            1 | 3 2 | 4 5

            1 3 2 4 5
            1 3 3 4 5  Max from left
            1 2 2 4 5  Min from right
         */
        public static List<int> GetMaxUnsortedSubArray(List<int> A)
        {
            var sorted = A.ToList();
            sorted.Sort();

            bool alreadySorted = true;
            for (int i = 1, prev = A[0]; i < A.Count; prev = A[i], i++)
            {
                if (prev > A[i])
                {
                    alreadySorted = false;
                }
            }

            if (alreadySorted)
            {
                return new List<int>(){ -1 };
            }

            int startI = -1;
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] != sorted[i])
                {
                    startI = i;
                    break;
                }
            }

            int endI = -1;
            for (int i = A.Count - 1; i>= 0; i--)
            {
                if (A[i] != sorted[i])
                {
                    endI = i;
                    break;
                }
            }


            return new List<int>(){startI, endI};
            /*if (A.Count == 1)
            {
                return new List<int>() { -1 }; //Already sorted
            }

            int startI = -1;
            for (int i = 0; i < A.Count - 1; i++)
            {
                int next = A[i + 1];
                if (next < A[i])
                {
                    int j = i;
                    for (; j > 0 && A[j - 1] == A[j]; j--)
                    {

                    }

                    startI = j == A.Count - 1 ? i : j;
                    break;
                }
            }

            int endI = -1;
            for (int i = A.Count - 1; i > 0; i--)
            {
                int next = A[i - 1];
                if (next > A[i])
                {
                    int j = i;
                    for (; j < A.Count - 2 && A[j + 1] == A[j]; j++)
                    {

                    }

                    endI = j == 0 ? i : j;
                    break;
                }
            }

            if (startI != -1)
            {
                while (endI < A.Count - 1 && A[endI] < A[startI] && A[endI + 1] < A[startI])
                {
                    endI++;
                }

                while (startI > 1 && A[startI] > A[endI] )
                {
                    startI--;
                }

                return new List<int>(){ startI, endI };
            }


            return new List<int>(){ - 1 }; //Already sorted*/
        }

        class SolutionEditorial
        {
            public List<int> subUnsort(List<int> a)
            {

                //1. Edge case checks
                if (a == null || a.Count < 2) return new List<int> { -1 };

                //2. Find the minimum index till where elements are sorted.
                int minI = 0;
                for (; minI < a.Count - 1; minI++) if (a[minI] > a[minI + 1]) break;

                //If all elements are sorted, return -1
                if (minI == a.Count - 1) return new List<int> { -1 };

                //3. Find the maximum index after which all elements are sorted.
                int maxI = a.Count - 1;
                for (; maxI > 0; maxI--) if (a[maxI] < a[maxI - 1]) break;

                //4. Now shift the min to left and max to right, until the left num
                //is greater than the smallest element in the unsorted part and
                //right num is smaller than the greatest element in the unsorted part.
                int min = int.MaxValue, max = int.MinValue;

                //4a. Find the min and max in the unsorted part.
                for (int i = minI; i <= maxI; i++)
                {
                    min = Math.Min(min, a[i]);
                    max = Math.Max(max, a[i]);
                }

                //4b. Moving the min to left.
                int gMin = 0;
                for (; gMin <= minI; gMin++) if (a[gMin] > min) break;

                //4c. Moving the max to right.
                int gMax = a.Count - 1;
                for (; gMax >= maxI; gMax--) if (a[gMax] < max) break;

                //5. Return the min and max.
                return new List<int> { gMin, gMax };
            }
        }

        class SolutionFastest
        {
            public List<int> subUnsort(List<int> A)
            {
                List<int> indexes = new List<int>();

                if (A == null || A.Count <= 1)
                {
                    indexes.Add(-1);
                    return indexes;
                }

                int si = 0;

                while (si < A.Count - 1)
                {
                    if (A[si] > A[si + 1])
                    {
                        break;
                    }
                    si++;
                }

                if (si == A.Count - 1)
                {
                    indexes.Add(-1);
                    return indexes;
                }

                int ei = A.Count - 1;

                while (ei > 0)
                {
                    if (A[ei] < A[ei - 1])
                    {
                        break;
                    }
                    ei--;
                }

                int min = A[si]; int max = A[si];

                for (int i = si + 1; i <= ei; i++)
                {
                    if (A[i] > max)
                    {
                        max = A[i];
                    }

                    if (A[i] < min)
                    {
                        min = A[i];
                    }
                }

                for (int i = 0; i < si; i++)
                {
                    if (A[i] > min)
                    {
                        si = i;
                    }
                }

                for (int i = A.Count - 1; i >= ei + 1; i--)
                {
                    if (A[i] < max)
                    {
                        ei = i;
                    }
                }

                indexes.Add(si);
                indexes.Add(ei);

                return indexes;
            }
        }


        class SolutionLightweight
        {

            public List<int> subUnsort(List<int> A)
            {

                int firstDev = int.MaxValue;
                int lastDev = int.MinValue;
                int min = int.MaxValue;
                int max = int.MinValue;

                for (int i = 0; i < A.Count - 1; i++)
                {
                    if (A[i] > A[i + 1])
                    {
                        firstDev = Math.Min(i, firstDev);
                        lastDev = Math.Max(i + 1, lastDev);
                    }
                }

                if (firstDev == int.MaxValue)
                {
                    return new List<int> { -1 };
                }

                for (int i = firstDev; i <= lastDev; i++)
                {
                    min = Math.Min(A[i], min);
                    max = Math.Max(A[i], max);
                }

                while (firstDev > 0 && A[firstDev - 1] > min)
                {
                    firstDev--;
                }
                while (lastDev < A.Count - 1 && A[lastDev + 1] < max)
                {
                    lastDev++;
                }


                return new List<int> { firstDev, lastDev };

            }

        }



    }

    /*
     * You are given an array (zero indexed) of N non-negative integers, A0, A1 ,…, AN-1.
Find the minimum sub array Al, Al+1 ,…, Ar so if we sort(in ascending order) that sub array, then the whole array should get sorted.
If A is already sorted, output -1.

Example :

Input 1:

A = [1, 3, 2, 4, 5]

Return: [1, 2]

Input 2:

A = [1, 2, 3, 4, 5]

Return: [-1]
In the above example(Input 1), if we sort the subarray A1, A2, then whole array A should get sorted.





    Assume that Al, …, Ar is the minimum-unsorted-subarray which is to be sorted.
then min(Al, …, Ar) >= max(A0, …, Al-1)
and max(Al, …, Ar) <= min(Ar+1, …, AN-1)

How would you solve now?





     */
}
