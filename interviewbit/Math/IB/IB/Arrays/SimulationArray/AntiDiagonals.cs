namespace IB.Arrays.SimulationArray
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class AntiDiagonals
    {
        public static void Test()
        {
            var matrix3 = new List<List<int>>()
            {
                new List<int>(){ 1, 2, 3 },
                new List<int>(){ 4, 5, 6 },
                new List<int>(){ 7, 8, 9 },
            };
            GetDiagonals(matrix3).Should().BeEquivalentTo(new List<List<int>>()
            {
                new List<int>(){ 1, },
                new List<int>(){ 2, 4 },
                new List<int>(){ 3, 5, 7 },
                new List<int>(){ 6, 8 },
                new List<int>(){ 9, }
            });

            var matrix2 = new List<List<int>>()
            {
                new List<int>(){ 1, 2 },
                new List<int>(){ 3, 4 }
            };
            GetDiagonals(matrix2).Should().BeEquivalentTo(new List<List<int>>()
            {
                new List<int>(){ 1, },
                new List<int>(){ 2, 3 },
                new List<int>(){ 4 }
            });
        }

        /*
         * Input: 	

1 2 3
4 5 6
7 8 9

Return the following :

[ 
  [1],
  [2, 4],
  [3, 5, 7],
  [6, 8],
  [9]
]
         */
        public static List<List<int>> GetDiagonals(List<List<int>> A)
        {
            var diagonals = new List<List<int>>(A.Count * 2 - 1);

            for (int i = 0; i < diagonals.Capacity; i++)
            {
                int diagonalSize = i < A.Count ?  i + 1 : diagonals.Capacity - i;
                var diagonal = new List<int>(diagonalSize);
                diagonals.Add(diagonal);

                if (i < A.Count)
                {
                    for (int x = i, y = 0; x >= 0; x--, y++)
                    {
                        int item = A[y][x];
                        diagonal.Add(item);
                    }
                }
                else
                {
                    for (int y = i - A.Count + 1, x = A.Count - 1; y < A.Count; y++, x--)
                    {
                        int item = A[y][x];
                        diagonal.Add(item);
                    }
                }

                Print(diagonals);
            }

            return diagonals;
        }

        private static void Print(List<List<int>> matrix)
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
     * Give a N*N square matrix, return an array of its anti-diagonals. Look at the example for more details.

Example:

		
Input: 	

1 2 3
4 5 6
7 8 9

Return the following :

[ 
  [1],
  [2, 4],
  [3, 5, 7],
  [6, 8],
  [9]
]


Input : 
1 2
3 4

Return the following  : 

[
  [1],
  [2, 3],
  [4]
]

     */
}
