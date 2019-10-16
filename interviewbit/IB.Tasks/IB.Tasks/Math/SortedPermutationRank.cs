namespace IB.Math
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FluentAssertions;

    internal static class SortedPermutationRank
    {
        public static void Test()
        {
            FindRank("acb").Should().Be(2);
            GetRankAmongstItsPermutationsSortedLexicographically2("cba").Should().Be(6);
        }

        public static long FindRank(String A)
        {
            long rank = 1;//assume start rank as 1
            while (A.Length != 1)
            {
                //Count of all smaller left characters
                long counter = 0;
                for (int i = 1; i < A.Length; i++)
                {
                    if (A[i] < A[0])
                    {
                        counter++;
                    }
                }

                //factorial of left string
                long pro = 1;
                for (int k = 1; k < A.Length; k++)
                {
                    pro *= k;
                }
                rank += (counter * pro) % 1000003;
                A = A.Substring(1);
            }
            return (int)(rank % 1000003);
        }

        /*public static int FactorialOf(int number)
        {
            int factorial = 1;
            for (int i = 1; i < number; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }*/

        private static int FactorialOf(int i)
        {
            if (i <= 1)
                return 1;
            return i * FactorialOf(i - 1);
        }

        private static int CountOfSmallerChars(string str, char @char)
        {
            int counter = 0;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] < @char)
                {
                    counter++;
                }
            }

            return counter;
        }

        public static int GetRankAmongstItsPermutationsSortedLexicographically2(string str)
        {
            int rank = 1;
            while (str.Length != 1)
            {
                int smallerCharsCount = CountOfSmallerChars(str, str[0]);
                int factorial = FactorialOf(str.Length);
                rank += (smallerCharsCount * factorial) % 1000003;
                str = str.Substring(1);
            }
            return rank % 1000003;
        }

        private static int GetRankAmongstItsPermutationsSortedLexicographically(string str)
        {
            int beforeCount = 0;
            char[] chars = str.ToCharArray();
            char[] charsSorted = chars.OrderBy(@char => @char).ToArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char @char = chars[i];
                int charIndex = Array.IndexOf(charsSorted, @char);

            }

            return beforeCount + 1;
        }

        /*
         *Given a string, find the rank of the string amongst its permutations sorted lexicographically.
Assume that no characters are repeated.

        Input : 'acb'
Output : 2

The order permutations with letters 'a', 'c', and 'b' : 
abc
acb
bac
bca
cab
cba

        The answer might not fit in an integer, so return your answer % 1000003
         *
         */
    }
}
