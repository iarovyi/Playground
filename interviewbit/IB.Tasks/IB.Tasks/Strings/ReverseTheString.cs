using System.Text;

namespace IB.Tasks.Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;

    using Xunit;
    public class ReverseTheString
    {
        [Fact]
        public void Test()
        {
            ReverseWordsAndTrimAndUseSingleSpace("the sky is blue").Should().Be("blue is sky the");
            ReverseWordsAndTrimAndUseSingleSpace("this is ib").Should().Be("ib is this");
        }

        public string ReverseWordsAndTrimAndUseSingleSpace(string A)
        {
            var sb = new StringBuilder();
            int letterCount = 0;

            for (int i = A.Length - 1; i >= 0; i--)
            {
                var isLetter = char.IsLetterOrDigit(A[i]);
                if (isLetter)
                {
                    letterCount++;
                }

                if (!isLetter)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" ");
                    }
                    sb.Append(A.Substring(i + 1, letterCount));
                    letterCount = 0;
                }
            }

            if (letterCount > 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }
                sb.Append(A.Substring(0, letterCount));
            }

            return sb.ToString();
        }

        class Solution
        {
            public string solve(string A)
            {
                var st = new Stack<string>();
                var i = 0;
                var charList = new List<char>();
                var result = new System.Text.StringBuilder();
                while (i < A.Length)
                {
                    if (A[i] != ' ')
                    {
                        charList.Add(A[i]);
                    }
                    if (A[i] == ' ')
                    {
                        if (charList.Count > 0)
                        {
                            st.Push(new String(charList.ToArray()));
                            charList.Clear();
                        }
                    }
                    i++;
                }
                if (charList.Count > 0)
                {
                    st.Push(new String(charList.ToArray()));
                }
                while (st.Count > 1)
                {
                    result.Append(st.Pop());
                    result.Append(" ");
                }
                if (st.Count > 0)
                {
                    result.Append(st.Pop());
                }
                return result.ToString();
            }
        }
    }

    /*
     * Given a string A.

Return the string A after reversing the string word by word.

NOTE:

A sequence of non-space characters constitutes a word.

Your reversed string should not contain leading or trailing spaces, even if it is present in the input string.

If there are multiple spaces between words, reduce them to a single space in the reversed string.



Input Format

The only argument given is string A.
Output Format

Return the string A after reversing the string word by word.
For Example

Input 1:
    A = "the sky is blue"
Output 1:
    "blue is sky the"

Input 2:
    A = "this is ib"
Output 2:
    "ib is this"
     */
}
