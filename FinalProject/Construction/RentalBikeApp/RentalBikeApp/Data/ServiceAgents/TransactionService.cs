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

using RentalBikeApp.Entities.SQLEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentalBikeApp.Data.ServiceAgents
{
    /// <summary>
    /// Provides functions to interact with transaction in the database
    /// </summary>
    public class TransactionService: BaseService
    {
        /// <summary>
        /// contructor of TransactionService
        /// </summary>
        /// <param name="connecter">The instance representing connection to database</param>
        public TransactionService(SQLConnecter connecter): base(connecter) { }

        /// <summary>Insert new transaction when user deposit money to rent the bike</summary>
        /// <param name="userId">the Id of user who want to rent the bike</param>
        /// <param name="bikeId">the id of rental bike</param>
        /// <param name="deposit">the desposit money to rent the bike</param>
        /// <returns>Return the new transaction or null if get error</returns>
        public Transaction InsertNewTransaction(int userId, int bikeId, int deposit)
        {
            User checkUser = connecter.SqlData.Users.Find(userId);
            if (checkUser == null) return null;
            BaseBike checkBike = connecter.SqlData.BaseBikes.Find(bikeId);
            if (checkBike == null) return null;
            Transaction transaction = new Transaction(userId, bikeId, deposit);
            connecter.SqlData.Transactions.Add(transaction);
            int check = connecter.SqlData.SaveChanges();
            if (check > 0) return transaction;
            else return null;
        }

        /// <summary>Get transaction by id</summary>
        /// <param name="transactionId">the id of specified transaction</param>
        /// <returns>Return the specified transaction</returns>
        public Transaction GetTransactionById(int transactionId)
        {
            return connecter.SqlData.Transactions.Find(transactionId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bikeId"></param>
        /// <returns></returns>
        public Transaction GetProcessTransaction(int bikeId)
        {
            return connecter.SqlData.Transactions.SingleOrDefault(x => x.BikeId == bikeId && x.EndAt == null);
        }

        /// <summary>Get all of transactions of the user</summary>
        /// <param name="userId">the Id of user</param>
        /// <returns>Return the specified user's transactions list</returns>
        public List<Transaction> GetListTransactionsByUserId(int userId)
        {
            return connecter.SqlData.Transactions.Where(x => x.UserId == userId).ToList();
        }

        /// <summary>Update the last transaction of the user after rented bike</summary>
        /// <param name="transactionId">the Id of transaction</param>
        /// <param name="rentalMoney">the rental money that user must to pay after rented bike</param>
        /// <param name="note">note if necessary</param>
        /// <returns>Return true if success or false if cause error</returns>
        public bool UpdateTransaction(int transactionId, int rentalMoney, string note = "")
        {
            Transaction transaction = connecter.SqlData.Transactions.Find(transactionId);
            if (transaction == null) return false;
            transaction.UpdateTransaction(rentalMoney, note);
            int check = connecter.SqlData.SaveChanges();
            return (check > 0);
        }
    }
}
