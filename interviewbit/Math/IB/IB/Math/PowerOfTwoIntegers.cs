using System;

namespace IB.Math
{
    using FluentAssertions;

    internal static class PowerOfTwoIntegers
    {
        public static void Test()
        {
            bool is1024064001 = IsThereNumberInSomePowerEqualsTo(1024064001);
            is1024064001.Should().BeTrue();

            bool is823543 = IsThereNumberInSomePowerEqualsTo(823543);
            is823543.Should().BeTrue();

            bool is4 = IsThereNumberInSomePowerEqualsTo(4);
            is4.Should().BeTrue();
        }

        public static bool IsThereNumberInSomePowerEqualsTo(int number)
        {
            for (int i = 2; i < 64; i++)
            {
                var root = NthRoot(number, i);
                Console.WriteLine($"{root}^{i}={number} ({(IsInteger(root)? "INTEGER":"not integer")})");
                if (IsInteger(root))
                {
                    return true;
                }

                /*int rounded = (int)System.Math.Round(root, MidpointRounding.AwayFromZero);
                System.Math.Pow(number, i)*/
            }

            return false;
        }

        //private static int IntPow(int x, uint pow)
        //{
        //    int ret = 1;
        //    while (pow != 0)
        //    {
        //        if ((pow & 1) == 1)
        //            ret *= x;
        //        x *= x;
        //        pow >>= 1;
        //    }
        //    return ret;
        //}

        private static bool IsInteger(double number)
        {
            return System.Math.Abs(number % 1) < 0.00000001;//(Double.Epsilon * 100);
        }

        private static double NthRoot(double A, int N)
        {
            return System.Math.Pow(A, 1.0 / N);
        }

        public static int RightAnswer(int A)
        {
            if (A == 1)
                return 1;
            for (int i = 2; i * i <= A; i++)
            {
                double baseLog = System.Math.Log(A) / i;
                int @base = (int)System.Math.Exp(baseLog);
                if (System.Math.Abs(System.Math.Pow(@base, i) - A) < 0.00000001)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
