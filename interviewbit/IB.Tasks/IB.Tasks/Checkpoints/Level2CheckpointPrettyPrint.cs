namespace IB.Tasks.Checkpoints
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    /// <summary>
    /// https://www.interviewbit.com/problems/prettyprint/
    /// </summary>
    public class Level2CheckpointPrettyPrint
    {
        [Fact]
        public void Test()
        {
            PrintConcentricRectangularPattern(4).Should().BeEquivalentTo(new List<List<int>>()
            {
                new List<int>(){ 4, 4, 4, 4, 4, 4, 4 }, //0
                new List<int>(){ 4, 3, 3, 3, 3, 3, 4 }, //1
                new List<int>(){ 4, 3, 2, 2, 2, 3, 4 }, //2
                new List<int>(){ 4, 3, 2, 1, 2, 3, 4 }, //3
                new List<int>(){ 4, 3, 2, 2, 2, 3, 4 }, //2
                new List<int>(){ 4, 3, 3, 3, 3, 3, 4 }, //1
                new List<int>(){ 4, 4, 4, 4, 4, 4, 4 }  //0
            });

            PrintConcentricRectangularPattern(3).Should().BeEquivalentTo(new List<List<int>>()
            {
                new List<int>(){ 3, 3, 3, 3, 3 }, //5 0
                new List<int>(){ 3, 2, 2, 2, 3 }, //3 1
                new List<int>(){ 3, 2, 1, 2, 3 }, //1 2
                new List<int>(){ 3, 2, 2, 2, 3 }, //3 3
                new List<int>(){ 3, 3, 3, 3, 3 }  //5 4
            });
        }

        public List<List<int>> PrintConcentricRectangularPattern(int A)
        {
            int sideLength = A * 2 - 1;
            var rows = GetMatrix(A);
            int center = sideLength / 2;
            int repeatingStartIndex = 0;

            for (int rowI = 0; rowI < sideLength; rowI++)
            {
                var row = rows[rowI];
                for (int leftI = 0, rightI = sideLength - 1, number = A; leftI <= center; leftI++, rightI--)
                {
                    row[leftI] = number;
                    if (leftI != rightI)
                    {
                        row[rightI] = number;
                    }

                    if (leftI < repeatingStartIndex)
                    {
                        number--;
                    }
                }

                repeatingStartIndex = rowI >= sideLength / 2 ? --repeatingStartIndex : ++repeatingStartIndex;
            }


            return rows;
        }

        private List<List<int>> GetMatrix(int size)
        {
            int sideLength = size * 2 - 1;
            var rows = new List<List<int>>();
            for (int i = 0; i < sideLength; i++)
            {
                var row = new List<int>(sideLength);
                for (int j = 0; j < sideLength; j++)
                {
                    row.Add(0);
                }
                rows.Add(row);
            }

            return rows;
        }
    }

    /*
     * Print concentric rectangular pattern in a 2d matrix.
Let us show you some examples to clarify what we mean.

Example 1:

Input: A = 4.
Output:

4 4 4 4 4 4 4 
4 3 3 3 3 3 4 
4 3 2 2 2 3 4 
4 3 2 1 2 3 4 
4 3 2 2 2 3 4 
4 3 3 3 3 3 4 
4 4 4 4 4 4 4 
Example 2:

Input: A = 3.
Output:

3 3 3 3 3 
3 2 2 2 3 
3 2 1 2 3 
3 2 2 2 3 
3 3 3 3 3 
The outermost rectangle is formed by A, then the next outermost is formed by A-1 and so on.

You will be given A as an argument to the function you need to implement, and you need to return a 2D array.
     */
}
