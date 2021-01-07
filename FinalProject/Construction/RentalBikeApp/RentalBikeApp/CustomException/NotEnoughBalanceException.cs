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
    /// Not enough balance exception
    /// </summary>
    public class NotEnoughBalanceException : PaymentException
    {
        /// <summary>
        /// contructor of NotEnoughBalanceException
        /// </summary>
        public NotEnoughBalanceException() : base("Thẻ không đủ số dư") { }
    }
}
