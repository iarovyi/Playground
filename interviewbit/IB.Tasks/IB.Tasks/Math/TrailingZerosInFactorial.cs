namespace IB.Math
{

    /*
     *Aproach:
     * The idea is:

The ZERO comes from 10.

The 10 comes from 2 x 5

And we need to account for all the products of 5 and 2, like 4×5 = 20 …

So, if we take all the numbers with 5 as a factor, we will have plenty of even numbers to pair with them to get factors of 10

Example 1:

How many multiples of 5 are there between 1 and 23?

These are 5, 10, 15, and 20, for four multiples of 5. Paired with 2s from the even factors, this makes for four factors of 10, so: 23! has 4 zeros.

Example 2:

How many multiples of 5 are there in the numbers from 1 to 100?

Because 100 ÷ 5 = 20, so, there are twenty multiples of 5 between 1 and 100.

But wait, actually 25 is 5×5, so each multiple of 25 has an extra factor of 5, e.g. 25 × 4 = 100，which introduces an extra of zero.

So, we need to know how many multiples of 25 are there between 1 and 100? Since 100 ÷ 25 = 4, there are four multiples of 25 between 1 and 100.

Finally, we get 20 + 4 = 24 trailing zeroes in 100!

The above examples tell us that we need to care about 5, 5×5, 5×5×5, 5×5×5×5 …

Example 3:

For given number 4617.

5^1 : 4617 ÷ 5 = 923.4, so we get 923 factors of 5

5^2 : 4617 ÷ 25 = 184.68, so we get 184 additional factors of 5

5^3 : 4617 ÷ 125 = 36.936, so we get 36 additional factors of 5

5^4 : 4617 ÷ 625 = 7.3872, so we get 7 additional factors of 5

5^5 : 4617 ÷ 3125 = 1.47744, so we get 1 more factor of 5

5^6 : 4617 ÷ 15625 = 0.295488, which is less than 1, so stop here.

Therefore, 4617! has 923 + 184 + 36 + 7 + 1 = 1151 trailing zeroes.
     *
     */
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class TrailingZerosInFactorial
    {
        public static void Test()
        {
            var fff = GetPrimeFactors(120);

            //5! = 120
            GetTrailingZeroesOfFactorial(5).Should().Be(1);
            GetTrailingZeroesOfFactorial(9247).Should().Be(2307);
        }

        public static int FactorialOf(int number)
        {
            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }


        /*
         * n = 5: There is one 5 and 3 2s in prime factors of 5! (2 * 2 * 2 * 3 * 5). So count of trailing 0s is 1.
           n = 11: There are two 5s and three 2s in prime factors of 11! (2 8 * 34 * 52 * 7). So count of trailing 0s is 2.
         */
        public static Dictionary<int,int> GetPrimeFactors(int number)
        {
            Dictionary<int, int> factorsWithCounts = new Dictionary<int, int>();
            for (int i = 2; i <= number; i++)
            {
                int iCount = 0;
                while (number % i == 0)
                {
                    iCount++;
                    number = number / i;
                }

                if (iCount != 0)
                {
                    factorsWithCounts[i] = iCount;
                }
            }

            return factorsWithCounts;
        }

        public static int GetTrailingZeroesOfFactorial(int number)
        {
            int trailingZerosCount = 0;
            for (int i = 1; i < int.MaxValue; i++)
            {
                int fiveInPower = (int)Math.Pow(5, i);
                int fivesCount = number / fiveInPower;
                trailingZerosCount = trailingZerosCount + fivesCount;
                if (fivesCount == 0)
                {
                    break;
                }

            }
            return trailingZerosCount;

            //5^1 : 4617 ÷ 5 = 923.4, so we get 923 factors of 5

            //int count2 = 0;
            //int count5 = 0;
            //int factorial = fa
            //for (int i = 2; i <= 5; i++)
            //{
            //    int iCount = 0;
            //    while (number % i == 0)
            //    {
            //        iCount++;
            //        number = number / i;
            //    }

            //    if (i == 2)
            //    {
            //        count2 = iCount;
            //    }

            //    if (i == 5)
            //    {
            //        count5 = iCount;
            //    }
            //}

            //return Math.Min(count2, count5);






            //var factorial = FactorialOf(number);


            //var factors = GetPrimeFactors(factorial);
            //int count2 = factors.TryGetValue(2, out int twoCount) ? twoCount : 0;
            //int count5 = factors.TryGetValue(5, out int fiveCount) ? fiveCount : 0;
            //return Math.Min(count2, count5);


            /*int factorial = FactorialOf(number);

            int trailingZeroCount = 0;
            int integer = factorial;
            while (integer > 0)
            {
                int digit = integer % 10;
                if (digit != 0)
                {
                    break;
                }

                trailingZeroCount++;
                integer = integer / 10;
            }

            return trailingZeroCount;*/
        }
    }
}
