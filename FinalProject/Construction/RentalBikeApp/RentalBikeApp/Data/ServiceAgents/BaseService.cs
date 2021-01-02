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

namespace RentalBikeApp.Data.ServiceAgents
{
    /// <summary>
    /// Provider function to interact tables in database
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// the instance representing connection to database
        /// </summary>
        protected SQLConnecter connecter;

        /// <summary>
        /// contructor of BaseService
        /// </summary>
        /// <param name="connecter">the instance representing connection to database</param>
        public BaseService(SQLConnecter connecter)
        {
            this.connecter = connecter;
        }
    }
}
