namespace IB.Math
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal class GetPrimeNumbers
    {
        public static void Test()
        {
            var primesUpTo7 = GetPrimeNumbersUpTo(7);
            primesUpTo7.Should().BeEquivalentTo(new[] {2, 3, 5, 7});
        }


        public static List<int> GetPrimeNumbersUpTo(int upperBoundIncluding)
        {
            var primes = new int[upperBoundIncluding + 1];
            for (int i = 2; i < primes.Length; i++)
            {
                primes[i] = 1;
            }

            for (int i = 2; i <= Math.Sqrt(upperBoundIncluding); i++)
            {
                if (primes[i] == 1)
                {
                    for (int j = i + i; j < primes.Length; j = j + i)
                    {
                        primes[j] = 0;
                    }
                }
            }

            var result = new List<int>();
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] == 1)
                {
                    result.Add(i);
                    //yield return i;
                }
            }

            return result;
        }

        /* Trial Division method - n * (n^(1/2))
        public static IList<int> GetPrimeNumbersUpTo(int upperBoundIncluding)
        {
            var primes = new List<int>();

            for (int i = 0; i <= upperBoundIncluding; i++)
            {
                if (IsPrimeNumber(i))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }*/

        private static bool IsPrimeNumber(int number)
        {
            if (number < 2)
            {
                return false;
            }

            double sqrt = Math.Sqrt(number);
            for (int i = 2; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
