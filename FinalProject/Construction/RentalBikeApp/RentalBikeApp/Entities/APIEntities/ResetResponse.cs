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

namespace RentalBikeApp.Entities.APIEntities
{
    /// <summary>
    /// representing the reset money response
    /// </summary>
    public class ResetResponse
    {
        /// <summary>
        /// error code of response
        /// </summary>
        public string errorCode { get; set; }

        /// <summary>
        /// card code of your card
        /// </summary>
        public string cardCode { get; set; }

        /// <summary>
        /// owner of card
        /// </summary>
        public string owner { get; set; }

        /// <summary>
        /// cvv of card
        /// </summary>
        public string cvvCode { get; set; }

        /// <summary>
        /// date expired of card
        /// </summary>
        public string dateExpired { get; set; }

        /// <summary>
        /// balance of card
        /// </summary>
        public string balance { get; set; }
    }
}
