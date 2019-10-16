namespace IB.Arrays.ArrayMath
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class MinStepsInInfiniteGrid
    {
        public static void Test()
        {
            //[(0, 0), (1, 1), (1, 2)]
            CountSteps(new List<int>() {0, 1, 1}, new List<int>() { 0, 1, 2}).Should().Be(2);
        }

        /*
         * (x,y) to 
    (x+1, y), 
    (x - 1, y), 
    (x, y+1), 
    (x, y-1), 
    (x-1, y-1), 
    (x+1,y+1), 
    (x-1,y+1), 
    (x+1,y-1) 
         *
         */
        private static int CountSteps(int x1, int y1, int x2, int y2)
        {
            int xDist = Math.Abs(x2 - x1);
            int yDist = Math.Abs(y2 - y1);

            return Math.Max(xDist, yDist);
        }

        private static int CountSteps(List<int> xCoordinates, List<int> yCoordinates)
        {
            if (xCoordinates.Count < 2)
            {
                return 0;
            }

            int x1 = xCoordinates[0];
            int y1 = yCoordinates[0];
            int stepsCount = 0;

            for (int i = 1; i < xCoordinates.Count; i++)
            {
                int x2 = xCoordinates[i];
                int y2 = yCoordinates[i];
                int distance = CountSteps(x1, y1, x2, y2);
                stepsCount += distance;
                x1 = x2;
                y1 = y2;
            }

            return stepsCount;
        }

        /*
         Input : [(0, 0), (1, 1), (1, 2)]
Output : 2

        You are in an infinite 2D grid where you can move in any of the 8 directions :

 (x,y) to 
    (x+1, y), 
    (x - 1, y), 
    (x, y+1), 
    (x, y-1), 
    (x-1, y-1), 
    (x+1,y+1), 
    (x-1,y+1), 
    (x+1,y-1) 
You are given a sequence of points and the order in which you need to cover the points. Give the minimum number of steps in which you can achieve it. You start from the first point.

Input :
Given two integer arrays A and B, where A[i] is x coordinate and B[i] is y coordinate of ith point respectively.
Output :
Return an Integer, i.e minimum number of steps.
Example :

Input : [(0, 0), (1, 1), (1, 2)]
Output : 2
It takes 1 step to move from (0, 0) to (1, 1). It takes one more step to move from (1, 1) to (1, 2).

This question is intentionally left slightly vague. Clarify the question by trying out a few cases in the “See Expected Output” section.


         *There are 2 lines in the input

Line 1 ( Corresponds to arg 1 ) : An integer array. First number is the size S of the array. Then S numbers follow which indicate the elements in the array.
    For example, Array: [1, 2, 6] will be written as "3 1 2 6"(without quotes).

Line 2 ( Corresponds to arg 2 ) : An integer array. First number is the size S of the array. Then S numbers follow which indicate the elements in the array.
    For example, Array: [1, 2, 6] will be written as "3 1 2 6"(without quotes).
Note that because the order of covering the points is already defined, the problem just reduces to figuring out the way to calculate the distance between 2 points (A, B) and (C, D).

Can you think of a formula for calculating the distance in O(1) ?

         *
         */
    }
}
