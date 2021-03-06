﻿namespace IB.Tasks.Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class AmazingSubarrays
    {
        [Fact]
        public void Test()
        {
            CountAllSubstringsThatStartsWithVowel("ABEC").Should().Be(6);
        }
        /*
         * ABEC
         * 	1. A
	        2. AB
	        3. ABE
	        4. ABEC
	        5. E
	        6. EC
         */
        public int CountAllSubstringsThatStartsWithVowel(string A)
        {
            long count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (IsVowel(A[i]))
                {
                    int localCount = (A.Length - i);
                    count = (count + localCount) % 10003;
                }
            }

            return (int)count;
        }

        private bool IsVowel(char character)
        {
            return character == 'a' || character == 'e' || character == 'i' || character == 'o' || character == 'u' ||
                   character == 'A' || character == 'E' || character == 'I' || character == 'O' || character == 'U';
        }
    }
}

    /*
     * You are given a string S, and you have to find all the amazing substrings of S.

Amazing Substring is one that starts with a vowel (a, e, i, o, u, A, E, I, O, U).

Input

Only argument given is string S.
Output

Return a single integer X mod 10003, here X is number of Amazing Substrings in given string.
Constraints

1 <= length(S) <= 1e6
S can have special characters
Example

Input
    ABEC

Output
    6

Explanation
	Amazing substrings of given string are :
	1. A
	2. AB
	3. ABE
	4. ABEC
	5. E
	6. EC
	here number of substrings are 6 and 6 % 10003 = 6.
     */
