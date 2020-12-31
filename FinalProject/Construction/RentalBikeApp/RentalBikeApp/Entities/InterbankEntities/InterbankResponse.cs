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
    /// representing response from interbank
    /// </summary>
    public class InterbankResponse
    {
        /// <summary>
        /// error code of response
        /// </summary>
        public string errorCode { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        public InterbankResponse(string errorCode)
        {
            this.errorCode = errorCode;
        }
    }
}
