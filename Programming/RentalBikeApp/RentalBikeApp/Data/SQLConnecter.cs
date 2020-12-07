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
using RentalBikeApp.Entities.SQLEntities;

namespace RentalBikeApp.Data
{
    public class SQLConnecter
    {
        private SQLData sqlData;
        private DbContextOptionsBuilder<SQLData> option;

        public SQLConnecter(string CONNECT_STRING)
        {
            option = new DbContextOptionsBuilder<SQLData>();
            option.UseSqlServer(CONNECT_STRING);
            sqlData = new SQLData(option.Options);
        }
        
        /// <value>
        /// Get SQL data
        /// </value>
        public SQLData SqlData
        {
            get { return sqlData; }
        }

        /// <value>
        /// Get option of SQL connect
        /// </value>
        public DbContextOptionsBuilder<SQLData> Option
        {
            get { return option; }
        }
    }
}
