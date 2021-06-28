namespace IB.Tasks.Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class LengthOfLastWord
    {
        [Fact]
        public void Test()
        {
            GetLengthOfLastWord("Hello World").Should().Be(5);
            GetLengthOfLastWord("d").Should().Be(1);
            GetLengthOfLastWord(" sKhHkumCICcmISZR").Should().Be(16);
        }

        public int GetLengthOfLastWord(string A)
        {
            int letterCount = 0;
            for (int i = A.Length - 1; i >= 0; i--)
            {
                bool isLetter = char.IsLetterOrDigit(A[i]);
                if (isLetter)
                {
                    letterCount++;
                }

                if (letterCount != 0 && !isLetter)
                {
                    break;
                }
            }

            return letterCount;
        }
    }
}


    /*
     * Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.

If the last word does not exist, return 0.

Note: A word is defined as a character sequence consists of non-space characters only.

Example:

Given s = "Hello World",

return 5 as length("World") = 5.

Please make sure you try to solve this problem without using library functions. Make sure you only traverse the string once.
     */
