// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.

namespace RentalBikeApp.Entities.APIEntities
{
    public class ProcessTransactionResponse
    {
        public string errorCode { get; set; }
        public TransactionInfo transaction { get; set; }
    }
}
