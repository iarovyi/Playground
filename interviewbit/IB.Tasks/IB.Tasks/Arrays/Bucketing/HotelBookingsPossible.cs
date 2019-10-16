namespace IB.Arrays.Bucketing
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;

    internal static class HotelBookingsPossible
    {
        public static void Test()
        {
            AreThereEnoughRooms(new List<int>() {1, 3, 5}, new List<int>() {2, 6, 8}, 1).Should().BeFalse();
            AreThereEnoughRooms(new List<int>() { 1, 2, 3, 4 }, new List<int>() { 10, 2, 6, 14 }, 4).Should().BeTrue();
        }

        public static bool AreThereEnoughRooms(List<int> arrivalDays, List<int> departureDays, int roomCount)
        {
            arrivalDays.Sort();
            departureDays.Sort();

            int arrivalsIndex = 0;
            int departuresIndex = 0;

            while (arrivalsIndex < arrivalDays.Count || departuresIndex < departureDays.Count)
            {
                if (departuresIndex >= departureDays.Count)     //Only arrivals left
                {
                    int futureArrivals = arrivalDays.Count - 1 - arrivalsIndex;
                    return futureArrivals > roomCount ? false : true;
                }

                if (arrivalsIndex >= arrivalDays.Count)         //Only departures left
                {
                    return true;
                }

                int nextArrivalDay = arrivalDays[arrivalsIndex];
                int nextDepartureDay = departureDays[departuresIndex];
                if (nextArrivalDay < nextDepartureDay)          //Arrival
                {
                    roomCount--;
                    arrivalsIndex++;
                } else if (nextDepartureDay < nextArrivalDay)   //Departure
                {
                    roomCount++;
                    departuresIndex++;
                } else                                         //Arrival and departure
                {
                    arrivalsIndex++;
                    departuresIndex++;
                }

                if (roomCount < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }

    /*
     * A hotel manager has to process N advance bookings of rooms for the next season. His hotel has K rooms. Bookings contain an arrival date and a departure date. He wants to find out whether there are enough rooms in the hotel to satisfy the demand. Write a program that solves this problem in time O(N log N) .

Input:


First list for arrival time of booking.
Second list for departure time of booking.
Third is K which denotes count of rooms.

Output:

A boolean which tells whether its possible to make a booking. 
Return 0/1 for C programs.
O -> No there are not enough rooms for N booking.
1 -> Yes there are enough rooms for N booking.
Example :

Input : 
        Arrivals :   [1 3 5]
        Departures : [2 6 8]
        K : 1

Return : False / 0 

At day = 5, there are 2 guests in the hotel. But I have only one room.
     */
}
