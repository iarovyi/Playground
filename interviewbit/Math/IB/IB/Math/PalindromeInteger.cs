namespace IB.Math
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class PalindromeInteger
    {
        public static void Test()
        {
            isPalindrome(12321).Should().BeTrue();
            isPalindrome(123).Should().BeFalse();
            isPalindrome(-2147447412).Should().BeFalse();
        }

        private static int GetIntegerLength(int number)
        {
            return (int)Math.Floor(Math.Log10(number) + 1);
        }

        public static bool isPalindrome(int number)
        {
            if (number < 0)
            {
                return false;
            }

            int integer = number, sum = 0;

            while (integer != 0)
            {
                int digitFromRightToLeft = integer % 10;
                //Walking from right to left and building a number from left to right
                sum = sum * 10 + digitFromRightToLeft;
                integer = integer / 10;
            }

            return number == sum;
        }
    }
}
