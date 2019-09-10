namespace IB.Math
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class ExcelColumnNumber
    {
        public static void Test()
        {
            int colZ = GetExcelColumn("Z");
            colZ.Should().Be(26);

            int colAa = GetExcelColumn("AA");
            colAa.Should().Be(27);

            int colAb = GetExcelColumn("AB");
            colAb.Should().Be(28);
        }

        /*
                101 = 100 + 1 = 2^2 + 2^0 = 4 + 1 = 5
                A  = 26^0            = 1      = 1
                B  = 2 * 26^0        = 2      = 2
                AA = 26^1 + 26^0     = 26 + 1 = 27
                AB = 26^1 + 2 * 26^0 = 26 + 2 = 28
                AC = 26^1 + 3 * 26^0 = 26 + 3 = 29
         */
        private static int GetLetterIndex(char letter) =>
            char.ToUpper(letter) - 64;

        private static int GetExcelColumn(string columnTitle)
        {
            int result = 0;

            for (int i = 0; i < columnTitle.Length; i++)
            {
                int letterVal = GetLetterIndex(columnTitle[columnTitle.Length - i - 1]);
                int power = (int) Math.Pow(26, i);
                result += letterVal * power;
            }

            return result;
        }


        /*
         * Given a column title as appears in an Excel sheet, return its corresponding column number.
         * Example:
         *  A -> 1
            B -> 2
            C -> 3
            ...
            Z -> 26
            AA -> 27
            AB -> 28 
         */
    }
}
