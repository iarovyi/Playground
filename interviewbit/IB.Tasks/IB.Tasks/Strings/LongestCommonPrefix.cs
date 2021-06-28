namespace IB.Tasks.Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;

    using Xunit;
    public class LongestCommonPrefix
    {
        [Fact]
        public void Test()
        {
            GetLongestCommonPrefix(new List<string>() { "abcdefgh", "aefghijk", "abcefgh" }).Should().Be("a");
            GetLongestCommonPrefix(new List<string>() { "abab", "ab", "abcd" }).Should().Be("ab");
        }

        public string GetLongestCommonPrefix(List<string> A)
        {
            if (!A.Any())
            {
                return "";
            }

            //A.Sort();
            string prefix = A[0];
            for (int i = 0; i < A.Count; i++)
            {
                prefix = CommonPrefix(prefix, A[i]);
                if (prefix.Length == 0)
                {
                    break;
                }
            }

            return prefix;
        }

        private string CommonPrefix(string a, string b)
        {
            for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
            {
                if (a[i] != b[i])
                {
                    return a.Substring(0, i);
                }
            }

            return a.Substring(0, Math.Min(a.Length, b.Length));
        }


        class Solution
        {
            public string longestCommonPrefix(List<string> A)
            {
                var ans = A[0];
                for (int i = 1; i < A.Count; i++)
                {
                    int end;
                    int n = ans.Length > A[i].Length ? A[i].Length : ans.Length;
                    for (end = 0; end < n; end++)
                    {
                        if (A[i][end] != ans[end]) break;
                    }
                    ans = ans.Substring(0, end);
                }
                return ans;
            }
        }
    }

    /*
     * Given the array of strings A,
you need to find the longest string S which is the prefix of ALL the strings in the array.

Longest common prefix for a pair of strings S1 and S2 is the longest string S which is the prefix of both S1
and S2.

For Example, longest common prefix of "abcdefgh" and "abcefgh" is "abc".



Input Format

The only argument given is an array of strings A.
Output Format

Return longest common prefix of all strings in A.
For Example

Input 1:
    A = ["abcdefgh", "aefghijk", "abcefgh"]
Output 1:
    "a"
    Explanation 1:
        Longest common prefix of all the strings is "a".

Input 2:
    A = ["abab", "ab", "abcd"];
Output 2:
    "ab"
    Explanation 2:
        Longest common prefix of all the strings is "ab".
     */
}
