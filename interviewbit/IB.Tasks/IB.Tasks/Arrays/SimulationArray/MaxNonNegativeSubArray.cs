namespace IB.Arrays.SimulationArray
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class MaxNonNegativeSubArray
    {
        public static void Test()
        {
            GetMaxSumSubArrayOfPositiveItems(new List<int>() { -75249, 43658, 11272, -50878, 37709, 38165, -43042, -22503 })
                .Should().BeEquivalentTo(new List<int>() { 37709, 38165 });

            GetMaxSumSubArrayOfPositiveItems(new List<int>() { 1967513926, 1540383426, -1303455736, -521595368 })
                .Should().BeEquivalentTo(new List<int>() { 1967513926, 1540383426 });

            GetMaxSumSubArrayOfPositiveItems(new List<int>() { 0, 0, -1, 0 })
                .Should().BeEquivalentTo(new List<int>() { 0, 0 });

            GetMaxSumSubArrayOfPositiveItems(new List<int>() { -1, -1, -1, -1, -1 })
                .Should().BeEquivalentTo(new List<int>() {});

            GetMaxSumSubArrayOfPositiveItems(new List<int>() { 1, 2, 5, -7, 2, 3 })
                .Should().BeEquivalentTo(new List<int>(){ 1,2,5 });

            GetMaxSumSubArrayOfPositiveItems(new List<int>() { 10, -1, 2, 3, -4, 100 })
                .Should().BeEquivalentTo(new List<int>() { 100 });
        }


        public static List<int> GetMaxSumSubArrayOfPositiveItems(List<int> A)
        {
            if (A.Count == 0)
            {
                return new List<int>();
            }

            int startI = 0;
            while (A[startI] < 0)
            {
                startI++;
                if (startI >= A.Count)
                {
                    return new List<int>();
                }
            }

            long globalSum = A[startI];
            int globalStart = startI;
            int globalEnd = startI;
            long localSum = A[startI];
            int localStart = startI;
            int localEnd = startI;
            for (int i = startI + 1; i < A.Count; i++)
            {


                localSum = Math.Max(A[i], A[i] + localSum);
                localEnd = i;

                int globalSize = globalEnd - globalStart;
                int localSize = localEnd - localStart;
                if (localSum > globalSum || (localSum == globalSum && localSize >= globalSize))
                {
                    globalSum = localSum;
                    globalStart = localStart;
                    globalEnd = localEnd;
                }

                if (localSum < 0 || A[i] < 0)
                {
                    localSum = 0;
                    localStart = i + 1;
                }
            }

            return A.GetRange(globalStart, globalEnd - globalStart + 1);
        }
    }
    /*
     * Given an array of integers, A of length N, find out the maximum sum sub-array of non negative numbers from A.

The sub-array should be contiguous i.e., a sub-array created by choosing the second and fourth element and skipping the third element is invalid.

Maximum sub-array is defined in terms of the sum of the elements in the sub-array.

Find and return the required subarray.

NOTE:

    1. If there is a tie, then compare with segment's length and return segment which has maximum length.
    2. If there is still a tie, then return the segment with minimum starting index.


Input Format:

The first and the only argument of input contains an integer array A, of length N.
Output Format:

Return an array of integers, that is a subarray of A that satisfies the given conditions.
Constraints:

1 <= N <= 1e5
1 <= A[i] <= 1e5
Examples:

Input 1:
    A = [1, 2, 5, -7, 2, 3]

Output 1:
    [1, 2, 5]

Explanation 1:
    The two sub-arrays are [1, 2, 5] [2, 3].
    The answer is [1, 2, 5] as its sum is larger than [2, 3].

Input 2:
    A = [10, -1, 2, 3, -4, 100]
    
Output 2:
    [100]

Explanation 2:
    The three sub-arrays are [10], [2, 3], [100].
    The answer is [100] as its sum is larger than the other two.
     */
}
