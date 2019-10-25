namespace IB.Tasks.BitManipulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class SingleNumber
    {
        [Fact]
        public void Test()
        {
            GetSingleNotDuplicatedNumber(new List<int>() {1, 2, 2, 3, 1}).Should().Be(3);
        }

        public int GetSingleNotDuplicatedNumber(List<int> A)
        {
            int xor = A[0];
            for (int i = 1; i < A.Count; i++)
            {
                xor = xor ^ A[i];
            }

            return xor;
        }
    }
    /*
     * Given an array of integers, every element appears twice except for one. Find that single one.

Note: Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

Example :

Input : [1 2 2 3 1]
Output : 3
     */
}
