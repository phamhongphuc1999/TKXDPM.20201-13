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

using RentalBikeApp.Entities.InterbankEntities;
using RentalBikeApp.Entities.SQLEntities;
using System;
using System.Threading.Tasks;

namespace RentalBikeApp.InterbankSubsystem
{
    /// <summary>
    /// The interface IPayment implements functions to payment rental money
    /// </summary>
    public interface IPayment
    {
        /// <summary>
        /// Send transaction to server
        /// </summary>
        /// <param name="card">The card information</param>
        /// <param name="amount">The amount of transaction</param>
        /// <param name="date">Date time transaction processed</param>
        /// <param name="transactionContent">Note of transaction</param>
        /// <param name="_version">Version of API, default 1.0.1</param>
        /// <returns>The transaction response information</returns>
        public Task<InterbankResponse> Pay(Card card, int amount, DateTime date, string transactionContent, string _version = "1.0.1");

        /// <summary>
        /// Send transaction to server
        /// </summary>
        /// <param name="card">The card information</param>
        /// <param name="amount">The amount of transaction</param>
        /// <param name="date">Date time transaction processed</param>
        /// <param name="transactionContent">Note of transaction</param>
        /// <param name="_version">Version of API, default 1.0.1</param>
        /// <returns>The transaction response information</returns>
        public Task<InterbankResponse> Refund(Card card, int amount, DateTime date, string transactionContent, string _version = "1.0.1");
    }
}
