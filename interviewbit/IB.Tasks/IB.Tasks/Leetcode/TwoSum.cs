namespace IB.Tasks.Leetcode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class TwoSum
    {
        [Fact]
        public void Test()
        {
            GetIndexesOfTwoItemsThatHasTargetSum(new[] {2, 7, 11, 15}, 9).Should().BeEquivalentTo(new[] {0, 1});
            GetIndexesOfTwoItemsThatHasTargetSum(new[] {-1, -2, -3, -4, -5}, -8).Should().BeEquivalentTo(new[] {2,4});
        }

        public int[] GetIndexesOfTwoItemsThatHasTargetSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                //if (nums[i] > target)
                //{
                //    continue;
                //}

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] {i, j};
                    }
                }
            }

            return new int[0];
        }
    }

    /*
     *
     * Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

Example:

Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].
     */
}
