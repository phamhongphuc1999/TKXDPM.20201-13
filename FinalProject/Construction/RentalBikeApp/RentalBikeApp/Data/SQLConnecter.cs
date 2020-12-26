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
    /// <summary>
    /// This class provider a method and option to connect SQL server
    /// </summary>
    public class SQLConnecter
    {
        /// <summary>
        /// representing of SQL database
        /// </summary>
        public SQLData SqlData { get; private set; }

        /// <summary>
        /// provider option for configuration connect
        /// </summary>
        public DbContextOptionsBuilder<SQLData> Option { get; private set; }

        private static SQLConnecter connecter;

        private SQLConnecter(string CONNECT_STRING)
        {
            Option = new DbContextOptionsBuilder<SQLData>();
            Option.UseSqlServer(CONNECT_STRING);
            SqlData = new SQLData(Option.Options);
        }

        /// <summary>
        /// Get only instance of connect
        /// </summary>
        /// <returns>The instance represeting the connection</returns>
        public static SQLConnecter GetInstance()
        {
            if(connecter == null) connecter = new SQLConnecter(Constant.SQL.SQL_CONNECT_STRING);
            return connecter;
        }
    }
}
