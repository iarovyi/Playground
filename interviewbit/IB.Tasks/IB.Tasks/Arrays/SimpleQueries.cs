namespace IB.Tasks.Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    /// <summary>
    /// https://www.interviewbit.com/problems/simple-queries/
    /// </summary>
    public class SimpleQueries
    {
        [Fact]
        public void Test()
        {
            new Solution().Solve(new List<int>() { 1, 2, 4 }, new List<int>() { 1, 2, 3, 4, 5, 6 })
                .Should().BeEquivalentTo(new List<int>() { 8, 8, 8, 2, 2, 1 });

            //1 * 2 * 4 = 8
            GetProductOfItsDivisors(4, (int)Math.Pow(10, 9) + 7).Should().Be(8);

            Solve(new List<int>() {1, 2, 4}, new List<int>() {1, 2, 3, 4, 5, 6})
                .Should().BeEquivalentTo(new List<int>() { 8, 8, 8, 2, 2, 1 });
        }

        public List<int> Solve(List<int> A, List<int> B)
        {
            /*
    1. [1]							1
    2. [1, 2]						2
    3. [1, 2, 4]					4
    4. [2]							2
    5. [2, 4]						4
    6. [4]							4


            1  1
            2  2
            4  3
             */
            //Find sums of sub-arrays
            int sumsCount = (A.Count + 1) * A.Count / 2;
            var subArraySums = new List<int>(sumsCount);
            for (int startIndex = 0; startIndex < A.Count; startIndex++)
            {
                int maxForStartingIndex = int.MinValue;
                for (int endIndex = startIndex; endIndex < A.Count; endIndex++)
                {
                    maxForStartingIndex = Math.Max(maxForStartingIndex, A[endIndex]);
                    subArraySums.Add(maxForStartingIndex);
                }
            }

            //Divide by product of its own divisors
            int mod = (int)Math.Pow(10, 9) + 7;
            for (int i = 0; i < subArraySums.Count; i++)
            {
                int product = GetProductOfItsDivisors(subArraySums[i], mod);
                subArraySums[i] = product;
            }

            //Revert
            subArraySums.Sort((a,b)=> a.CompareTo(b) * -1);

            //Perform query
            var result = new List<int>(B.Count);
            for (int i = 0; i < B.Count; i++)
            {
                int indexToQuery = B[i];
                int queryResult = subArraySums[indexToQuery - 1];
                result.Add(queryResult);
            }

            return result;
        }

        private int GetProductOfItsDivisors(int n, int mod)
        {
            //var divisors = GetDivisors(n);

            /*int countOfDivisors = (int)Math.Sqrt(n);
            double product = Math.Pow(n, countOfDivisors / 2d);
            int result = (int)(product % mod);
            return result;*/

            long product = 1;

            for (int smallerDivisor = 1; smallerDivisor <= Math.Sqrt(n); smallerDivisor++)
            {
                if (n % smallerDivisor == 0)
                {
                    product = (product * smallerDivisor) % mod;

                    int biggerDivisor = n / smallerDivisor;
                    if (biggerDivisor != smallerDivisor)
                    {
                        product = (product * biggerDivisor) % mod;
                    }
                }
            }

            return (int)product;
        }

        private List<int> GetDivisors(int n)
        {
            var divisors = new List<int>();

            for (int smallerDivisor = 1; smallerDivisor <= Math.Sqrt(n); smallerDivisor++)
            {
                if (n % smallerDivisor == 0)
                {
                    divisors.Add(smallerDivisor);
                    int biggerDivisor = n / smallerDivisor;
                    if (biggerDivisor != smallerDivisor)
                    {
                        divisors.Add(biggerDivisor);
                    }
                }
            }

            return divisors;
        }



        public class Solution
        {
            public List<int> Solve(List<int> A, List<int> B)
            {
                int n = A.Count;
                Stack<int> st = new Stack<int>();
                int[] left = new int[n];
                for (int i = 0; i < n; ++i)
                {
                    while (st.Count != 0 && A[st.Peek()] < A[i])
                    {
                        st.Pop();
                    }

                    left[i] = st.Count == 0 ? -1 : st.Peek();
                    st.Push(i);
                }

                st = new Stack<int>();
                int[] right = new int[n];
                for (int i = n - 1; i >= 0; --i)
                {
                    while (st.Count != 0 && A[st.Peek()] <= A[i])
                    {
                        st.Pop();
                    }

                    right[i] = st.Count == 0 ? n : st.Peek();
                    st.Push(i);
                }

                Dictionary<int, int> products = new Dictionary<int, int>();
                List<int[]> counts = new List<int[]>();
                for (int i = 0; i < n; ++i)
                {
                    int cnt = (i - left[i]) * (right[i] - i);
                    int a = A[i];

                    if (!products.TryGetValue(a, out int pr))
                    {
                        pr = ToProductOfDivisors(a);
                        products.Add(a, pr);
                    }
                    counts.Add(new int[] { pr, cnt });
                }

                counts.Sort((o1, o2) => o2[0] - o1[0]);

                int[] values = new int[n];
                long[] bounds = new long[n];
                for (int i = 0; i < n; ++i)
                {
                    int[] c = counts[i];
                    values[i] = c[0];
                    bounds[i] = c[1];

                    if (i > 0)
                    {
                        bounds[i] += bounds[i - 1];
                    };
                    if (bounds[i] > int.MaxValue * 2L)
                    {
                        bounds[i] = int.MaxValue * 2L;
                    };
                }

                List<int> res = new List<int>();
                foreach (int q in B)
                {
                    int pos = Array.BinarySearch(bounds, q);
                    if (pos < 0)
                    {
                        pos = -1 - pos;
                    }
                    res.Add(values[pos]);
                }

                return res;
            }

            private static readonly long Modulo = (long)(1e9 + 7);

            private int ToProductOfDivisors(int number)
            {
                long product = number;
                for (int i = 2; i * i <= number; ++i)
                {
                    if (number % i != 0) { continue; };
                    int divisor = (i * i == number) ? i : number;
                    product = (product * divisor) % Modulo;
                }
                return (int)product;
            }
        }
    }

    /*
     * You are given an array A having N integers.

You have to perform the following steps in a given order.

generate all subarrays of A.
take the maximum element from each subarray of A and insert it into a new array G.
replace every element of G with the product of their divisors mod 1e9 + 7.
sort G in descending order
perform Q queries
In each query, you are given an integer K, where you have to find the Kth element in G.

Note: Your solution will run on multiple test cases so do clear global variables after using them.


Input Format

The first argument given is an Array A, having N integers.
The second argument given is an Array B, where B[i] is the ith query.
Output Format

Return an Array X, where X[i] will have the answer for the ith query.
Constraints

1 <= N <= 1e5
1 <= A[i] <= 1e5
1 <= Q <= 1e5
1 <= k <= (N * (N + 1))/2 
For Example

Input:
    A = [1, 2, 4]
    B = [1, 2, 3, 4, 5, 6]
Output:
    X = [8, 8, 8, 2, 2, 1]
   
Explanation:
    subarrays of A	  maximum element
    ------------------------------------
    1. [1]							1
    2. [1, 2]						2
    3. [1, 2, 4]					4
    4. [2]							2
    5. [2, 4]						4
    6. [4]							4

	original
	G = [1, 2, 4, 2, 4, 4]
	
	after changing every element of G with product of their divisors
	G = [1, 2, 8, 2, 8, 8]
	
	after sorting G in descending order
	G = [8, 8, 8, 2, 2, 1]



    A brute force solution to solve this problem is to do as instructed in the statement.
But this will give time out.
So can we reduce complexity?
Can we do Binary Search for each query?
do you know product of divisors of a number can be written as N D/2, where N is number and D is number of divisors of N.


    We can solve this problem by doing the binary search for each query.
How?
First, you need to find that how many times an element will appear in array G. i.e in how many subarrays an element is the greatest one.
You can find that by finding the next greater element for the current element in both sides and then by multiplying them.
Once you found the frequency of each element in an array G, you can sort the pairs(product_of_divisors_of_element, frequency) according to there value in descending order followed by taking the prefix sum of there frequencies you can do the binary search for each query.

Please refer complete solution for more insight.
     */
}