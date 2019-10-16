namespace IB.Tasks.BitManipulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    /// <summary>
    /// https://www.interviewbit.com/problems/number-of-1-bits/
    /// </summary>
    public class NumberOf1Bits
    {
        [Fact]
        public void Test()
        {
            long number = 0b00000000000000000000000000001011;
            GetNumSetBits(number).Should().Be(3);
        }

        public int GetNumSetBits(long a)
        {
            int setBitsCount = 0;

            for (int i = 0; i < 32; i++)
            {
                if ((a & (1 << i)) != 0)
                {
                    setBitsCount++;
                }
            }

            return setBitsCount;
        }

        public class SolutionEditorial
        {
            public int numSetBits(long a)
            {
                int count = 0;
                while (a > 0)
                {
                    count += (int)(a % 2);
                    a = a >> 1;
                }
                return count;
            }
        }

        public class SolutionFast
        {
            public int numSetBits(long a)
            {

                int count = 0;
                while (a > 0)
                {

                    if ((a & 1) == 1)
                    {

                        count = count + 1;
                    }
                    a = a >> 1;
                }

                return count;
            }
        }

        public class SolutionLightweight
        {
            public int numSetBits(long a)
            {
                int ans = 0;
                while (a > 0)
                {
                    ans += (int)(a & 1);
                    a >>= 1;
                }
                return ans;
            }
        }
    }

    /*
     * Write a function that takes an unsigned integer and returns the number of 1 bits it has.

Example:

The 32-bit integer 11 has binary representation

00000000000000000000000000001011
so the function should return 3.

Note that since Java does not have unsigned int, use long for Java



    Bruteforce:
Iterate 32 times, each time determining if the ith bit is a ’1′ or not.
This is probably the easiest solution, and the interviewer would probably not be too happy about it.
This solution is also machine dependent (You need to be sure that an unsigned integer is 32-bit).
In addition, this solution is not very efficient too because you need to iterate 32 times no matter what.

A better solution:
This special solution uses a trick which is normally used in bit manipulations.
Notice what x - 1 does to bit representation of x.
x - 1 would find the first set bit from the end, and then set it to 0, and set all the bits following it.

Which means if x = 10101001010100
                              ^
                              |
                              |
                              |

                       First set bit from the end
Then x - 1 becomes 10101001010(011)

All other bits in x - 1 remain unaffected.
This means that if we do (x & (x - 1)), it would just unset the last set bit in x (which is why x&(x-1) is 0 for powers of 2).

Can you use the above fact to come up with a solution ?
     */
}
