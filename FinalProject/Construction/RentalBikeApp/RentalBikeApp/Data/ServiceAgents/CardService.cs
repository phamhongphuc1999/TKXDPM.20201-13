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

using RentalBikeApp.Entities.SQLEntities;
using System.Linq;

namespace RentalBikeApp.Data.ServiceAgents
{
    /// <summary>
    /// Provides functions to interact with card table in the database
    /// </summary>
    public class CardService : BaseService
    {
        /// <summary>
        /// contructor of CardService
        /// </summary>
        /// <param name="connecter">The instance representing connection to database</param>
        public CardService(SQLConnecter connecter) : base(connecter) { }

        /// <summary>
        /// Get card information by owner
        /// </summary>
        /// <param name="owner">the owner's id</param>
        /// <returns>The instance represent by card</returns>
        public Card GetCardByOwner(string owner)
        {
            return connecter.SqlData.Cards.SingleOrDefault(x => x.Owners == owner);
        }

        /// <summary>
        /// Get card information by user id
        /// </summary>
        /// <param name="userID">The user's id</param>
        /// <returns></returns>
        public Card GetCardByUser(int userID)
        {
            return connecter.SqlData.Cards.SingleOrDefault(x => x.UserId == userID);
        }
    }
}
