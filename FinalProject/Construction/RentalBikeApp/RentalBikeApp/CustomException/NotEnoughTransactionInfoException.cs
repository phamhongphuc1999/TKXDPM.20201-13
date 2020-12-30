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
    /// Not enough transaction information exception
    /// </summary>
    public class NotEnoughTransactionInfoException: PaymentException
    {
        /// <summary>
        /// contructor of NotEnoughTransactionInfoException
        /// </summary>
        public NotEnoughTransactionInfoException(): base("Không đủ thông tin giao dịch") { }
    }
}
