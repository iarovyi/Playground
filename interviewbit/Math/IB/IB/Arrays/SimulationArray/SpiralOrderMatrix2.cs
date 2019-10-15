namespace IB.Arrays.SimulationArray
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal class SpiralOrderMatrix2
    {
        public static void Test()
        {
            var expectedMatrix3 = new List<List<int>>()
            {
                new List<int>(){ 1,2,3 },
                new List<int>(){ 8,9,4 },
                new List<int>(){ 7,6,5 }
            };
            var matrix3 = GenerateMatrix(3);
            matrix3.Should().BeEquivalentTo(expectedMatrix3);

            var expectedMatrix4 = new List<List<int>>()
            {
                new List<int>(){ 1,   2,  3,  4 },
                new List<int>(){ 12, 13, 14,  5 },
                new List<int>(){ 11, 16, 15,  6 },
                new List<int>(){ 10,  9,  8,  7 }
            };
            var matrix4 = GenerateMatrix(4);
            matrix4.Should().BeEquivalentTo(expectedMatrix4);
        }


        public static List<List<int>> GenerateMatrix(int A)
        {
            if (A == 0)
            {
                return new List<List<int>>(0);
            }

            var matrix = GenerateEmptyMatrix(A);

            int xDirection = 1;
            int yDirection = 0;
            int xMin = 0;
            int xMax = A - 1;
            int yMin = 0;
            int yMax = A - 1;
            matrix[0][0] = 1;
            int previousX = 0;
            int previousY = 0;

            for (int n = 2, x = 0, y = 0; n <= A * A; n++, previousX = x, previousY = y)
            {
                x = xDirection > 0 ? x + 1 : (xDirection < 0 ? x - 1 : x);
                y = yDirection > 0 ? y + 1 : (yDirection < 0 ? y - 1 : y);
                bool isXChanged = x != previousX;
                bool isYChanged = y != previousY;

                if (x == xMin && y == yMin && isYChanged)
                {
                    xDirection = 1;
                    yDirection = 0;
                    xMin++;
                } else if (x == xMax && y == yMin && isXChanged)
                {
                    xDirection = 0;
                    yDirection = 1;
                    yMin++;
                } else if (x == xMax && y == yMax && isYChanged)
                {
                    xDirection = -1;
                    yDirection = 0;
                    xMax--;
                } else if (x == xMin && y == yMax && isXChanged)
                {
                    xDirection = 0;
                    yDirection = -1;
                    yMax--;
                }

                matrix[y][x] = n;

                //Console.WriteLine($"N = {n}, x={x}, y={y} direction=[{xDirection},{yDirection}] {(isXChanged ? "x" : "")} {(isYChanged ? ",y" : "")} changed");
                //PrintMatrix(matrix);
            }


            return matrix;
        }

        public static List<List<int>> GenerateEmptyMatrix(int A)
        {
            var matrix = new List<List<int>>(A);
            for (int i = 0; i < A; i++)
            {
                var row = new List<int>(A);
                for (int j = 0; j < A; j++)
                {
                    row.Add(0);
                }
                matrix.Add(row);
            }

            return matrix;
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var row in matrix)
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
     *
     * Given an integer A, generate a square matrix filled with elements from 1 to A2 in spiral order.



Input Format:

The first and the only argument contains an integer, A.
Output Format:

Return a 2-d matrix of size A x A satisfying the spiral order.
Constraints:

1 <= A <= 1000
Examples:

Input 1:
    A = 3

Output 1:
    [   [ 1, 2, 3 ],
        [ 8, 9, 4 ],
        [ 7, 6, 5 ]   ]

Input 2:
    4

Output 2:
    [   [1, 2, 3, 4],
        [12, 13, 14, 5],
        [11, 16, 15, 6],
        [10, 9, 8, 7]   ]
     */
}
