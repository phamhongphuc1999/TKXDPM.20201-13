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
    /// Invalid transaction amount exception
    /// </summary>
    public class InvalidTransactionAmountException: PaymentException
    {
        /// <summary>
        /// contructor of InvalidTransactionAmountException
        /// </summary>
        public InvalidTransactionAmountException(): base("Số tiền không hợp lệ") { }
    }
}
