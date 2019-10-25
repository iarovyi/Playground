namespace IB.Tasks.BitManipulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class DivideIntegers
    {
        [Fact]
        public void Test()
        {
            new FastSolution().divide(5, 2).Should().Be(2);
            new FastSolution().divide(-2147483648, -1).Should().Be(2147483647);
            new FastSolution().divide(-2147483648, 1).Should().Be(-2147483648);


            Divide(5, 2).Should().Be(2);
            Divide(-2147483648, -1).Should().Be(2147483647);
            Divide(-2147483648, 1).Should().Be(-2147483648);



        }

        //https://www.geeksforgeeks.org/divide-two-integers-without-using-multiplication-division-mod-operator/
        public static long Divide(long dividend, long divisor)
        {
            /*
             * dividend = quotient * divisor + remainder
             * Iterate on the bit position ‘i’ from 31 to 1 and
             * find the first bit for which divisor«i is less than dividend
             */

            // Calculate sign of divisor  
            // i.e., sign will be negative  
            // only iff either one of them  
            // is negative otherwise it  
            // will be positive 
            long sign = ((dividend < 0) ^
                         (divisor < 0))
                ? -1
                : 1;

            // remove sign of operands 
            dividend = Math.Abs(dividend);
            divisor = Math.Abs(divisor);

            // Initialize the quotient 
            long quotient = 0, temp = 0;

            // test down from the highest  
            // bit and accumulate the  
            // tentative value for 
            // valid bit 
            for (int i = 31; i >= 0; --i)
            {

                if (temp + (divisor << i) <= dividend)
                {
                    temp += divisor << i;
                    quotient |= 1L << i;
                }
            }

            return (sign * quotient);
        }

        //https://www.geeksforgeeks.org/divide-two-integers-without-using-multiplication-division-mod-operator/
        private static int DivideNotOptimal(int dividend, int divisor)
        {
            // Calculate sign of divisor i.e., 
            // sign will be negative only iff 
            // either one of them is negative 
            // otherwise it will be positive 
            int sign = ((dividend < 0) ^
                        (divisor < 0))
                ? -1
                : 1;

            // Update both divisor and 
            // dividend positive 
            dividend = dividend == int.MinValue ? int.MaxValue : Math.Abs(dividend);
            divisor = divisor == int.MinValue ? int.MaxValue : Math.Abs(divisor);

            // Initialize the quotient 
            int quotient = 0;

            while (dividend >= divisor)
            {
                dividend -= divisor;
                ++quotient;
            }

            return sign * quotient;
        }

        static int divide(int dividend, int divisor)
        {

            // Calculate sign of divisor i.e., 
            // sign will be negative only iff 
            // either one of them is negative 
            // otherwise it will be positive 
            int sign = ((dividend < 0) ^
                        (divisor < 0))
                ? -1
                : 1;

            // Update both divisor and 
            // dividend positive 
            dividend = Math.Abs(dividend);
            divisor = Math.Abs(divisor);

            // Initialize the quotient 
            int quotient = 0;

            while (dividend >= divisor)
            {
                dividend -= divisor;
                ++quotient;
            }

            return sign * quotient;
        }

        class LightweightSolution
        {
            //divide numbers using "long division" method
            /*
             * In essence, if you're doing Q = N/D:

Align the most-significant ones of N and D.
Compute t = (N - D);.
If (t >= 0), then set the least significant bit of Q to 1, and set N = t.
Left-shift N by 1.
Left-shift Q by 1.
Go to step 2.
             */
            public int divide(int A, int B)
            {
                int divisor = B;
                int dividend = A;
                if (divisor == 1)
                {
                    return dividend;
                }



                bool negative = false;
                if ((dividend < 0 && divisor >= 0) || (dividend >= 0 && divisor < 0))
                {
                    negative = true;
                }

                int result = 0;
                if (dividend == -2147483648)
                {
                    dividend = 2147483647;
                    if (divisor == 2)
                    {
                        result = 1;
                    }
                }

                if (divisor == -2147483648)
                {
                    return 0;
                }

                if (dividend < 0)
                {
                    dividend = ~(dividend) + 1;
                }

                if (divisor < 0)
                {
                    divisor = ~(divisor) + 1;
                }


                int temp = dividend;

                int tempCount = 0;
                for (int i = 30; i >= 0; i--)
                {
                    int t = 1 << i;
                    if ((t & divisor) == t)
                    {
                        tempCount = 30 - i;
                        break;
                    }
                }

                for (int i = tempCount; i >= 0; i--)
                {
                    int divisorT = divisor << i;
                    if (divisorT >= 0 && divisorT < 2147483647)
                    {
                        if (divisorT <= dividend)
                        {
                            //Console.WriteLine(i);
                            dividend = dividend - divisorT;
                            result = result | (1 << i);
                        }
                    }
                }

                //while (temp >= divisor) {
                //    result++;
                //    temp = temp - divisor;
                //}

                if (negative)
                {
                    result = ~(result) + 1;
                }

                return result;
            }
        }

        class FastSolution
        {
            public int divide(int A, int B)
            {

                if (B == 0 || (A == Int32.MinValue && B == -1))
                    return Int32.MaxValue;

                long x = Math.Abs((long)A);
                long y = Math.Abs((long)B);
                long result = 0;

                while (x >= y)
                {
                    long temp = y, multiple = 1;

                    while (x >= (temp << 1))
                    {
                        temp <<= 1;
                        multiple <<= 1;
                    }

                    x -= temp;
                    result += multiple;
                }

                if (A < 0 ^ B < 0)
                    result = -result;

                return (result > Int32.MaxValue || result < Int32.MinValue) ? Int32.MaxValue : (int)result;
            }
        }

        class EditorialSolution
        {
            public int divide(int A, int B)
            {
                //handle special cases
                if (B == 0) return int.MaxValue;
                if (B == -1 && A == int.MinValue)
                    return int.MaxValue;

                //get positive values
                long pDividend = Math.Abs((long) A);
                long pDivisor = Math.Abs((long) B);

                int result = 0;
                while (pDividend >= pDivisor)
                {
                    //calculate number of left shifts
                    int numShift = 0;
                    while (pDividend >= (pDivisor << numShift))
                    {
                        numShift++;
                    }

                    //dividend minus the largest shifted divisor
                    result += 1 << (numShift - 1);
                    pDividend -= (pDivisor << (numShift - 1));
                }

                if ((A > 0 && B > 0) || (A < 0 && B < 0))
                {
                    return result;
                }
                else
                {
                    return -result;
                }
            }
        }

    }

}
