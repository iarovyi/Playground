namespace IB.Math
{
    using System;
    using FluentAssertions;

    internal static class ReverseInteger
    {
        public static void Test()
        {
            Reverse(123).Should().Be(321);
            Reverse(-123).Should().Be(-321);
            Reverse(1463847413).Should().Be(0);
        }

        public static int Reverse(int number)
        {
            int integer = Math.Abs(number);
            int reversed = 0;
            try
            {
                while (integer > 0)
                {
                    int digit = integer % 10;
                    checked
                    {
                        reversed = reversed * 10 + digit;
                    }
                    integer = integer / 10;
                }
            }
            catch (OverflowException)
            {
                return 0;
            }
            return number > 0 ? reversed : reversed * -1;
        }


        /*
         Reverse digits of an integer.

        Example1:

        x = 123,

        return 321
        Example2:

        x = -123,

        return -321

        Return 0 if the result overflows and does not fit in a 32 bit signed integer
         */
    }
}
