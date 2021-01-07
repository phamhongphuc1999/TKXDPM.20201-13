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

using Microsoft.EntityFrameworkCore;

namespace RentalBikeApp.Entities.SQLEntities
{
    /// <summary>
    /// this class use to interact all of table in database
    /// </summary>
    public class SQLData : DbContext
    {
        /// <summary>
        /// contructor of SQLData
        /// </summary>
        /// <param name="option">The option for configurate SQLData</param>
        public SQLData(DbContextOptions<SQLData> option) : base(option)
        {
        }

        /// <summary>
        /// representing of Users table
        /// </summary>
        public DbSet<User> Users { get; private set; }

        /// <summary>
        /// representing of BaseBike table
        /// </summary>
        public DbSet<BaseBike> BaseBikes { get; private set; }

        /// <summary>
        /// representing of Bike table
        /// </summary>
        public DbSet<BikeTable> Bikes { get; private set; }

        /// <summary>
        /// representing of Tandem table
        /// </summary>
        public DbSet<TandemTable> Tandems { get; private set; }

        /// <summary>
        /// representing of ElectricBike table
        /// </summary>
        public DbSet<ElectricBikeTable> ElectricBikes { get; private set; }

        /// <summary>
        /// representing of Card table
        /// </summary>
        public DbSet<Card> Cards { get; private set; }

        /// <summary>
        /// representing of Station table
        /// </summary>
        public DbSet<Station> Stations { get; private set; }

        /// <summary>
        /// representing of Transaction table
        /// </summary>
        public DbSet<Transaction> Transactions { get; private set; }
    }
}
