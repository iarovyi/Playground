namespace IB.Arrays.Bucketing
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using FluentAssertions;

    public static class FindDuplicateInArray
    {
        public static void Test()
        {
            //http://algorithmsforinterview.blogspot.com/2012/09/using-xor-operator-for-finding.html
            int xor =   0b0000_0000_0000_0001;// 1; 0b0000_0000_0000_0001
            xor = xor ^ 0b0000_0000_0000_0010;// 2; 0b0000_0000_0000_0011
            //xor = xor ^ 0b0000_0000_0000_0011;// 3; 0b0000_0000_0000_0000
            xor = xor ^ 0b0000_0000_0000_0100;// 4; 0b0000_0000_0000_0100

            xor = xor ^ 0b0000_0000_0000_0001;// 1; 0b0000_0000_0000_0101
            xor = xor ^ 0b0000_0000_0000_0010;// 2; 0b0000_0000_0000_0111
            xor = xor ^ 0b0000_0000_0000_0010;// 2; 0b0000_0000_0000_0101
            xor = xor ^ 0b0000_0000_0000_0011;// 3; 0b0000_0000_0000_0110
            xor = xor ^ 0b0000_0000_0000_0100;// 4; 0b0000_0000_0000_0010
            xor = xor ^ 0b0000_0000_0000_0011;// 3; 0b0000_0000_0000_0000

            bool foundDuplicate = xor == 2;

            FindNumberRepeatedOnce(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 5 }).Should().Be(5);

            FindNumberRepeatedOnce(new List<int>() { 54, 55, 56, 57, 58, 55 }).Should().Be(55); //FAIL
            //FindNumberRepeatedOnce(new List<int>() {2, 55, 88, 3, 5, 55}).Should().Be(55);      //FAIL

            new SolutionEditorial().repeatedNumber(new List<int>() { 3, 4, 1, 4, 1 }).Should().Be(1);//1 or 4

            var bigList = new List<int>(){ 247, 240, 303, 9, 304, 105, 44, 204, 291, 26, 242, 2, 358, 264, 176, 289, 196, 329, 189, 102, 45, 111, 115, 339, 74, 200, 34, 201, 215, 173, 107, 141, 71, 125, 6, 241, 275, 88, 91, 58, 171, 346, 219, 238, 246, 10, 118, 163, 287, 179, 123, 348, 283, 313, 226, 324, 203, 323, 28, 251, 69, 311, 330, 316, 320, 312, 50, 157, 342, 12, 253, 180, 112, 90, 16, 288, 213, 273, 57, 243, 42, 168, 55, 144, 131, 38, 317, 194, 355, 254, 202, 351, 62, 80, 134, 321, 31, 127, 232, 67, 22, 124, 271, 231, 162, 172, 52, 228, 87, 174, 307, 36, 148, 302, 198, 24, 338, 276, 327, 150, 110, 188, 309, 354, 190, 265, 3, 108, 218, 164, 145, 285, 99, 60, 286, 103, 119, 29, 75, 212, 290, 301, 151, 17, 147, 94, 138, 272, 279, 222, 315, 116, 262, 1, 334, 41, 54, 208, 139, 332, 89, 18, 233, 268, 7, 214, 20, 46, 326, 298, 101, 47, 236, 216, 359, 161, 350, 5, 49, 122, 345, 269, 73, 76, 221, 280, 322, 149, 318, 135, 234, 82, 120, 335, 98, 274, 182, 129, 106, 248, 64, 121, 258, 113, 349, 167, 192, 356, 51, 166, 77, 297, 39, 305, 260, 14, 63, 165, 85, 224, 19, 27, 177, 344, 33, 259, 292, 100, 43, 314, 170, 97, 4, 78, 310, 61, 328, 199, 255, 159, 185, 261, 229, 11, 295, 353, 186, 325, 79, 142, 223, 211, 152, 266, 48, 347, 21, 169, 65, 140, 83, 156, 340, 56, 220, 130, 117, 143, 277, 235, 59, 205, 153, 352, 300, 114, 84, 183, 333, 230, 197, 336, 244, 195, 37, 23, 206, 86, 15, 187, 181, 308, 109, 293, 128, 66, 270, 209, 158, 32, 25, 227, 191, 35, 40, 13, 175, 146, 299, 207, 217, 281, 30, 357, 184, 133, 245, 284, 343, 53, 210, 306, 136, 132, 239, 155, 73, 193, 278, 257, 126, 331, 294, 250, 252, 263, 92, 267, 282, 72, 95, 337, 154, 319, 341, 70, 81, 68, 160, 8, 249, 96, 104, 137, 256, 93, 178, 296, 225, 237 };
            FindAnyRepeatedNumber(bigList).Should().Be(73);
            FindAnyRepeatedNumber(new List<int>() {3, 4, 1, 4, 1}).Should().Be(1);//1 or 4
        }

        /// <param name="A">
        ///  Sequential numbers with only one duplicated number
        /// </param>
        /// <returns></returns>
        public static int FindNumberRepeatedOnce(List<int> A)
        {
            //x ^ x = 0

            int min = A.Min();
            int max = A.Max();

            int xor = A[0];
            for (int i = 1; i < A.Count; i++)
            {
                xor = xor ^ A[i];
            }

            for (int i = min; i <= max; i++)
            {
                xor = xor ^ i;
            }

            return xor;
        }


        public static int FindAnyRepeatedNumber(List<int> A)
        {
            var copy = A.ToList();
            copy.Sort();

            for (int i = 1, prev = copy[0]; i < A.Count; prev = copy[i], i++)
            {
                if (prev == copy[i])
                {
                    return prev;
                }
            }

            return -1;
        }


        class SolutionEditorial
        {
            //https://medium.com/solvingalgo/solving-algorithmic-problems-find-a-duplicate-in-an-array-3d9edad5ad41
            //O(1) Space, 1 pass
            public int repeatedNumber(List<int> A)
            {
                if (A.Count < 2) return -1;
                //sum of all numbers from 1 to n
                long sum = -1L * A.Count * (A.Count - 1) / 2;
                foreach (int i in A)
                {
                    sum += i;
                }
                return (int)sum;
            }
        }

        class SolutionFastest
        {
            public int repeatedNumber(List<int> A)
            {
                int a = 0;
                int e = 0;
                for (int i = 0; i < A.Count; ++i)
                {
                    a = a ^ A[i];
                    e = e ^ (i);
                }

                return a ^ e;
            }
        }

        class SolutionLightweight
        {
            HashSet<int> set = new HashSet<int>();
            public int repeatedNumber(List<int> A)
            {
                if (A.Count() == 0) return -1;
                for (int i = 0; i < A.Count(); i++)
                {
                    if (set.Contains(A[i])) return A[i];
                    else set.Add(A[i]);
                }

                return -1;
            }
        }
    }

    /*
     * Given a read only array of n + 1 integers between 1 and n, find one number that repeats in linear time using less than O(n) space and traversing the stream sequentially O(1) times.

Sample Input:

[3 4 1 4 1]
Sample Output:

1
If there are multiple possible answers ( like in the sample case above ), output any one.

If there is no duplicate, output -1





    Note that summing up the numbers or XOR of the numbers is not going to work in this case.

Can you try solving the problem in sqrt(n) space?

Split the numbers from 1 to n in sqrt(n) ranges so that range i corresponds to [sqrt(n) * i .. sqrt(n) * (i + 1)).



    Split the numbers from 1 to n in sqrt(n) ranges so that range i corresponds to [sqrt(n) * i .. sqrt(n) * (i + 1)).

Do one pass through the stream of numbers and figure out how many numbers fall in each of the ranges.

At least one of the ranges will contain more than sqrt(n) elements.

Do another pass and process just those elements in the oversubscribed range.

Using a hash table to keep frequencies, you’ll find a repeated element.

This is O(sqrt(n)) memory and 2 sequential passes through the stream.
     */
}
