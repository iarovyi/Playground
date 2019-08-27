namespace IB.Math
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using FluentAssertions;

    internal static class Converter
    {
        public static void Test()
        {
             string binary357 = ToNumberSystemOf(2, 357);
             string triple357 = ToNumberSystemOf(3, 357);

            /*int decimal6 = FromBinary("110");
            decimal6.Should().Be(6);

            string binary6 = ToBinary(6);
            binary6.Should().Be("110");

            string binary357 = ToBinary(357);
            binary357.Should().Be("101100101");*/
        }

        private static string ToNumberSystemOf(int numberSystem, int number)
        {
            if (numberSystem > 10) { throw new ArgumentOutOfRangeException(nameof(numberSystem));}

            var result = new List<int>();
            while (number > 0)
            {
                result.Add(number % numberSystem);
                number = number / numberSystem;
            }

            return string.Join("", result.Select(i => i.ToString()).Reverse());
        }


        //Now any number like 1010110 can be expressed as 1000000 + 10000 + 100 + 10 = 2^6 + 2^4 + 2^2 + 2^1
        private static int BinaryToDecimal(string binary)
        {
            int result = 0;
            for (int i = binary.Length - 1, power = 0; i >= 0; i--, power++)
            {
                var character = binary[i];
                bool is1 = character == '1' ? true :
                           character == '0' ? false :
                                              throw new ArgumentException("Number can contain only 0 or 1");

                if (is1)
                {
                    result += (int)Math.Pow(2, power);
                }
            }

            return result;
        }

        private static string DecimalToBinary(int number)
        {
            var result = new List<int>();
            int rest = number;
            do
            {
                result.Add(rest % 2 == 0 ? 0 : 1);
                rest = rest / 2;
            } while (rest > 0);

            return string.Join("", result.Select(i => i.ToString()).Reverse());
        }
    }
}
