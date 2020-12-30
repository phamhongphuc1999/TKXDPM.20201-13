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
    /// Internal server error exception
    /// </summary>
    public class InternalServerErrorException: PaymentException
    {
        /// <summary>
        /// contructor of InternalServerErrorException
        /// </summary>
        public InternalServerErrorException():base("Internal Server Error") { }
    }
}
