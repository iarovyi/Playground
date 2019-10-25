namespace IB.Tasks.BitManipulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class BitHelper
    {
        //Hacker's Delight 1st Edition - book about bit hacks
        //TODO https://catonmat.net/low-level-bit-hacks



        #region Alternatives
        private const int MinInt = unchecked((int)0b10000000000000000000000000000000);
        private const int MaxInt = 0b01111111111111111111111111111111;
        public static int ToggleBitsIncludingSignBit(this int number) => ~number;
        public static int ToggleBitsExceptSignBit(this int number) => number ^ MaxInt;
        public static int Negate(this int number) => ~number + 1; //In two's complement system (like int,long in C#)
        #endregion

        #region Tricks

        public static bool IsBitSet(this int number, int index) => (number & (1 << index)) != 0;
        public static int SetBit(this int number, int index) => number | (1 << index);
        public static int UnsetBit(this int number, int index) => number & ~(1 << index);

        public static int ToggleBit(this int number, int index) => number ^ (1 << index);



        public static bool IsEven(this int number) => (number & 1) == 0;
        public static int ClearTheLowestSetBit(int number) => number & (number - 1);
        public static int ExtractLowestSetBitAndRest0(int number) => number & ~(number - 1);


        /*
              01010111 (x)      01011000 (x)
            & 01010110 (x-1)  & 01010111 (x-1)
              --------          --------
              01010110          01010000
              Subtracting 1 will underflow so all "0" after it will become "1" and last "1" will become "0"
              So it will be:    <unchanged part> 1 <zeros>
                              & <unchanged part> 0 <ones>
                                -------------------------
                                <unchanged part> 0 <zeros>
         */
        public static int UnsetTheRightmost1Bit(this int number) => number & (number - 1);

        /*
           -x=~x+1 (in "Two's Complement" system)
        1)              2)  01000011   3)   10111100               
           ~ 10111100     + 00000001      & 01000100  (-x or ~x+1)    
             --------       --------        --------                  
             01000011       01000100        00000100  
            Adding one makes them carry this one all the way to bit 1, which is the first zero bit. 

               <unchanged part> 1 <zeros>
             & <toggled part>   1 <zeros>
               --------------------------
               <zeros>          1 <zeros>
         */
        public static int KeepOnlyRightmost1Bit(this int number) => number & (-number);

        /*
            1) 10111100  2)  10111100  (x)         <unchanged> 1 <zeros>
             - 00000001    | 10111011  (x-1)     | <unchanged> 0 <ones>
               --------      --------              ---------------------
               10111011      10111111              <unchanged> 1 <ones>
         */
        public static int ToggleRightTrailingZeros(this int number) => number | (number - 1);


        /*
                01110111  (x)           10111100  (x)
                --------                --------
                10001000  (~x)          01000011  (~x)
            &   01111000  (x+1)     &   10111101  (x+1)
                --------                --------
                00001000                00000001
         */
        public static int ToggleRightmost0AndRest0(this int number) => ~number & (number + 1);

        /*
x & (x + (1 << n)) = x, with the run of set bits (possibly length 0) starting at bit n cleared.
x & ~(x + (1 << n)) = the run of set bits (possibly length 0) in x, starting at bit n.
x | (x + 1) = x with the lowest cleared bit set.
x | ~(x + 1) = extracts the lowest cleared bit of x (all others are set).
x | (x - (1 << n)) = x, with the run of cleared bits (possibly length 0) starting at bit n set.
x | ~(x - (1 << n)) = the lowest run of cleared bits (possibly length 0) in x, starting at bit n are the only clear bits.
         */
        #endregion


        public static int CountSetBits(long number)
        {
            int setBitsCount = 0;
            while (number > 0)
            {
                setBitsCount += (int)(number & 1);
                number >>= 1;
            }
            return setBitsCount;
        }

        public static int UnsetLastSetBit(int number)
        {
            return number & (number - 1); //10101001010100 & 10101001010(011)
        }

        public static string ToBitsString(this long number)
        {
            return Convert.ToString(number, 2).PadLeft(64, '0');
        }

        public static string ToBitsString(this int number)
        {
            return Convert.ToString(number, 2).PadLeft(32, '0');

            /*char[] b = new char[32];
            int pos = 31;
            int i = 0;

            while (i < 32)
            {
                if ((number & (1 << i)) != 0)
                    b[pos] = '1';
                else
                    b[pos] = '0';
                pos--;
                i++;
            }
            return new string(b);*/

            //return ToNumberSystemOf(2, number);
        }

        private static string ToNumberSystemOf(int numberSystem, int number)
        {
            if (numberSystem > 10) { throw new ArgumentOutOfRangeException(nameof(numberSystem)); }

            var result = new List<int>();
            while (number > 0)
            {
                result.Add(number % numberSystem);
                number = number / numberSystem;
            }

            return string.Join("", result.Select(i => i.ToString()).Reverse());
        }
    }
}
