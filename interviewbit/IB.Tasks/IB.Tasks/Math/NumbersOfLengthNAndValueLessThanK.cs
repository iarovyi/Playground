namespace IB.Math
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using FluentAssertions;

    internal static class NumbersOfLengthNAndValueLessThanK
    {
        public static void Test()
        {
            GetCountOfPossibleNumbers2(new[] {0, 1, 5}, 1, 2).Should().Be(2);
            GetCountOfPossibleNumbers2(new[] { 0, 1, 2, 5 }, 2, 21).Should().Be(5);
        }

        /*
 *0 1 5 
 *0 1 2 5 
 */
        private static int GetCountOfPossibleNumbers(int[] sortedDigits, int digitLength, int maxValue)
        {




            return 0;
        }

        public static int GetCountOfPossibleNumbers2(int[] A, int B, int C)
        {
            int count = 0;
            string a = "";
            for (int i = 0; i < C; i++)
            {
                a += i;
                int rem = 0;
                if (a.Length == B)
                {
                    string[] b = a.Split("");
                    int[] cp = new int[a.Length];
                    for (int k = 0; k < a.Length; k++)
                    {
                        cp[k] = int.Parse(b[k]);
                    }
                    for (int k = 0; k < a.Length; k++)
                    {
                        bool ans = A.Contains(cp[k]);
                        if (ans) { rem++; }
                    }
                    if (rem == B) { count++; }
                }
                a = "";
            }

            return count;
        }

        /*
         *
         * Given a set of digits (A) in sorted order, find how many numbers of length B are possible whose value is less than number C.
         * Input:
	  0 1 5  
	  1  
	  2  
	Output:  
	  2 (0 and 1 are possible)  

	Input:
	  0 1 2 5  
	  2  
	  21  
	Output:
	  5 (10, 11, 12, 15, 20 are possible)


        1 <= B <= 9, 0 <= C <= 1e9 & 0 <= A[i] <= 9


        Hint:
        Access Hint
Find solution of each cases seperately.

Case 1 : When B is greater than length of C
Case 2: When B is smaller than length of C
Case 3: When B is equal to length of C.
         */
    }
}
