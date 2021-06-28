namespace IB.Tasks.BinarySearching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class SquareRootOfInteger
    {
        [Fact]
        public void Test()
        {
            Sqrt(11).Should().Be(3);
            Sqrt(2147483647).Should().Be(46340);
        }

        public int Sqrt(int number)
        {
            int startI = 0;
            int endI = number;
            int latestSmaller = 0;

            while (startI <= endI)
            {
                int mid = startI + (endI - startI) / 2;
                int inPower = mid * mid;

                if (inPower == number)
                {
                    return mid;
                }

                if (inPower > number)
                {
                    endI = mid - 1;
                }
                else if (inPower < number)
                {
                    latestSmaller = mid;
                    startI = mid + 1;
                }
            }

            return latestSmaller;
        }

        public class Solution
        {
            public int sqrt(int a)
            {
                long low = 1;
                long high = a;
                while (low <= high)
                {
                    long mid = (high + low) / 2;
                    if (mid * mid == a)
                    {
                        return (int)mid;
                    }
                    if (mid * mid > a)
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                // if we did not find an exact match the high variable is smaller than low
                // and therefore contains the floor value of sqrt.
                return (int)high;
            }
        }

    }

    /*
     * Implement int sqrt(int x).

Compute and return the square root of x.

If x is not a perfect square, return floor(sqrt(x))

Example :

Input : 11
Output : 3
DO NOT USE SQRT FUNCTION FROM STANDARD LIBRARY
     */
}
