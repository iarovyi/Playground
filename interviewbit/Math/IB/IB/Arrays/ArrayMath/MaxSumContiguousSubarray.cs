namespace IB.Arrays.ArrayMath
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class MaxSumContiguousSubArray
    {
        internal static void Test()
        {
            GetMaxPossibleSubArraySum(new List<int>() { -163, -20 }).Should().Be(-20);
            GetMaxPossibleSubArraySum(new List<int>() { 1, 2, 3, 4, -10 }).Should().Be(10);
            GetMaxPossibleSubArraySum(new List<int>() { -2, 1, -3, 4, -1, 2, 1, -5, 4 }).Should().Be(6);
        }

        //https://afshinm.name/2018/06/24/why-kadane-algorithm-works/
        //https://e-maxx.ru/algo/maximum_average_segment
        /*
         В самом деле, рассмотрим первый момент времени, когда сумма s стала отрицательной. 
         Это означает, что, стартовав с нулевой частичной суммы, мы в итоге пришли к отрицательной 
         частичной сумме — значит, и весь этот префикс массива, равно как и любой его суффикс имеют
         отрицательную сумму. Следовательно, от всего этого префикса массива в дальнейшем не может
         быть никакой пользы: он может дать только отрицательную прибавку к ответу.
         */
        public static int GetMaxPossibleSubArraySum(List<int> A)
        {
            if (A.Count == 0)
            {
                return 0;
            }

            int globalMaxSum = A[0];
            int localMaxSum = A[0];
            for (int i = 1; i < A.Count; i++)
            {
                localMaxSum = Math.Max(A[i], localMaxSum + A[i]);

                if (localMaxSum > globalMaxSum)
                {
                    globalMaxSum = localMaxSum;
                }

                if (localMaxSum < 0)
                {
                    localMaxSum = 0;
                }
            }

            return globalMaxSum;
        }

        /*
         * Find the contiguous subarray within an array, A of length N which has the largest sum.

Input Format:

The first and the only argument contains an integer array, A.
Output Format:

Return an integer representing the maximum possible sum of the contiguous subarray.
Constraints:

1 <= N <= 1e6
-1000 <= A[i] <= 1000
For example:

Input 1:
    A = [1, 2, 3, 4, -10]

Output 1:
    10

Explanation 1:
    The subarray [1, 2, 3, 4] has the maximum possible sum of 10.

Input 2:
    A = [-2, 1, -3, 4, -1, 2, 1, -5, 4]

Output 2:
    6

Explanation 2:
    The subarray [4,-1,2,1] has the maximum possible sum of 6.
         */
    }
}
