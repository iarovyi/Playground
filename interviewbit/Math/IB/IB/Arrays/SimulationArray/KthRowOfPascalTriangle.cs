namespace IB.Arrays.SimulationArray
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;

    internal static class KthRowOfPascalTriangle
    {
        public static void Test()
        {
            GetPascalTriangleRow(0).Should().BeEquivalentTo(new List<int>() { 1 });
            GetPascalTriangleRow(1).Should().BeEquivalentTo(new List<int>() { 1, 1 });
            GetPascalTriangleRow(2).Should().BeEquivalentTo(new List<int>() { 1, 2, 1 });
            GetPascalTriangleRow(3).Should().BeEquivalentTo(new List<int>() { 1, 3, 3, 1 });
            GetPascalTriangleRow(4).Should().BeEquivalentTo(new List<int>() { 1, 4, 6, 4, 1 });
        }

        public static List<int> GetPascalTriangleRow(int A)
        {
            if (A == 0)
            {
                return new List<int>() { 1 };
            }

            var row = new List<int>(A + 1) { 1 };
            for (int i = 1; i < A; i++)
            {
                row.Add(0);
            }
            row.Add(1);

            for (int rowIndex = 1, rowSize = rowIndex + 1; rowIndex <= A; rowIndex++, rowSize++)
            {
                for (int i = rowSize - 2; i > 0; i--)
                {
                    row[i] = row[i] + row[i - 1];
                }

                row[rowSize - 1] = 1;
            }

            return row;
        }

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
     * Given an index k, return the kth row of the Pascal’s triangle.

Pascal’s triangle : To generate A[C] in row R, sum up A’[C] and A’[C-1] from previous row R - 1.

Example:

Input : k = 3

Return : [1,3,3,1]
 NOTE : k is 0 based. k = 0, corresponds to the row [1]. 
Note:Could you optimize your algorithm to use only O(k) extra space?
     */
}
