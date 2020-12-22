﻿// --------------------RENTAL BIKE APP-----------------
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

namespace RentalBikeApp.Entities.APIEntities
{
    /// <summary>
    /// representing the reset money response
    /// </summary>
    public class ResetResponse
    {
        public string errorCode { get; set; }
        public string cardCode { get; set; }
        public string owner { get; set; }
        public string cvvCode { get; set; }
        public string dateExpired { get; set; }
        public string balance { get; set; }
    }
}
