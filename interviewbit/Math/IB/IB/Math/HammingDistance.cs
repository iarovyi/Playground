namespace IB.Math
{
    using System.Collections.Generic;
    using FluentAssertions;

    internal static class HammingDistance
    {
        public static void Test()
        {
            var hammigDistance = HammigDistance(2, 7);
            hammigDistance.Should().Be(2);

            var sum = SumOfHammingDistanceForAllPairsInList(new List<int>() {2, 4, 6});
            sum.Should().Be(8);
        }

        public static int SumOfHammingDistanceForAllPairsInList(List<int> numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    sum += HammigDistance(numbers[i], numbers[j]);
                }
            }

            return sum;
        }

        static bool IsBitSet(int b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }

        //https://stackoverflow.com/questions/12171584/what-is-the-fastest-way-to-count-set-bits-in-uint32
        static int NumberOfSetBits(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
        }

        public static int HammigDistance(int a, int b)
        {
            int differentBitsCount = 0;

            for (int i = 0; i < 32; i++)
            {
                bool isABitSet = (a & (1 << i)) != 0;
                bool isBBitSet = (b & (1 << i)) != 0;
                if (isABitSet != isBBitSet)
                {
                    differentBitsCount++;
                }

            }

            return differentBitsCount;

            /*int differentBitsCount = 0;
            int restA = a;
            int restB = b;

            do
            {
                //int bitA = restA % 2 == 0 ? 0 : 1;
                //int bitB = restB % 2 == 0 ? 0 : 1;
                if ((restA % 2) != (restB % 2)) ///bitA != bitB
            {
                differentBitsCount++;
                }

                restA = restA / 2;
                restB = restB / 2;
            } while (restA > 0 || restB > 0);

            return differentBitsCount;*/
        }

        static int countSetBits(int n)
        {
            int count = 0;
            while (n > 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }
    }

    /*
     Hamming distance between two non-negative integers is defined as the number of positions at which the corresponding bits are different.

For example,

HammingDistance(2, 7) = 2, as only the first and the third bit differs in the binary representation of 2 (010) and 7 (111).

Given an array of N non-negative integers, find the sum of hamming distances of all pairs of integers in the array.
Return the answer modulo 1000000007.

    Let f(x, y) be the hamming distance defined above.

A=[2, 4, 6]

We return,
f(2, 2) + f(2, 4) + f(2, 6) + 
f(4, 2) + f(4, 4) + f(4, 6) +
f(6, 2) + f(6, 4) + f(6, 6) = 

0 + 2 + 1
2 + 0 + 1
1 + 1 + 0 = 8
     */
}
