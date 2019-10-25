using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Xunit.Abstractions;

namespace IB.Tasks.BitManipulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ReverseBits
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ReverseBits(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private const int MinInt = unchecked((int)0b10000000000000000000000000000000);
        private const int MaxInt = 0b01111111111111111111111111111111;

        [Fact]
        public void Test()
        {
            int source =                   0b00000000000000000000000000000011;
            int expected = unchecked((int) 0b11000000000000000000000000000000);
            int actual = ReverseIntergerBits(source);

            int lightweightResult = (int)new LightweightSolution().reverse(source);
            int editorialResult = (int)new EditorialSolution().reverse(source);
            int fastResult = (int)new FastSolution().reverse(source);
            

            var ff = SwapBits(source, 0, 5).ToBitsString();

            string res = actual.ToBitsString();
            _testOutputHelper.WriteLine($"Final number is: {res}");

            actual.Should().Be(expected);
        }

        private static int SwapBits(int number, int i, int j)
        {
            if ((number & (1 << i)) != (number & (1 << j))) //i-th bit is not equal to j-th bit
            {
                number ^= ((1 << i) | (1 << j));            //toggle i-th and j-th bits
            }

            return number;
        }

        private static int ReverseIntergerBits(int a)
        {
            for (int rightI = 0, leftI = 31; rightI < 16; rightI++, leftI--)
            {
                bool isRightSet = IsSet(a, rightI);
                bool isLeftSet = IsSet(a, leftI);

                if (isRightSet != isLeftSet)
                {
                    a = isRightSet ? SetBit(a, leftI) : UnsetBit(a, leftI);
                    a = isLeftSet ? SetBit(a, rightI) : UnsetBit(a, rightI);
                }
            }

            return a;

            /*for (int rightI = 0, leftI = 31; rightI < 16; rightI++, leftI--)
            {
                bool isRightSet = IsSet(number, rightI);
                bool isLeftSet = IsSet(number, leftI);

                number = isRightSet ? SetBit(number, leftI) : UnsetBit(number, leftI);
                number = isLeftSet ? SetBit(number, rightI) : UnsetBit(number, rightI);
            }

            return number;*/
        }

        private static bool IsSet(int number, int index)
        {
            return (number & (1 << index)) != 0;
        }

        private static int SetBit(int number, int index)
        {
            return number | (1 << index);
        }

        private static int UnsetBit(int number, int index)
        {
            return number & ~(1 << index);
        }


        public class EditorialSolution
        {
            public long reverse(int A)
            {
                int rev = 0;

                for (int i = 0; i < 32; i++)
                {
                    rev <<= 1;
                    if ((A & (1 << i)) != 0)
                        rev |= 1;
                }

                return rev;

            }
        }

        public class FastSolution
        {
            public int reverse(int number)
            {
                int result = 0;

                for (int i = 0; i < 32; i++)
                {
                    result = result << 1;
                    if ((number & 1) == 1)
                    {
                        result += 1;
                    }

                    number = number >> 1;
                }

                return result;
            }

        }


        public class LightweightSolution
        {
            public long reverse(int A)
            {
                int rev = 0;

                /* start at the lowest bit
                    shift it over by 1
                    and if 
                */
                for (int i = 0; i < 32; i++)
                {
                    rev = rev << 1;
                    if ((A & (1 << i)) != 0)
                        rev |= 1;
                }
                return rev;
            }
        }

    }
}
