// --------------------RENTAL BIKE APP-----------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//   Su Huu Vu Quang
//   Pham Hong Phuc
//   Tran Minh Quang
//   Ngo Minh Quang
//
//
// ------------------------------------------------------

using System;

namespace RentalBikeApp.Bussiness
{
    public class ReturnBikeController
    {
        /// <summary>
        /// Calculate rental fee for rental bike
        /// </summary>
        /// <param name="timeRent">The time that the user has rented the car</param>
        /// <param name="category">The category of rental bike</param>
        /// <returns>The rental money that use must rent</returns>
        public int CalculateFee(string timeRent, Config.SQL.BikeCategory category)
        {
            string[] times = timeRent.Split(':');
            double hour = Int64.Parse(times[0]);
            double minute = Int64.Parse(times[1]);
            double second = Int64.Parse(times[2]);
            double timeMinutes = 60 * hour + minute + Math.Abs(second / 60) - 10;
            if (category != Config.SQL.BikeCategory.BIKE) timeMinutes = 1.5 * timeMinutes;
            if (timeMinutes <= 0) return 0;
            timeMinutes -= 30;
            if (timeMinutes <= 0) return 10000;
            return (int)(10000 + Math.Abs(timeMinutes / 15));
        }
    }
}
