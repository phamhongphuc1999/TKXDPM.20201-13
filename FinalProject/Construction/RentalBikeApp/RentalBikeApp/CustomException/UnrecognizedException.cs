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
    /// Unrecognized exception
    /// </summary>
    public class UnrecognizedException: Exception
    {
        /// <summary>
        /// contructor of UnrecognizedException
        /// </summary>
        public UnrecognizedException(): base("giao dịch không thành công") { }
    }
}
