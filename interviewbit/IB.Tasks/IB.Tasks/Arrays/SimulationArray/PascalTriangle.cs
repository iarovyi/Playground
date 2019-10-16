namespace IB.Arrays.SimulationArray
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class PascalTriangle
    {
        public static void Test()
        {
            GeneratePascalTriangle(5).Should().BeEquivalentTo(new List<List<int>>()
            {
                new List<int>(){ 1 },
                new List<int>(){ 1,1 },
                new List<int>(){ 1,2,1 },
                new List<int>(){ 1,3,3,1 },
                new List<int>(){ 1,4,6,4,1 }
            });
        }

        //Pascal’s triangle : To generate A[C] in row R, sum up A’[C] and A’[C-1] from previous row R - 1.
        public static List<List<int>> GeneratePascalTriangle(int A)
        {
            var triangle = new List<List<int>>(A);
            List<int> previousRow = null;
            for (int rowIndex = 0; rowIndex < A; rowIndex++)
            {
                var row = new List<int>(rowIndex + 1);
                triangle.Add(row);

                for (int columnIndex = 0; columnIndex < row.Capacity; columnIndex++)
                {
                    if (columnIndex == 0 || columnIndex == row.Capacity - 1)
                    {
                        row.Add(1);
                    }
                    else
                    {
                        int newValue = previousRow[columnIndex] + previousRow[columnIndex - 1];
                        row.Add(newValue);
                    }
                }

                previousRow = row;
            }

            //PrintTriangle(triangle);

            return triangle;
        }

        private static void PrintTriangle(List<List<int>> triangle)
        {
            foreach (var row in triangle)
            {
                foreach (int n in row)
                {
                    Console.Write($" {n}");
                }

                Console.WriteLine();
            }
        }
    }

    /*
     * Given numRows, generate the first numRows of Pascal’s triangle.

Pascal’s triangle : To generate A[C] in row R, sum up A’[C] and A’[C-1] from previous row R - 1.

Example:

Given numRows = 5,

Return

[
     [1],
     [1,1],
     [1,2,1],
     [1,3,3,1],
     [1,4,6,4,1]
]
     */
}
