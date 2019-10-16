namespace IB.Math
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class GreatestCommonDivisor
    {
        public static void Test()
        {
            GetGreatestCommonDivisor(30, 18).Should().Be(6);
        }

        //Алгоритм нахождения НОД Евлклида
        //https://younglinux.info/algorithm/euclidean
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
    }
}
