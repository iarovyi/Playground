namespace IB.Math
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class PrimeSum
    {
        public static void Test()
        {
            //10 = 3 + 7 = 5 + 5
            var primes = GetTwoPrimesWithSumOf(10);
            primes.Should().BeEquivalentTo(new []{3,7});
        }

        /*
         *If [a, b] is one solution with a <= b,
and [c,d] is another solution with c <= d, then

[a, b] < [c, d] 

If a < c OR a==c AND b < d. 
         *
         */
        private static List<int> GetTwoPrimesWithSumOf(int evenNumber)
        {
            var primes = GetPrimeNumbersUpTo(evenNumber).ToArray();
            var primesSet = new HashSet<int>(primes);
            foreach (int prime in primes)
            {
                int secondPrime = evenNumber - prime;
                if (primesSet.Contains(secondPrime))
                {
                    return new List<int>(){ prime, secondPrime };
                }
            }

            return null;
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
    }
}
