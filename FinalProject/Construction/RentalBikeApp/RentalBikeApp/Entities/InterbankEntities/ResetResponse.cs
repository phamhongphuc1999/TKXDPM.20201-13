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

namespace RentalBikeApp.Entities.InterbankEntities
{
    /// <summary>
    /// representing the reset money response
    /// </summary>
    public class ResetResponse: InterbankResponse
    {
        /// <summary>
        /// card code of your card
        /// </summary>
        public string cardCode { get; protected set; }

        /// <summary>
        /// owner of card
        /// </summary>
        public string owner { get; protected set; }

        /// <summary>
        /// cvv of card
        /// </summary>
        public string cvvCode { get; protected set; }

        /// <summary>
        /// date expired of card
        /// </summary>
        public string dateExpired { get; protected set; }

        /// <summary>
        /// balance of card
        /// </summary>
        public string balance { get; protected set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="cardCode"></param>
        /// <param name="owner"></param>
        /// <param name="cvvCode"></param>
        /// <param name="dateExpired"></param>
        /// <param name="balance"></param>
        public ResetResponse(string errorCode, string cardCode, string owner, string cvvCode, string dateExpired, string balance) : base(errorCode)
        {
            this.cardCode = cardCode;
            this.owner = owner;
            this.cvvCode = cvvCode;
            this.dateExpired = dateExpired;
            this.balance = balance;
        }
    }
}
