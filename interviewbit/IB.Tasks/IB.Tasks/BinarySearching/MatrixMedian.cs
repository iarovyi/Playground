namespace IB.Tasks.BinarySearching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class MatrixMedian
    {
        [Fact]
        public void Test()
        {
            FindMedian(new List<List<int>>()
            {
                new List<int>(){ 1, 3, 5 },
                new List<int>(){ 2, 6, 9 },
                new List<int>(){ 3, 6, 9 }
            }).Should().Be(5);
        }

        public int FindMedian(List<List<int>> A)
        {
            return new Solution().findMedian(A);
        }

        class Solution
        {
            public int findMedian(List<List<int>> arrList)
            {

                var min = int.MaxValue;
                var max = int.MinValue;

                var r = arrList.Count;
                var c = arrList[0].Count;

                foreach (var t in arrList)
                {
                    if (t[0] < min)
                    {
                        min = t[0];
                    }

                    var m = t.Count - 1;

                    if (t[m] > max)
                    {
                        max = t[m];
                    }
                }

                var desired = (r * c + 1) / 2;

                while (min < max)
                {
                    var mid = min + (max - min) / 2;
                    var place = 0;

                    for (int i = 0; i < r; i++)
                    {
                        var get = Array.BinarySearch(arrList[i].ToArray(), mid);

                        if (get < 0)
                        {
                            get = Math.Abs(get) - 1;
                        }
                        else
                        {
                            while (get < arrList[i].Count && arrList[i][get] == mid)
                            {
                                get++;
                            }
                        }

                        place = place + get;
                    }

                    if (place < desired)
                    {
                        min = mid + 1;
                    }
                    else
                    {
                        max = mid;
                    }
                }

                return min;
            }
        }
    }

    /*
     * Given a N cross M matrix in which each row is sorted, find the overall median of the matrix. Assume N*M is odd.

For example,

Matrix=
[1, 3, 5]
[2, 6, 9]
[3, 6, 9]

A = [1, 2, 3, 3, 5, 6, 6, 9, 9]

Median is 5. So, we return 5.
     */


}
