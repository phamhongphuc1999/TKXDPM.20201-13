﻿// --------------------RENTAL BIKE APP-----------------
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
        public SQLData(DbContextOptions<SQLData> option): base(option)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Tandem> Tandems { get; set; }
        public DbSet<ElectricBike> ElectricBikes { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
