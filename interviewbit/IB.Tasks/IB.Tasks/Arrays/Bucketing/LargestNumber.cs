using System.Collections;
using System.Linq;

namespace IB.Arrays.Bucketing
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class LargestNumber
    {
        public static void Test()
        {
            GetLargestNumber(new List<int>() {3, 30, 34, 5, 9}).Should().Be("9534330");
        }

        private static int GetTheMostSignificantDigit(int number)
        {
            while (number % 10 > 10)
            {
                number %= 10;
            }

            return number;
        }

        /*
         *
         * function largestNumber(A) {
        var sortedA = A.sort(function (a,b) {
            return (b.toString()+a.toString()) - (a.toString()+b.toString());
        }).filter(function(v) { return v>0});
        return sortedA.length == 0 ? '0' : sortedA.join('');
}
         */

        public static string GetLargestNumber(List<int> A)
        {
            A.Sort((a, b) =>
            {
                return (int)(long.Parse(b.ToString() + a.ToString()) - long.Parse(a.ToString() + b.ToString()));
            });

            A = A.Where(i => i > 0).ToList();

            return A.Count == 0 ? "0" : string.Join("", A.Select(i => i.ToString()).ToArray());

            /* List<int> largestCombination = new List<int>();
             Dictionary<int, List<int>> byDigit = new Dictionary<int, List<int>>(10);
             for (int i = 0; i < A.Count; i++)
             {
                 int number = A[i];
                 int digit = GetTheMostSignificantDigit(number);
                 if (!byDigit.ContainsKey(digit))
                 {
                     byDigit[digit] = new List<int>();
                 }
 
                 byDigit[digit].Add(number);
             }
 
             foreach (var digitNumbers in byDigit)
             {
                 digitNumbers.Value.Sort();
             }
 
             for (int digit = 9; digit >= 0; digit--)
             {
                 if (!byDigit.ContainsKey(digit))
                 {
                     continue;
                 }
 
                 List<int> numbers = byDigit[digit];
                 List<int> nextDigitNumbers = byDigit.ContainsKey(digit - 1) ? byDigit[digit - 1] : null;
 
                 while (numbers.Any())
                 {
 
                     if (numbers.First() == digit)
                     {
 
                     }
                     else
                     {
                         largestCombination.Add(numbers.Last());
                         numbers.RemoveAt(numbers.Count - 1);
                     }
 
                 }
 
             }
 
             
 
             return string.Join("", largestCombination);*/
        }
    }

    /*
     * Given a list of non negative integers, arrange them such that they form the largest number.

For example:

Given [3, 30, 34, 5, 9], the largest formed number is 9534330.

Note: The result may be very large, so you need to return a string instead of an integer.
     */
}
