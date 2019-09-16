namespace IB.Math
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class SortedPermutationRank
    {
        public static void Test()
        {
            GetRankAmongstItsPermutationsSortedLexicographically("acb").Should().Be(2);
        }

        private static int GetRankAmongstItsPermutationsSortedLexicographically(string str)
        {
            return 1;
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
