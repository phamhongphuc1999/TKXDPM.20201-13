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
    public class SQLData: DbContext
    {
        /// <summary>
        /// contructor of SQLData
        /// </summary>
        /// <param name="option">The option for configurate SQLData</param>
        public SQLData(DbContextOptions<SQLData> option): base(option)
        {
        }

        /// <summary>
        /// representing of user table
        /// </summary>
        public DbSet<User> Users { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<BaseBike> BaseBikes { get; private set; }

        /// <summary>
        /// representing of bike table
        /// </summary>
        public DbSet<BikeTable> Bikes { get; private set; }

        /// <summary>
        /// representing of tandem table
        /// </summary>
        public DbSet<TandemTable> Tandems { get; private set; }

        /// <summary>
        /// representing of electric bike table
        /// </summary>
        public DbSet<ElectricBikeTable> ElectricBikes { get; private set; }

        /// <summary>
        /// representing of card table
        /// </summary>
        public DbSet<Card> Cards { get; private set; }

        /// <summary>
        /// representing of station table
        /// </summary>
        public DbSet<Station> Stations { get; private set; }

        /// <summary>
        /// representing of transaction table
        /// </summary>
        public DbSet<Transaction> Transactions { get; private set; }
    }
}
