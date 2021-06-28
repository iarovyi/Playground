using System.Text.RegularExpressions;

namespace IB.Tasks.Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class PalindromeString
    {
        [Fact]
        public void Test()
        {
            IsPalindromeConsideringOnlyAlphanumeric("A man, a plan, a canal: Panama").Should().BeTrue();
            IsPalindromeConsideringOnlyAlphanumeric("race a car").Should().BeFalse();
        }

        public bool IsPalindromeConsideringOnlyAlphanumeric(string A)
        {
            string str = A.ToLower();
            int startI = 0;
            int endI = str.Length - 1;
            while (startI < endI)
            {
                while (!char.IsLetterOrDigit(str[startI]) && startI < str.Length - 1)
                {
                    startI++;
                }

                while (!char.IsLetterOrDigit(str[endI]) && endI > 0)
                {
                    endI--;
                }

                if (startI >= endI)
                {
                    break;
                }

                if (char.ToLower(str[startI]) != char.ToLower(str[endI]))
                {
                    return false;
                }

                startI++;
                endI--;
            }

            return true;
        }

        class Solution
        {
            public int isPalindrome(string A)
            {
                Regex r = new Regex("^[a-zA-Z0-9]*$");
                var start = 0; var end = A.Length - 1;
                while (start <= end)
                {
                    if (!r.IsMatch(A[start].ToString()))
                    {
                        start++; continue;
                    }
                    if (!r.IsMatch(A[end].ToString()))
                    {
                        end--; continue;
                    }
                    if (A[start].ToString().ToLower() != A[end].ToString().ToLower())
                    {
                        return 0;
                    }
                    start++; end--;
                }
                return 1;
            }
        }
}


    /*
     *
     * Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

Example:

"A man, a plan, a canal: Panama" is a palindrome.

"race a car" is not a palindrome.

Return 0 / 1 ( 0 for false, 1 for true ) for this problem
     */
}
