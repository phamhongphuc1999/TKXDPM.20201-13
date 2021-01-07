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
    /// Suspicious transaction exception
    /// </summary>
    public class SuspiciousTransactionException : PaymentException
    {
        /// <summary>
        /// contructor of SuspiciousTransactionException
        /// </summary>
        public SuspiciousTransactionException() : base("Giao dịch bị nghi ngờ gian lận") { }
    }
}
