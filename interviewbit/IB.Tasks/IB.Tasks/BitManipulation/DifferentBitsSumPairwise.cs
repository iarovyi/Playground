namespace IB.Tasks.BitManipulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class DifferentBitsSumPairwise
    {
        [Fact]
        public void Test()
        {
            CountSetBits(0b00000010000000000000000000000011).Should().Be(3);
            CountSumOfDifferentBits(new List<int>() {1, 3, 5}).Should().Be(8);
        }

        public int CountSetBits(int number)
        {
            int count = 0;
            while (number != 0)
            {
                bool isSet = (number & 1) != 0;
                if (isSet)
                {
                    count++;
                }
                number = number >> 1;
            }

            return count;
        }

        public int CountDifferentBits(int a, int b)
        {
            return CountSetBits(a ^ b);
        }

        private static readonly long Modulo = (long)(1e9 + 7);

        public int CountSumOfDifferentBits(List<int> A)
        {
            //count(1)*count(0) + count(0)*count(1)
            long totalCont = 0;

            for (int i = 0; i < 32; i++)
            {
                long setCount = 0;
                long unsetCount = 0;
                for (int j = 0; j < A.Count; j++)
                {
                     int number = A[j];
                     bool isSet = (number & (1 << i)) != 0;
                     if (isSet)
                     {
                         setCount++;
                     }
                     else
                     {
                         unsetCount++;
                     }
                }

                long iBitCount = 2 * setCount * unsetCount;
                totalCont = (totalCont + iBitCount) % Modulo;
            }

            return (int)totalCont;
            /*int sum = 0;
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < A.Count; j++)
                {
                    int count = CountDifferentBits(A[i], A[j]);
                    sum = (int)(((long)sum + count) % Modulo);
                }
            }
            return sum;*/
        }

        class Solution
        {

            public int cntBits(List<int> A)
            {
                long ans = 0;  // Initialize result

                // traverse over all bits
                for (int i = 0; i < 32; i++)
                {
                    // count number of elements with i'th bit set
                    long count = 0;
                    for (int j = 0; j < A.Count; j++)
                        if ((A[j] & (1 << i)) != 0)
                            count++;

                    // Add "count * (n - count) * 2" to the answer
                    ans += ((count * (A.Count - count) % 1000000007) * 2);
                }

                return (int)(ans % 1000000007);
            }
        }
    }
}

    /*
     * We define f(X, Y) as number of different corresponding bits in binary representation of X and Y. For example, f(2, 7) = 2, since binary representation of 2 and 7 are 010 and 111, respectively. The first and the third bit differ, so f(2, 7) = 2.

You are given an array of N positive integers, A1, A2 ,…, AN. Find sum of f(Ai, Aj) for all pairs (i, j) such that 1 ≤ i, j ≤ N. Return the answer modulo 109+7.

For example,

A=[1, 3, 5]

We return

f(1, 1) + f(1, 3) + f(1, 5) + 
f(3, 1) + f(3, 3) + f(3, 5) +
f(5, 1) + f(5, 3) + f(5, 5) =

0 + 1 + 1 +
1 + 0 + 2 +
1 + 2 + 0 = 8
     */
