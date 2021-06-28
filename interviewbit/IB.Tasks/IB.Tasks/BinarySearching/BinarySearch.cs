namespace IB.Tasks.BinarySearching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class BinarySearch
    {
        [Fact]
        public void Test()
        {
            FindWithBinarySearch(new List<int>() { 1,2,3,4,5,6,7,8 }, 4).Should().Be(3);
        }

        private int FindWithBinarySearch(List<int> list, int item)
        {
            int startI = 0;
            int endI = list.Count - 1;

            while (startI <= endI)
            {
                int mid = startI + (endI - startI) / 2;

                int midItem = list[mid];
                if (midItem == item)
                {
                    return mid;
                } 
                
                if (midItem > item)
                {
                    endI = mid - 1;
                } else if (midItem < item)
                {
                    startI = mid + 1;
                }
            }

            return -1;
        }
    }
}
