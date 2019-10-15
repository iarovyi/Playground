using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace IB.Arrays.ArrayMath
{
    public static class RepeatAndMissingNumberArray
    {
        public static void Test()
        {
            RepeatedNumber(new List<int>() {3, 1, 2, 5, 3}).Should().BeEquivalentTo(new List<int>(){ 3, 4});
        }


        public static List<int> RepeatedNumber(List<int> A/*repeated numbers from 1 to n*/)
        {
            /*
             *  sum = 1 + 2 + ... + n + duplicated - missing
             *  sum - 1 -2 - ... - n = duplicated - missing
             * missing = duplicated + 1 + 2 + ... + n - sum;
             */
            int duplicatedNumber = 0;
            int maxNumber = int.MinValue;
            bool[] visited = new bool[A.Capacity + 1];
            int sum = 0;

            for (int i = 0; i < A.Count; i++)
            {
                int val = A[i];
                sum = sum + val;
                if (visited[val] == true)
                {
                    duplicatedNumber = val;
                }

                visited[val] = true;

                if (val > maxNumber)
                {
                    maxNumber = val;
                }
            }

            int sumFrom1ToN = (maxNumber + 1) * maxNumber / 2;
            int missingNumber = duplicatedNumber + sumFrom1ToN - sum;
            return new List<int>(){ duplicatedNumber, missingNumber };
        }



        class Solution
        {
            /*
             *     Sum(Actual) = Sum(1...N) + A - B

    Sum(Actual) - Sum(1...N) = A - B. 

    Sum(Actual Squares) = Sum(1^2 ... N^2) + A^2 - B^2

    Sum(Actual Squares) - Sum(1^2 ... N^2) = (A - B)(A + B) 

    = (Sum(Actual) - Sum(1...N)) ( A + B). 
We can use the above 2 equations to get the value of A and B.
             */
            public List<int> repeatedNumber(List<int> A)
            {
                long sumDiff = 0;
                long squareSumDiff = 0;
                for (int i = 0; i < A.Count; i++)
                {
                    long expectedNumber = i + 1;
                    long actualNumber = A[i];
                    sumDiff += (expectedNumber - actualNumber);
                    squareSumDiff += ((expectedNumber * expectedNumber) - (actualNumber * actualNumber));
                }
                long missingNumber = (sumDiff + (squareSumDiff / sumDiff)) / 2;
                long repeatedNumber = missingNumber - sumDiff;
                List<int> result = new List<int>();
                result.Add((int)repeatedNumber);
                result.Add((int)missingNumber);
                return result;
            }
        }
    }
    /*
     * You are given a read only array of n integers from 1 to n.

Each integer appears exactly once except A which appears twice and B which is missing.

Return A and B.

Note: Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

Note that in your output A should precede B.

Example:

Input:[3 1 2 5 3] 

Output:[3, 4] 

A = 3, B = 4
     */

}
