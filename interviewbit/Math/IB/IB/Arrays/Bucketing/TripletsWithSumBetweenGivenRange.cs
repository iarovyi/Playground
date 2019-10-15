namespace IB.Arrays.Bucketing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FluentAssertions;

    internal static class TripletsWithSumBetweenGivenRange
    {
        public static void Test()
        {
            AreThereSumOf3NumbersGreater1AndLess2(new List<string>(){ "0.6", "0.7", "0.8", "1.2", "0.4" }).Should().BeTrue();
            AreThereSumOf3NumbersGreater1AndLess2(new List<string>() { "0.6", "0.7", "0.8", "0.2", "0.4" }).Should().BeFalse();
        }

        public static bool AreThereSumOf3NumbersGreater1AndLess2(List<string> A)
        {
            List<float> numbers = A.Select(float.Parse).ToList();
            numbers.Sort();

            int left = 0;
            int right = numbers.Count - 1;
            while (left < right - 1)
            {
                float sum = numbers[left] + numbers[right] + numbers[left + 1];
                if (sum >= 2)
                {
                    right = right - 1;
                } else if (sum <= 1)
                {
                    left = left + 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        class Solution
        {
            public int solve(List<string> A)
            {
                List<double> parsedval = new List<double>();
                for (int i = 0; i < A.Count; i++)
                {
                    parsedval.Add(Convert.ToDouble(A[i]));
                }
                List<double> firstBucket = new List<double>();
                List<double> secondBucket = new List<double>();
                List<double> thirdBucket = new List<double>();
                for (int i = 0; i < parsedval.Count; i++)
                {
                    if (parsedval[i] < (double)2 / 3)
                    {
                        firstBucket.Add(parsedval[i]);
                    }
                    else
                    if (parsedval[i] >= (double)2 / 3 && parsedval[i] <= 1)
                    {
                        secondBucket.Add(parsedval[i]);
                    }
                    else if (parsedval[i] > 1 && parsedval[i] < 2)
                    {
                        thirdBucket.Add(parsedval[i]);
                    }
                }
                firstBucket.Sort();
                secondBucket.Sort();
                thirdBucket.Sort();

                if (firstBucket.Count >= 3 && (firstBucket[firstBucket.Count - 1] + firstBucket[firstBucket.Count - 2] + firstBucket[firstBucket.Count - 3] >= 1))
                {
                    return 1;
                }
                if (firstBucket.Count >= 2 && thirdBucket.Count >= 1 && (firstBucket[0] + firstBucket[0] + thirdBucket[0] <= 2))
                {
                    return 1;
                }
                if (firstBucket.Count >= 1 && secondBucket.Count >= 2 && (firstBucket[0] + secondBucket[0] + secondBucket[1] <= 2))
                {
                    return 1;
                }
                if (firstBucket.Count >= 1 && secondBucket.Count >= 1 && thirdBucket.Count >= 1 && (firstBucket[0] + secondBucket[0] + thirdBucket[0] <= 2))
                {
                    return 1;
                }
                if (firstBucket.Count >= 2 && secondBucket.Count >= 1 && (firstBucket[firstBucket.Count - 1] + firstBucket[firstBucket.Count - 2] + secondBucket[0] < 2) && (firstBucket[firstBucket.Count - 1] + firstBucket[firstBucket.Count - 2] + secondBucket[0] > 1))
                {
                    return 1;
                }
                if (firstBucket.Count >= 2 && secondBucket.Count >= 1 && (firstBucket[0] + firstBucket[1] + secondBucket[secondBucket.Count - 1] > 1) && (firstBucket[0] + firstBucket[1] + secondBucket[secondBucket.Count - 1] < 2))
                {
                    return 1;
                }
                return 0;
            }
        }

    }

    /*
     * Given an array of real numbers greater than zero in form of strings.
Find if there exists a triplet (a,b,c) such that 1 < a+b+c < 2 .
Return 1 for true or 0 for false.

Example:

Given [0.6, 0.7, 0.8, 1.2, 0.4] ,

You should return 1

as

0.6+0.7+0.4=1.7

1<1.7<2

Hence, the output is 1.

O(n) solution is expected.

Note: You can assume the numbers in strings don’t overflow the primitive data type and there are no leading zeroes in numbers. Extra memory usage is allowed.
     */
}
