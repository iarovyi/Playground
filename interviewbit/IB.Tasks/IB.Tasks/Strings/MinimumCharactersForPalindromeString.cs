namespace IB.Tasks.Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;

    using Xunit;
    public class MinimumCharactersForPalindromeString
    {
        [Fact]
        public void Test()
        {
            MinPrefixLengthToMakePalindrome("ABC").Should().Be(2);
            MinPrefixLengthToMakePalindrome("AACECAAAA").Should().Be(2);
        }

        /*
         *
         *
         */
        public int MinPrefixLengthToMakePalindrome(string A)
        {
            return new Solution().solve(A);
            return 0;
        }

        class Solution
        {
            public int solve(string A)
            {
                int left = 0; int right = A.Length - 1;
                int sum = 0;
                bool foundPartialMirroring = false;
                while (left < right)
                {
                    if (A[left] != A[right])
                    {

                        if (foundPartialMirroring)
                        {
                            sum += left;
                            left = 0;
                            right++;
                            foundPartialMirroring = false;
                        }
                        else sum++;
                    }
                    else
                    {
                        foundPartialMirroring = true;
                        left++;
                    }
                    right--;
                }
                if (sum == A.Length)
                    sum -= 1;
                return sum;
            }
        }
    }


    /*
     *
     * Given an string A. The only operation allowed is to insert characters in the beginning of the string.

Find how many minimum characters are needed to be inserted to make the string a palindrome string.



Input Format

The only argument given is string A.
Output Format

Return the minimum characters that are needed to be inserted to make the string a palindrome string.
For Example

Input 1:
    A = "ABC"
Output 1:
    2
    Explanation 1:
        Insert 'B' at beginning, string becomes: "BABC".
        Insert 'C' at beginning, string becomes: "CBABC".

Input 2:
    A = "AACECAAAA"
Output 2:
    2
    Explanation 2:
        Insert 'A' at beginning, string becomes: "AAACECAAAA".
        Insert 'A' at beginning, string becomes: "AAAACECAAAA".
     */
}
