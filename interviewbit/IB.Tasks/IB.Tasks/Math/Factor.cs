namespace IB.Math
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using FluentAssertions;

    internal static class Factor
    {
        public static void Test()
        {
            //1, 7, 29, 203, 421, 2947, 12209, 85463
            var factorsOf85463 = FactorsOf(85463);

            //36 18 12 9  6  4  3   2   1
            int[] expected = new[] {1, 2, 3, 4, 6, 9, 12, 18, 36};
            var factors = FactorsOf(36);
            expected.Should().BeEquivalentTo(factors);
        }

        public static IList<int> FactorsOf(int number)
        {
            var smallFactors = new List<int>() { /*1, number*/ };
            var bigFactors = new List<int>();
            int sqrt = (int)Math.Sqrt(number);

            for (int i = 1; i <= sqrt; i++)
            {
                int remainder = number % i;
                if (remainder == 0)
                {
                    smallFactors.Add(i);
                    int remainder2 = number / i;
                    if (remainder2 != sqrt)
                    {
                        bigFactors.Add(remainder2);
                    }
                }
            }

            bigFactors.Reverse();
            return smallFactors.Union(bigFactors).ToList();
        }
    }
}
