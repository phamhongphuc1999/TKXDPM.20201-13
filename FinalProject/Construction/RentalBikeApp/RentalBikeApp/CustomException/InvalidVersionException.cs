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
    /// Invalid version exception
    /// </summary>
    public class InvalidVersionException : PaymentException
    {
        /// <summary>
        /// contructor of InvalidVersionException
        /// </summary>
        public InvalidVersionException() : base("Thiếu thông tin version") { }
    }
}
