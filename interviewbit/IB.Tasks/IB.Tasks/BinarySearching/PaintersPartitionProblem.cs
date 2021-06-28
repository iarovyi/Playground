namespace IB.Tasks.BinarySearching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class PaintersPartitionProblem
    {
        [Fact]
        public void Test()
        {
            GetMinimumTimeToPaintAllBoards(2, 1, new List<int>() { 1, 20, 40, 41 })
                .Should().Be(61);

            GetMinimumTimeToPaintAllBoards(2, 5, new List<int>() {1, 10})
                .Should().Be(50);
        }

        public class ReverseComparer<T> : IComparer<T>
        {
            public int Compare(T x, T y)
            {
                return Comparer<T>.Default.Compare(y, x);
            }
        }

        /*
         * 1  20  40  41
         * 102 101 81 41
         *   
         *  51
         */

        /// <summary>
        /// K : Number of painters
        /// T : Time taken by painter to paint 1 unit of board
        /// L : A List which will represent length of each board
        /// </summary>
        public int GetMinimumTimeToPaintAllBoards(int numberOfPainters, int unitTimeTaken, List<int> boardSizes)
        {
            boardSizes.Sort();
            int totalUnits = boardSizes.Sum();
            int[] sums = new int[boardSizes.Count];
            int optimalUnitsPerPainter = totalUnits / numberOfPainters;

            for (int i = sums.Length - 1, sum = 0; i >= 0; i--)
            {
                sums[i] = boardSizes[i] + sum; 
                sum += boardSizes[i];
            }

           // int[] reversedSums = ((int[]) sums.Clone()).Reverse().ToArray();

            int plannedBoardsStartI = sums.Length;
            int plannedUnits = 0;
            long maxPainterUnits = 0;
            int plannedPainters = 0;

            while (plannedBoardsStartI > 0)
            {
                int painterStartI = Array.BinarySearch(sums, 0, plannedBoardsStartI, optimalUnitsPerPainter + plannedUnits, new ReverseComparer<int>());
                if (painterStartI < 0)
                {
                    painterStartI = Math.Abs(~painterStartI) - 1;
                    if (plannedPainters == numberOfPainters - 1)
                    {
                        painterStartI = 0;
                    }
                }

                plannedBoardsStartI = painterStartI;
                int painterUnits = sums[painterStartI] - plannedUnits;
                plannedUnits += painterUnits;
                maxPainterUnits = Math.Max(maxPainterUnits, painterUnits);
                plannedPainters++;
            }

            long result = maxPainterUnits * unitTimeTaken;

            return (int)(result % 10000003);
        }

        class Solution
        {

            public bool IsPossible(List<int> arr, int m, int currMin)
            {
                var currSum = 0;
                var painter = 1;

                for (var i = 0; i < arr.Count; i++)
                {
                    if (arr[i] > currMin)
                        return false;

                    if (currSum + arr[i] > currMin)
                    {
                        painter++;
                        currSum = arr[i];

                        if (painter > m)
                            return false;
                    }
                    else
                    {
                        currSum += arr[i];
                    }
                }

                return true;
            }

            public int paint(int m, int b, List<int> arr)
            {
                var sum = 0;

                for (var i = 0; i < arr.Count; i++)
                    sum += arr[i];

                var start = 0;
                var end = sum;
                var result = int.MaxValue;

                while (start <= end)
                {
                    int mid = (start + end) / 2;

                    if (IsPossible(arr, m, mid))
                    {
                        result = Math.Min(mid, result);
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }

                return (int)(((long)result * b) % 10000003);
            }
        }

    }
    /*
     * You have to paint N boards of length {A0, A1, A2, A3 … AN-1}. There are K painters available and you are also given how much time a painter takes to paint 1 unit of board. You have to get this job done as soon as possible under the constraints that any painter will only paint contiguous sections of board.

2 painters cannot share a board to paint. That is to say, a board
cannot be painted partially by one painter, and partially by another.
A painter will only paint contiguous boards. Which means a
configuration where painter 1 paints board 1 and 3 but not 2 is
invalid.
Return the ans % 10000003

Input :
K : Number of painters
T : Time taken by painter to paint 1 unit of board
L : A List which will represent length of each board

Output:
     return minimum time to paint all boards % 10000003
Example

Input : 
  K : 2
  T : 5
  L : [1, 10]
Output : 50
     */
}
