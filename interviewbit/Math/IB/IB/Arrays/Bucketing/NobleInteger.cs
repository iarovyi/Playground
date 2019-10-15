using FluentAssertions;

namespace IB.Arrays.Bucketing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class NobleInteger
    {
        public static void Test()
        {
            var numbers = new List<int>()
            {
                -4, 7, 5, 3, 5, -4, 2, -1, -9, -8, -3, 0, 9, -7, -4, -10, -4, 2, 6, 1, -2, -3, -1, -8, 0, -8, -7, -3, 5, -1, -8, -8, 8, -1, -3, 3, 6, 1, -8, -1, 3, -9, 9, -6, 7, 8, -6, 5, 0, 3, -4, 1, -10, 6, 3, -8, 0, 6, -9, -5, -5, -6, -3, 6, -5, -4, -1, 3, 7, -6, 5, -8, -5, 4, -3, 4, -6, -7, 0, -3, -2, 6, 8, -2, -6, -7, 1, 4, 9, 2, -10, 6, -2, 9, 2, -4, -4, 4, 9, 5, 0, 4, 8, -3, -9, 7, -8, 7, 2, 2, 6, -9, -10, -4, -9, -5, -1, -6, 9, -10, -1, 1, 7, 7, 1, -9, 5, -1, -3, -3, 6, 7, 3, -4, -5, -4, -7, 9, -6, -2, 1, 2, -1, -7, 9, 0, -2, -2, 5, -10, -1, 6, -7, 8, -5, -4, 1, -9, 5, 9, -2, -6, -2, -9, 0, 3, -10, 4, -6, -6, 4, -3, 6, -7, 1, -3, -5, 9, 6, 2, 1, 7, -2, 5


                /*,-10,-10,-10,-10,-10,-10,-10,
                -9,-9,-9,-9,-9,-9,-9,-9,-9,
                -8,-8,-8,-8,-8,-8,-8,-8,-8,
                -7,-7,-7,-7,-7,-7,-7,-7,          //8
                -6,-6,-6,-6,-6,-6,-6,-6,-6,-6,-6, //11
                -5,-5,-5,-5,-5,-5,-5,-5,
                -4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,
                -3,-3,-3,-3,-3,-3,-3,-3,-3,-3,-3,-3,
                -2,-2,-2,-2,-2,-2,-2,-2,-2,-2,
                -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
                0,0,0,0,0,0,0,0,
                1,1,1,1,1,1,1,1,1,1,
                2,2,2,2,2,2,2,2,
                3,3,3,3,3,3,3,3,
                4,4,4,4,4,4,4,
                5,5,5,5,5,5,5,5,5,5,
                6,6,6,6,6,6,6,6,6,6,6,6, //12
                7,7,7,7,7,7,7,7,7,   //9
                8,8,8,8,8,           //5
                9,9,9,9,9,9,9,9,9,9  //10*/
            };

            DoesArrayContainsNAndNNumbersBiggerThanN(numbers).Should().BeFalse();
            DoesArrayContainsNAndNNumbersBiggerThanN(new List<int>() { 1, 2, 3, 4, 7, 8, 9, 7 }).Should().BeTrue();
            DoesArrayContainsNAndNNumbersBiggerThanN(new List<int>() { 1, 2, 3, 4, 7, 8, 3, 7 }).Should().BeFalse();
        }

        public static bool DoesArrayContainsNAndNNumbersBiggerThanN(List<int> A /*A[0] is size*/)
        {
            A.Sort();

            for (int i = 0; i < A.Count; i++)
            {
                int n = A[i];

                for (int j = i + 1; j < A.Count && A[j] == n; j++)
                {
                    i = j;
                }

                int biggerThanNCount = A.Count - i - 1;
                if (biggerThanNCount == n)
                {
                    return true; //1
                }
            }

            return false; //-1
        }


        class Solution
        {

            private static int MyComparision(string A, string B)
            {
                if (A.StartsWith(B) || B.StartsWith(A))
                {

                    long num1 = long.Parse(A + B);
                    long num2 = long.Parse(B + A);
                    return (int)(num1 - num2);
                }

                return A.CompareTo(B);
            }

            public string largestNumber(List<int> A)
            {
                var strA = new List<string>();
                foreach (int elem in A)
                {
                    strA.Add(elem.ToString());
                }
                strA.Sort(Solution.MyComparision);
                strA.Reverse();
                var maxStr = string.Join("", strA.ToArray());
                maxStr = maxStr.TrimStart('0');
                if (string.IsNullOrEmpty(maxStr))
                {
                    maxStr = "0";
                }
                return maxStr;
            }
        }
    }

    /*
     * Given an integer array, find if an integer p exists in the array such that the number of integers greater than p in the array equals to p
If such an integer is found return 1 else return -1.

    There are 1 lines in the input

Line 1 ( Corresponds to arg 1 ) : An integer array. First number is the size S of the array. Then S numbers follow which indicate the elements in the array.

     */
}
