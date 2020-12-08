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

using RentalBikeApp.Data;
using RentalBikeApp.Entities.SQLEntities;
using System.Linq;

namespace RentalBikeApp.Business.SQLServices
{
    public class CardService
    {
        private SQLConnecter connecter;

        public CardService()
        {
            connecter = new SQLConnecter(Config.SQL.SQL_CONNECT_STRING);
        }

        /// <summary>
        /// Get card information by owner
        /// </summary>
        /// <param name="ownerId">the owner's id</param>
        /// <returns>The instance represent by card</returns>
        public Card GetCardByOwner(string owner)
        {
            return connecter.SqlData.Cards.SingleOrDefault(x => x.Owners == owner);
        }
    }
}
