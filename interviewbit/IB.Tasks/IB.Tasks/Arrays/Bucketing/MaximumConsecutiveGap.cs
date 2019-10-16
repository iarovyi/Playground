namespace IB.Arrays.Bucketing
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class MaximumConsecutiveGap
    {
        public static void Test()
        {
            GetMaxDifBetweenAdjacent(new List<int>(){ 1, 10, 5 }).Should().Be(5);
        }

        public static int GetMaxDifBetweenAdjacent(List<int> A)
        {
            A.Sort();

            int maxDif = 0;
            for (int i = 1, prev = 0; i < A.Count; i++, prev++)
            {
                maxDif = Math.Max(maxDif, A[i] - A[prev]);
            }

            return maxDif;
        }

        class Solution
        {
            public int maximumGap(List<int> A)
            {
                int min = int.MaxValue;
                int max = int.MinValue;

                foreach (int n in A)
                {
                    min = Math.Min(min, n);
                    max = Math.Max(max, n);
                }
                if (A.Count <= 1 || (max == min))
                {
                    return 0;
                }
                int gap = (int)Math.Ceiling((double)(max - min) / (A.Count - 1));
                List<int> mins = new List<int>();
                List<int> maxs = new List<int>();
                List<int> count = new List<int>();
                int bucketCount = A.Count;
                for (int i = 0; i < bucketCount; i++)
                {
                    mins.Add(int.MaxValue);
                    maxs.Add(int.MinValue);
                    count.Add(0);
                }
                foreach (int n in A)
                {
                    int bucket = (n - min) / gap;
                    mins[bucket] = Math.Min(mins[bucket], n);
                    maxs[bucket] = Math.Max(maxs[bucket], n);
                    count[bucket]++;
                }
                int lastSeen = maxs[0];
                int result = lastSeen;
                for (int i = 1; i < bucketCount; i++)
                {
                    if (count[i] > 0)
                    {
                        result = Math.Max(result, mins[i] - lastSeen);
                        lastSeen = maxs[i];
                    }
                }
                return result;
            }

        }

    }

    /*
     * Given an unsorted array, find the maximum difference between the successive elements in its sorted form.

Try to solve it in linear time/space.

Example :

Input : [1, 10, 5]
Output : 5 
Return 0 if the array contains less than 2 elements.

You may assume that all the elements in the array are non-negative integers and fit in the 32-bit signed integer range.
You may also assume that the difference will not overflow.







    Any form of sorting is going to be at least O(n * log n), so we need to think outside of sorting.

Also, you can use extra O(n) space.

Try to think starting from maximum and minimum of array.

How can you use the gap between them to separate elements into different blocks/buckets in such a way that you dont have to evaluate the answer for elements within buckets.
   




    Now, first try to think if you were already given the minimum value MIN and maximum value MAX in the array of size N, under what circumstances would the max gap be minimum and maximum ?

Obviously, maximum gap will be maximum when all elements are either MIN or MAX making maxgap = MAX - MIN.

Maximum gap will be minimum when all the elements are equally spaced apart between MIN and MAX. Lets say the spacing between them is gap.

So, they are arranged as

MIN, MIN + gap, MIN + 2*gap, MIN + 3*gap, ... MIN + (N-1)*gap 
where

MIN + (N-1)*gap = MAX 
=> gap = (MAX - MIN) / (N - 1). 
So, we know now that our answer will lie in the range [gap, MAX - MIN].
Now, if we know the answer is more than gap, what we do is create buckets of size gap for ranges

  [MIN, MIN + gap), [Min + gap, `MIN` + 2* gap) ... and so on
There will only be (N-1) such buckets. We place the numbers in these buckets based on their value.

If you pick any 2 numbers from a single bucket, their difference will be less than gap, and hence they would never contribute to maxgap ( Remember maxgap >= gap ). We only need to store the largest number and the smallest number in each bucket, and we only look at the numbers across bucket.

Now, we just need to go through the bucket sequentially ( they are already sorted by value ), and get the difference of min_value with max_value of previous bucket with at least one value. We take maximum of all such values.
     *
     *
     *
     * */
}
