using System.Linq;

namespace IB.Math
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class ExcelColumnTitle
    {
        public static void Test()
        {
            string bcsus = GetExcelColumn(980089);
            bcsus.Should().Be("BCSUS");

            string a = GetExcelColumn(1);
            a.Should().Be("A");

            string b = GetExcelColumn(2);
            b.Should().Be("B");

            string z = GetExcelColumn(26);
            z.Should().Be("Z");
        }

        //private static int GetLetterIndex(char letter) =>
        //    char.ToUpper(letter) - 64;

        private static char GetLetterIndex(int letterIndex)
        {
            return Convert.ToChar(letterIndex + 64);
        }


        /*
            980089   19  S
            37695    21  U
            1449     19  S
            55       3   C
            2        2   B
         */
        private static string GetExcelColumn(int columnIndex)
        {
            var result = new List<char>();
            int rest = columnIndex;
            do
            {
                int charIndex = rest % 26;
                if (charIndex == 0)
                {
                    charIndex = 26;
                    rest = rest - 26;
                }

                char letter = GetLetterIndex(charIndex);
                result.Add(letter);
                rest = rest / 26;
            } while (rest > 0);

            return string.Join("", result.Select(i => i.ToString()).Reverse());
        }

        //private static int GetExcelIndex(string columnTitle)
        //{
        //    int result = 0;

        //    for (int i = 0; i < columnTitle.Length; i++)
        //    {
        //        int letterVal = GetLetterIndex(columnTitle[columnTitle.Length - i - 1]);
        //        int power = (int)System.Math.Pow(26, i);
        //        result += letterVal * power;
        //    }

        //    return result;
        //}

        /*
         *  1 -> A
            2 -> B
            3 -> C
            ...
            26 -> Z
            27 -> AA
            28 -> AB 
 */
    }
}
