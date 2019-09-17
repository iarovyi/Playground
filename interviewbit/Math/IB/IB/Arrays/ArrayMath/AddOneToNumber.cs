namespace IB.Arrays.ArrayMath
{
    using System.Collections.Generic;
    using FluentAssertions;

    internal static class AddOneToNumber
    {
        public static void Test()
        {
            PlusOne(new List<int>() {1, 2, 3}).Should().BeEquivalentTo(new List<int>() {1, 2, 4});
            PlusOne(new List<int>() { 0, 1, 2, 3 }).Should().BeEquivalentTo(new List<int>() { 1, 2, 4 });
            PlusOne(new List<int>() { 9,9,9,9,9 }).Should().BeEquivalentTo(new List<int>() { 1,0,0,0,0,0 });
        }


        // 19999 + 1
        public static List<int> PlusOne(List<int> digits)
        {
            int addition = 1;

            for (int i = digits.Count - 1; i >= 0; i--)
            {
                int digit = digits[i];
                int newDigit = digit + addition;
                if (newDigit > 9)
                {
                    addition = newDigit - 9;
                    newDigit = 0;
                }
                else
                {
                    addition = 0;
                }


                digits[i] = newDigit;
            }

            if (addition != 0)
            {
                var newDigits = new List<int>(digits.Count + 1) {addition};
                newDigits.AddRange(digits);
                digits = newDigits;
            }

            while (digits.Count > 0 && digits[0] == 0)
            {
                digits.RemoveAt(0);
            }

            return digits;
        }

        /*
         *Given a non-negative number represented as an array of digits,

add 1 to the number ( increment the number represented by the digits ).

The digits are stored such that the most significant digit is at the head of the list.

Example:

If the vector has [1, 2, 3]

the returned vector should be [1, 2, 4]

as 123 + 1 = 124
         *
         */
    }
}
