using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class ShiftLeftArray
    {
        public static int[] RotateLeft(int[] a, int d)
        {
            int[] temp = new int[a.Length];
            for (int oldI = 0, newI = a.Length - d; oldI < d; oldI++, newI++)
            {
                temp[newI] = a[oldI];
            }

            for (int oldI = d; oldI < a.Length; oldI++)
            {
                int newI = oldI - d;
                temp[newI] = a[oldI];
            }

            return temp;
        }
    }
}
