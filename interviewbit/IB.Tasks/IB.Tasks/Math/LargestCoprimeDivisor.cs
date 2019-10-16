namespace IB.Math
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class LargestCoprimeDivisor
    {
        public static void Test()
        {
            GetLargestCoprimeDivisor(30, 12).Should().Be(5);
        }

        //A % X = 0
        //gcd(X, B) = 1
        private static int GetLargestCoprimeDivisor(int A, int B)
        {
            //for (int i = A; i > 0; i--)
            for (int i = A/2; i > 0; i--)
            {
                int greatestDivisor = GetGreatestCommonDivisor(B, i);
                if (greatestDivisor == 1 && A % i == 0)
                {
                    return i;
                }
            }

            return 1;
        }

        public static int GetGreatestCommonDivisor(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }

            return a + b;
        }

        /*
         *You are given two positive numbers A and B. You need to find the maximum valued integer X such that:

X divides A i.e. A % X = 0
X and B are co-prime i.e. gcd(X, B) = 1
For example,
         *
         *
         * A = 30
B = 12
We return
X = 5
         */
    }
}
