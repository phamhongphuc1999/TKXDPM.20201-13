// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

namespace RentalBikeApp.Entities.APIEntities
{
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
