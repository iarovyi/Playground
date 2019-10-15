namespace IB.Arrays.Bucketing
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class MaxDistance
    {
        public static void Test()
        {
            Solution1.maximumGap(new List<int>() {3 /**/, 5, 4 /**/, 2}).Should().Be(2);
            GetMaximumDistanceBetweenSmallerNumberOnLeftAndBiggerOnRight(new List<int>() {3/**/, 5, 4/**/, 2}).Should().Be(2);
        }

        /*
         * 3 5 4 2
         *
         * 5 6 4 1 1 1 1 6 0
         *
         *
         * 2 3 4 5
         * 3 0 2 1
         *
         * 3 5 4 2
         * 3 3 3 2 LMin
         * 5 5 4 2 LMax
         *
         */

        public static int GetMaximumDistanceBetweenSmallerNumberOnLeftAndBiggerOnRight(List<int> A)
        {


            return -1;
        }
    }

    static class Solution1
    {
        public static int maximumGap(List<int> A)
        {
            int maxDiff;
            int i, j;
            int n = A.Count;
            int[] RMax = new int[n];
            int[] LMin = new int[n];

            if (A.Count == 1)
                return 0;

            /* Construct LMin[] such that LMin[i] stores the minimum value
               from (arr[0], arr[1], ... arr[i]) */
            LMin[0] = A[0];
            for (i = 1; i < n; ++i)
                LMin[i] = Math.Min(A[i], LMin[i - 1]);

            /* Construct RMax[] such that RMax[j] stores the maximum value
               from (arr[j], arr[j+1], ..arr[n-1]) */
            RMax[n - 1] = A[n - 1];
            for (j = n - 2; j >= 0; --j)
                RMax[j] = Math.Max(A[j], RMax[j + 1]);

            /* Traverse both arrays from left to right to find optimum j - i
               This process is similar to merge() of MergeSort */
            i = 0; j = 0; maxDiff = -1;
            while (j < n && i < n)
            {
                if (LMin[i] <= RMax[j])
                {
                    maxDiff = Math.Max(maxDiff, j - i);
                    j = j + 1;
                }
                else
                    i = i + 1;
            }

            return maxDiff;
        }
    }


    class Solution2
    {
        public int maximumGap(List<int> A)
        {
            int n = A.Count;
            int maxDiff;
            int i, j;

            if (n == 1)
                return 0;

            int[] RMax = new int[n];
            int[] LMin = new int[n];

            // Construct LMin[] such that LMin[i]  
            // stores the minimum value 
            // from (arr[0], arr[1], ... arr[i])  
            LMin[0] = A[0];
            for (i = 1; i < n; ++i)
                LMin[i] = min(A[i], LMin[i - 1]);

            // Construct RMax[] such that  
            // RMax[j] stores the maximum value 
            // from (arr[j], arr[j+1], ..arr[n-1])  
            RMax[n - 1] = A[n - 1];
            for (j = n - 2; j >= 0; --j)
                RMax[j] = max(A[j], RMax[j + 1]);

            // Traverse both arrays from left  
            // to right to find optimum j - i 
            // This process is similar to merge()  
            // of MergeSort  
            i = 0; j = 0; maxDiff = -1;
            while (j < n && i < n)
            {
                if (LMin[i] <= RMax[j])
                {
                    maxDiff = max(maxDiff, j - i);
                    j = j + 1;
                }
                else
                    i = i + 1;
            }

            return maxDiff;
        }

        static int max(int x, int y)
        {
            return x > y ? x : y;
        }

        static int min(int x, int y)
        {
            return x < y ? x : y;
        }
    }


    class Solution3
    {
        public int maximumGap(List<int> A)
        {
            int maxDiff;
            int i, j;
            int n = A.Count;
            int[] RMax = new int[n];
            int[] LMin = new int[n];

            if (A.Count == 1)
                return 0;

            /* Construct LMin[] such that LMin[i] stores the minimum value
               from (arr[0], arr[1], ... arr[i]) */
            LMin[0] = A[0];
            for (i = 1; i < n; ++i)
                LMin[i] = Math.Min(A[i], LMin[i - 1]);

            /* Construct RMax[] such that RMax[j] stores the maximum value
               from (arr[j], arr[j+1], ..arr[n-1]) */
            RMax[n - 1] = A[n - 1];
            for (j = n - 2; j >= 0; --j)
                RMax[j] = Math.Max(A[j], RMax[j + 1]);

            /* Traverse both arrays from left to right to find optimum j - i
               This process is similar to merge() of MergeSort */
            i = 0; j = 0; maxDiff = -1;
            while (j < n && i < n)
            {
                if (LMin[i] <= RMax[j])
                {
                    maxDiff = Math.Max(maxDiff, j - i);
                    j = j + 1;
                }
                else
                    i = i + 1;
            }

            return maxDiff;
        }
    }
}

/*
 * Given an array A of integers, find the maximum of j - i subjected to the constraint of A[i] <= A[j].

If there is no solution possible, return -1.

Example :

A : [3 5 4 2]

Output : 2 
for the pair (3, 4)



Let us say we sort the array. Note that we cannot just blindly sort the array. We need to make sure that 
we also store the original index of the values when we are sorting the array.

Now iterate over every element in the sorted array as A[i]. Let us say index[i] stores the actual index of A[i].

Now we are looking for all values of A[j] which are bigger than A[i]. Since the array is sorted, all the 
elements to the right of A[i] will qualify for being A[j].
Since we want to maximize index[j] - index[i], and index[i] is fixed, we are essentially looking at max index[j] for all j > i.

This seems much easier. Can you think of a solution from this point?

 */
