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

namespace RentalBikeApp.CustomException
{
    /// <summary>
    /// Invalid card exception
    /// </summary>
    public class InvalidCardException: PaymentException
    {
        /// <summary>
        /// contructor of InvalidCardException
        /// </summary>
        public InvalidCardException(): base("Thẻ không hợp lệ") { }
    }
}
