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

using System;

namespace RentalBikeApp.CustomException
{
    /// <summary>
    /// PAyment exception
    /// </summary>
    public class PaymentException: Exception
    {
        /// <summary>
        /// contructor of PaymentException
        /// </summary>
        public PaymentException() : base() { }

        /// <summary>
        /// contructor of PaymentException
        /// </summary>
        /// <param name="message">message when exception occur</param>
        public PaymentException(string message) : base(message) { }
    }
}
