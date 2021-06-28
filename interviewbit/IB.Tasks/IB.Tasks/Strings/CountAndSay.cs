using System.Text;

namespace IB.Tasks.Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class CountAndSay
    {
        [Fact]
        public void Test()
        {
            countAndSay(1).Should().Be("1");
            countAndSay(2).Should().Be("11");      //two 1s or 21
            countAndSay(3).Should().Be("21");      //one 2, then one 1
            countAndSay(4).Should().Be("1211");
            countAndSay(5).Should().Be("111221");

            countAndSay(6).Should().Be("312211");
        }

        public string countAndSay(int A)
        {
            List<char> phrase = new List<char>(){'1'};
            for (int i = 1; i < A; i++)
            {
                phrase = SpellString(phrase);
            }

            return new string(phrase.ToArray());
        }

        private List<char> SpellString(List<char> str)
        {
            if (str.Count == 0)
            {
                return str;
            }

            int i = 0;
            while (i < str.Count)
            {
                char digit = str[i];
                int digitCount = 0;

                for (int j = i; j < str.Count && str[j] == digit; j++)
                {
                    digitCount++;
                }
          
                str.RemoveRange(i + 1, digitCount - 1);
                str.Insert(i, (char)(digitCount + 48));
                i = i + 2;
            }

            return str;
        }

        class Solution
        {
            public string countAndSay(int A)
            {
                if (A == 0)
                {
                    return string.Empty;
                }
                var result = "1";
                for (var i = 1; i < A; i++)
                {
                    result = ReadtheNumber(result);
                }
                return result;
            }

            string ReadtheNumber(string A)
            {
                var result = new System.Text.StringBuilder();
                var i = 1;
                var currentChar = A[0];
                var count = 1;
                while (i < A.Length)
                {
                    if (A[i] != currentChar)
                    {
                        result.Append(count.ToString());
                        result.Append(currentChar.ToString());
                        currentChar = A[i];
                        count = 1;
                    }
                    else
                    {
                        count++;
                    }
                    i++;
                }
                result.Append(count.ToString());
                result.Append(currentChar.ToString());
                return result.ToString();
            }
        }
    }

    /*
     * The count-and-say sequence is the sequence of integers beginning as follows:

1, 11, 21, 1211, 111221, ...
1 is read off as one 1 or 11.
11 is read off as two 1s or 21.

21 is read off as one 2, then one 1 or 1211.

Given an integer n, generate the nth sequence.

Note: The sequence of integers will be represented as a string.

Example:

if n = 2,
the sequence is 11.
     */
}
