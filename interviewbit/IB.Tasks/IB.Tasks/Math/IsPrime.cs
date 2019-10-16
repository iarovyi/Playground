namespace IB.Math
{
    using System;
    using FluentAssertions;

    internal static class IsPrime
    {
        public static void Test()
        {
            bool is36Prime = IsPrimeNumber(36);
            bool is17Prime = IsPrimeNumber(17);
            bool is97Prime = IsPrimeNumber(97);

            is97Prime.Should().BeTrue();
            is17Prime.Should().BeTrue();
            is36Prime.Should().BeFalse();
        }

        public static bool IsPrimeNumber(int number)
        {
            if (number == 1)
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
