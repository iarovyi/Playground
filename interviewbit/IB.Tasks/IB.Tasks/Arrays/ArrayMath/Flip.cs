namespace IB.Arrays.ArrayMath
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal class Flip
    {
        public static void Test()
        {
            FlipString("010").Should().BeEquivalentTo(new List<int>() {1, 1});
            FlipString("111").Should().BeEquivalentTo(new List<int>() { });
        }

        /*
         * 10101000011110000010101
         * 100000010000000001
         *
         */

        public static List<int> FlipString(string A)
        {
            if (A.Length == 0)
            {
                return new List<int>();
            }


            //var ls = new Stack<int>();
            //var rs = new Stack<int>();
            //var benefits = new Stack<int>();

            int maxStartIndex = 0;
            int maxEndIdex = 0;
            int maxBenefit = 0;// A[0] == '0' ? 1 : -1;

            int startIndex = 0;
            int endIdex = 0;
            int benefit = 0;

            for (int i = 0; i < A.Length; i++)
            {
                int flipBenefit = A[i] == '0' ? 1 : -1;
                benefit = flipBenefit + benefit;
                endIdex = i;

                if (benefit < 0)
                {
                    startIndex = i + 1;
                    endIdex = i + i;
                    benefit = 0;
                }

                if (benefit > maxBenefit)
                {
                    maxStartIndex = startIndex;
                    maxEndIdex = endIdex;
                    maxBenefit = benefit;
                }
            }

            if (maxBenefit > 0)
            {
                return new List<int>() { maxStartIndex + 1, maxEndIdex + 1 };
            }

            return new List<int>();
        }
    }


    /*
     *
     * You are given a binary string(i.e. with characters 0 and 1) S consisting of characters S1, S2, …, SN. In a single operation, you can choose two indices L and R such that 1 ≤ L ≤ R ≤ N and flip the characters SL, SL+1, …, SR. By flipping, we mean change character 0 to 1 and vice-versa.

Your aim is to perform ATMOST one operation such that in final string number of 1s is maximised. If you don’t want to perform the operation, return an empty array. Else, return an array consisting of two elements denoting L and R. If there are multiple solutions, return the lexicographically smallest pair of L and R.

Notes:

Pair (a, b) is lexicographically smaller than pair (c, d) if a < c or, if a == c and b < d.
For example,

S = 010

Pair of [L, R] | Final string
_______________|_____________
[1 1]          | 110
[1 2]          | 100
[1 3]          | 101
[2 2]          | 000
[2 3]          | 001

We see that two pairs [1, 1] and [1, 3] give same number of 1s in final string. So, we return [1, 1].
Another example,

If S = 111

No operation can give us more than three 1s in final string. So, we return empty array [].
     */
}
