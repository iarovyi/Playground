namespace IB.Tasks.BitManipulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class SingleNumber2
    {
        [Fact]
        public void Test()
        {
            GetSingleNotDuplicatedThreeTimesNumber(new List<int>() { 1, 2, 4, 3, 3, 2, 2, 3, 1, 1 }).Should().Be(4);
            var list = new List<int>()
            {
                3,3,3,10,10,10,11,11,11,22,22,22,64,64,64,66,66,66,102,102,102,108,108,108,120,120,120,166,
                166,166,169,169,169,172,172,172,176,176,176,194,194,194,203,203,203,215,215,215,247,283,283,
                283,290,290,290,303,303,303,308,308,308,313,313,313,319,319,319,374,374,374,379,379,379,382,
                382,382,383,383,383,395,395,395,400,400,400,406,406,406,417,417,417,460,460,460,463,463,463,
                479,479,479,489,489,489,554,554,554,572,572,572,584,584,584,587,587,587,601,601,601,609,609,
                609,619,619,619,630,630,630,680,680,680,707,707,707,713,713,713,726,726,726,788,788,788,801,
                801,801,809,809,809,811,811,811,885,885,885,886,886,886,890,890,890,901,901,901,938,938,938,
                965,965,965,973,973,973,992,992,992
            };

            string dddd = string.Join(",", list.OrderBy(i => i));

            GetSingleNotDuplicatedThreeTimesNumber(list).Should().Be(247);
        }

        public int GetSingleNotDuplicatedThreeTimesNumber(List<int> A)
        {
            int xor = A[0];
            for (int i = 1; i < A.Count; i++)
            {
                xor = xor ^ A[i];
            }

            return xor;
        }

        /*
         * Given an array of integers, every element appears thrice except for one which occurs once.

Find that element which does not appear thrice.

Note: Your algorithm should have a linear runtime complexity.

Could you implement it without using extra memory?

Example :

Input : [1, 2, 4, 3, 3, 2, 2, 3, 1, 1]
Output : 4


        Having noticed that if X has 1 in that position, we will have 3x+1 number of 1s in that position.
        If X has 0 in that position, we will have 3x+1 number of 0 in that position.

A straightforward implementation is to use an array of size 32 to keep track of the total count of ith bit.

We can improve this based on the previous solution using three bitmask variables:

ones as a bitmask to represent the ith bit had appeared once.
twos as a bitmask to represent the ith bit had appeared twice.
threes as a bitmask to represent the ith bit had appeared three times.
When the ith bit had appeared for the third time, clear the ith bit of both ones and twos to 0. 
The final answer will be the value of ones.
         */

        class EditorialSolution
        {
            public int singleNumber(List<int> A)
            {
                int first = 0;
                int second = 0;

                foreach (var tmpInt in A)
                {
                    first = (first ^ tmpInt) & ~second;
                    second = (second ^ tmpInt) & ~first;
                }

                return first;
            }
        }


        class FastSolution
        {
            public int singleNumber(List<int> A)
            {
                int firstTimeOccurence = 0;
                int secondTimeOccurence = 0; int[] arr = A.ToArray();

                for (int i = 0; i < arr.Length; i++)
                {
                    secondTimeOccurence = secondTimeOccurence | (firstTimeOccurence & arr[i]);
                    firstTimeOccurence = firstTimeOccurence ^ arr[i];

                    int neutraliser = ~(firstTimeOccurence & secondTimeOccurence);
                    firstTimeOccurence = firstTimeOccurence & neutraliser;
                    secondTimeOccurence = secondTimeOccurence & neutraliser;
                }
                return firstTimeOccurence;
            }
        }

        class LightweightSolution
        {
            public int singleNumber(List<int> A)
            {

                var ret = new List<int>();

                for (int i = 0; A.Any(x => x > 0); i++)
                {
                    var Arr = A.Select(x => x % 2);
                    A = A.Select(x => x >> 1).ToList();
                    ret.Add(Arr.Aggregate((x, y) => x + y) % 3);
                }
                return GetNumber(ret);
            }

            private int GetNumber(List<int> a)
            {
                var num = 0;
                for (int i = 0; i < a.Count; i++)
                {
                    num = a[i] * ((int)Math.Pow(2, i)) + num;
                }
                return num;
            }
        }
    }
}
